using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SafeguardClassifications.Models;
using SafeguardClassifications.ViewModels;

namespace SafeguardClassifications.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }


        public IActionResult Types()
        {
            var d = new MaintainanceTable();
            var t = new IncidentTypes(d);   
            return View(t); 
        }



        //public IActionResult CauseGroups()
        //{
        //    var d = new MaintainanceTable();
        //    var t = new CauseGroups(d);
            
        //    return View(t);
        //}


        public IActionResult CauseGroups()
        {

         

                var arg = RouteData.Values["id"];
                var d = findMatchingCauseGroups(arg.ToString());
                var t = new CauseGroups(d);

                return View(t);

            

        
        }

        private MaintainanceTable findMatchingCauseGroups(string arg)
        {
            var d = new MaintainanceTable();
            var result = new MaintainanceTable();
            result.Classifications.Clear();

            foreach ( Classification c in d.Classifications)

            {
                if (c.incidentType == arg)
                {
                    result.Classifications.Add(c);
                }

                
            }

            return result;

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
