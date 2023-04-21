using System;
using System.Collections.Generic;
using System.Text;
using ServiceContracts;
namespace TaxCalculator.Services
{
    public class CountryTaxServiceFactory : ICountryTaxServiceFactory
    {
        public ICountryTaxCalculatorService CreateCountryTaxService(CountryEnum country)
        {
            return new CountryTaxCalculatorService(country);
        }
    }
}
