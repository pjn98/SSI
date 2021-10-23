using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace Zadanie2._4
{
    public class ChartHelper
    {
        public void GenerateChart(Chart chart, Dictionary<string, List<List<double>>> sampleBase, int column1, int column2)
        {
            chart.Series.Clear();
            var series1 = chart.Series.Add("klasa 1");
            var series2 = chart.Series.Add("klasa 2");
            var series3 = chart.Series.Add("klasa 3");

            var series1XPoints = GetPoints(sampleBase, "1", column1, column2).XPoints;
            var series1YPoints = GetPoints(sampleBase, "1", column1, column2).YPoints;

            var series2XPoints = GetPoints(sampleBase, "2", column1, column2).XPoints;
            var series2YPoints = GetPoints(sampleBase, "2", column1, column2).YPoints;

            var series3XPoints = GetPoints(sampleBase, "3", column1, column2).XPoints;
            var series3YPoints = GetPoints(sampleBase, "3", column1, column2).YPoints;

            Draw(series1, series1XPoints, series1YPoints, SeriesChartType.Point);
            Draw(series2, series2XPoints, series2YPoints, SeriesChartType.Point);
            Draw(series3, series3XPoints, series3YPoints, SeriesChartType.Point);
        }

        private static void Draw(Series series, List<double> xValues, List<double> yValues, SeriesChartType chartType)
        {
            series.ChartType = chartType;
            series.MarkerSize = 5;
            for (var i = 0; i < xValues.Count; i++)
                series.Points.AddXY(xValues[i], yValues[i]);
        }

        private static PointsDto GetPoints(Dictionary<string, List<List<double>>> sampleBase, string key, int column1, int column2)
        {
            var listX = new List<double>();
            var listY = new List<double>();
            foreach (var sample in sampleBase.Where(x => x.Key == key))
            {
                foreach (var value in sample.Value)
                {
                    listX.Add(value[column1]);
                    listY.Add(value[column2]);
                }
            }
            return new PointsDto
            {
                XPoints = listX,
                YPoints = listY
            };
        }
    }
}
