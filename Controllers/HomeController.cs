using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using System.Diagnostics;
using System;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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

        [HttpPost]
        public ActionResult Index(SMSModel sms)
        {
            string accountSid = "AC2e2c87520d12668c69f072ed78c667d1";
            string authToken = "00d940e70b2229411874c6bc7d8d2116";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"{sms.Body}",
                from: new Twilio.Types.PhoneNumber("+14344426627"),
                to: new Twilio.Types.PhoneNumber("+528993603776")
            );

            Console.WriteLine(message.Sid);

            return View();
        }
    }
}