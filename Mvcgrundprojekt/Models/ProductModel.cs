using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvcgrundprojekt.Models
{
    public class ProductModel
    {
        //ID 
        public int ProductID { get; set; }
        //Namn
        public string ProductName { get; set; }
        //Sort, typ hel böna eller mald eller nåt?
        public string ProductType { get; set; }
        //Varifrån den kommer ifrån
        public string ProductCountry { get; set; }
        //Vad den kostar
        public int Price { get; set; }
        //Vad produkten är och vad den smakar etc
        public string Description { get; set; }
        //Bild-länken
        public string ImgUrl { get; set; }
        //Hur många som finns i lager
        public int Amount { get; set; }

        public List<ProductModel> productList()
        {
            //skapar ett gäng produkter direkt och lägger i listan av produkter
            List<ProductModel> products = new List<ProductModel>()
            {
                new ProductModel () {
                    ProductID = 1,
                    ProductName = "Gevalia mörk rost",
                    ProductType = "mald",
                    ProductCountry = "Sweden",
                    Price =200,
                    Description = "Ett extra fyllig kaffe med en härligt intensiv arom. Gevalia Mörkrost består till 70% av bönor från gårdar som är Rainforest Alliance-certifierade, och som med fördel kan rostas lite mörkare.",
                    ImgUrl = "http://www.gevalia.se/gevalia2/images/sesv1/pictures/products/product%20images/prod_large_dark_tassimo2.png",
                    Amount = 340
                },
                new ProductModel () {
                    ProductID = 2,
                    ProductName = "Gevalia mörk rost ekoligisk",
                    ProductType = "mald",
                    ProductCountry = "Sweden",
                    Price = 50,
                    Description = "Ett extra fyllig kaffe med en härligt intensiv arom. Gevalia Mörkrost består till 70% av bönor från gårdar som är Rainforest Alliance-certifierade, och som med fördel kan rostas lite mörkare, plus att det är ekologist!.",
                    ImgUrl = "https://static.mathem.se/shared/images/products/large/kaffe-morkrost-eko-450g-gevalia.jpg",
                    Amount = 340
                }
            };
            return products;
        }
    }
}