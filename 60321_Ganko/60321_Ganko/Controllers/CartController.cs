using _60321_Ganko.DAL.Entities;
using _60321_Ganko.DAL.Interfaces;
using _60321_Ganko.Models;
using System.Web.Mvc;

namespace _60321_Ganko.Controllers
{
    public class CartController : Controller
    {
        private IRepository<Car> _repository;

        public CartController(IRepository<Car> repository)
        {
            _repository = repository;
        }

        // GET: Cart
        [Authorize]
        public ActionResult IndexCart(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return View(GetCart());
        }

        // получение корзины из сессии
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart==null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // добавление товара в корзину
        public RedirectResult AddToCart(int id, string returnUrl)
        {
            var item = _repository.Get(id);
            if (item != null)
            {
                GetCart().AddItem(item);
            }

            return Redirect(returnUrl);
        }

        public PartialViewResult CartSummary(string returnUrl)
        {
            TempData["returnUrl"] = returnUrl;
            return PartialView(GetCart());
        }
    }
}