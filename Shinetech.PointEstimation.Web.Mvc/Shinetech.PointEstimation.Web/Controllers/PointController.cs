using System.Web.Http;
using Shinetech.PointEstimation.Domain;
using Shinetech.PointEstimation.Web.ClientCommunication;
using EstimationPoint = Shinetech.PointEstimation.Web.Mvc.ViewModels.Point.EstimationPoint;

namespace Shinetech.PointEstimation.Web.Controllers
{
    public class PointController : ApiController
    {
        private readonly EstimationProcessor _processor;
        private readonly ISignalHub _signalHub;

        public PointController(
            EstimationProcessor processor,
            ISignalHub signalHub)
        {
            _processor = processor;
            _signalHub = signalHub;
        }

        public string Post(EstimationPoint point)
        {
            try
            {
                var pointModel = _processor.Estimate(point.Voter, point.Point);
                _signalHub.SendTo<ClientSignalConnection>(Newtonsoft.Json.JsonConvert.SerializeObject(
                    new { pointModel.Voter, pointModel.Point, CreatedTime = pointModel.CreatedTime.ToString("hh:mm:ss") }));
            }
            catch
            {
                return "Fail";
            }
            return "Success";
        }
    }
}
