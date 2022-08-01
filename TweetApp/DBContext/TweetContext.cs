using Microsoft.EntityFrameworkCore;
using TweetApp.Model;

namespace TweetApp.DBContext
{
    //Context for Application 
    public class TweetContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            Connection connection = new Connection();
            dbContextOptionsBuilder.UseSqlServer(connection.ConnectionString);
        }

        public DbSet<UserDetails> TWUser { get; set; }
        public DbSet<ActiveStatus> TWActiveStatus { get; set; }
        public DbSet<TweetPost> TWTweetpost { get; set; }
    }
}
