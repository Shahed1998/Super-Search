using Api.Repos;
using Api.Services.SolrServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Api.Controllers
{
    [Route("api/Solr/[controller]")]
    [ApiController]
    public class CountrySearchController : ControllerBase
    {
        private readonly ICountrySearchService _solr;
        public CountrySearchController(ICountrySearchService solr)
        {
            _solr = solr;
        }

        [HttpGet]
        public async Task<IActionResult> GetData(string countryName)
        {

            if (string.IsNullOrWhiteSpace(countryName))
                return BadRequest("Country Name cannot be empty.");

            var results = await _solr.Search(countryName);
            return Ok(results);
        }

        [HttpPost]
        public ActionResult MigrateCountryFromDB()
        {
            _solr.MigrateDataFromDB();
            return Ok();
        }
    }
}
