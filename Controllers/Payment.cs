using Microsoft.AspNetCore.Mvc;
using Stripe;

namespace SMS.Controllers
{
    public class Payment : Controller
    {
        public IActionResult Index()
        {
            ViewBag.StripePublishKey = "pk_test_51N0V4tJjTkiFWgEAtmFsNHXwx0INFclDzlVwqnUvfAJyfOy9uRWUtNMiUPW6X4C27UL3RJupToINQ0HwdFbkn5bB00tLGpKM0X";
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            Stripe.StripeConfiguration.ApiKey = "sk_test_51N0V4tJjTkiFWgEAEjg9MaTGGswC1fWdytseKO9ypgafIHOZuLTA1hfFaC0opOqJzMu9PsV9MKt2vp5JpV9lucEV0034F71I1t";

            var myCharge = new Stripe.ChargeCreateOptions();
            // always set these properties
            myCharge.Amount = 1000;
            myCharge.Currency = "MXN";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = "TEST";
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            return View();
        }
    }
}
