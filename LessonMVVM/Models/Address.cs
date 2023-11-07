using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LessonMVVM.Models
{
    public class Address
    {
        private string street;
        private string city;

        [JsonPropertyName("street")]
        public string Street { get => street; set => street = value; }

        [JsonPropertyName("city")]
        public string City { get => city; set => city = value; }

        public Address()
        {
            
        }

        public Address(string street, string city)
        {
            Street = street;
            City = city;
        }
    }
}
