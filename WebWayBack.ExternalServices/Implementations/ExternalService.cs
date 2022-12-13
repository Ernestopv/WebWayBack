using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebWayBack.ExternalServices.Interfaces;
using WebWayBack.Infrastructure.Settings;
using WebWayBack.Models;

namespace WebWayBack.ExternalServices.Implementations
{
    public class ExternalService: IExternalService
    {
        private readonly HttpClient _httpClient = new();

        private readonly int _currentYear;

        private const int BirthWebYear = 1991;

        private readonly AppSettings _appSettings;

        public ExternalService(IConfiguration configuration)
        {
            _appSettings = configuration.Get<AppSettings>()!;
            _currentYear = DateTime.UtcNow.Year;
         
        }


        /// <summary>
        /// Get web archive 
        /// </summary>
        /// <param name="website"></param>
        /// <returns></returns>
        public async Task<List<List<string>>?> GetHistoricWebArchives(string website)
        {
            var searchUrl = $"{_appSettings.BaseUrl}/cdx/search/cdx?url={website}&from={BirthWebYear}&to={_currentYear}&limit=1&output=json";

            var response = await _httpClient.GetAsync(searchUrl);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var webArchives = JsonConvert.DeserializeObject<List<List<string>>>(responseString);

            return webArchives;
        }


        /// <summary>
        /// Get old website
        /// </summary>
        /// <param name="website"></param>
        /// <param name="timestamp"></param>
        /// <returns></returns>
        public async Task<ExternalResponse?> GetOldWebsite(string website, string timestamp)
        {
            var getOldWebsite = $"{_appSettings.BaseUrl}/wayback/available?url={website}&timestamp={timestamp}";

            var response = await _httpClient.GetAsync(getOldWebsite);

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var oldWebsiteDetails = JsonConvert.DeserializeObject<ExternalResponse>(responseString);

            return oldWebsiteDetails;
        }

        public async Task<bool> CheckExternalServiceConnectionAsync(CancellationToken cancellationToken = default)
        {
            var response = await  _httpClient.GetAsync(_appSettings.BaseUrl);

            return response.IsSuccessStatusCode;
        }
    }
}
