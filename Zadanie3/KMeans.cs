using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    public class KMeans
    {
        public Dictionary<int, List<List<double>>> KMeansAlgorithm(int m, int iters, List<List<double>> samples, Metrics.Metric metric)
        {
            var vDictionary = SelectMeasures(m, samples);
            vDictionary = CalculateDistanceAndGroup(samples, vDictionary, metric);
            var charts = new ChartHelper();

            for (var i = 0; i < iters; i++)
            {
                var vDictionaryTmp = new Dictionary<int, List<List<double>>>();
                foreach (var item in vDictionary)
                {
                    var a = item;
                    double avgX = 0;
                    double avgY = 0;
                    foreach (var value in item.Value)
                    {
                        avgX += value[0];
                        avgY += value[1];
                    }

                    vDictionaryTmp.Add(item.Key,
                        new List<List<double>> { new List<double> { avgX / item.Value.Count, avgY / item.Value.Count } });
                }

                vDictionary.Clear();
                vDictionary = vDictionaryTmp;
                vDictionary = CalculateDistanceAndGroup(samples, vDictionary, metric);
            }

            return vDictionary;
        }

        public Dictionary<int, List<List<double>>> SelectMeasures(int m, List<List<double>> samples)
        {
            var random = new Random();
            var vDictionary = new Dictionary<int, List<List<double>>>();
            while (vDictionary.Keys.Count != m)
            {
                var number = random.Next(0, samples.Count());
                if (!vDictionary.ContainsKey(number))
                    vDictionary.Add(number, new List<List<double>>() { samples[number] });
            }

            return vDictionary;
        }

        public Dictionary<int, List<List<double>>> CalculateDistanceAndGroup(List<List<double>> samples, Dictionary<int, List<List<double>>> vDictionary, Metrics.Metric metric)
        {
            var index = 0;
            foreach (var sample in samples)
            {
                var samplesList = new List<CalculatedSampleDto>();

                if (vDictionary.Keys.Contains(index))
                {
                    index++;
                    continue;
                }
                foreach (var key in vDictionary.Keys)
                {
                    var distance = metric(sample, vDictionary[key].First(), 2);
                    samplesList.Add(new CalculatedSampleDto
                    {
                        ValueList = sample,
                        Distance = distance,
                        DictionaryKey = key
                    });
                }

                samplesList = samplesList.OrderBy(x => x.Distance).ToList();
                vDictionary[samplesList.First().DictionaryKey].Add(samplesList.First().ValueList);
                index++;
            }

            return vDictionary;
        }
    }
}
