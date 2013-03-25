using System;
using System.Collections.Generic;
using System.Linq;
using Shinetech.PointEstimation.Web.ViewModels.Home;

namespace Shinetech.PointEstimation.Web.Mvc.ViewModels.Estimation
{
    public class Infomation : Page
    {
        public IEnumerable<EstimationPoint> Points { set; get; }


        public string Average
        {
            get
            {
                if (Points.Any())
                    return Points.Average(x => x.Point).ToString("f");
                return "No points data.";
            }
        }

        public Infomation()
        {
            Points = Enumerable.Empty<EstimationPoint>();
        }


    }
}