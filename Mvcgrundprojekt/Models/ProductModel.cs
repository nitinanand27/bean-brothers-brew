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
                    ProductName = "Santa Isabel",
                    ProductType = "Grounded",
                    ProductCountry = "Guatemala",
                    Price = 120,
                    Description = "Vi är glada att återigen kunna erbjuda ett kaffe från Familjen Valdés i Guatemala, det är 2 år sedan senast. Familjen har varit kaffebönder ända sedan 1875 när deras förfäder anlade farmen Santa Isabel. Redan då hade man förstått att den vulkaniska och mineralrika jorden i bergsområdena runt Cobán var exemplariska förhållanden för kaffeodling. ",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h6089/32396089-origpic-412d02.jpg",
                    Amount = 79
                },
                new ProductModel () {
                    ProductID = 2,
                    ProductName = "Buena Vista",
                    ProductType = "Bean",
                    ProductCountry = "Ethiopia",
                    Price = 110,
                    Description = "Ursprungen kan skifta beroende på årstid och vilka kaffen som finns tillgängliga. Just nu innehåller blandningen bönor från kooperativ i Etiopien. Blandningen är välbalanserad, mjukt rostat fram till första crack (vanligtvis den stund i rostningen då en klassisk mörkrost inleds). Kaffet har fortfarande kvar massor av härliga aromer från kaffets naturliga karaktär, samtidigt som mustigheten mjukas upp med en lätt mörkrostad ton. Detta är en blandning som tilltalar de flesta som uppskattar riktigt gott kaffe.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h2673/13992673-origpic-058958.jpg",
                    Amount = 60
                },
                    new ProductModel () {
                    ProductID = 3,
                    ProductName = "Monsoon Malabar",
                    ProductType = "Bean",
                    ProductCountry = "India",
                    Price = 130,
                    Description = "Ett i alla meningar unikt kaffe, som ger en känsla av hur kaffet smakade för 300 år sedan då det skeppades i segelbåtar av trä mellan Indien och Europa. De många och långa veckorna på havet förändrade både kaffets utseende och smak. Detta uppnår man idag genom att exponera bönorna för fuktiga och varma monsunvindar under 2-3 månader, vilket sätter sin prägel på kaffet. Bönorna blir under lagringen stora, spröda och vackert gyllengula. Smaken är kraftfull, mogen och sirapslik. Eftersmaken har karaktär av jordkällare och torvig whisky.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h9320/25289320-origpic-6e3c67.jpg",
                    Amount = 30
                },
                    new ProductModel () {
                    ProductID = 4,
                    ProductName = "Popayan La Sierra",
                    ProductType = "Grounded",
                    ProductCountry = "Colombia",
                    Price = 110,
                    Description = "Detta specialkaffe växer i den röda och näringsrika vulkanjorden på den vackra Popayanplatån. Den höga kvaliteten på kaffet är en kombination av läget och höjden mellan två bergskedjor som ger skugga och på så sätt bidrar till att träden växer långsammare. Just dessa bönor har blivit hanterade med extra omsorg och kärlek på vår gård Rosalia som ligger i Caucaregionen.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h4677/39314677-origpic-0dd37c.jpg",
                    Amount = 97
                },
                    new ProductModel () {
                    ProductID = 5,
                    ProductName = "Santa Isabel",
                    ProductType = "Grounded",
                    ProductCountry = "Guatemala",
                    Price = 111,
                    Description = "JN är glada att återigen kunna erbjuda ett kaffe från Familjen Valdés i Guatemala, det är 2 år sedan senast. Familjen har varit kaffebönder ända sedan 1875 när deras förfäder anlade farmen Santa Isabel. Redan då hade man förstått att den vulkaniska och mineralrika jorden i bergsområdena runt Cobán var exemplariska förhållanden för kaffeodling",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h6089/32396089-origpic-412d02.jpg",
                    Amount = 12
                },
                    new ProductModel () {
                    ProductID = 6,
                    ProductName = "Champs Coffee",
                    ProductType = "Grounded",
                    ProductCountry = "Indonesia",
                    Price = 110,
                    Description = "Rekommenderas som bryggkaffe (denna påsen är bryggmalen) Bönorna är odlade i Indonesien, Sumatra Lintong och är rostad av Gårdsrosteriet i Huskvarna!",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h8623/31938623-origpic-0b37c4.jpg",
                    Amount = 15
                },
                    new ProductModel () {
                    ProductID = 7,
                    ProductName = "Ethiopia Gedeo",
                    ProductType = "Grounded",
                    ProductCountry = "Ethiopia",
                    Price = 99,
                    Description = "I den lilla subregionen Gedeo i södra Etiopien ligger välkända och toppresterande processtationer på rad; Konga, Aricha, Chelba. Detta är ett unikt kaffe som varit i ropet i flera år och som är enkelt att älska. Kring stationerna odlar lokalbefolkningen kaffe på höjder av nära 2000 meter över havet. Varieteterna är som oftast i Etiopien en blandning av inhemska typer.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h8937/778937-origpic-f56a8a.jpg",
                    Amount = 99
                },
                    new ProductModel () {
                    ProductID = 8,
                    ProductName = "Espresso FTO",
                    ProductType = "Grounded",
                    ProductCountry = "Indonesia",
                    Price = 130,
                    Description = "Det här är något så sällsynt som ett espressokaffe som är både gott och etiskt. J&N har blandat arabicabönor från Etiopien (regionen Yirgacheffe) och Indonesien (Gayoprovinsen på Sumatra).",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h2673/13992673-origpic-058958.jpg",
                    Amount = 60
                },
                    new ProductModel () {
                    ProductID = 9,
                    ProductName = "Gayo Mountain",
                    ProductType = "Grounded",
                    ProductCountry = "Indonesia",
                    Price = 99,
                    Description = "Sumatra Gayo Mountain kommer från Aceh-provinsen på Sumatras allra nordligaste spets. Allt kaffe odlas helt utan kemikalier. Kaffet växer på upp till 2000 meters höjd.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h8118/778118-origpic-594cb9.jpg",
                    Amount = 77,
                },
                    new ProductModel () {
                    ProductID = 10,
                    ProductName = "Bourbon Jungle",
                    ProductType = "Bean",
                    ProductCountry = "Ethiopia",
                    Price = 45,
                    Description = "Bakgrunden till denna blandning var att J&N längtade efter ett riktigt mörkrostat kaffe som innehåller högkvalitativa bönor som - trots den mörka rostningen - har kvar de flesta av sina aromer. Kaffet har en rundhet samtidigt som det är bittersött, nästan lite rökigt. Eftersmaken är kraftig och lång. Drick det gärna i presskanna, som brygg eller varför inte som espresso, moka och automat! 500g.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h8937/778937-origpic-f56a8a.jpg",
                    Amount = 89,
                },
                    new ProductModel () {
                    ProductID = 11,
                    ProductName = "Elida Natural",
                    ProductType = "Grounded",
                    ProductCountry = "Panama",
                    Price = 129,
                    Description = "Ett unikt kaffe på många sätt. Wilford Lamastus är respekterad i hela kaffevärlden för sin kvalitet och innovativitet. Denna catuai växer mycket högt (näst högsta plantagen i Panama) och det speciella mikroklimatet i regionen gör kaffet helt unikt.",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h6069/40566069-origpic-f6adf5.jpg",
                    Amount = 45
                },
                    new ProductModel () {
                    ProductID = 12,
                    ProductName = " Gachatha AA",
                    ProductType = "Grounded",
                    ProductCountry = "Kenya",
                    Price = 89,
                    Description = "Vid foten av Aberdarene, 150km norr om Nairobi, ligger processtationen och kooperativet Gachatha som drivs av drygt 1100 småbönder",
                    ImgUrl = "http://www.baristashopen.se/shop/4461/art61/h6118/34486118-origpic-1f4585.jpg",
                    Amount = 120
                }
            };
            return products;
        }
    }
}