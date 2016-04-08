using Mvcgrundprojekt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvcgrundprojekt.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index(string search)
        {
            if (search == null)
            {
            //Denna metoden skapar en lista av alla produkter som finns i Session["productList"] och returnerar den till view:n
            var productList = (from x in (List<ProductModel>)Session["productList"]
                               select x).ToList();
            return View(productList);
            }
            else
            {
                var searchResult = (from x in (List<ProductModel>)Session["productList"]
                                    where x.ProductName == search
                                    select x).ToList();
                return View(searchResult);
            }

        }
        public ActionResult Edit(ProductModel input)
        {
            //om det som kommer in inte är ett försök att ändra på nånting, dvs att det är null så visas bara viewn
            //om det kommer med en produkt fullt med nya saker så ändrar den det aktuella produkten till det nya
            //och hittar den gamla produkten och skriver över den
            if (input.Description != null)
            {
                //hämtar listan
                var productList = (List<ProductModel>)Session["productList"];
                //skapar ny ProductModel från vad som kommer ifrån formuläret
                var newEditedProduct = new ProductModel()
                {
                    ProductID = input.ProductID,
                    ProductName = input.ProductName,
                    ProductType = input.ProductType,
                    ProductCountry = input.ProductCountry,
                    Price = input.Price,
                    Description = input.Description,
                    ImgUrl = input.ImgUrl,
                    Amount = input.Amount
                };
                //hitta gamla produkten i listan
                var oldProduct = productList.FindIndex(x => x.ProductID == input.ProductID);
                //byt ut produkten
                productList[oldProduct] = newEditedProduct;
                //skicka till index på produkter
                return RedirectToAction("index");
            }

            return View();
        }
        public ActionResult Search(string search)
        {
            var searchResult = (from x in (List<ProductModel>)Session["productList"]
                                where x.ProductName == search
                                select x).ToList();
            return View(searchResult);
        }
        public ActionResult Delete(ProductModel input)
        {
            //det som kommer in genom "ProductModel input" är ett ID
            //tar bort från produktlista beroende på vilket ID som kommer från view:n
            var lista = (List<ProductModel>)Session["productList"];
            lista.RemoveAll(x => x.ProductID == input.ProductID);
            //Session["productList"] = lista;
            return RedirectToAction("index");
        }
        //public ActionResult AddNewProduct()
        //{
        //    return View();
        //}
        public ActionResult AddNewProduct(ProductModel input)
        {
            //kollar först om den som försöker lägga till produkt är en administratör
            if (!(bool)Session["admin"])
            {
                return Redirect("/product/index");
            }
            //kollar att den som är inloggad är admin och att inmatningen inte är null
            if ((bool)Session["admin"] && input.ProductType != null)
            {
                //hämtar listan med produkter
                var lista = (List<ProductModel>)Session["productList"];
                //skapar nytt objekt av ProductModel från det som kommer ifrån view:n
                var newProduct = new ProductModel()
                {
                    ProductID = lista.Count() + 1,
                    ProductName = input.ProductName,
                    ProductType = input.ProductType,
                    ProductCountry = input.ProductCountry,
                    Price = input.Price,
                    Description = input.Description,
                    ImgUrl = input.ImgUrl,
                    Amount = input.Amount
                };
                //lägger till objektet i listan och skickar tillbaka till index
                lista.Add(newProduct);
                return RedirectToAction("index");

            }
            return View();
        }
    }
}