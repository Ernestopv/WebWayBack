using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using WebWayBack.Api.Controllers;
using WebWayBack.Models;
using WebWayBack.Services.Interfaces;
using Xunit;

namespace WebWayBack.Api.Tests.Implementations
{
    public class SearchControllerTests
    {
        private readonly IWebWayBackService _webWayBackService;

        private readonly SearchController _sut;

        public SearchControllerTests()
        {
            _webWayBackService = Substitute.For<IWebWayBackService>();
            _sut = new SearchController(_webWayBackService);
        }

        [Fact]
        public async Task Test_GetOldestWebsiteAsync_Ok()
        {
            var requestPayload = new Request()
            {
                UrlWebsite = "http://web.archive.org/web/20070107012955/http://www.facebook.com:80/"
            };
            //Arrange
            var response = new Response()
            {
                TimeStamp = "20070107012955",
                Available = true,
                WebsiteUrl = "http://web.archive.org/web/20070107012955/http://www.facebook.com:80/"
            };

            _webWayBackService.GetOldestWebsiteUrlAsync(Arg.Any<string>()).Returns(Task.FromResult(response));
            //Act

            var actionResult = await _sut.GetOldestWebsiteAsync(requestPayload);
            var okObjectResult = actionResult as OkObjectResult;

            var result = okObjectResult!.Value as Response;
            //Assert

            Assert.NotNull(okObjectResult);
            Assert.NotNull(result);
            result.Should().BeEquivalentTo(response);
        }
    }
}
