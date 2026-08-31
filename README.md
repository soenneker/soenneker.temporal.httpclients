[![](https://img.shields.io/nuget/v/soenneker.temporal.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.temporal.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.temporal.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.temporal.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.temporal.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.temporal.httpclients/actions/workflows/codeql.yml)
[![](https://img.shields.io/nuget/dt/soenneker.temporal.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.temporal.httpclients/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Temporal.HttpClients
Provides a cached, authenticated `HttpClient` for Temporal's HTTP API.

## Installation

```bash
dotnet add package Soenneker.Temporal.HttpClients
```

## Configuration

```json
{
  "Temporal": {
    "ClientBaseUrl": "https://your-namespace.your-account.tmprl.cloud/",
    "ApiKey": "your-api-key"
  }
}
```

Requests use `Authorization: Bearer {token}` by default. Override `Temporal:AuthHeaderName` or `Temporal:AuthHeaderValueTemplate` when the endpoint uses a different authentication scheme; `{token}` in the value template is replaced with `Temporal:ApiKey`.

## Registration

```csharp
using Soenneker.Temporal.HttpClients.Registrars;

services.AddTemporalOpenApiHttpClientAsSingleton();
```

Use `AddTemporalOpenApiHttpClientAsScoped()` when the wrapper should follow the current scope. Each wrapper owns its cached client entry and removes that client when disposed.

## Usage

```csharp
using Soenneker.Temporal.HttpClients.Abstract;

public sealed class TemporalService
{
    private readonly ITemporalOpenApiHttpClient _temporalHttpClient;

    public TemporalService(ITemporalOpenApiHttpClient temporalHttpClient)
    {
        _temporalHttpClient = temporalHttpClient;
    }

    public async Task<HttpResponseMessage> GetSystemInfo(CancellationToken cancellationToken)
    {
        HttpClient client = await _temporalHttpClient.Get(cancellationToken);
        return await client.GetAsync("api/v1/system-info", cancellationToken);
    }
}
```

Reuse the returned client. Do not dispose it directly; the wrapper owns its cached client entry.
