using System;
using System.Collections.Generic;

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
            var sampleBase = decisionSystem.ReadSampleBase(samples, values, separator);
            foreach (var name in sampleBase.AttrNames)
            {
                Console.Write(name + " ");
            }

            foreach (var sample in sampleBase.Samples)
            {
                Console.WriteLine();
                foreach (var record in sample)
                {
                    Console.Write(record + " ");
                }
            }
            Console.WriteLine();
            Console.WriteLine(sampleBase.Samples[0][1]);
            Console.WriteLine(sampleBase.IfAttrSym[0]);
            Console.WriteLine(sampleBase.AttrNames[0]);
            Console.ReadKey();
        }
    }
}
