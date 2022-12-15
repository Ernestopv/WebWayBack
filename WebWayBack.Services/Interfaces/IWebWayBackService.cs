using WebWayBack.Models;

namespace WebWayBack.Services.Interfaces
{
    public interface IWebWayBackService
    {
        Task<Response> GetOldestWebsiteUrlAsync(string website);
    }
}
