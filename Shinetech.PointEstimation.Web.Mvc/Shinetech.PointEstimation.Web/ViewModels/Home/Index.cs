using System;
using System.Collections.Generic;
using System.Linq;
using Shinetech.PointEstimation.Web.Mvc.ViewModels;

namespace Shinetech.PointEstimation.Web.ViewModels.Home
{
    public class Index : Page
    {
        public IEnumerable<EstimationPoint> Points { set; get; }

        public int? EstimationResult { set;get;}
    }
}