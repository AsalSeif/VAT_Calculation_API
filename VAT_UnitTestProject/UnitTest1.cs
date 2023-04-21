using CommonException;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TaxCalculator;
using CommonException;
using TaxCalculator.Model.Enums;
using ServiceContracts;

namespace VAT_UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CalculateBaseOnGrossValue_TaxRateIsNotValidForCountry_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
            
            try
            {
                countryTaxCalculator.CalculateBaseOn_GrossValue(3,100);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.TaxRateIsNotValid);
            }
            
        }
        [TestMethod]
        public void CalculateBaseOnNetValue_TaxRateIsNotValidForCountry_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
            
            try
            {
                countryTaxCalculator.CalculateBaseOn_NetValue(3,100);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.TaxRateIsNotValid);
            }
            
        }
        [TestMethod]
        public void CalculateBaseOnVATValue_TaxRateIsNotValidForCountry_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
           
            try
            {
                countryTaxCalculator.CalculateBaseOn_VATValue(3,100);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.TaxRateIsNotValid);
            }
            
        }
        [TestMethod]
        public void CalculateBaseOnGrossValue_GrossValueIsZero_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
            
            try
            {
                countryTaxCalculator.CalculateBaseOn_GrossValue(5,0);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.CalculationBaseValueIsNotValid);
            }
            
        }
        [TestMethod]
        public void CalculateBaseOnNetValue_GrossValueIsZero_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);

            try
            {
                countryTaxCalculator.CalculateBaseOn_NetValue(5,0);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.CalculationBaseValueIsNotValid);
            }
            
        }
        [TestMethod]
        public void CalculateBaseOnVATValue_GrossValueIsZero_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);

            try
            {
                countryTaxCalculator.CalculateBaseOn_VATValue(5,0);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.CalculationBaseValueIsNotValid);
            }
            
        }
        [TestMethod]
        public void CalculateBaseOnGrossValue_CalculationCorrection_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
           
            var result=countryTaxCalculator.CalculateBaseOn_GrossValue(5,105);
            Assert.IsTrue(result.Net == 100);
            Assert.IsTrue(result.VAT == 5);

        }
        [TestMethod]
        public void CalculateBaseOnVATValue_CalculationCorrection_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
            
            var result=countryTaxCalculator.CalculateBaseOn_VATValue(5,5);
            Assert.IsTrue(result.Net == 100);
            Assert.IsTrue(result.Gross == 105);

        }
        [TestMethod]
        public void CalculateBaseOnNetValue_CalculationCorrection_Test()
        {
            var countryTaxCalculator = new CountryTaxCalculatorService(CountryEnum.Austria);
            
            var result=countryTaxCalculator.CalculateBaseOn_NetValue(5,100);

            #region Assertion
            Assert.IsTrue(result.VAT == 5);
            Assert.IsTrue(result.Gross == 105);
            #endregion
        }
        [TestMethod]
        public void CountryIsNotSupported_Test()
        {
            try
            {
                var countryTaxCalculator = new CountryTaxCalculatorService(0);
                Assert.Fail("no exception thrown");
            }
            catch (BusinessException ex)
            {
                #region Assertion
                Assert.IsTrue(ex.BussinesExceptionCode == TaxCalculationBusinessExceptionEnum.CountryIsNotSupported);
                
                #endregion
            }
           

            
        }
    }
}
