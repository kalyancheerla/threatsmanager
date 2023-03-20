using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Security.Cryptography;
using ThreatsManager.Interfaces.ObjectModel.Entities;
using ThreatsManager.Utilities;
using ThreatsManager.Packaging;
using System.Drawing;
using ThreatsManager.Engine;
using System.Collections.Generic;

namespace DigraphConverter
{
    class Program
    {
        static void GetAll(object obj)
        {
            foreach (var property in obj.GetType().GetProperties())
                Console.WriteLine(property.Name);
            Console.WriteLine();
            foreach (var method in obj.GetType().GetMethods())
                Console.WriteLine(method.Name);
        }

        static void Main(string[] args)
        {
            if (args.Length == 2 && File.Exists(args[0]))
            {
                // initialize the ThreatsManager engine
                var loader = new ModelLoader();
                var model = loader.LoadDefaultModel();

                // input file
                string input_file = args[0];
                string output_file = args[1];

                // deserialize JSON directly from a file
                var microsvcs = new MicroSvcsLoader().LoadJSONFile(input_file);

                // project index
                int pj_idx = 0;
                foreach (var msvcpj in microsvcs)
                {
                    // increment the idx
                    pj_idx++;

                    // add diagram
                    var diagram = model.AddDiagram($"Diagram {pj_idx}");

                    // add required trust boundaries
                    var aws_trustboundary = model.AddGroup<ITrustBoundary>("AWS Ava Zone");
                    diagram.AddGroupShape(aws_trustboundary.Id, new PointF(0,0), new SizeF(2000, 1000));

                    var openshift_trustboundary = model.AddGroup<ITrustBoundary>("OpenShift Trust Boundary");
                    diagram.AddGroupShape(openshift_trustboundary.Id, new PointF(0, 200), new SizeF(2000, 800));

                    // set tb parent
                    openshift_trustboundary.SetParent(aws_trustboundary);

                    var pjprocess = model.AddEntity<IProcess>(msvcpj.Name);
                    diagram.AddShape(pjprocess, new PointF(-1500, -100));
                    pjprocess.SetParent(openshift_trustboundary);

                    // node index
                    int node_idx = 0;
                    foreach (var msvcnode in msvcpj.Nodes)
                    {
                        // increment the idx
                        node_idx++;

                        var nodeprocess = model.AddEntity<IProcess>(msvcnode.Name);
                        diagram.AddShape(nodeprocess, new PointF(node_idx*500-1500, -300));
                        nodeprocess.SetParent(aws_trustboundary);
                        var nodepj_link = model.AddDataFlow("Flow", nodeprocess.Id, pjprocess.Id);
                        diagram.AddLink(nodepj_link);

                        // pod index
                        int pod_idx = 0;
                        foreach (var msvcpod in msvcnode.Pods)
                        {
                            // increment the idx
                            pod_idx++;

                            var podprocess = model.AddEntity<IProcess>(msvcpod);
                            diagram.AddShape(podprocess, new PointF(pod_idx*500-1200, node_idx*200));
                            podprocess.SetParent(openshift_trustboundary);
                            var nodepod_link = model.AddDataFlow("Flow", nodeprocess.Id, podprocess.Id);
                            diagram.AddLink(nodepod_link);
                            var pjpod_link = model.AddDataFlow("Flow", pjprocess.Id, podprocess.Id);
                            diagram.AddLink(pjpod_link);
                        }
                    }
                }

                // Save the model to a file in JSON format.
                var fileName = output_file;
                var json = ThreatModelManager.Serialize(model);
                var package = Package.Create(fileName);
                package.Add("threatmodel.json", json);
                package.Save();
            }
        }
    }
}
