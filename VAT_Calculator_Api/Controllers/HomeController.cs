using CommonExtension;
using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VAT_Calculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
       
        ICountryTaxServiceFactory _TaxServiceFactory;

        public HomeController(ICountryTaxServiceFactory taxServiceFactory)
        {
            _TaxServiceFactory = taxServiceFactory;
        }
        [HttpGet]
        public string Get() => ":(";
        // GET: api/<VatCalculatorController>
        [HttpGet]
        [Route("Countries/all")]
        public List<EnumValue> Get_Countries() => EnumExtension.GetValues<CountryEnum>();

        // GET api/<VatCalculatorController>/5
        [HttpGet("{id}")]
        [Route("TaxRates/{id}")]
        public List<double> Get_VAT_Rates(int id)
        {
            return _TaxServiceFactory.CreateCountryTaxService((CountryEnum)id).GetTaxRates();
        }


        [HttpGet]
        [Route("TaxBaseOnVat/{countryId}/{taxRate}/{vatValue}")]
        public string CalculateBaseOnVAT(int countryId, double taxRate, double vatValue)
        {
           
            var taxCalculatorService = _TaxServiceFactory.CreateCountryTaxService((CountryEnum)countryId);
            var taxCalculationValues=taxCalculatorService.CalculateBaseOn_VATValue(taxRate,vatValue);
            return taxCalculationValues.ToJson();
        }
        [HttpGet]
        [Route("TaxBaseOnNet/{countryId}/{taxRate}/{netValue}")]
        public string CalculateBaseOnNet(int countryId, double taxRate, double netValue)
        {
           var taxCalculatorService = _TaxServiceFactory.CreateCountryTaxService((CountryEnum)countryId);
            var taxCalculationValues = taxCalculatorService.CalculateBaseOn_NetValue(taxRate,netValue);
            return taxCalculationValues.ToJson();
        }
        [HttpGet]
        [Route("TaxBaseOnGross/{countryId}/{taxRate}/{grossValue}")]
        public string CalculateBaseOnGross(int countryId, double taxRate, double grossValue)
        {
            var taxCalculatorService = _TaxServiceFactory.CreateCountryTaxService((CountryEnum)countryId);
            var taxCalculationValues=taxCalculatorService.CalculateBaseOn_GrossValue(taxRate,grossValue);
            return taxCalculationValues.ToJson();

        }
    }
}
