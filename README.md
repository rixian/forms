# VendorHub Forms Client

[![NuGet package](https://img.shields.io/nuget/v/VendorHub.Forms.svg)](https://nuget.org/packages/VendorHub.Forms)
[![codecov](https://codecov.io/gh/VendorHub/forms/branch/master/graph/badge.svg)](https://codecov.io/gh/VendorHub/forms)

## Features

* Manage forms and submissions.
* Automatic token refreshing via [Token Extensions](https://github.com/rixian/extensions-tokens)
* TLS 1.2 connection to VendorHub APIs.

## Details

This library registers an ITokenClient with the logical name `vendorhub_forms_token`, and an HttpClient with the logical name `vendorhub_forms`.

## Usage

### Basic Dependency Injection
```csharp
IServiceCollection services = ...;

string clientId = "REPLACE_ME";
string clientSecret = "REPLACE_ME";

services.AddFormsClient(clientId, clientSecret);

...

public class Foo
{
    public Foo(IFormsClient formsClient) // Injected IFormsClient
    {
        ...
    }
}
```

### Advanced Dependency Injection
```csharp
IServiceCollection services = ...;

string clientId = "REPLACE_ME";
string clientSecret = "REPLACE_ME";
string authority = "https://identity.vendorhub.io";
string scope = "vendorhub.forms";

services.AddFormsClient(new FormsClientOptions
    {
        FormsApiUri = new Uri("https://api.vendorhub.io"),
        TokenClientOptions = new TokenClientOptions
        {
            Authority = authority,
            ClientId = clientId,
            ClientSecret = clientSecret,
            Scope = scope,
            RequireHttps = true,
            ValidateIssuerName = true,
        }
    });

...

public class Foo
{
    public Foo(IFormsClient formsClient) // Injected IFormsClient
    {
        ...
    }
}
```