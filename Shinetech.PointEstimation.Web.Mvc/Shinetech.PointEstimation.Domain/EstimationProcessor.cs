using System;
using System.Collections.Generic;
using System.Linq;

namespace Shinetech.PointEstimation.Domain
{

    public sealed class EstimationProcessor
    {
        public int? EstimationResult
        {
            get
            {
                if (Points.Any())
                    return (int)Math.Ceiling(Points.Average(x => x.Point));
                return null;
            }
        }

        public EstimationProcessor()
        {
            Points = new List<EstimationPoint>();
        }

        public IList<EstimationPoint> Points { get; private set; }

        public EstimationPoint Estimate(string voter, int point)
        {
            var estimationPoint = Points.SingleOrDefault(x => x.Voter == voter);
            if (estimationPoint != null)
            {
                estimationPoint.Point = point;
            }
            else
            {
                estimationPoint = new EstimationPoint
                {
                    Voter = voter,
                    Point = point,
                    CreatedTime = DateTime.Now
                };
                Points.Add(estimationPoint);
            }

            return estimationPoint;
        }

        public void Reset()
        {
            this.Points.Clear();
        }
    }
}
