using Api.Models;
using Api.Repos;
using SolrNet;
using SolrNet.Commands.Parameters;

namespace Api.Services.SolrServices
{
    public class CountrySearchService : ICountrySearchService
    {
        private readonly ISolrOperations<SolrCountry> _solr;
        private readonly ICountryRepo _country;

        public CountrySearchService(ISolrOperations<SolrCountry> solr, ICountryRepo countryRepo)
        {
            _solr = solr;
            _country = countryRepo;
        }

        public void MigrateDataFromDB()
        {
            try
            {
                var totalCountries = _country.Total();
                var batchSize = 1000;
                var totalBatches = Math.Ceiling((double)totalCountries / batchSize);

                for (var batch = 0; batch <= totalBatches; batch++)
                {
                    var countryList = _country.GetAll(batch * batchSize, batchSize).Select(x => new SolrCountry() { Id = x.Id.ToString(), CountryName = x.Name});
                    _solr.AddRange(countryList);
                }

                _solr.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<SolrCountryResponse>> Search(string query)
        {
            var options = new QueryOptions
            {
                Rows = 10,
                ExtraParams = new Dictionary<string, string>
                {
                    { "defType", "edismax" },
                    { "qf", "CountryName" },
                    { "fl", "*,score" }
                }
            };

            var fuzzyQuery = query.EndsWith("~") ? query : query + "~";

            var solrQuery = new SolrQuery(fuzzyQuery);

            var results = await _solr.QueryAsync(solrQuery, options);

            double maxScore = results.Max(r => r.Score) ?? 1;

            var response = results.Select(r => new SolrCountryResponse
            {
                Id = r.Id,
                CountryName = r.CountryName,
                Score = r.Score,
                Percent = (decimal)Math.Round((double)(r.Score ?? 0)  / (double)maxScore * 100, 1)
            }).ToList();


            return response;
        }
    }
}
