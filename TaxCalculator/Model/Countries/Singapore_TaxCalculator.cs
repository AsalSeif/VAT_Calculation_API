using System;
using System.Collections.Generic;

public class Singapore_TaxCalculator:BaseTaxCalculator
{
	public override CountryEnum Country => CountryEnum.Singapore;

    public override List<double> TaxRates => new List<double> { 7 };

}
