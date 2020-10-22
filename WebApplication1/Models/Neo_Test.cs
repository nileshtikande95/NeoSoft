using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class Neo_Test
    {
        public int Row_Id { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string EmailAddress { get; set; }
        [Display(Name = "CountryName")]
        public int CountryId { get; set; }
        [Display(Name = "StateName")]
        public int StateId { get; set; }
        [Display(Name = "City")]
        public int CityId { get; set; }
        
        [Required(ErrorMessage = "PAN Number is required")]
        [RegularExpression("^([A-Za-z]){5}([0-9]){4}([A-Za-z]){1}$", ErrorMessage = "Invalid PAN Number")]
        [Remote("IsPanNumberExist", "Neosoft", ErrorMessage = "Pan Number name already exist")]
        public string PanNumber { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]
        [Remote("IsPassportNumberExist", "Neosoft", ErrorMessage = "Passport Number name already exist")]
        [RegularExpression("^([A-Za-z]){2}([0-9]){2}([A-Za-z]){2}$", ErrorMessage = "Invalid Passport Number")]
        public string PassportNumber { get; set; }
        public string ProfileImage { get; set; }
        public string Gender { get; set; }
        public bool IsActive { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
    }
}