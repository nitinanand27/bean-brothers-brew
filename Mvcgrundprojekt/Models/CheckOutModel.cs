using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvcgrundprojekt.Models
{
    public class CheckOutModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string imgUrl { get; set; }
        public int TotalAmountPerID { get; set; }
        public string Email { get; set; }
        public int totalPrice { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Personnumber { get; set; }
        public string PhoneNumber { get; set; }

    }
}