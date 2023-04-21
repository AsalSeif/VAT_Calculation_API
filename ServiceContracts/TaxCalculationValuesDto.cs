using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceContracts
{
    public class TaxCalculationValuesDto
    {
       public double TaxRate { set; get; }
        public double VAT { set; get; }
        public double Gross { set; get; }
        public double Net { set; get; }

    }
}
