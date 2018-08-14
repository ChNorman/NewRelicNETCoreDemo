using System;
using System.Threading;
using System.Diagnostics;
using Demo.BuisnessLogic;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using NRConfig;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        [Instrument(MetricName = "Worker/Index", Name = "HomeController")]
        public IActionResult Index()
        {

            NewRelic.Api.Agent.NewRelic.AddCustomParameter("Discount Code", "Summer Super Sale");
            NewRelic.Api.Agent.NewRelic.AddCustomParameter("Item Code", (Single)31456);
            var tempWorker = new MyWorker();
            tempWorker.DoWork();

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [Instrument(MetricName = "Worker/Contact", Name = "HomeController")]
        public IActionResult Contact()
        {
            var bar = new Bar();
            bar.Bar1();
            bar.Bar2();
            
            ViewData["Message"] = "Your contact page.";

            Thread.Sleep(5000);

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
