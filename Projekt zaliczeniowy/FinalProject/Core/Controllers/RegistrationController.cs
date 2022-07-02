using Core.Entities;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly Entities.AppContext _context;

        public RegistrationController(Entities.AppContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UEmail,UFirstName,ULastName,ULogin,UPassword,UPasswordConfirmed")] User user)
        {                                              
            if (ModelState.IsValid)                    
            {                                          
                _context.Add(user);                 
                await _context.SaveChangesAsync();     
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
