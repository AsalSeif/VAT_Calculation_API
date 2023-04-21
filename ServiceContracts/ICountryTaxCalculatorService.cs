using System;
using System.Collections.Generic;

namespace ServiceContracts
{
    public interface ICountryTaxCalculatorService
    {
        List<double> GetTaxRates();
        TaxCalculationValuesDto CalculateBaseOn_VATValue(double taxRate, double vatValue);
        TaxCalculationValuesDto CalculateBaseOn_GrossValue(double taxRate, double grossValue);
        TaxCalculationValuesDto CalculateBaseOn_NetValue(double taxRate, double netValue);
        
    }
}
