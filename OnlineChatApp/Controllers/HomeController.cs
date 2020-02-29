using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineChatApp.Data;
using OnlineChatApp.Models;

namespace OnlineChatApp.Controllers
{

    public class HomeController : Controller
    {
        public readonly ApplicationDbContext _Context;
        public readonly UserManager<AppUser> _userManager;

        public HomeController(ApplicationDbContext context , UserManager<AppUser> userManager)
        {
            _Context = context;
            _userManager = userManager;
        }

      
        public async Task< IActionResult> Index()
        {
            var CurrentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = CurrentUser.UserName;
            }
            var Messages = await _Context.Messages.ToListAsync();
            return View();
        }

        public async Task<IActionResult> _Create(Message message)
        {
            if(ModelState.IsValid)
            {
                message.UserName = User.Identity.Name;
                var sender = await _userManager.GetUserAsync(User);
                message.UserID = sender.Id;
                await _Context.Messages.AddAsync(message);
                await _Context.SaveChangesAsync();
                return Ok();
            }
            return Error();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
