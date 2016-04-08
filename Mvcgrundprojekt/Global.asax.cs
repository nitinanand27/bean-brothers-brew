using Mvcgrundprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Mvcgrundprojekt
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start(object sender, EventArgs e)
        {
            ShoppingCartModel shoppingCart = new ShoppingCartModel();
            Session["shoppingCart"] = shoppingCart.shoppingCart();
            ProductModel productList = new ProductModel();
            Session["productList"] = productList.productList();
            UserModel userList = new UserModel();
            Session["userList"] = userList.userList();
            Session["userName"] = "";
            Session["loggedInMessage"] = "Not logged in";
            Session["userLoggedIn"] = false;
            Session["admin"] = false;
            Session["totalPrice"] = 0;
        }
    }
}
