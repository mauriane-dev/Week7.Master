using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week7.Master.Core.BusinessLayer;
using Week7.Master.MVC.Models;

namespace Week7.Master.MVC.Controllers
{
    public class UtentiController : Controller
    {
        private readonly IBusinessLayer BL; //per collegarsi alle logiche di business

        public UtentiController(IBusinessLayer bl)
        {
            BL = bl; //o con this
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            return View(new UtenteLoginViewModel
            {
                ReturnUrl = returnUrl
            });
        }


        [HttpPost]
        public IActionResult Login(UtenteLoginViewModel utenteLoginViewModel)
        {
            if (utenteLoginViewModel == null)
            {
                return View();
            }

            var account = BL.GetAccount(utenteLoginViewModel.Username);
            if(account!=null && ModelState.IsValid)
            {
                if (account.Password == utenteLoginViewModel.Password)
                {
                    //l'utente è autenticato
                    //TODO da completare

                }
            }
            return View();
        }

        public IActionResult Forbidden() => View();
        //{
        //    return View();
        //}
    }
}
