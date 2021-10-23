using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Zadanie2._4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var separator = '\t';
            var samples = @"C:\Users\ja\source\repos\SSI\Zadanie2.4\iris.txt";
            var values = @"C:\Users\ja\source\repos\SSI\Zadanie2.4\iris-type.txt";
            var decisionSystem = new DecisionSystem();
            var sampleBase = new SampleBaseDto
            {
                AttrNames = decisionSystem.ReadAttributeNames(values, separator),
                IfAttrSym = decisionSystem.CheckIfAttrSym(values, separator),
                GroupedSamples = decisionSystem.GroupSamples(samples, separator)
            };
            var charts = new ChartHelper();
            charts.GenerateChart(chart1, sampleBase, 2, 3);
            charts.GenerateChart(chart2, sampleBase, 1, 3);
            charts.GenerateChart(chart3, sampleBase, 0, 3);
            charts.GenerateChart(chart4, sampleBase, 1, 2);
        }

    }
}
