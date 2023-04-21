using CommonException;
using System;
using System.Collections.Generic;
using ServiceContracts;
using TaxCalculator.Model.Enums;

public abstract class BaseTaxCalculator
{
    private readonly double MIN_VALID_BASE_VALUE=0.0;

    public abstract CountryEnum Country { get; }
	public abstract List<double> TaxRates { get; }
	private void CheckTaxRateValidation(double taxRate)
	{
		if (!TaxRates.Contains(taxRate)) throw new BusinessException($"Tax Rate is not valid for {Enum.GetName(typeof(CountryEnum), Country)}",TaxCalculationBusinessExceptionEnum.TaxRateIsNotValid);
	}

	public virtual TaxCalculationValuesDto CalculateBaseOn_VATValue(double taxRate, double vatValue)
	{
		if (ValidateParameters(taxRate, vatValue))
		{
			var netValue = vatValue / ( taxRate / 100);
			var grossValue = netValue + vatValue;
			return new TaxCalculationValuesDto
			{
				Net = netValue,
				VAT = vatValue,
				Gross = grossValue,
			};
		}
		return new TaxCalculationValuesDto();
	}

    public virtual TaxCalculationValuesDto CalculateBaseOn_GrossValue(double taxRate, double grossValue)
	{
		if (ValidateParameters(taxRate, grossValue))
		{
			var netValue = grossValue / (1 + taxRate / 100);
			var vatValue = grossValue - netValue;
			return new TaxCalculationValuesDto
			{
				Net = netValue,
				VAT = vatValue,
				Gross = grossValue,
			};
		}
		return new TaxCalculationValuesDto();
    }

    private bool ValidateParameters(double taxRate, double baseCalculationValue)
    {
        CheckTaxRateValidation(taxRate);
        CheckBaseValueValidation(baseCalculationValue);
		return true;
    }

    private void CheckBaseValueValidation(double baseValue)
    {
		if (baseValue <= MIN_VALID_BASE_VALUE) throw new BusinessException(TaxCalculationBusinessExceptionEnum.CalculationBaseValueIsNotValid);
    }

    public virtual TaxCalculationValuesDto CalculateBaseOn_NetValue(double taxRate,double netValue )
	{
		if (ValidateParameters(taxRate, netValue))
		{
			var vatValue = netValue * taxRate / 100;
			var grossValue = netValue + vatValue;
			return new TaxCalculationValuesDto
			{
				Net = netValue,
				VAT = vatValue,
				Gross = grossValue,
			};
			
		}
		return new TaxCalculationValuesDto();
	}
	
}
 