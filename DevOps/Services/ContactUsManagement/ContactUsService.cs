using DevOps.Data;
using DevOps.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevOps.Services.ContactUsManagement
{
    public class ContactUsService
    {
        private readonly AppDbContext _context;

        public ContactUsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ContactUs>> GetAll()
        {
            return await _context.ContactUs.ToListAsync();
        }

        public async Task<List<ContactUs>> GetUnReadContact()
        {
            return await _context.ContactUs.Where(mbox => !mbox.IsRead).ToListAsync();
        }

        public async Task<List<ContactUs>> GetReadContact()
        {
            return await _context.ContactUs.Where(mbox => mbox.IsRead).ToListAsync();
        }

        public async Task<ContactUs> GetSpecific(int id)
        {
            var contactUs = await _context.ContactUs
              .FirstOrDefaultAsync(m => m.Id == id);
            
            if(contactUs is null) return null;

            await GetItRead(contactUs);

            return contactUs;
        }

        public async Task GetItRead(ContactUs model)
        {
            if (!model.IsRead)
            {
                model.IsRead = true;
                _context.Update(model);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<ContactUs> Create(ContactUs model)
        {
            _context.Add(model);

            try
            {
                await _context.SaveChangesAsync();

                return model;
            }
            catch
            {

                return null;
            }

        }


        public async Task<ContactUs> Edit(ContactUs contact)
        {
            var model = await GetSpecific(contact.Id);

            if (model is null) return null;

            _context.Update(model);

            try
            {
                await _context.SaveChangesAsync();

                return model;
            }
            catch
            {

                return null;
            }
        }


        public async Task<bool> Delete(int id)
        {
            var result = await GetSpecific(id);
            if (result is null)  return false;

            _context.ContactUs.Remove(result);

            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {

                return false;
            }


        }
    }
}
