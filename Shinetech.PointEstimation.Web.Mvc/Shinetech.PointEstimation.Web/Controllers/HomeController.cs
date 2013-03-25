using System.Linq;
using System.Web.Mvc;
using Shinetech.PointEstimation.Domain;
using Shinetech.PointEstimation.Web.ClientCommunication;
using EstimationPoint = Shinetech.PointEstimation.Web.ViewModels.Home.EstimationPoint;
using Index = Shinetech.PointEstimation.Web.ViewModels.Home.Index;

namespace Shinetech.PointEstimation.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISignalHub _signalHub;
        private readonly EstimationProcessor _processor;

        public HomeController(
            ISignalHub signalHub,
            EstimationProcessor processor)
        {
            _signalHub = signalHub;
            _processor = processor;
        }

        public ActionResult Index()
        {
            var viewModel = new Index
            {

                Points = _processor.Points.Select(x => new EstimationPoint
                {
                    CreatedTime = x.CreatedTime,
                    Point = x.Point,
                    Voter = x.Voter
                }).ToList(),
                EstimationResult = _processor.EstimationResult
            };
            return View(viewModel);
        }

        public ActionResult Estimate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Estimate(EstimationPoint command)
        {
            _processor.Estimate(command.Voter, command.Point);
            _signalHub.SendTo<ClientSignalConnection>("Updated");
            return Json(new { Success = "1" });
        }

        public ActionResult ProcessInfomation()
        {
            var viewModel = new Index
            {
                EstimationResult = _processor.EstimationResult,
                Points = _processor.Points.Select(x => new EstimationPoint
                {
                    CreatedTime = x.CreatedTime,
                    Point = x.Point,
                    Voter = x.Voter
                })
            };
            return PartialView("ProcessInfomation", viewModel);
        }

        public ActionResult Reset()
        {
            _processor.Reset();

            _signalHub.SendTo<ClientSignalConnection>("Updated");
            return RedirectToAction("Index");
        }
    }
}
