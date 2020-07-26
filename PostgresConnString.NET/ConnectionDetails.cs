using System;
using PostgresConnString.NET.Utils;

namespace PostgresConnString.NET
{
    public class ConnectionDetails
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public string Database { get; set; }

        public string User { get; set; }

        public string Password { get; set; }

        public ConnectionDetails(string host, string user, string password, string database, int? port = null)
        {
            Host = host;
            User = user;
            Password = password;
            Database = database;
            Port = port ?? 5432;
        }

        public static ConnectionDetails Parse(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url), "Url cannot be null.");
            }
            
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException(nameof(url), "Url cannot be empty or contain only whitespace characters.");
            }

            var (host, user, password, database, port) = Parser.Parse(url);
            return new ConnectionDetails(host, user, password, database, port);
        }
    }
}