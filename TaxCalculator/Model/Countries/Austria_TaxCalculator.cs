using System;
using System.Collections.Generic;

public class Austria_TaxCalculator : BaseTaxCalculator
{
    public override CountryEnum Country => CountryEnum.Austria;

    public override List<double> TaxRates => new List<double> { 5, 10, 13, 20 };
}
