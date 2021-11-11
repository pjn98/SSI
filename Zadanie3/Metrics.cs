using System;
using System.Collections.Generic;

namespace Zadanie3
{
    public class Metrics
    {
        public delegate double Metric(List<double> x, List<double> y, int p);
        public static double EuclideanMetric(List<double> x, List<double> y, int p)
        {
            double distance = 0;
            for (var j = 0; j < x.Count; j++)
            {
                distance += (x[j] - y[j]) * (x[j] - y[j]);
            }
            return Math.Sqrt(distance);
        }

        public static double ManhattanMetric(List<double> x, List<double> y, int p)
        {
            double distance = 0;
            for (var j = 0; j < x.Count; j++)
            {
                distance += Math.Abs(x[j] - y[j]);
            }
            return distance;
        }

        public static double ChebyshevMetric(List<double> x, List<double> y, int p)
        {
            double distance = 0;
            for (var j = 0; j < x.Count; j++)
            {
                if (distance < Math.Abs(x[j] - y[j]))
                {
                    distance = Math.Abs(x[j] - y[j]);
                }
            }
            return distance;
        }

        public static double MinkowskiMetric(List<double> x, List<double> y, int p)
        {
            double distance = 0;
            double pp = Convert.ToDouble(p);
            for (var j = 0; j < x.Count; j++)
            {
                distance += Math.Pow(Math.Abs(x[j] - y[j]), pp);
            }
            distance = Math.Pow(distance, (1 / pp));
            return distance;
        }

        public static double LogarithmMetric(List<double> x, List<double> y, int p)
        {
            double distance = 0;
            for (var j = 0; j < x.Count; j++)
            {
                distance += Math.Abs(Math.Log(x[j], 10) - Math.Log(y[j], 10));
            }
            return distance;
        }
    }
}
