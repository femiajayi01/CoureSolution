using System.Collections.Generic;
using CoureAPI.Models;

namespace CoureAPI.Interfaces
{
    public interface ICoure
    {
        
        IEnumerable<CountryDetail> GetCountryDetailByCountryCode(string countryCode);

        Country GetCountry(string countryCode);

        IEnumerable<CountryDetail> GetCountryDetailsById(int id);
    }
}
