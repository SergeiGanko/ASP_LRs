using _60321_Ganko.DAL.Entities;
using _60321_Ganko.DAL.Interfaces;
using _60321_Ganko.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _60321_Ganko.Controllers
{
    public class CatalogController : Controller
    {

        List<MenuItem> items;
        private IRepository<Car> _repository;

        public CatalogController(IRepository<Car> repository)
        {
            items = new List<MenuItem>
            {
                new MenuItem{Name="Домой", Controller="Home", Action="Index", Active=string.Empty},
                new MenuItem{Name="Каталог", Controller="Car", Action="List", Active=string.Empty},
                new MenuItem{Name="Администрирование", Controller="Admin", Action="Index", Active=string.Empty},
            };

            _repository = repository;
        }

        //// GET: Menu
        //public ActionResult Index()
        //{
        //    return View();
        //}

        public PartialViewResult Main(string a="Index", string c="Home")
        {
            //items.First(m => m.Controller == c).Active = "active";
            //return PartialView(items);
            var activeItem = items.FirstOrDefault(m => m.Controller == c);
            if (activeItem != null)
            {
                activeItem.Active = "active";
            }
            return PartialView(items);
        }

        public PartialViewResult UserInfo() => PartialView();

        public PartialViewResult Side()
        {
            var groups = _repository
                .GetAll()
                .Select(c => c.ClassType)
                .Distinct();

            return PartialView(groups);
        }

        public PartialViewResult Map() => PartialView(items);
    }
}