using FluentAssertions;
using Xunit;

namespace PostgresConnString.NET.Tests
{
    public class ExportTests
    {
        [Fact]
        public void ShouldGenerateNpgsqlConnectionStringWithDefaultValues()
        {
            var details = new ConnectionDetails();
            var connection = details.ToNpgsqlConnectionString();

            connection
                .Should()
                .Be(
                    "User ID=;Password=;Server=;Port=5432;Database=;Pooling=true;SSL Mode=Prefer;Trust Server Certificate=true");
        }

        [Fact]
        public void ShouldGenerateNpgsqlConnectionStringWithSpecifiedValues()
        {
            var host = "localhost";
            var user = "user";
            var password = "password";
            var port = 3310;
            var database = "database";

            var details = new ConnectionDetails(host, user, password, database, port);
            var connection = details.ToNpgsqlConnectionString();

            connection
                .Should()
                .Be(
                    $"User ID={user};Password={password};Server={host};Port={port};Database={database};Pooling=true;SSL Mode=Prefer;Trust Server Certificate=true");
        }
    }
}