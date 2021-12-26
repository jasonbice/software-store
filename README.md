# Software Store

The store is implemented as a single page application using 
[.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) and [Angular 12](https://angular.io/). The 
backend uses a static datastore implemented as `SoftwareStore.Core.SoftwareRepository`. The frontend 
manages state via [NgRx](https://ngrx.io/).

The backend supports paged results, though the frontend does not yet implement pagination.

## Solution Structure

- `SoftwareStore.Core`
  - Houses business logic and business-layer services, as well as the static `Software` data.
- `SoftwareStore.SharedKernel`
  - A library that is intended to be shared throughout the solution. Utility classes, abstractions, etc., are placed here.
- `SoftwareStore.Tests`
  - The test project for the rest of the solution, structured as `SoftwareStore.Tests.[Project].[ProjectFolder(s)]`.
  - The included tests are non-exhaustive and provide only critical coverage.
- `SoftwareStore.Web`
  - The .NET 5 REST API to be consumed by the frontend, which exposes the following endpoints:
    - `GET /software`
  - The Angular 12 project, housed within the `ClientApp` folder.

## Running the Application

The frontend is hardcoded to access the API at `http://localhost:5000`. Specifically, this access is defined 
at `/Web/ClientApp/src/app/shared/services/software.service.ts:14`. Ideally this would be from an 
environment variables file (.env).

### Prerequisites

- npm 
  - This solution was created with [npm 6.14.15](https://www.npmjs.com/package/npm/v/6.14.15).
- Angular 12
- .NET 5

### Steps

1. Open a terminal session in `/SoftwareStore/Web/ClientApp`.
2. Run `npm install`.
3. Move to `/Software/Web`.
4. Run `dotnet run`.
5. Navigate a browser to `https://localhost:5002/`.