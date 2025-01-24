using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContactAPI.Data;
using Microsoft.EntityFrameworkCore;
using ContactAPI.Models;
using ContactAPI.DTOs;

namespace ContactAPI.Controllers
{   
    [Route("[controller]")]
    [ApiController]

    public class ContactsController : ControllerBase
    {   
        private readonly ContactsRepo _context;

        public ContactsController(ContactsRepo context)
        {
            _context = context;
        }


        [HttpGet]

        public async Task<IActionResult> GetAllContacts() {
            var contacts = await _context.Contacts.ToListAsync();

            return Ok(contacts);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetContactById(int id) {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact != null) return Ok(contact);
            else return NotFound();
        }

        [HttpPost]

        public async Task<IActionResult> AddContact(ContactsDTO contactsDTO) {
            var contact = new Contact {
                email = contactsDTO.email,
                name = contactsDTO.name,
                number = contactsDTO.number
            };

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return Ok("Contact Added \n");
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateContact(int id, ContactsDTO newContact) {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact != null) {
                contact.email = newContact.email;
                contact.name = newContact.name;
                contact.number = newContact.number;
            } else return NotFound();
            
            await _context.SaveChangesAsync();
            return Ok("Contact Updated \n");
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteContact(int id) {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact != null) {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            } else return NotFound();

            return Ok("Contact Deleted \n");
        }
    }
}