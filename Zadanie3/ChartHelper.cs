using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Zadanie3
{
    public class ChartHelper
    {
        private static PointsDto GetPoints(Dictionary<int, List<List<double>>> sampleBase, int key, int column1, int column2)
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

        public void GenerateChart(Chart chart, Dictionary<int, List<List<double>>> sampleBase, int column1, int column2)
        {
            chart.Series.Clear();
            foreach (var key in sampleBase.Keys)
            {
                var series = chart.Series.Add($"index środka: {key}");
                var seriesXPoints = GetPoints(sampleBase, key, column1, column2).XPoints;
                var seriesYPoints = GetPoints(sampleBase, key, column1, column2).YPoints;
                Draw(series, seriesXPoints, seriesYPoints, SeriesChartType.Point, chart, "X", "Y");
            }

            DrawGroupMeasures(chart, sampleBase, column1, column2);
        }

        private static void Draw(Series series, List<double> xValues, List<double> yValues, SeriesChartType chartType, Chart chart, string axisX, string axisY)
        {
            series.ChartType = chartType;
            series.MarkerSize = 5;
            chart.ChartAreas[0].AxisX.Title = axisX;
            chart.ChartAreas[0].AxisY.Title = axisY;
            for (var i = 1; i < xValues.Count; i++)
                series.Points.AddXY(xValues[i], yValues[i]);
        }

        private void DrawGroupMeasures(Chart chart, Dictionary<int, List<List<double>>> sampleBase, int column1, int column2)
        {
            var series = chart.Series.Add("środki");
            series.ChartType = SeriesChartType.Point;
            series.MarkerSize = 10;
            foreach (var key in sampleBase.Keys)
            {
                var seriesXPoints = GetPoints(sampleBase, key, column1, column2).XPoints;
                var seriesYPoints = GetPoints(sampleBase, key, column1, column2).YPoints;
                series.Points.AddXY(seriesXPoints[0], seriesYPoints[0]);
            }
        }
    }
}
