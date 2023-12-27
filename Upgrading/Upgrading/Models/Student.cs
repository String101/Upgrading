using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upgrading.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Student Number")]
        [ValidateNever]
        public string StudentId { get; set; } = string.Empty;
        [Display(Name ="Name")]
        [ValidateNever]
        public string StudentName { get; set; }=string.Empty;
        [Display(Name = "Surname")]
        [ValidateNever]
        public string StudentSurname { get; set; } = string.Empty;
        [Display(Name = "Identity Number")]
        public string StudentIdentityNumber { get; set; } = string.Empty;
        [NotMapped]
        public IFormFile? StudentIdentityCard { get; set; }
        [NotMapped]
        public IFormFile? MatricStatement { get; set; }
        [Display(Name = "IdentityCard ")]
        public string? IdentityCardUrl { get; set; }
        [Display(Name = "Statement")]
        public string? StatementUrl { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Display(Name = "Email")]
        [ValidateNever]
        public string Email {  get; set; } = string.Empty;
        [Display(Name = "Guardian Name")]
        public string ParentName { get; set; } = string.Empty;
        [Display(Name = "Guardian Surname")]
        public string ParentSurname { get; set; } = string.Empty;
        [Display(Name = "Guardian Phone Number")]
        public string ParentPhoneNumber { get; set; } = string.Empty;
        [Display(Name = "Guardian Email")]
        public string ParentEmail { get; set; } = string.Empty;
        [Display(Name = "Street Address")]
        public string Line1 {  get; set; } = string.Empty;
        [Display(Name = "City or Locality")]
        public string Line2 { get; set; } = string.Empty;
        [Display(Name = "Province")]
        public string Line3 { get; set; } = string.Empty;
        [Display(Name = "ZIP Code")]
        public string Line4 { get; set; } = string.Empty;
        [Display(Name = "Country")]
        public string Line5 { get; set; } = string.Empty;
        public string Status { get; set; } = SD.StatusPending;
       
        public List<string> ListOfSubjects { get; set; }

    }
}
