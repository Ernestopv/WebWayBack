using FluentValidation;

namespace WebWayBack.Models.Validators
{
    public class RequestValidator : AbstractValidator<Request>
    {
        private string _patternWebsite =
            @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

        public RequestValidator()
        {
            RuleFor(x => x.UrlWebsite).NotEmpty();
            RuleFor(x => x.UrlWebsite).Matches(_patternWebsite);
        }
    }
}
