using System;
using System.Collections.Generic;

public class UK_TaxCalculator : BaseTaxCalculator
{
    public override CountryEnum Country => CountryEnum.United_Kingdom;

    public override List<double> TaxRates => new List<double> { 5,20 };
}
