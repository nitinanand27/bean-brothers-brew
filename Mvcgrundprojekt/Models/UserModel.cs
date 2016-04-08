﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvcgrundprojekt.Models
{
    public class UserModel
    {
        //Förnamn
        [Required(ErrorMessage = "Förnamn krävs")]  
        public string Firstname { get; set; }

        //Efternamn
        [Required(ErrorMessage = "Efternamn krävs")]
        public string Lastname { get; set; }

        //Lösenord
        [Required(ErrorMessage = "Lösenord ")]
        public string Password { get; set; }

        //Måste ha en korrekt email, ett regular expression kollar att det stämmer
        [Required(ErrorMessage = "Email krävs")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Måste vara en korrekt email")]
        public string Email { get; set; }
        
        //Adress krävs
        [Required(ErrorMessage = "Adress krävs")]
        public string Address { get; set; }

        //Behöver personnummer, måste vara 10 siffror långt
        [Required(ErrorMessage = "Personnummer krävs")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "ex: 8606114679")]
        public string Personnumber { get; set; }

        //Telefonnummer, måste vara mellan 6 och 10
        [Required(ErrorMessage = "Telefonnummer krävs")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Måste vara mellan 6 och 10 siffror")]
        public string PhoneNumber { get; set; }
        
        //Sätter om användaren är admin eller inte, den är false som standard i controllern
        public bool Admin { get; set; }

        public List<UserModel> userList()
        {
            List<UserModel> users = new List<UserModel>()
            {
                //skapar tre användare direkt, man använder sin mail för att logga in!
                new UserModel () {
                    Firstname = "Robert",
                    Lastname = "Hansson",
                    Password = "123",
                    Email = "robban@robban.se",
                    Address = "Wall Street 1 New York",
                    Personnumber = "5001124657",
                    PhoneNumber = "0123456789",
                    Admin = true
                },
                    new UserModel () {
                    Firstname = "Jimmy",
                    Lastname = "Jazz",
                    Password = "123",
                    Email = "jimmyjazz@jimmyjazz.se",
                    Address = "Biggest Skyscraper 99 Tokyo",
                    Personnumber = "4602457894",
                    PhoneNumber = "987654321",
                    Admin = true
                },
                    new UserModel () {
                    Firstname = "Karl XVI",
                    Lastname = "Gustav",
                    Password = "123",
                    Email = "administrator",
                    Address = "Kungliga Slottet 107 70 Stockholm",
                    Personnumber = "0012124679",
                    PhoneNumber = "65498741",
                    Admin = true
                },
                    new UserModel () {
                    Firstname = "Patrik",
                    Lastname = "Nilsson",
                    Password = "123",
                    Email = "patteee@gmail.com",
                    Address = "Strandvägen 40 31145 Falkenberg",
                    Personnumber = "8606114679",
                    PhoneNumber = "0709695196",
                    Admin = true
                }
            };
            return users;
        }

    }   

}