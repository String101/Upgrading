using System.ComponentModel.DataAnnotations.Schema;


namespace Upgrading.Models
{
    public class TimeTable
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile? Timetable { get; set; }

        public string? TimetableUrl { get; set; }
        public string? Type {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
