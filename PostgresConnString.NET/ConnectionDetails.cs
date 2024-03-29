﻿using System;
using PostgresConnString.NET.Utils;

namespace PostgresConnString.NET
{
    /// <summary>
    /// Contains a postgresql connection details
    /// </summary>
    public class ConnectionDetails
    {
        /// <summary>
        /// The database server host address
        /// Default: ""
        /// </summary>
        public string Host { get; set; } = string.Empty;

        /// <summary>
        /// The port the database is on
        /// Default: 5432
        /// </summary>
        public int Port { get; set; } = 5432;

        /// <summary>
        /// The database name
        /// Default: ""
        /// </summary>
        public string Database { get; set; } = string.Empty;

        /// <summary>
        /// The login user name
        /// Default: ""
        /// </summary>
        public string User { get; set; } = string.Empty;

        /// <summary>
        /// The login password
        /// Default: ""
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Initialize with default values
        /// </summary>
        public ConnectionDetails()
        {
        }

        /// <summary>
        /// Initialize with specified values
        /// </summary>
        /// <param name="host">The database server host address</param>
        /// <param name="user">The login user name</param>
        /// <param name="password">The login password</param>
        /// <param name="database">The database name</param>
        /// <param name="port">The port the database is on</param>
        public ConnectionDetails(string host, string user, string password, string database, int? port = null)
        {
            if (!string.IsNullOrWhiteSpace(host))
                Host = host;

            if (!string.IsNullOrWhiteSpace(user))
                User = user;

            if (!string.IsNullOrWhiteSpace(password))
                Password = password;

            if (!string.IsNullOrWhiteSpace(database))
                Database = database;

            if (port.HasValue)
                Port = port.Value;
        }

        /// <summary>
        /// Parse a postgres connection url
        /// </summary>
        /// <param name="url">A postgres connection url</param>
        /// <returns>The <see cref="ConnectionDetails"/></returns>
        /// <exception cref="ArgumentNullException">Thrown on null input</exception>
        /// <exception cref="ArgumentException">Thrown on empty or whitespace input</exception>
        public static ConnectionDetails Parse(string url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url), "Url cannot be null.");

            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("Url cannot be empty or contain only whitespace characters.", nameof(url));

            var (host, user, password, database, port) = Parser.Parse(url);
            return new ConnectionDetails(host, user, password, database ?? string.Empty, port);
        }

        /// <summary>
        /// Generates a formatted, valid Npgsql connection with the connection details
        /// </summary>
        /// <returns>A formatted <see cref="string"/></returns>
        public string ToNpgsqlConnectionString() =>
            $"User ID={User};Password={Password};Server={Host};Port={Port};Database={Database};Pooling=true;SSL Mode=Prefer;Trust Server Certificate=true";
    }
}