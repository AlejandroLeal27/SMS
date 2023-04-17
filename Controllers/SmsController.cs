using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace SMS.Controllers
{
    public class SmsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Send(SMSModel sms)
        {
            string accountSid = "AC2e2c87520d12668c69f072ed78c667d1";
            string authToken = "00d940e70b2229411874c6bc7d8d2116";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create(
                body: $"{sms.Body}",
                from: new Twilio.Types.PhoneNumber("+14344426627"),
                to: new Twilio.Types.PhoneNumber($"{sms.Phone}")
            );

            Console.WriteLine(message.Sid);
            return RedirectToAction("Index");
        }
    }
}
