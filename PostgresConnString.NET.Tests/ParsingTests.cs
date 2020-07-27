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

        [Fact]
        public void ShouldParsePostgresUrlStringWithoutAuthInfo()
        {
            var details = ConnectionDetails.Parse("postgres://@somehost:381/somedatabase");

            details
                .Should()
                .NotBeNull();
            details.Database
                .Should()
                .Be("somedatabase");
            details.User
                .Should()
                .BeEmpty();
            details.Password
                .Should()
                .BeEmpty();
            details.Host
                .Should()
                .Be("somehost");
            details.Port
                .Should()
                .Be(381);
        }

        [Fact]
        public void ShouldParsePostgresUrlStringWithoutPort()
        {
            var details = ConnectionDetails.Parse("postgres://someuser:somepassword@localhost/somedatabase");

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
                .Be("localhost");
            details.Port
                .Should()
                .Be(5432);
        }

        [Fact]
        public void ShouldParsePostgresUrlStringWithoutDatabase()
        {
            var details = ConnectionDetails.Parse("postgres://someuser:somepassword@somehost:341/");

            details
                .Should()
                .NotBeNull();
            details.Database
                .Should()
                .BeEmpty();
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
                .Be(341);
        }
    }
}