using System.Collections.Generic;
using System.Linq;
using CoureAPI.Data;
using CoureAPI.Interfaces;
using CoureAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICoure _repository;
        public CountryController(ICoure repository)
        {
            _repository = repository;
        }


        // Eager Loading

        // GET: api/CountryDetails/phoneNumber
        [HttpGet]
        [Route("CountryDetails/{phoneNumber}")]
        public IActionResult CountryDetails(string phoneNumber)
        {
            var countryCode = phoneNumber.Substring(0, 3);

            var countryDetails = _repository.GetCountryDetailByCountryCode(countryCode).ToList();

            if (countryDetails.Count == 0)
            {
                return NotFound();
            }
            
            var country = countryDetails.FirstOrDefault()?.Country;
            var result = new
            {
                number = phoneNumber,
                country = new 
                {
                    countryCode,
                    name = country?.Name,
                    countryIso = country?.CountryIso,
                    countryDetails = countryDetails.Select(x=> new Dictionary<string,string>()
                    {
                       ["operator"] = x.Operator,
                       ["operatorCode"] = x.OperatorCode
                    })
                }
            };
            return Ok(result);

        }

        // Lazy loading

        // GET: api/CountryDetails/phoneNumber
        [HttpGet]
        [Route("CountryDetailssss/{phoneNumber}")]
        public IActionResult CountryDetailssss(string phoneNumber)
        {
            var countryCode = phoneNumber.Substring(0, 3);

            var country = _repository.GetCountry(countryCode);


            var countryDetails = _repository.GetCountryDetailsById(country.Id).ToList();

            if (countryDetails.Count == 0)
            {
                return NotFound();
            }

            var result = new
            {
                number = phoneNumber,
                country = new
                {
                    countryCode,
                    name = country?.Name,
                    countryIso = country?.CountryIso,
                    countryDetails = countryDetails.Select(x => new Dictionary<string, string>()
                    {
                        ["operator"] = x.Operator,
                        ["operatorCode"] = x.OperatorCode
                    })
                }
            };
            return Ok(result);

        }



    }
}
