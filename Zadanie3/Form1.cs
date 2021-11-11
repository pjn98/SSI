using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Zadanie3
{
    public partial class Form1 : Form
    {
        private readonly Metrics.Metric _metric = Metrics.EuclideanMetric;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var separator = '\t';
            var samples = @"C:\Users\ja\source\repos\SSI\Zadanie3\spirala.txt";
            var values = @"C:\Users\ja\source\repos\SSI\Zadanie3\spirala-type.txt";
            var decisionSystem = new DecisionSystem();
            var sampleBase = new SampleBaseDto
            {
                Samples = decisionSystem.ReadSamples(samples, separator),
                AttrNames = decisionSystem.ReadAttributeNames(values, separator),
                IfAttrSym = decisionSystem.CheckIfAttrSym(values, separator)
            };
            var m = 4;
            var iters = 100;
            var kMeans = new KMeans();
            var vDictionary = kMeans.KMeansAlgorithm(m, iters, sampleBase.Samples, _metric);
            var charts = new ChartHelper();
            charts.GenerateChart(chart1, vDictionary, 0, 1);
        }
    }
}