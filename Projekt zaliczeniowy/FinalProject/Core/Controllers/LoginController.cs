using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Controllers
{
    public class LoginController : Controller
    {
        private readonly Entities.AppContext _context;
        private readonly IAccountService _accountService;

        public LoginController(Entities.AppContext context, IAccountService accountService)
        {
            _context = context;
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Login([FromBody] LoginDTO loginDTO)
        {
            string token = _accountService.GenerateJwt(loginDTO);
            return Ok();
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
