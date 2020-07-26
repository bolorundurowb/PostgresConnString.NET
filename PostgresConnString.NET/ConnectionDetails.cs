using System;
using PostgresConnString.NET.Utils;

namespace PostgresConnString.NET
{
    public class ConnectionDetails
    {
        public string Host { get; set; } = string.Empty;

        public int Port { get; set; } = 5432;

        public string Database { get; set; } = string.Empty;

        public string User { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public ConnectionDetails()
        {
        }

        public ConnectionDetails(string host, string user, string password, string database, int? port = null)
        {
            if (!string.IsNullOrWhiteSpace(host))
            {
                Host = host;
            }

            if (!string.IsNullOrWhiteSpace(user))
            {
                User = user;
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                Password = password;
            }

            if (!string.IsNullOrWhiteSpace(database))
            {
                Database = database;
            }

            if (port.HasValue)
            {
                Port = port.Value;
            }
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

        public string ToNpgsqlSConnectionString() =>
            $"User ID={User};Password={Password};Server={Host};Port={Port};Database={Database};Pooling=true;SSL Mode=Prefer;Trust Server Certificate=true";
    }
}