using WebWayBack.Models;

namespace WebWayBack.ExternalServices.Interfaces
{
    public interface IExternalService
    {
        Task<List<List<string>>?> GetHistoricWebArchivesAsync(string website);

        Task<ExternalResponse?> GetOldWebsiteAsync(string website, string? timestamp);

        Task<bool> CheckExternalServiceConnectionAsync(CancellationToken cancellationToken = default);
    }
}
