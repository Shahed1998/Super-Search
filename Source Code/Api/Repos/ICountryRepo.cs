using Api.Models;

namespace Api.Repos
{
    public interface ICountryRepo 
    {
        int Total();
        List<Country> GetAll(int skip, int batchSize);
    }
}
