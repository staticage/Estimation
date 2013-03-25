using System.Collections.Generic;
using System.Linq;
using Shinetech.PointEstimation.Web.Mvc.ViewModels;
using Shinetech.PointEstimation.Web.ViewModels.Home;

namespace Shinetech.PointEstimation.Web.ViewModels.Estimation
{
    public class Index : Page
    {
        public long ProcessId { get; set; }
        public IEnumerable<EstimationPoint> Points { set; get; }

        public Index()
        {
            Points = Enumerable.Empty<EstimationPoint>();
        }
    }
}