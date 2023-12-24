using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Upgrading.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Display(Name = "Learner Name")]
        public string StudentName { get; set; }
        [Display(Name = "Learner Surname")]
        public string StudentSurname { get; set; }
        [Display(Name = "Learner Email")]
        public string Email { get; set; }
        public string? StudentId { get; set; }
    }
}
