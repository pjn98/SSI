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

namespace Zadanie4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            var start = 0;
            var end = 100;
            var variabilityRange = new Random().NextDouble() * 100;
            var incrementalFactor = 1.1;
            var iterations = 100;
            var spread = 10.0;
            var functionPoints = GenerateSinusFunctionChartPoints(end);
            var algorithmPoints = GenerateAlgorithmPoints(variabilityRange, iterations, spread, incrementalFactor, start, end);
            Draw(chart1.Series.Add("sin(x/10)*sin(x/200)"), functionPoints.XPoints, functionPoints.YPoints, SeriesChartType.Spline, 5);
            Draw(chart1.Series.Add("początek"), algorithmPoints.XPoints.GetRange(0, 1), algorithmPoints.YPoints.GetRange(0, 1), SeriesChartType.Point, 10);
            Draw(chart1.Series.Add("punkty pośrednie"), algorithmPoints.XPoints.GetRange(1, algorithmPoints.XPoints.Count - 2), algorithmPoints.YPoints.GetRange(1, algorithmPoints.XPoints.Count - 2), SeriesChartType.Point, 5);
            Draw(chart1.Series.Add("koniec"), algorithmPoints.XPoints.GetRange(algorithmPoints.XPoints.Count - 1, 1), algorithmPoints.YPoints.GetRange(algorithmPoints.XPoints.Count - 1, 1), SeriesChartType.Point, 10);
        }

        private PointsDto GenerateAlgorithmPoints(double variabilityRange, int iterations, double spread, double incrementalFactor, double start, double end)
        {
            var seriesXPoints = new List<double>();
            var seriesYPoints = new List<double>();

            var x = variabilityRange;
            var y = Math.Sin(x / 10) * Math.Sin(x / 200);
            seriesXPoints.Add(x);
            seriesYPoints.Add(y);

            var random = new Random();
            for (var i = 0; i < iterations; i++)
            {
                var newX = x + random.NextDouble() * (spread - (-spread)) + (-spread);
                newX = newX > end ? end : newX < start ? start : newX;
                var newY = Math.Sin(newX / 10) * Math.Sin(newX / 200);
                seriesXPoints.Add(newX);
                seriesYPoints.Add(newY);
                if (newY >= y)
                {
                    x = newX;
                    y = newY;
                    spread *= incrementalFactor;
                }
                else
                {
                    spread /= incrementalFactor;
                }
            }
            return new PointsDto
            {
                XPoints = seriesXPoints,
                YPoints = seriesYPoints
            };
        }

        private PointsDto GenerateSinusFunctionChartPoints(double end)
        {
            double x = 0;
            var seriesXPoints = new List<double>();
            var seriesYPoints = new List<double>();

            while (x <= end)
            {
                seriesXPoints.Add(x);
                seriesYPoints.Add(Math.Sin(x / 10) * Math.Sin(x / 200));
                x += 0.1;
            }

            return new PointsDto
            {
                XPoints = seriesXPoints,
                YPoints = seriesYPoints
            };
        }

        private void Draw(Series series, List<double> xValues, List<double> yValues, SeriesChartType chartType, int size)
        {
            series.ChartType = chartType;
            series.MarkerSize = size;
            for (var i = 0; i < xValues.Count; i++)
                series.Points.AddXY(xValues[i], yValues[i]);
        }
    }
}
