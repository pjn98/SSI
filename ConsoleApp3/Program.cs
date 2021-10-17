using System;
using System.Collections.Generic;
using ConsoleTables;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var separator = ' ';
            var samples = @"C:\Users\ja\source\repos\SSI\ConsoleApp3\wartosci.txt";
            var values = @"C:\Users\ja\source\repos\SSI\ConsoleApp3\atrybuty.txt";
            var decisionSystem = new DecisionSystem();
            var sampleBase = new SampleBaseDto
            {
                Samples = decisionSystem.ReadSamples(samples, separator),
                AttrNames = decisionSystem.ReadAttributeNames(values, separator),
                IfAttrSym = decisionSystem.CheckIfAttrSym(values, separator)
            };

            var table = new ConsoleTable(sampleBase.AttrNames.ToArray());

            foreach (var sample in sampleBase.Samples)
            {
                table.AddRow(sample.ToArray());
            }

            table.Write();
            Console.WriteLine("Samples[0][2] = " + sampleBase.Samples[0][2]);
            Console.WriteLine("IfAttrSym[1] = " + sampleBase.IfAttrSym[1]);
            Console.WriteLine("AttrNames[1] = " + sampleBase.AttrNames[1]);
            Console.ReadKey();
        }
    }
}
