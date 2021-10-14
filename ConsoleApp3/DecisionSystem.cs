using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp3
{
    public class DecisionSystem
    {
        public SampleBaseDto ReadSampleBase(string pathSamples, string pathValues, char separator)
        {
            Replace(pathSamples);
            Replace(pathValues);
            var samples = File.ReadAllLines(pathSamples).Select(x => x.Split(separator).ToList()).ToList();
            var attrs = File.ReadAllLines(pathValues).Select(x => x.Split(separator).ToList()).ToList();
            var names = new List<string>();
            var ifAttrSym = new List<bool>();
            foreach (var attr in attrs)
            {
                names.Add(attr[0]);
                ifAttrSym.Add(attr[1] == "s");
            }

            return new SampleBaseDto
            {
                Samples = samples,
                AttrNames = names,
                IfAttrSym = ifAttrSym
            };
        }

        private void Replace(string path)
        {
            var file = File.ReadAllText(path);
            file = file.Replace(".", ",");
            File.WriteAllText(path, file);
        }
    }
}
