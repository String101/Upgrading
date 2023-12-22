using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Pkcs;

namespace Upgrading.Models
{
    public class Subjects
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string  SubjectId {get;set;}
        public string SubjectName { get;set;}
    }
}
