using System;
using System.Web.Mvc;

namespace _60321_Ganko.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyText = "Лабораторная работа №2";
            SelectList Colors = new SelectList(
                Enum.GetValues(typeof(System.Drawing.KnownColor)));
            ViewBag.Colors = Colors;
            ViewBag.MyText = Request.QueryString["Colors"] ?? "Лабораторная работа №2";
            return View();
        }
    }
}