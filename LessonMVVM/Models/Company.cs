using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LessonMVVM.Models
{
    public class Company
    {
        private string name;
        private string bs;

        [JsonPropertyName("name")]
        public string Name { get => name; set => name = value; }


        [JsonPropertyName("bs")]
        public string Bs { get => bs; set => bs = value; }

        public Company()
        {
            
        }

        public Company(string name, string bs)
        {
            Name = name;
            Bs = bs;
        }
    }
}
