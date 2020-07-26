namespace PostgresConnString.NET.Models
{
    public class ConnectionDetails
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }
    }
}