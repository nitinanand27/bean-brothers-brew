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
            //är man inte inloggad så skickas man tillbakatill loginsidan
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/login/index");
            }
            //eller om man går till sidan utan att skickat med nånting, typ för att kolla vad som finns i det
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            return View(shoppingCartList);
        }


        public ActionResult AddToCart(ProductModel inputCart)
        {
            //om man försöker läggga in saker i varukorgen utan att vara inloggad
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/login/index");
            }
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            //om man kommer hit utan att ha klickat på "lägg till i varukorg"
            //så skickas man tillbaka med en tom lista i view:n
            if (inputCart.ProductID == 0)
            {
                return View(shoppingCartList);
            }
            //hämta produktlistan till en array så att productList[0] alltid är den produkten man får info om
            //
            var productList = (from x in (List<ProductModel>)Session["productList"]
                               where x.ProductID == inputCart.ProductID
                               select x).ToArray();
            //skapa nytt objekt att lägga i kundvagnen och får sin info från productList[0].
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
                //är det första saken in i shoppincarten så lägg till direkt och ändra priset på totalen
                Session["totalPrice"] = newItemToCart.totalPrice;
                Session["amountInCart"] = 1;
                shoppingCartList.Add(newItemToCart);
                return Redirect("/product/index");
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
                        //och ändra totala priset med så mycket den kosatar
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
            var amountInCart = 0;
            foreach (var item in shoppingCartList)
            {
                amountInCart += item.TotalAmountPerID;
            }
            Session["amountInCart"] = amountInCart;
            Session["shoppingCart"] = shoppingCartList;
            return Redirect("/product/index");
        }
        //ta bort från shoppinglistan
        public ActionResult Delete(ShoppingCartModel itemToDelete)
        {
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/login/index");
            }
            ////////////////////
            //shoppingCartList[0] innehåller alltid totala priset på hela shoppingcarten!
            ///////////////////
            //hämtar shopping listan            
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            //hämtar en lista på alla attribut av den produkt man vill ta bort och lägger i lista
            var productList = (from x in (List<ProductModel>)Session["productList"]
                               where x.ProductID == itemToDelete.ProductID
                               select x).ToList();

            //loopar igenom för att se om det redan finns en av samma i listan
            for (int i = 0; i < shoppingCartList.Count(); i++)
            {
                //om det blir en match
                if (shoppingCartList[i].ProductID == itemToDelete.ProductID)
                {
                    if (shoppingCartList[i].TotalAmountPerID == 0)
                    {
                        break;
                    }
                    //om det finns fler än en av produkten i listan
                    if (shoppingCartList[i].TotalAmountPerID > 1)
                    {
                        //ta bort en från den produkten från listan
                        var amountInCart = (int)Session["amountInCart"];
                        amountInCart--;
                        Session["amountInCart"] = amountInCart;
                        shoppingCartList[i].TotalAmountPerID--;
                        //justera priset 
                        shoppingCartList[0].totalPrice -= productList[0].Price;
                        Session["totalPrice"] = shoppingCartList[0].totalPrice;
                    }
                    else
                    {
                        var amountInCart = (int)Session["amountInCart"];
                        amountInCart--;
                        Session["amountInCart"] = amountInCart;
                        //justera pris om det är den sista kvar av produkten i listan
                        shoppingCartList[0].totalPrice -= productList[0].Price;
                        Session["totalPrice"] = shoppingCartList[0].totalPrice;
                        //ta bort produkten från listan
                        shoppingCartList.RemoveAll(x => x.ProductID == itemToDelete.ProductID);
                        //var newItemToCart = new ShoppingCartModel() { totalPrice = 0 };
                        //shoppingCartList.Add(newItemToCart);                   
                    } 
                }
            }
            if (shoppingCartList.Count() == 0)
            {
                Session["amountInCart"] = 0;
            }
            Session["shoppingCart"] = shoppingCartList;
            return Redirect("/product/index");
        }

        //skall kommenteras!
        public ActionResult CheckOut ()
        {
            //kollar först om man är inloggad
            if (!(bool)Session["userLoggedIn"])
            {
                return Redirect("/login/index");
            }
            //hämtar hela shoppingcart-listan
            var shoppingCartList = (List<ShoppingCartModel>)Session["shoppingCart"];
            //hämtar vilken användare det är, jämför Email med session-objektet = ["userName"]
            // för att få användar-info och lägger allting i en array, så man kan använda user[0] för att lätt komma åt infon
            if (shoppingCartList.Count() == 0)
            {
                var newItemToCart = new ShoppingCartModel();
                shoppingCartList.Add(newItemToCart);
            }
            var user = (from x in (List<UserModel>)Session["userList"]
                            where x.Email == (string)Session["userName"]
                            select x).ToArray();

            //skapar en ny lista med vad som skall checkas ut!
            var checkOutList = new List<CheckOutModel>();

            //för varje produkt i shoppingcarten så kopieras användarens information och informationen om vilka produkter som ska med
            foreach (var item in shoppingCartList)
            {
                var newCheckOut = new CheckOutModel()
                {

                    //personinfon blir samma varje gång efterseom det är user[0], user[0] skapas längre upp
                    Firstname = user[0].Firstname,
                    Lastname = user[0].Lastname,
                    Email = user[0].Email,
                    Personnumber = user[0].Personnumber,
                    PhoneNumber = user[0].PhoneNumber,
                    Address = user[0].Address,

                    //lägger in infon om vilka produkter som skall köpas i produktlistan
                    //går igenom hela listan och lägger till det som finns
                    ProductName = shoppingCartList[0].ProductName,
                    imgUrl = shoppingCartList[0].imgUrl,
                    totalPrice = shoppingCartList[0].totalPrice,
                    ProductID = shoppingCartList[0].ProductID,
                    TotalAmountPerID = shoppingCartList[0].TotalAmountPerID,
                };
                //lägger in grejer checkout-listan
                checkOutList.Add(newCheckOut);
            }


            return View(checkOutList);
        }
    }
}