using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmChartsComponent.Models
{
    public class ChartControl
    {
        public ChartModel[] ChartModels { get; set; }

        public int CountPoints { get; set; }

        public ChartControl()
        {
            ChartModels = new ChartModel[0];
        }

        public ChartControl(int countPoints, int countChart)
        {
            ChartModels = new ChartModel[countChart];
            for (int i = 0; i < countChart; i++)
            {
                ChartModels[i] = new ChartModel { Id = $"chartdiv{i}" };
            }

            CountPoints = countPoints;
            /*ChartModels = new ChartModel[2]
            {
                new ChartModel{ Id="chartdiv1"},
                new ChartModel{ Id="chartdiv2"}
            };*/
        }
    }
}
