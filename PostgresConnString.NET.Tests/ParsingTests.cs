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
    }
}