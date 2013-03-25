using Shinetech.PointEstimation.Entities;

namespace Shinetech.PointEstimation.Services
{
    public interface IEstimationService
    {
        EstimationProcess GetCurrentEstimationProcess();
//        long StartNewEstimationProcess();
        EstimationPoint Estimate(string voter, int point);
//        long Finish();
//        void Cancel();
//        EstimationProcess GetEstimationProcess(long proccessId);
    }
}