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

                // deserialize JSON directly from a file
                var microsvcs = new MicroSvcsLoader().LoadJSONFile(input_file);
                new MicroSvcsLoader().PrettyPrint(microsvcs);
            }
        }
    }
}
