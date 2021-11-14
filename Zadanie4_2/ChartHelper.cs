using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;

namespace Zadanie4_2
{
    public class ChartHelper
    {
        public void GenerateChart(Chart chart, MuPlusLambdaDto muPlusLambda)
        {
            chart.Series.Clear();
            chart.Titles.Clear();
            var maxValue = muPlusLambda.MuPool.Max(x => x.AdaptationFunctionValue);
            chart.Titles.Add($"Najwyższa wartość: {maxValue}");
            var muPool = chart.Series.Add("Populacja rodzicielska");
            var lambdaPool = chart.Series.Add("Populacja potomna");
            muPool.MarkerStyle = MarkerStyle.Cross;
            lambdaPool.MarkerStyle = MarkerStyle.Circle;

            chart.ChartAreas[0].AxisY.Minimum = 0;
            chart.ChartAreas[0].AxisY.Maximum = 100;
            chart.ChartAreas[0].AxisX.Minimum = 0;
            chart.ChartAreas[0].AxisX.Maximum = 100;
            chart.ChartAreas[0].BackImage = @"C:\Users\ja\source\repos\SSI\Zadanie4_2\chart.png";
            chart.ChartAreas[0].BackImageWrapMode = ChartImageWrapMode.Scaled;

            var muPoolXPoints = GetPoints(muPlusLambda.MuPool).XPoints;
            var muPoolYPoints = GetPoints(muPlusLambda.MuPool).YPoints;
            var lambdaPoolXPoints = GetPoints(muPlusLambda.LambdaPool).XPoints;
            var lambdaPoolYPoints = GetPoints(muPlusLambda.LambdaPool).YPoints;

            Draw(lambdaPool, lambdaPoolXPoints, lambdaPoolYPoints, SeriesChartType.Point, 5);
            Draw(muPool, muPoolXPoints, muPoolYPoints, SeriesChartType.Point, 7);
        }

        private void Draw(Series series, List<double> xValues, List<double> yValues, SeriesChartType chartType, int size)
        {
            series.ChartType = chartType;
            series.MarkerSize = size;
            for (var i = 0; i < xValues.Count; i++)
                series.Points.AddXY(xValues[i], yValues[i]);
        }

        private static PointsDto GetPoints(List<IndividualDto> individualList)
        {
            var listX = new List<double>();
            var listY = new List<double>();

            foreach (var individual in individualList)
            {
                listX.Add(individual.ParametersList[0]);
                listY.Add(individual.ParametersList[1]);
            }

            return new PointsDto
            {
                XPoints = listX,
                YPoints = listY
            };
        }
    }
}
