using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactAPI.Models
{
    public class Contact
    {
        public int id {get; set;}
        public int number {get; set;}
        public string name {get; set;}
        public string email {get; set;}
    }
}