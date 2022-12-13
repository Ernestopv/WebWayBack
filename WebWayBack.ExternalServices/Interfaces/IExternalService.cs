using WebWayBack.Models;

namespace WebWayBack.ExternalServices.Interfaces
{
    public interface IExternalService
    {
        Task<List<List<string>>?> GetHistoricWebArchives(string website);

        Task<ExternalResponse?> GetOldWebsite(string website, string timestamp);

        Task<bool> CheckExternalServiceConnectionAsync(CancellationToken cancellationToken = default);
    }
}
