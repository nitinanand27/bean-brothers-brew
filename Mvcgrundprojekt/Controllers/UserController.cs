using Mvcgrundprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcgrundprojekt.Controllers
{
    public class UserController : Controller
    {

        // GET: User
        public ActionResult Index ()
        {
            return View();
        }
        public ActionResult Register()
        {
            if ((bool)Session["userLoggedIn"])
            {
                return Redirect("/home/Index");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel registerInput)
        {
            //Om registreringen går igenom valideringen
            if (ModelState.IsValid)
            {
                //Skapar en ny användare och sätter attributen som användaren skrev in
                UserModel newUser = new UserModel()
                {
                    Firstname = registerInput.Firstname,
                    Lastname = registerInput.Lastname,
                    Password = registerInput.Password,
                    Email = registerInput.Email,
                    Address = registerInput.Address,                    
                    Personnumber = registerInput.Personnumber,
                    PhoneNumber = registerInput.PhoneNumber,
                    Admin = false,                    
                };
                //Häntar listan med användare och lägger sen till den nya användaren
                var lista = (List<UserModel>)Session["userList"];
                lista.Add(newUser);                
                return RedirectToAction("Index");
            }

            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
    }
}