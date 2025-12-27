using SolrNet.Attributes;

namespace Api.Models
{
    public class SolrCountryResponse
    {
        public string? Id { get; set; }
        public string? CountryName { get; set; }
        public double? Score { get; set; }
        public decimal? Percent { get; set; }

    }
}
