# VAT_Calculation_API
This is a .net core web api that is designed to calculate VAT on your purchases. Currently, basic information is available for 4 countries: Austria, Singapore, United Kingdom and Portugal.
calculation base on VAT, Price without VAT and Price with VAT is possible.

## Getting Started

Clone the repository.
```shell
git clone https://github.com/AsalSeif/VAT_Calculation_Api.git
```
* Run npm install to install all dependencies
### Web API

1. Install latest [.NET core](https://www.microsoft.com/net/core). 
If latest is incompatible with the current version of .net core for this project (2.0)
download .NET core SDK 2.0 from [release archives](https://github.com/dotnet/core/blob/master/release-notes/download-archives/2.0.0-download.md).

2. Restore and run the web api
```shell
cd VAT_CALC/VAT_Api
dotnet restore
dotnet run
```

3. Navigate to http://localhost:5000/api.

4. To test running scripts locally go to `resources` folder and edit `template-settings.json` with custom configuration and local paths to the scripts that the api will run.

Check section [deployment](#deployment) on how to setup the project in production.

### API Endpoints
| HTTP Verbs | Endpoints | Action |
| --- | --- | --- |
| GET | /api/Home/Countries/all | To get list of supported countries |
| GET | /api/Home/TaxRates/{id} | To get allowded tax rate in the specific country |
| GET | /api/Home/TaxBaseOnVat/{countryId}/{taxRate}/{vatValue} | To calculate net and gross amount base on valued-added amount and taxRate |
| GET | /api/Home/TaxBaseOnNet/{countryId}/{taxRate}/{netValue} | To calculate valued-added tax and gross amount base on net amount and taxRate |
| GET | /api/Home/TaxBaseOnGross/{countryId}/{taxRate}/{grossValue} | To calculate net and valued-added tax amount base ongross amount and taxRate |
