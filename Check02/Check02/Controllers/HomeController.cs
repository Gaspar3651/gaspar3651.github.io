using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Check02.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
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

        public void GetImagemSol()
        {
            WebImage wbImage = new WebImage("~/Views/Shared/imagens/sol.png");
            wbImage.Resize(20, 20);
            wbImage.FileName = "quati.jpg";
            wbImage.Write();
        }

        public void GetImagemLua()
        {
            WebImage wbImage = new WebImage("~/Views/Shared/imagens/lua.png");
            wbImage.Resize(20, 20);
            wbImage.FileName = "quati.jpg";
            wbImage.Write();
        }
    }
}