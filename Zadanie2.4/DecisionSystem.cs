using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zadanie2._4
{
    public class DecisionSystem
    {
        public List<List<string>> ReadSamples(string pathSamples, char separator)
        {
            Replace(pathSamples);
            return ReadFile(pathSamples, separator);
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

        public Dictionary<string, List<List<double>>> GroupSamples(string path, char separator)
        {
            var samples = ReadSamples(path, separator);
            foreach (var sample in samples)
            {
                var sampleClass = sample.Last();
                sample[sample.Count - 1] =
                    sampleClass == "1" ? "Setosa" : sampleClass == "2" ? "Versicolour" : sampleClass == "3" ? "Virginica" : sampleClass;
            }
            var samplesDictionary = new Dictionary<string, List<List<double>>>();
            foreach (var sample in samples)
            {
                var sampleWithoutClass = sample.GetRange(0, sample.Count - 1).Select(x => double.Parse(x)).ToList();
                if (samplesDictionary.ContainsKey(sample.Last()))
                    samplesDictionary[sample.Last()].Add(sampleWithoutClass);
                else
                    samplesDictionary.Add(sample.Last(), new List<List<double>>() { sampleWithoutClass });
            }

            return samplesDictionary;
        }
    }
}
