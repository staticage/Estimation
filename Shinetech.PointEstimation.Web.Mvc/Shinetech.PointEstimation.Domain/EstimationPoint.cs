using System;

namespace Shinetech.PointEstimation.Domain
{
    public class EstimationPoint
    {
        public virtual string Voter { set; get; }
        public virtual int Point { set; get; }
        public virtual DateTime CreatedTime { set; get; }
        public virtual EstimationProcessor Processor { get; set; }
    }
}
