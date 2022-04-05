using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevOps.Data;
using DevOps.Models;
using DevOps.Services.ContactUsManagement;

namespace DevOps.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ContactUsService _contactUsService;
        public ContactUsController(ContactUsService contactUsService)
        {
            _contactUsService = contactUsService;

        }

        // GET: ContactUs
        public async Task<IActionResult> Index()
        {
            return View(await _contactUsService.GetAll());
        }

        public async Task<IActionResult> GetAllActiveContactUs()
        {
            return View("Index", await _contactUsService.GetUnReadContact());
        }

        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _contactUsService.GetSpecific(id.Value);

            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContactUs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
               var result = await _contactUsService.Create(contactUs);

                if (result is null) return BadRequest(contactUs);

                return RedirectToAction(nameof(Index));
            }
            return View(contactUs);
        }

        // GET: ContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _contactUsService.GetSpecific(id.Value);

            if (contactUs == null)
            {
                return NotFound();
            }
            return View(contactUs);
        }

        // POST: ContactUs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactUs contactUs)
        {
            if (id != contactUs.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return View(contactUs);

            var result = await _contactUsService.Edit(contactUs);

            if(result is null) return BadRequest(contactUs);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var contactUs = await _contactUsService.GetSpecific(id.Value);

            if (contactUs == null)
                return NotFound();

            return View(contactUs);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _contactUsService.Delete(id);

            if(result == false)
                return BadRequest(result);
            
            return RedirectToAction(nameof(Index));
        }

    }
}
