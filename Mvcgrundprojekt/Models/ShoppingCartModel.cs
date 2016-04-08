using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvcgrundprojekt.Models
{
    public class ShoppingCartModel
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string imgUrl { get; set; }
        public int TotalAmountPerID { get; set; }
        public int Price { get; set; }
        public string userEmail { get; set; }
        public int totalPrice { get; set; }

        public List<ShoppingCartModel> shoppingCart()
        {
            //skapar ett gäng produkter direkt och lägger i listan av produkter
            List<ShoppingCartModel> shoppingCart = new List<ShoppingCartModel>()
            {


            };
            return shoppingCart;
        }
    }
}