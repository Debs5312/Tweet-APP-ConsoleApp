namespace TweetApp.DBContext
{
    internal class Connection
    {
        public string ConnectionString { get; set; }
        public Connection()
        {
            ConnectionString = "data source=CTSDOTNET380;Initial Catalog=dev.Twitter.com;User ID=sa;Password=pass@word1";
        }
    }
}
