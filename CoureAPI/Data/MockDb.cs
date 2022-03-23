using CoureAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CoureAPI.Data
{
    public static class MockDb
    {
        public static void Populate(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<Context>());
            }
        }

        private static void SeedData(Context context)
        {
            context.Countries.Add(new Country { Id = 1, CountryCode = "234", Name = "Nigeria", CountryIso = "NG" });
            context.Countries.Add(new Country { Id = 2, CountryCode = "233", Name = "Ghana", CountryIso = "GH" });
            context.Countries.Add(new Country { Id = 3, CountryCode = "229", Name = "Benin Republic", CountryIso = "BN" });
            context.Countries.Add(new Country { Id = 4, CountryCode = "225", Name = "Cote d'Ivoire", CountryIso = "CIV" });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 1,
                CountryId = 1,
                Operator = "MTN Nigeria",
                OperatorCode = "MTN NG"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 2,
                CountryId = 1,
                Operator = "Airtel Nigeria",
                OperatorCode = "ANG"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 3,
                CountryId = 1,
                Operator = "9 Mobile Nigeria",
                OperatorCode = "ETN"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 4,
                CountryId = 1,
                Operator = "Globacom Nigeria",
                OperatorCode = "GLO NG"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 5,
                CountryId = 2,
                Operator = "Vodafone Ghana",
                OperatorCode = "Vodafone GH"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 6,
                CountryId = 2,
                Operator = "MTN Ghana",
                OperatorCode = "MTN Ghana"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 7,
                CountryId = 2,
                Operator = "Tigo Ghana",
                OperatorCode = "Tigo Ghana"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 8,
                CountryId = 3,
                Operator = "MTN Benin",
                OperatorCode = "MTN Benin"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 9,
                CountryId = 3,
                Operator = "Moov Benin",
                OperatorCode = "Moov Benin"
            });
            context.CountryDetails.Add(new CountryDetail
            {
                Id = 10,
                CountryId = 4,
                Operator = "MTN Cote d'Ivoire",
                OperatorCode = "MTN Cote d'Ivoire"
            });
            context.SaveChangesAsync();
        }



    }
}
