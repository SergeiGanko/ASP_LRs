using _60321_Ganko.DAL.Entities;
using _60321_Ganko.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _60321_Ganko.Controllers
{
    [Authorize(Roles ="admin")]
    public class AdminController : Controller
    {
        private IRepository<Car> _repository;

        public AdminController(IRepository<Car> repository)
        {
            _repository = repository;
        }

        // GET: Admin
        public ActionResult Index()
        {
            return View(_repository.GetAll());
        }

        // GET: Admin/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View(new Car());
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(Car car, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    car.Image = new byte[count];
                    imageUpload.InputStream.Read(car.Image, 0, (int)count);
                    car.MimeType = imageUpload.ContentType;
                }

                try
                {
                    _repository.Create(car);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(car);
                }
            }
            else return View(car);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Car car, HttpPostedFileBase imageUpload = null)
        {
            if (ModelState.IsValid)
            {
                if (imageUpload != null)
                {
                    var count = imageUpload.ContentLength;
                    car.Image = new byte[count];
                    imageUpload.InputStream.Read(car.Image, 0, (int)count);
                    car.MimeType = imageUpload.ContentType;
                }

                try
                {
                    _repository.Update(car);

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(car);
                }
            }
            else return View(car);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_repository.Get(id));
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _repository.Delete(id);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(_repository.Get(id));
            }
        }
    }
}
