using Mvcgrundprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcgrundprojekt.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult shoppingCartPartial()
        {
            //skickar hela shoppingcart-listan till en partiaview
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            return PartialView(shoppingCartList);
        }
    }
}