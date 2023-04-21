using CommonException;
using System;
using System.Collections.Generic;
using System.Text;
using TaxCalculator.Model.Enums;
using ServiceContracts;

namespace TaxCalculator
{
    public class CountryTaxCalculatorService: ICountryTaxCalculatorService
    {
        
        public CountryTaxCalculatorService(CountryEnum country)
        {
            switch(country)
            {
                case CountryEnum.Austria:
                    TaxCalculator = new Austria_TaxCalculator();
                    break;
                case CountryEnum.United_Kingdom:
                    TaxCalculator = new UK_TaxCalculator();
                    break;
                case CountryEnum.Singapore:
                    TaxCalculator = new Singapore_TaxCalculator();
                    break;
                case CountryEnum.Portugal:
                    TaxCalculator = new Portugal_TaxCalculator();
                    break;
                default:
                    throw new BusinessException(TaxCalculationBusinessExceptionEnum.CountryIsNotSupported);
            }
        }
        BaseTaxCalculator TaxCalculator { get; set; }
        public List<double> GetTaxRates()
        {
            return TaxCalculator.TaxRates;
        }
        public TaxCalculationValuesDto CalculateBaseOn_VATValue(double taxRate, double vatValue)
        {
            return TaxCalculator.CalculateBaseOn_VATValue(taxRate,vatValue);
        }
        public TaxCalculationValuesDto CalculateBaseOn_GrossValue(double taxRate, double grossValue)
        {
           return TaxCalculator.CalculateBaseOn_GrossValue(taxRate,grossValue);
        }
        public TaxCalculationValuesDto CalculateBaseOn_NetValue(double taxRate, double netValue)
        {
            return TaxCalculator.CalculateBaseOn_NetValue(taxRate,netValue);
        }
    }
}
