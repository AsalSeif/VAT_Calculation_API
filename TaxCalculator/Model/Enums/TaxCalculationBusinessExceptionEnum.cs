using CommonException;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaxCalculator.Model.Enums
{
    public class TaxCalculationBusinessExceptionEnum:BusinessEnum
    {
        protected TaxCalculationBusinessExceptionEnum(int internalValue) : base(internalValue)
        {

        }
        public static readonly BusinessEnum TaxRateIsNotValid = new BusinessEnum(100,"Tax Rate is not valid.");
        public static readonly BusinessEnum CalculationBaseValueIsNotValid = new BusinessEnum(101,"Price or VAT value is Zero or Negative!!!");
        public static readonly BusinessEnum CountryIsNotSupported = new BusinessEnum(102, "Country is not supported!!!");

    }
}
