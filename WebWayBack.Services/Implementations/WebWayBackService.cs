using WebWayBack.ExternalServices.Interfaces;
using WebWayBack.Models;
using WebWayBack.Services.Interfaces;

namespace WebWayBack.Services.Implementations
{
    public class WebWayBackService:IWebWayBackService
    {
        private readonly IExternalService _externalService;
        public WebWayBackService(IExternalService externalService)
        {
            _externalService = externalService;

        }
        public async Task<Response> GetOldestWebsiteUrlAsync(string website)
        {

            var webArchives = await _externalService.GetHistoricWebArchivesAsync(website.ToLower());
            if (webArchives!.Count == 0 || webArchives.Count == 1) return new Response();
            
            var webArchive = webArchives!.Skip(1).FirstOrDefault();
            var timeStamp = webArchive!.Skip(1).FirstOrDefault();

            var oldWebsite = await _externalService.GetOldWebsiteAsync(website, timeStamp);

            if (oldWebsite == null ) return new Response();
            
            var date = GetDate(timeStamp);

            return new Response()
            {
                WebsiteUrl = oldWebsite!.Archived_snapshots!.Closest!.Url,
                TimeStamp = date,
                Available = true,
            };


        }

        private static string GetDate(string? timeStamp)
        {
            var data = long.Parse(timeStamp!);
            var year = int.Parse(data.ToString().Substring(0, 4));
            var month = int.Parse(data.ToString().Substring(4, 2));
            var day = int.Parse(data.ToString().Substring(6, 2));
            var hour = int.Parse(data.ToString().Substring(8, 2));
            var minute = int.Parse(data.ToString().Substring(10, 2));
            var second = int.Parse(data.ToString().Substring(12, 2));

            var date = new DateTime(year, month, day, hour, minute, second).ToString("D");
            return date;
        }
    }
}
