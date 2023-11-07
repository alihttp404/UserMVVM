using LessonMVVM.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LessonMVVM.Models
{
    public class User : NotificationService
    {
        private int id;
        private string name;
        private string username;
        private string email;
        private Address address;
        private string website;
        private Company company;

        [JsonPropertyName("id")]
        public int Id { get => id; set { id = value; OnPropertyChanged(); } }

        [JsonPropertyName("name")]
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }

        [JsonPropertyName("username")]
        public string Username { get => username; set { username = value; OnPropertyChanged(); } }

        [JsonPropertyName("email")]
        public string Email { get => email; set { email = value; OnPropertyChanged(); } }

        [JsonPropertyName("website")]
        public string Website { get => website; set { website = value; OnPropertyChanged(); } }

        [JsonPropertyName("address")]
        public Address Address { get => address; set { address = value; OnPropertyChanged(); } }

        [JsonPropertyName("company")]
        public Company Company { get => company; set { company = value; OnPropertyChanged(); } }



        public User()
        {
            
        }

        public User(string name, string username, string email, string website, Address address, Company company)
        {
            Name = name;
            Username = username;
            Email = email;
            Website = website;
            Address = address;
            Company = company;
        }
    }
}
