using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeDrone.Web.Core.Infrastructure.Google;
using Xunit;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace WeDrone.Test.Infrastructure
{
    public class APIClientTests
    {
        private readonly APIClient mockClient;
        private readonly APIClient client;

        public APIClientTests()
        {
            this.mockClient = new APIClient("testkey");
            this.client = new APIClient("realkey");
        }

        [Fact]
        public void GetQueryURI_ShouldReturnURIGivenValidQuery()
        {
            //Arrange
            string query = "101 Bloor Street";

            //Act
            string actual = this.mockClient.GetAddressQueryURI(query);

            //Assert
            string expected = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input=101%20Bloor%20Street&inputtype=textquery&fields=formatted_address,place_id&key=testkey";
            actual.Should().Be(expected);
        }

        [Fact]
        public void GetQueryURI_ShouldReturnURIAfterTrimmingLeadingAndTrailingSpaces()
        {
            //Arrange
            string query = " 101 Bloor Street ";

            //Act
            string actual = this.mockClient.GetAddressQueryURI(query);

            //Assert
            string expected = "https://maps.googleapis.com/maps/api/place/findplacefromtext/json?input=101%20Bloor%20Street&inputtype=textquery&fields=formatted_address,place_id&key=testkey";
            actual.Should().Be(expected);
        }

        [Fact]
        public void GetQueryURI_ShouldReturnNullGivenEmptyString()
        {
            //Arrange
            string query = "  ";

            //Act
            string actual = this.mockClient.GetAddressQueryURI(query);

            //Assert
            actual.Should().BeNull("because the query is empty");
        }

        [Fact]
        public void GetAddresses_ShouldReturnNullGivenEmptyString()
        {
            //Arrange
            string query = "  ";

            //Act
            string actual = this.mockClient.GetAddressQueryURI(query);

            //Assert
            actual.Should().BeNull("because the query is empty");
        }

        [Fact]
        public async void GetAddresses_ShouldReturnValidAddressResponse()
        {
            //Arrange
            string query = " 101 Bloor Street East ";

            //Act
            var actual = await client.GetAddress(query);

            //Assert
            //actual.candidates.First().formatted_address.Should().Be("101 Bloor St E, Oshawa, ON L1H 3M3, Canada");
        }
    }
}
