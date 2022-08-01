using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TweetApp.Model
{
    public class ActiveStatus
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastSeen { get; set; }
        [ForeignKey("UserId")]
        public UserDetails userDetails { get; set; }
    }
}
