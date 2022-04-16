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
using Microsoft.AspNetCore.Authorization;

namespace DevOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly ContactUsService _contactUsService;
        public ContactUsController(ContactUsService contactUsService)
        {
            _contactUsService = contactUsService;

        }

        // GET: ContactUs
        [HttpGet("index")]
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return Ok(await _contactUsService.GetAll());
        }

        [Authorize]
        [HttpGet("getAllActiveContactUs")]
        public async Task<IActionResult> GetAllActiveContactUs()
        {
            return Ok(await _contactUsService.GetUnReadContact());
        }

        // GET: ContactUs/Details/5
        [HttpGet("details")]
        [Authorize]
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

            return Ok(contactUs);
        }

        // POST: ContactUs/Create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
               var result = await _contactUsService.Create(contactUs);

                if (result is null) return BadRequest(contactUs);

                return RedirectToAction(nameof(Index));
            }
            return Ok(contactUs);
        }

        // GET: ContactUs/Edit/5

        [HttpGet("edit")]
        [Authorize]
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
            return Ok(contactUs);
        }

        // POST: ContactUs/Edit/5
        [HttpPost("edit")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ContactUs contactUs)
        {
            if (id != contactUs.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(contactUs);

            var result = await _contactUsService.Edit(contactUs);

            if(result is null) return BadRequest(contactUs);
            
            return RedirectToAction(nameof(Index));
        }

        // POST: ContactUs/Delete/5
        [HttpPost("delete")]
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
