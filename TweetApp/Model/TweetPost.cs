using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TweetApp.Model
{
    public class TweetPost
    {
        [Key]
        public int PostID { get; set; }
        [ForeignKey("UserId")]
        public int PostedBy { get; set; }
        public string Caption { get; set; }
        public string PostBody { get; set; }
        public string PostedOn { get; set; }

        public UserDetails userDetails { get; set; }
    }
}
