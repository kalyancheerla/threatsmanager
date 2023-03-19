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
                // Initialize the ThreatsManager engine.
                var loader = new ModelLoader();
                var model = loader.LoadDefaultModel();

                // add diagram
                var diagram = model.AddDiagram("My Diagram");

                // input file
                string input_file = args[0];
                string output_file = args[1];

                // deserialize JSON directly from a file
                var microsvcs = new MicroSvcsLoader().LoadJSONFile(input_file);
                //new MicroSvcsLoader().PrettyPrint(microsvcs);


                // TEST
                // Create groups
                var group1 = model.AddGroup<ITrustBoundary>("TB 1");
                diagram.AddGroupShape(group1.Id, new PointF(0,0), new SizeF(500, 500));
                var group2 = model.AddGroup<ITrustBoundary>("TB 2");
                diagram.AddGroupShape(group2.Id, new PointF(0, 0), new SizeF(500, 500));

                // create entities
                var process1 = model.AddEntity<IProcess>("Project");
                diagram.AddShape(process1, new PointF(100, 200));
                var process2 = model.AddEntity<IProcess>("Node");
                diagram.AddShape(process2, new PointF(200, 100));
                var process3 = model.AddEntity<IProcess>("Pod 1");
                diagram.AddShape(process3, new PointF(300, 300));
                var process4 = model.AddEntity<IProcess>("Pod 2");
                diagram.AddShape(process4, new PointF(400, 300));
                var process5 = model.AddEntity<IProcess>("Pod 3");
                diagram.AddShape(process5, new PointF(500, 300));

                // set parents
                group2.SetParent(group1);
                process1.SetParent(group2);
                process2.SetParent(group1);
                process3.SetParent(group2);
                process4.SetParent(group2);
                process5.SetParent(group2);

                // create data flows
                var dataflow1 = model.AddDataFlow("Flow", process2.Id, process1.Id);
                diagram.AddLink(dataflow1);
                var dataflow2 = model.AddDataFlow("Flow", process2.Id, process3.Id);
                diagram.AddLink(dataflow2);
                var dataflow3 = model.AddDataFlow("Flow", process2.Id, process4.Id);
                diagram.AddLink(dataflow3);
                var dataflow4 = model.AddDataFlow("Flow", process2.Id, process5.Id);
                diagram.AddLink(dataflow4);
                var dataflow5 = model.AddDataFlow("Flow", process1.Id, process3.Id);
                diagram.AddLink(dataflow5);
                var dataflow6 = model.AddDataFlow("Flow", process1.Id, process4.Id);
                diagram.AddLink(dataflow6);
                var dataflow7 = model.AddDataFlow("Flow", process1.Id, process5.Id);
                diagram.AddLink(dataflow7);

                //GetAll(diagram);

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
