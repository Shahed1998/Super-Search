using Api.Models;

namespace Api.Services.SolrServices
{
    public interface ICountrySearchService
    {
        Task<List<SolrCountryResponse>> Search(string query);
        void MigrateDataFromDB();
    }
}
