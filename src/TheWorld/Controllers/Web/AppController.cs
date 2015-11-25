using Microsoft.AspNet.Mvc;
using System;
using TheWorld.Services;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        public AppController(IMailService service)
        {
            _mailService = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = Startup.Configuration["AppSettings:SiteEmailAddress"];

                if (string.IsNullOrWhiteSpace(email))
                {
                    ModelState.AddModelError("", "Could not send email, configuration problem"); // empty string translates to object level error
                }

                if (_mailService.SendMail(email, // send mail returns bool
                    email,
                    $"Contact Page from {model.Name} ({model.Email})",
                    model.Message))
                {
                    ModelState.Clear(); // to prevent multiple send clicks

                    ViewBag.Message = "Mail Sent.";

                }
            }
            else
            {

            }
            return View();
        }
    }

    
}
