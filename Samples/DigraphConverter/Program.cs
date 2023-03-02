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

                // create a dict to use for data flow
                Dictionary<string, Guid> processDict = new Dictionary<string, Guid>();

                int index = 0;
                foreach (string line in File.ReadLines(input_file))
                {
                    string pattern1 = @"^(\d+)\s*\[\s*label\s*=\s*""([^""]*)""\s*\]$";
                    string pattern2 = @"^(\d+)\s*->\s*(\d+)\s*\[constraint=(\w+)\]$";

                    Match match = Regex.Match(line, pattern1);
                    if (match.Success)
                    {
                        var id = match.Groups[1].Value;
                        var label = match.Groups[2].Value;

                        // add process entities and then in diagram
                        var process = model.AddEntity<IProcess>(id);
                        diagram.AddShape(process, new PointF(10*id.Length, 100*index));

                        // add guids in dict
                        processDict.Add(id, process.Id);
                    }

                    match = Regex.Match(line, pattern2);
                    if (match.Success)
                    {
                        var sourceNode = match.Groups[1].Value;
                        var destNode = match.Groups[2].Value;

                        // add dataflow in model and then in diagram
                        IDataFlow dataFlow = model.AddDataFlow("Flow", processDict[sourceNode], processDict[destNode]);
                        diagram.AddLink(dataFlow);
                    }
                    index++;
                }

                // Save the model to a file in JSON format.
                var fileName = "sample_threat_model.tm";
                var json = ThreatModelManager.Serialize(model);
                var package = Package.Create(fileName);
                package.Add("threatmodel.json", json);
                package.Save();
            }
        }
    }
}
