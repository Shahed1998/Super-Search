using SolrNet.Attributes;

namespace Api.Models
{
    public class SolrCountry
    {
        [SolrUniqueKey("id")]
        public string? Id { get; set; }
        [SolrUniqueKey("CountryName")]
        public string? CountryName { get; set; }
        [SolrUniqueKey("score")]
        public double? Score { get; set; }
    }
}
