using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Helper;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    public class StudentiController : Controller
    {
        private readonly IBusinessLayer BL; //per collegarsi alle logiche di business

        public StudentiController(IBusinessLayer bl)
        {
            BL = bl; //o con this
        }

        public IActionResult Index()
        {
            var studenti = BL.GetAllStudenti();
            List<StudenteViewModel> studentiViewModel = new List<StudenteViewModel>();
            foreach (var item in studenti)
            {
                studentiViewModel.Add(item?.ToStudenteViewModel());
            }
            return View(studentiViewModel);
        }

        public IActionResult Details(int id)
        {
            var studente = BL.GetAllStudenti().FirstOrDefault(s => s.ID == id);
            var studenteViewModel = studente.ToStudenteViewModel();
            return View(studenteViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudenteViewModel studenteViewModel)
        {
            if (ModelState.IsValid)
            {
                var studente = studenteViewModel.ToStudente();
                BL.InserisciNuovoStudente(studente);
                return RedirectToAction(nameof(Index));
            }

            return View(studenteViewModel);
        }


    }
}
