using Mvcgrundprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcgrundprojekt.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult LogOut ()
        {
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/home/Index");
            }
            //sätter tillbaka alla sessions-variablar till ursprunget
            Session["loggedInMessage"] = "not logged in";
            Session["userLoggedIn"] = false;
            Session["admin"] = false;
            var clearList = (List<ShoppingCartModel>)Session["shoppingCart"];
            clearList.Clear();
            Session["shoppingCart"] = clearList;
            Session["amountInCart"] = 0;
            return Redirect("/Home");
        }
        public ActionResult Index(string email, string password)
        {
            if ((bool)Session["userLoggedIn"])
            {
                return Redirect("/home/Index");
            }
            //Kollar om det kommer nånting från view:n         
            if (email != null && password != null)
            {
                //hämtar listan med användare
                var lista = (List<UserModel>)Session["userList"];
                //var password = input.Password;
                //var email = input.Email;
                //kollar om användaren/lösenordet finns som en match i listan med användare
                foreach (var users in lista)
                {
                    if (users.Email == email && users.Password == password)
                    {
                        //Loggar in användaren om det blir en match
                        Session["loggedInMessage"] = "logged in";
                        Session["userLoggedIn"] = true;
                        Session["userName"] = email;
                        //Om den som loggar in är admin 
                        if (users.Admin)
                        {
                            Session["admin"] = true;
                        }
                    }
                }
                return Redirect("/home/index");
            }
            else
            {
                return Redirect("/home/index");
            }


        }
    }
}