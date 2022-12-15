using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWayBack.Models;
using WebWayBack.Services.Interfaces;

namespace WebWayBack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IWebWayBackService _webWayBackService;
        public SearchController(IWebWayBackService webWayBackService)
        {
            _webWayBackService = webWayBackService;
        }

        [HttpPost]
        public async Task<IActionResult> GetOldestWebsiteAsync([FromBody]Request request)
        {
            var oldestWebsite = await _webWayBackService.GetOldestWebsiteUrlAsync(request!.UrlWebsite!);

            return Ok(oldestWebsite);
        }
    }
}
