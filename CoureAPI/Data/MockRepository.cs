using System.Collections.Generic;
using System.Linq;
using CoureAPI.Data;
using CoureAPI.Interfaces;
using CoureAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoureAPI.Data
{
    public class MockRepository : ICoure
    {
        private readonly Context _context;
        public MockRepository(Context context)
        {
            _context = context;
        }

        public Country GetCountry(string countryCode)
        {
            return _context.Countries.FirstOrDefault(x => x.CountryCode == countryCode);
        }

        public IEnumerable<CountryDetail> GetCountryDetailsById(int id)
        {
            return _context.CountryDetails.Where(x => x.Country.Id == id).ToList();

        }


        public IEnumerable<CountryDetail> GetCountryDetailByCountryCode(string countryCode)
        {
            return _context.CountryDetails.Include(x => x.Country).ToList()
                .Where(x => x.Country.CountryCode == countryCode).ToList();
        }

    }
}
