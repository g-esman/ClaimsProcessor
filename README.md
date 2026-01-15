# Claims Processor API

### Overview
This project is a small API for validating healthcare claims and providing summary reports.

### Stack
- .NET 8
- ASP.NET Core Web API
- xUnit for testing
- Swagger for API documentation

### Endpoints
- `POST /claims/validate`: Accepts a list of claims and returns a summary report.
- `GET /swagger`: API documentation and testing interface.

### How to Run
``bash
dotnet build
dotnet run --project src/ClaimsProcessor.Api/ClaimsProcessor.Api.csproj
API will be available at http://localhost:5052

### How to Test
``bash
dotnet test

### Architecture layers and decisions
- API: Handle HTTP requests and responses. Also provides exception handling.
	   The mappings were intentionally implemented manually to avoid using licensed libraries such as AutoMapper.
	   If the application grows and justifies it, the manual mappings could be replaced by such a library.

- Application: Orchestrates the business logic and generates the summary report.

- Domain: Contains the core business entities and validation logic.

### Example Request
curl -X POST http://localhost:5052/claims/validate \
-H "Content-Type: application/json" \
-d '[{"Id":1,"Provider":"ClinicA","Amount":100.5,"DiagnosisCode":"A01","Status":"Approved"}]'

### Example Response
{
"totalClaims": 1,
"validClaims": 1,
"invalidClaims": 0,
"totalApprovedAmount": 100.5
}
