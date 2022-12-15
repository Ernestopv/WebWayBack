using FluentAssertions;
using NSubstitute;
using WebWayBack.ExternalServices.Interfaces;
using WebWayBack.Models;
using WebWayBack.Services.Implementations;
using Xunit;

namespace WebWayBack.Services.Tests.Implementations
{
    public class WebWayBackServiceTests
    {
        private readonly IExternalService _externalService;
        private readonly WebWayBackService _sut;
        public WebWayBackServiceTests()
        {
            _externalService = Substitute.For<IExternalService>();
            _sut = new WebWayBackService(_externalService);
        }

        [Fact]
        public async Task TestGetOldestWebsiteUrlWhenWebArchiveList_IsZero()
        {
            //Arrange
            var webSite = "www.example.com";
            var expectedResult = new Response();
            _externalService.GetHistoricWebArchivesAsync(Arg.Any<string>()).Returns(new List<List<string>>());

            //Act
            var result =  await _sut.GetOldestWebsiteUrlAsync(webSite);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
            result.Available.Should().Be(false);

        }

        [Fact]
        public async Task TestGetOldestWebsiteUrlWhenWebArchiveList_TimeStamp_isNull()
        {
            //Arrange
            var webSite = "www.example.com";
            var expectedResult = new Response();
            var webArchiveList = new List<List<string>>()
            {
                new()
                {  "urlkey",
                    "timestamp",
                    "original",
                    "mimetype",
                    "statuscode",
                    "digest",
                    "length"
                }
            };
            _externalService.GetHistoricWebArchivesAsync(Arg.Any<string>()).Returns(webArchiveList);

            //Act
            var result = await _sut.GetOldestWebsiteUrlAsync(webSite);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
            result.Available.Should().Be(false);

        }

        [Fact]
        public async Task TestGetOldestWebsiteUrlWhen_OldWebsite_isNull()
        {
            //Arrange
            var webSite = "www.example.com";
            var expectedResult = new Response();
            var webArchiveList = new List<List<string>>()
            {
                new()
                {  "urlkey",
                    "timestamp",
                    "original",
                    "mimetype",
                    "statuscode",
                    "digest",
                    "length"
                },
                new()
                {
                    "com,thefacebook)/",
                    "20040212031928",
                    "http://www.thefacebook.com:80/",
                    "text/html",
                    "200",
                    "BRCE3MHJKWB42YWG5MQ62QYXXZM57AMR",
                    "2246"

                }
            };
            _externalService.GetHistoricWebArchivesAsync(Arg.Any<string>()).Returns(webArchiveList);
            await _externalService.GetOldWebsiteAsync(Arg.Any<string>(), Arg.Any<string>());

            //Act
            var result = await _sut.GetOldestWebsiteUrlAsync(webSite);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
            result.Available.Should().Be(false);

        }


        [Fact]
        public async Task TestGetOldestWebsiteUrl_OK()
        {
            //Arrange
            var webSite = "www.example.com";
            var expectedResult = new Response()
            {
                Available = true,
                TimeStamp = "Thursday, February 12, 2004",
                WebsiteUrl = "http://web.archive.org/web/20070107012955/http://www.facebook.com:80/"
            };
            var webArchiveList = new List<List<string>>()
            {
                new()
                {  "urlkey",
                    "timestamp",
                    "original",
                    "mimetype",
                    "statuscode",
                    "digest",
                    "length"
                },
                new()
                {
                    "com,thefacebook)/",
                    "20040212031928",
                    "http://www.thefacebook.com:80/",
                    "text/html",
                    "200",
                    "BRCE3MHJKWB42YWG5MQ62QYXXZM57AMR",
                    "2246"
                }
            };

            var externalResponse = new ExternalResponse()
            {
                Archived_snapshots = new Archived_Snapshots()
                {
                    Closest = new Closest()
                    {
                        Url = "http://web.archive.org/web/20070107012955/http://www.facebook.com:80/",
                        Available = "true",
                        TimeStamp = "20070107012955",
                        Status = "200",
                    }
                },
                Url = "www.facebook.com"
            };
            _externalService.GetHistoricWebArchivesAsync(Arg.Any<string>()).Returns(webArchiveList);
            _externalService.GetOldWebsiteAsync(Arg.Any<string>(), Arg.Any<string>()).Returns(externalResponse);

            //Act
            var result = await _sut.GetOldestWebsiteUrlAsync(webSite);

            //Assert
            result.Should().BeEquivalentTo(expectedResult);
            result.Available.Should().Be(true);
            result.TimeStamp.Should().Be("Thursday, February 12, 2004");
        }
    }
}
