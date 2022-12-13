using WebWayBack.Models;

namespace WebWayBack.Services.Interfaces
{
    public interface IWebWayBackService
    {
        Task<Response> GetOldestWebsiteUrl(string website);
    }
}
