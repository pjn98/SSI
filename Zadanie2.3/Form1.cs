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

namespace Zadanie2._3
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
            Wykres.Series.Clear();
            var series1 = Wykres.Series.Add("łamane");
            series1.ChartType = SeriesChartType.Spline;
            var series2 = Wykres.Series.Add("punkty");
            series2.ChartType = SeriesChartType.Point;
            var series3 = Wykres.Series.Add("sinus");
            series3.ChartType = SeriesChartType.Spline;

            var series1XPoints = new List<double> {-2, -1.7, -1.3, -0.8, 0, 0.8, 1.3, 1.7, 2, 1.7, 1.3, 0.8, 0, -0.8, -1.3, -1.7, -2};
            var series1YPoints = new List<double> {0, 0.8, 1.5, 1.8, 2, 1.8, 1.5, 0.8, 0, -0.8, -1.5, -1.8, -2, -1.8, -1.5, -0.8, 0 };

            var series2XPoints = new List<double> {-1, 0, 1 };
            var series2YPoints = new List<double> {1, 0 , 1 };

            var series3XPoints = new List<double> {-1, 0, 1 };
            var series3YPoints = new List<double> {0, -1, 0 };

            for (var i = 0; i < series1XPoints.Count; i++)
                series1.Points.AddXY(series1XPoints[i], series1YPoints[i]);

            for (var i = 0; i < series2XPoints.Count; i++)
                series2.Points.AddXY(series2XPoints[i], series2YPoints[i]);

            for (var i = 0; i < series3XPoints.Count; i++)
                series3.Points.AddXY(series3XPoints[i], series3YPoints[i]);

        }
    }
}
