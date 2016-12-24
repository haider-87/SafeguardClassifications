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
            var d = new MaintainanceTable();
            var t = new IncidentTypes(d);
            return View(t);
         // return View();
       }

        public IActionResult About()
        {
            ViewData["Message"] = "About this project";

            return View();
        }


        public IActionResult Types()

            
        {
            var d = new MaintainanceTable();
            var t = new IncidentTypes(d);   
            return View(t); 
        }




        public IActionResult CauseGroups()
        {

         

                var arg = RouteData.Values["id"];
                var d = findMatchingCauseGroups(arg.ToString());
                var c = findMatchingComments(arg.ToString());
                var t = new CauseGroupsVM(d, c);
                return View(t);

            

        
        }

        public IActionResult Causes()
        {

            var arg = RouteData.Values["id"];
          
            var d = findMatchingCauses(arg.ToString());
            var t = new Cause1s(d);
            return View(t);




        }

        private MaintainanceTable findMatchingCauses(string v)
        {
            var d = new MaintainanceTable();
            var result = new MaintainanceTable();
            result.Classifications.Clear();

            foreach (Classification c in d.Classifications)

            {
                if (c.causeGroup == v)
                {
                    result.Classifications.Add(c);
                }


            }

            return result;
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


        private Comments findMatchingComments(string arg)
        {
            var d = new Comments();
            var result = new Comments();
            result.CommentsList.Clear();

            foreach (Comment c in d.CommentsList)

            {
                if (c.incidentType == arg)
                {
                    result.CommentsList.Add(c);
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
