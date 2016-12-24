using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using DotNet.Highcharts.Samples.Models;
using Point = DotNet.Highcharts.Options.Point;
using DotNet.Highcharts;
using System.Drawing;

namespace PWC_Task_3._0.Controllers
{
    public class StartController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        // [HttpPost]
        public ActionResult Import()
        {
            return View("~/Views/Chart/Index.cshtml");
        }

        //public ViewResult  Test()
        //{
        //    return View();
        //}




    }
}