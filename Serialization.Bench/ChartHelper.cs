using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.DataVisualization.Charting;

namespace Serialization.Bench
{
    public static class ChartHelper
    {
        public static void CreateChart(string imagePath,string name, IEnumerable<BenchResult> results, Func<BenchResult,double> selector)
        {
            Chart chart = new Chart();
            chart.Width = 500;
            chart.Height = 400;
            chart.Titles.Add(name);
            var area = new ChartArea("Default");
            chart.ChartAreas.Add(area);
            var series = new Series("Default");
            chart.Series.Add(series);
            area.AxisX.LabelAutoFitStyle = LabelAutoFitStyles.LabelsAngleStep90;
            area.AxisX.LabelStyle.TruncatedLabels = false;
            area.AxisX.Interval = 1;
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.XValueType = ChartValueType.String;

            series.YValueType = ChartValueType.Int32;
            
            foreach(var r in results.OrderBy( r => selector(r)))
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(r.Serializer.Replace("Adapter",""),(int)Math.Round(selector(r)));
                point.AxisLabel = r.Serializer.Replace("Adapter", "");
                series.Points.Add(point);
            }


            chart.SaveImage(imagePath, ChartImageFormat.Png);            
        }    
    }
}
