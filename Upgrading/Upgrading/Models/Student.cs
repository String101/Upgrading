using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upgrading.Models
{
    public class Student
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Student Number")]
        public string StudentId { get; set; }
        [Display(Name ="Name")]
        public string StudentName { get; set; }
        [Display(Name = "Surname")]
        public string StudentSurname { get; set; }
        [Display(Name = "Identity Number")]
        public string StudentIdentityNumber { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        public string Email {  get; set; }
        [Display(Name = "Guardian Name")]
        public string ParentName { get; set; }
        [Display(Name = "Guardian Surname")]
        public string ParentSurname { get; set; }
        [Display(Name = "Guardian Phone Number")]
        public string ParentPhoneNumber { get; set; }
        [Display(Name = "Guardian Email")]
        public string ParentEmail { get; set; }
        [Display(Name = "Street Address")]
        public string Line1 {  get; set; }
        [Display(Name = "City or Locality")]
        public string Line2 { get; set; }
        [Display(Name = "Province")]
        public string Line3 { get; set; }
        [Display(Name = "ZIP Code")]
        public string Line4 { get; set; }
        [Display(Name = "Country")]
        public string Line5 { get; set; }
        public string Status { get; set; } = SD.StatusPending;

        public List<string> ListOfSubjects { get; set; }
        
    }
}
