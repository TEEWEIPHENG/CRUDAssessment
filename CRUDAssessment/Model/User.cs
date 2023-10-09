using System.ComponentModel.DataAnnotations;

namespace CRUDAssessment.Model
{
    public class User
    {
        [Key]
        public int userID { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? phone_number { get; set; }
        public string? skillsets { get; set; }
        public string? hobby { get; set; }
    }
}
