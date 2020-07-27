using System;

namespace PostgresConnString.NET.Utils
{
    internal static class Parser
    {
        internal static (string, string, string, string, int?) Parse(string url)
        {
            var normalizedUrl = url.Trim();
            return normalizedUrl.StartsWith("/") ? ParseUnixSocket(normalizedUrl) : ParsePostgresUrl(normalizedUrl);
        }

        private static (string, string, string, string, int?) ParseUnixSocket(string socket)
        {
            var parts = socket.Split(new[]
            {
                ' '
            }, 2);
            return (parts[0], null, null, parts[1], null);
        }

        private static (string, string, string, string, int?) ParsePostgresUrl(string url)
        {
            var uri = new Uri(url);

            var databasePath = uri.AbsolutePath;
            var auth = uri.UserInfo ?? ":";
            var authParts = auth.Split(new[]
            {
                ':'
            }, 2);

            var host = uri.Host;
            var port = uri.Port;
            var user = authParts[0];
            var password = authParts[1];
            var databaseName = databasePath?.Trim('/');

            return (host, user, password, databaseName, port);
        }
    }
}