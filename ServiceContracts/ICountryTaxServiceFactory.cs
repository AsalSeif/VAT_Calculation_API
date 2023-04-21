using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public interface ICountryTaxServiceFactory
    {
        ICountryTaxCalculatorService CreateCountryTaxService(CountryEnum country);
    }
}
