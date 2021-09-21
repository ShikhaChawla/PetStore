using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            var listOfAvailablepets = availablepets();
            var distinctCategories = distinctCategory(listOfAvailablepets);
            var sortedCategories = sortedData(listOfAvailablepets, distinctCategories);
            printTheOutput(sortedCategories);
            unitTest(sortedCategories);
        }
        public static List<Petdetails> availablepets()
        {
            List<Petdetails> petDetailsList = new List<Petdetails>();
          
            var fireUrl = "https://petstore.swagger.io/v2/pet/findByStatus?status=available".ToString();
            string decodedUrl = HttpUtility.UrlDecode(fireUrl);
            HttpWebRequest req = WebRequest.Create(decodedUrl) as HttpWebRequest;
            using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse) 
            {
                Console.OutputEncoding = System.Text.Encoding.Unicode;
                StreamReader reader = new StreamReader(resp.GetResponseStream());
                var testjson = reader.ReadToEnd();
                var deserilised = JsonConvert.DeserializeObject<List<Pet>>(testjson);
                foreach (var list in deserilised)
                {
                    if(list.status.Contains("available"))
                    {
                        Petdetails petDetail = new Petdetails();
                       
                        if (list.category != null && list.category.name != null && list.category.id != null)
                        {
                            petDetail.id = list.id;
                            petDetail.name = list.name;
                            petDetail.category = list.category;
                            petDetail.status = list.status;
                            petDetailsList.Add(petDetail);
                        }
                    }
                }
            }
            return petDetailsList;
        }

        public static List<string> distinctCategory(List<Petdetails> allPets) 
        {
            List<string> categoryNames = new List<string>();
            foreach (var allpetlist in allPets)
            {
                var categories = allpetlist.category.name;
                categoryNames.Add(categories);
            }
            List<string> distinctcategories = categoryNames.Distinct().ToList();
            return distinctcategories;
        }

        public static List<CategoryAndPets> sortedData(List<Petdetails> listOfAvailablepets, List<string> distinctCategories)
        {
            distinctCategories.Sort();
           
            List<CategoryAndPets> catAndPetList = new List<CategoryAndPets>();
            foreach (var category in distinctCategories)
            {
                CategoryAndPets catAndPet = new CategoryAndPets();
                List<string> allPets = new List<string>();
                catAndPet.category = category;
                foreach (var availablepets in listOfAvailablepets) 
                {
                    if (availablepets.category.name == category)
                    {
                        string name = "";
                        name = availablepets.name;
                        allPets.Add(name);  
                    }
                    
                }
                allPets.Sort();
                allPets.Reverse();
                catAndPet.petName = allPets;
                catAndPetList.Add(catAndPet);
            }
            return catAndPetList;
        }
        public static void printTheOutput(List<CategoryAndPets> sortedCatories) {
            Console.Write("Please see the list of Available pets Sorted in Categories and displayed in reverse order by name:");
            Console.WriteLine(" ");

            foreach (var output in sortedCatories)
            {
                Console.WriteLine(output.category + " - ");
                foreach (var pets in output.petName)
                {
                    Console.WriteLine("\t" + pets);
                }
                Console.WriteLine();
            }

            Console.WriteLine(" ");
        }

        public static void unitTest(List<CategoryAndPets> sortedCatories)
        {

            Console.WriteLine("Unit Test: Enter a Category name to see if the avaliable pets are same or not (Case Sensitive)");
            string catagoryName = Console.ReadLine();
            Console.WriteLine("The avalaible pets for this Catagory are as follows");
            foreach (var sortedlist in sortedCatories)
            {
                if (sortedlist.category == catagoryName)
                {
                    foreach (var pets in sortedlist.petName)
                    {
                        Console.WriteLine("\t" + pets);
                    }
                }
            }
        }
    }
}
