using System;
using FluentAssertions;
using Xunit;

namespace PostgresConnString.NET.Tests
{
    public class ParsingTests
    {
        [Fact]
        public void ShouldThrowOnNullInput()
        {
            Action action = () => ConnectionDetails.Parse(null);
            action
                .Should()
                .ThrowExactly<ArgumentNullException>();
        }

        [Fact]
        public void ShouldThrowOnEmptyInput()
        {
            Action action = () => ConnectionDetails.Parse(string.Empty);
            action
                .Should()
                .ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void ShouldThrowOnWhitespaceInput()
        {
            Action action = () => ConnectionDetails.Parse("  \t \r \n");
            action
                .Should()
                .ThrowExactly<ArgumentException>();
        }

        [Fact]
        public void ShouldParsePostgresUrlString()
        {
            var details = ConnectionDetails.Parse("postgres://someuser:somepassword@somehost:381/somedatabase");

            details
                .Should()
                .NotBeNull();
            details.Database
                .Should()
                .Be("somedatabase");
            details.User
                .Should()
                .Be("someuser");
            details.Password
                .Should()
                .Be("somepassword");
            details.Host
                .Should()
                .Be("somehost");
            details.Port
                .Should()
                .Be(381);
        }
    }
}