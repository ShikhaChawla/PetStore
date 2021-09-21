using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class PerStoreModels
    {


    }
    public class APIResponse
    {
        public Int32? code { get; set; }
        public string type { get; set; }
        public string message { get; set; }
      
    }
    public class Category
    {
        public Int64? id  { get; set; }
        public string name { get; set; }

    }
    public class Pet
    {
        public Int64? id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string[] photoUrls { get; set; }
        public tags[] tags { get; set; }
        public string status { get; set; }
    }

    public class Petdetails
    {
        public Int64? id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public string status { get; set; }
    }
   
    public class Tag
    {
        public Int64? id { get; set; }
        public string name { get; set; }

    }
    [Serializable()]
    [XmlRoot(ElementName = "tags")]
    public class tags
    {
        [System.Xml.Serialization.XmlElement("OrderedMap")]
        public string OrderedMap { get; set; }
        public Tag tagg { get; set; }
    }
    public class Order
    {
        public Int64? id { get; set; }
        public Int64? petId { get; set; }
        public Int32? quantity { get; set; }
        public string shipDate { get; set; }
        public string status { get; set; }
        public bool complete { get; set; }
       
    }
    public class User
    {
        public Int64? id { get; set; }
        public string username { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public Int32? userStatus { get; set; }

    }

    public class CategoryAndPets
    {
        public string category { get; set; }
        public List<string> petName { get; set; }
    }
}
