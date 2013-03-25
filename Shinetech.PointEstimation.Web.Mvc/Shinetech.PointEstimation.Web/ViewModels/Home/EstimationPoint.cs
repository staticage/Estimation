using System;

namespace Shinetech.PointEstimation.Web.ViewModels.Home
{
    public class EstimationPoint
    {
        public DateTime CreatedTime { set; get; }
        public string Voter { set; get; }
        public int Point { set; get; }
    }
}