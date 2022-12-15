using FluentAssertions;
using WebWayBack.Models.Validators;
using Xunit;

namespace WebWayBack.Models.Tests.Validators
{
    public class RequestValidatorTests
    {
        private  readonly RequestValidator _validator;
        public RequestValidatorTests()
        {
            _validator = new RequestValidator();
        }


        [Fact]
        public void Test_URLWebsite_Wrong_Format_onRequest()
        {
            //Arrange
            var request = new Request()
            {
                UrlWebsite = "www"
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Test_URLWebsite_Ok_Format_onRequest()
        {
            //Arrange
            var request = new Request()
            {
                UrlWebsite = "www.faceboo.com"
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void Test_URLWebsite_Empty_Format_onRequest()
        {
            //Arrange
            var request = new Request()
            {
                UrlWebsite = ""
            };

            //Act
            var result = _validator.Validate(request);

            //Assert
            result.IsValid.Should().BeFalse();
        }
    }
}
