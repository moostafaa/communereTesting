using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace communereTesting.Controllers
{
    public class HomeController : baseController
    {
        public ActionResult Index()
        {
            ServiceLayer.Contract.Gym.IGymService service = new ServiceLayer.DLServices.Gym.GymService();
            var model = service.GetGyms();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}