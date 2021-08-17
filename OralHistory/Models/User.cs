using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OralHistory.Models
{
    public class User
    {
        

        [Required(ErrorMessage = "Narrator name is required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be longer than 3 characters and shorter than 60 characters.")]
        public string NarratorName { get; set; }

        
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be longer than 3 characters and shorter than 60 characters.")]
        [Required(ErrorMessage = "Donor name is required")]
        public string DonorName { get; set; }

      
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Name must be longer than 3 characters and shorter than 60 characters.")]
        [Required(ErrorMessage = "Interviewer name is required")]
        public string InterviewerName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid. Format example@email.com")]
        public string Email { get; set; }


        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Phone is not valid")]
        public string PhoneNumber { get; set; }


        [StringLength(512, MinimumLength = 5, ErrorMessage = "Title must be longer than 5 characters and shorter than 512 characters.")]
        [Required(ErrorMessage = "Title is required")]
        public string TitleOH { get; set; }

        public DateTime Date { get; set; }

        public string Location { get; set; }

        public HttpPostedFileBase[] multipleFiles { get; set; }

    }
}