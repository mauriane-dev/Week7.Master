using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    public class CounterController : Controller
    {
        private readonly ICounterService counterService;
        private readonly ICounterService counterService2;

        public CounterController(ICounterService counterService, ICounterService counterService2)
        {
            this.counterService = counterService;
            this.counterService2 = counterService2;

        }
        public IActionResult Index()
        {
            var a = counterService.Count();
            var b = counterService2.Count();

            CounterViewModel c = new CounterViewModel { A = a, B = b };
            return View(c);
        }
    }
}
