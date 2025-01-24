using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ContactAPI.Models;

namespace ContactAPI.Data
{
    public class ContactsRepo : DbContext
    {
        public ContactsRepo(DbContextOptions<ContactsRepo> options) : base (options)
        {
            
        }

        public DbSet<Contact> Contacts {get; set;}
    }
}