using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OralHistory.Models;
using System.IO;

namespace OralHistory.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Thanks()
        {

            return View();
        }

        /*[HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                ViewData["DonorName"] = formCollection["DonorName"];
                ViewData["NarratorName"] = formCollection["NarratorName"];
                ViewData["Email"] = formCollection["Email"];
                ViewData["TitleOH"] = formCollection["TitleOH"];
                ViewData["files"] = formCollection["files"];
            }
            return View("Thanks");
        }*/




        /* [HttpPost]
         public ActionResult Index(FormCollection formCollection, HttpPostedFileBase files)
         {
             try
             {
                 //single audio file
                 if (files != null && files.ContentLength > 0)
                 {
                     var fileName = Path.GetFileName(files.FileName);
                     var path = Path.Combine((@"D:\uploads"), fileName);
                     files.SaveAs(path);
                 }
                 if (ModelState.IsValid)
                 {
                     ViewData["DonorName"] = formCollection["DonorName"];
                     ViewData["NarratorName"] = formCollection["NarratorName"];
                     ViewData["Email"] = formCollection["Email"];
                     ViewData["TitleOH"] = formCollection["TitleOH"];
                     ViewData["files"] = formCollection["files"];
                 }
                 return View("Thanks");
             }
             catch
             {

                 return View();
             }

         }*/

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase audioFile, string donorName, string narratorName, string email, string titleOh)
        {
            
            try
            {
                //single audio file
                if (ModelState.IsValid && audioFile != null && audioFile.ContentLength > 0)
                {
                    
                    var fileName = Path.GetFileName(audioFile.FileName);
                    var path = Path.Combine((@"D:\uploads"), fileName);
                    audioFile.SaveAs(path);

                    ViewData["DonorName"] = donorName;
                    ViewData["NarratorName"] = narratorName;
                    ViewData["Email"] = email;
                    ViewData["TitleOH"] = titleOh;
                    ViewData["audioFile"] = audioFile.FileName;

                }
                return View("Thanks");
            }
            catch
            {
                return View();
            }


        }

    }
}