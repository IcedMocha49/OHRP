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
        
        [HttpPost]
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
        }


        /* [HttpPost]
         public ActionResult Index(HttpPostedFileBase files)
         {
             try
             {
                 string directory = @"D:\";
                 if (files != null && files.ContentLength > 0)
                 {
                     var fileName = Path.GetFileName(files.FileName);
                     files.SaveAs(Path.Combine(directory, fileName));
                 }
                 ViewBag.Message = "File Uploaded Successfully!!";
                 return View();
             }
             catch
             {
                 ViewBag.Message = "File upload failed!!";
                 return View();
             }
         }*/
        /*[HttpPost]
        public ActionResult Index(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                foreach (string key in formCollection.AllKeys)
                {
                    Response.Write("Key = " + key + "  ");
                    Response.Write("Value = " + formCollection[key]);
                    Response.Write("<br/>");
                }
            }
            return View("Thanks");
        }*/


    }
}