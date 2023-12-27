namespace Upgrading.Models
{
    public class SD
    {
        public const string Role_Student = "Student";
        public const string Role_Admin = "Admin";
        public const string Role_FMU = "AdminFMU";

        public const string StatusPending = "Your Application has been received";
        public const string StatuseRejected = "Rejected";
        public const string StatuseApproved = "Accepted";

        public static DateOnly RegistrationDate = new DateOnly(2024, 1, 29);
        public static DateOnly OpenApplicationDate = new DateOnly(2024, 1, 29);

    }
}
