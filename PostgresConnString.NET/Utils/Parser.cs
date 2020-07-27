using System;

namespace PostgresConnString.NET.Utils
{
    internal static class Parser
    {
        internal static (string, string, string, string, int?) Parse(string url)
        {
            var uri = new Uri(url);

            var databasePath = uri.AbsolutePath;
            var auth = string.IsNullOrWhiteSpace(uri.UserInfo) ? ":" : uri.UserInfo;
            var authParts = auth.Split(new[]
            {
                ':'
            }, 2);

            var host = uri.Host;
            var port = uri.Port;
            var user = authParts[0];
            var password = authParts[1];
            var databaseName = databasePath?.Trim('/');

            return (host, user, password, databaseName, port == -1 ? (int?) null : port);
        }
    }
}