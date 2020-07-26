namespace PostgresConnString.NET
{
    public class ConnectionDetails
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public ConnectionDetails(string host, string user, string password, string database, int port = 5432)
        {
            Host = host;
            User = user;
            Password = password;
            Database = database;
            Port = port;
        }
    }
}