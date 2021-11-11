using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie3
{
    public class DecisionSystem
    {
        public List<List<double>> ReadSamples(string pathSamples, char separator)
        {
            Replace(pathSamples);
            var samples = ReadFile(pathSamples, separator);
            var doubleSamples = new List<List<double>>();
            foreach (var sample in samples)
            {
                doubleSamples.Add(sample.Select(x => double.Parse(x)).ToList());
            }

            return doubleSamples;
        }

        public List<string> ReadAttributeNames(string pathValues, char separator)
        {
            Replace(pathValues);
            var attrs = ReadFile(pathValues, separator);
            var names = new List<string>();
            attrs.ForEach(x => names.Add(x[0]));

            return names;
        }

        public List<bool> CheckIfAttrSym(string pathValues, char separator)
        {
            Replace(pathValues);
            var attrs = ReadFile(pathValues, separator);
            var ifAttrSym = new List<bool>();
            attrs.ForEach(x => ifAttrSym.Add(x.Last() == "s"));

            return ifAttrSym;
        }

        private static List<List<string>> ReadFile(string path, char separator)
        {
            return File.ReadAllLines(path).Select(x => x.Split(separator).ToList()).ToList();
        }

        private static void Replace(string path)
        {
            var file = File.ReadAllText(path);
            file = file.Replace(".", ",");
            File.WriteAllText(path, file);
        }
    }
}
