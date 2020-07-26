using FluentAssertions;
using Xunit;

namespace PostgresConnString.NET.Tests
{
    public class ConnectionDetailsTests
    {
        [Fact]
        public void DefaultConstructorShouldUseDefaultValue()
        {
            var details = new ConnectionDetails();

            details
                .Should()
                .NotBeNull();
            details.Database
                .Should()
                .BeEmpty();
            details.User
                .Should()
                .BeEmpty();
            details.Password
                .Should()
                .BeEmpty();
            details.Host
                .Should()
                .BeEmpty();
            details.Port
                .Should()
                .Be(5432);
        }
        
        [Fact]
        public void OverloadConstructorShouldUseProvidedValues()
        {
            var host = "localhost";
            var user = "user";
            var password = "password";
            var port = 3310;
            var database = "database";
            
            var details = new ConnectionDetails(host, user, password, database, port);

            details
                .Should()
                .NotBeNull();
            details.Database
                .Should()
                .Be(database);
            details.User
                .Should()
                .Be(user);
            details.Password
                .Should()
                .Be(password);
            details.Host
                .Should()
                .Be(host);
            details.Port
                .Should()
                .Be(port);
        }
        
        [Fact]
        public void OverloadConstructorShouldUseDefaultValueWhenNullIsPassed()
        {
            var details = new ConnectionDetails(null, null, null, null, null);

            details
                .Should()
                .NotBeNull();
            details.Database
                .Should()
                .BeEmpty();
            details.User
                .Should()
                .BeEmpty();
            details.Password
                .Should()
                .BeEmpty();
            details.Host
                .Should()
                .BeEmpty();
            details.Port
                .Should()
                .Be(5432);
        }
    }
}