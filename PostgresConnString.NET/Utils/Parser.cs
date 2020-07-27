using System;

namespace PostgresConnString.NET.Utils
{
    internal static class Parser
    {
        internal static (string, string, string, string, int?) Parse(string url)
        {
            var normalizedUrl = url.Trim();

            if (normalizedUrl.StartsWith("/"))
            {
                return ParseUnixSocket(normalizedUrl);
            }
        }

        private static (string, string, string, string, int?) ParseUnixSocket(string socket)
        {
            var parts = socket.Split(' ');
            return (parts[0], null, null, parts[1], null);
        }
    }
}