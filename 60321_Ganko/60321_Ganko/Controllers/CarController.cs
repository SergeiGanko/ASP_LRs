using _60321_Ganko.DAL.Entities;
using _60321_Ganko.DAL.Interfaces;
using _60321_Ganko.Models;
using System.Linq;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace _60321_Ganko.Controllers
{
    public class CarController : Controller
    {
        int pageSize = 3;

        IRepository<Car> _repository;

        public CarController(IRepository<Car> repository)
        {
            _repository = repository;
        }

        // GET: Car
        public ActionResult List(string group, int page = 1)
        {
            var lst = _repository
                .GetAll()
                .Where(c=> group==null || c.ClassType.Equals(group))
                .OrderBy(c => c.Price);

            var model = PageListViewModel<Car>.CreatePage(lst, page, pageSize);

            if (Request.IsAjaxRequest())
            {
                return PartialView("ListPartial", model);
            }
            return View(model);
        }

        public FileContentResult GetImage(int carId)
        {
            var car = _repository.Get(carId);
            if (car != null)
            {
                return File(car.Image, car.MimeType);
            }
            else return null;
        }

        public async Task<FileResult> GetImageAsync(int carId)
        {
            var car = await _repository.GetAsync(carId);
            if (car != null)
            {
                return File(car.Image, car.MimeType);
            }
            else return null;
        }
    }
}