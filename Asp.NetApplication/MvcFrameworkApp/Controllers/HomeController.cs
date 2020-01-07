﻿using MvcFrameworkApp.Models;
using Shared.Services;
using System.Web.Mvc;

namespace MvcFrameworkApp.Controllers
{
    public class HomeController : Controller
    {
        private ICurrentDateService currentDateService;
        private IUserService userService;

        public HomeController(ICurrentDateServiceFactory currentDateServiceFactory, IUserService userService)
        {
            this.currentDateService = currentDateServiceFactory.GetCurrentDateService();
            this.userService = userService;
        }

        public ActionResult Index()
        {
            var model = new IndexModel();
            model.CurrentDate = currentDateService.CurrentDate;
            model.User = userService.GetUser(1);
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}