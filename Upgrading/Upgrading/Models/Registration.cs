using System.ComponentModel.DataAnnotations.Schema;

namespace Upgrading.Models
{
    public class Registration
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile? RegistrationFee { get; set; }

        public string RegistrationFeeUrl { get; set; } = string.Empty;
        public bool Accomodation { get; set; } = false;
        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
