using System.ComponentModel.DataAnnotations;

namespace TweetApp.Model
{
    public class UserDetails
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email ID is required.")]
        public string Email { get; set; }
        public string Gender { get; set; }
        [Required(ErrorMessage = "Password required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
