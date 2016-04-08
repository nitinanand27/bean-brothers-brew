using Mvcgrundprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcgrundprojekt.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index ()
        {
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/login/index");
            }
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            return View(shoppingCartList);
        }


        public ActionResult AddToCart(ProductModel inputCart)
        {
            //om man försöker läggga in saker i varukorgen utan att vara inloggad
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/product/index");
            }
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            //om man kommer hit utan att ha klickat på "lägg till i varukorg"
            //så skickas man tillbaka med en tom lista i view:n
            if (inputCart.ProductID == 0)
            {
                return View(shoppingCartList);
            }
            //hämta produktlistan
            var productList = (from x in (List<ProductModel>)Session["productList"]
                               where x.ProductID == inputCart.ProductID
                               select x).ToArray();
            //skapa nytt objekt att lägga i kundvagnen
                var newItemToCart = new ShoppingCartModel()
                {
                    ProductID = productList[0].ProductID,
                    Price = productList[0].Price,
                    ProductName = productList[0].ProductName,
                    TotalAmountPerID = 1,
                    imgUrl = productList[0].ImgUrl,
                    totalPrice = productList[0].Price,
                    userEmail = (string)Session["userName"]
                };
            //om listan är tom - lägg till produkten direkt
            bool found = false;
            if (shoppingCartList.Count() == 0)
            {
                Session["totalPrice"] = newItemToCart.totalPrice;
                shoppingCartList.Add(newItemToCart);
                return Redirect("index");
            }
            //annars loopa igenonm listan            
            else
            {
                for (int i = 0; i < shoppingCartList.Count(); i++)
                {
                    
                    //kolla om produkten som ska in i listan redan finns
                    if (shoppingCartList[i].ProductID == inputCart.ProductID)
                    {
                        //finns den så öka antalet av just den produkten med 1
                        shoppingCartList[0].totalPrice += productList[0].Price;
                        shoppingCartList[i].TotalAmountPerID++;
                        Session["totalPrice"] = shoppingCartList[0].totalPrice;
                        found = true;
                        break;
                    }
                }
                
            }
            if (!found)
            {
                //finns den inte i listan, så lägg till
                shoppingCartList[0].totalPrice += productList[0].Price;
                Session["totalPrice"] = shoppingCartList[0].totalPrice;
                shoppingCartList.Add(newItemToCart);
            }
            Session["shoppingCart"] = shoppingCartList;
            return Redirect("index");
        }

        public ActionResult Delete(ShoppingCartModel itemToDelete)
        {
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            var productList = (from x in (List<ProductModel>)Session["productList"]
                               where x.ProductID == itemToDelete.ProductID
                               select x).ToList();


            for (int i = 0; i < shoppingCartList.Count(); i++)
            {
                if (shoppingCartList[i].ProductID == itemToDelete.ProductID)
                {
                    if (shoppingCartList[i].TotalAmountPerID == 0)
                    {
                        break;
                    }
                    if (shoppingCartList[i].TotalAmountPerID > 1)
                    {
                        shoppingCartList[i].TotalAmountPerID--;
                        shoppingCartList[0].totalPrice -= productList[0].Price;
                        Session["totalPrice"] = shoppingCartList[0].totalPrice;
                    }
                    else
                    {
                        shoppingCartList[0].totalPrice -= productList[0].Price;
                        Session["totalPrice"] = shoppingCartList[0].totalPrice;
                        shoppingCartList.RemoveAll(x => x.ProductID == itemToDelete.ProductID);
                        //var newItemToCart = new ShoppingCartModel() { totalPrice = 0 };
                        //shoppingCartList.Add(newItemToCart);                   
                    } 
                }
            }
            Session["shoppingCart"] = shoppingCartList;
            return RedirectToAction("Index");
        }


        public ActionResult CheckOut ()
        {
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/login/index");
            }

            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            var user = (from x in (List<UserModel>)Session["userList"]
                            where x.Email == (string)Session["userName"]
                            select x).ToArray();

            var checkOutList = new List<CheckOutModel>();

            foreach (var item in shoppingCartList)
            {
                var newCheckOut = new CheckOutModel()
                {
                    Firstname = user[0].Firstname,
                    Lastname = user[0].Lastname,
                    Email = user[0].Email,
                    Personnumber = user[0].Personnumber,
                    PhoneNumber = user[0].PhoneNumber,
                    Address = user[0].Address,
                    

                    ProductName = shoppingCartList[0].ProductName,
                    imgUrl = shoppingCartList[0].imgUrl,
                    totalPrice = shoppingCartList[0].totalPrice,
                    ProductID = shoppingCartList[0].ProductID,
                    TotalAmountPerID = shoppingCartList[0].TotalAmountPerID,
                };
                checkOutList.Add(newCheckOut);
            }


            return View(checkOutList);
        }
    }
}