using System;
using System.Collections.Generic;

public class Portugal_TaxCalculator:BaseTaxCalculator
{
    public override CountryEnum Country =>CountryEnum.Portugal;

    public override List<double> TaxRates => new List<double> { 6, 13, 23 };
}
