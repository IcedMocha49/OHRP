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
        public ActionResult Index(HttpPostedFileBase audioFile, HttpPostedFileBase deedFile, HttpPostedFileBase[] multipleFiles, 
            string donorName, string narratorName, string interviewerName, string email, string titleOh)
        {
            try
            {
                //validates if audio and deed file are not null
                if (ModelState.IsValid && audioFile != null && audioFile.ContentLength > 0 && deedFile != null)
                {
                    
                        var fileName = Path.GetFileName(audioFile.FileName);//gets file name
                        //saves to specified path to directory
                        var path = Path.Combine((@"D:\uploads"), fileName);
                        audioFile.SaveAs(path);

                        var fileName2 = Path.GetFileName(deedFile.FileName);
                        var path2 = Path.Combine((@"D:\uploads"), fileName2);
                        deedFile.SaveAs(path2);

                    //iterates through all files for additional files input 
                    foreach (HttpPostedFileBase files in multipleFiles)
                    {
                        if (files != null && files.ContentLength > 0)
                        {
                            var fileName3 = Path.GetFileName(files.FileName);
                            var path3 = Path.Combine((@"D:\uploads"), fileName3);
                            files.SaveAs(path3);
                        }
                    }

                    //if model state is valid then user entry is passed to thanks view
                    ViewData["DonorName"] = donorName;
                    ViewData["NarratorName"] = narratorName;
                    ViewData["InterviewerName"] = interviewerName;
                    ViewData["Email"] = email;
                    ViewData["TitleOH"] = titleOh;
                    ViewData["audioFile"] = audioFile.FileName;
                    //returns thanks view
                    return View("Thanks");
                }
                return View();
            }
            catch
            {
                return View();
            }

        }

    }
}