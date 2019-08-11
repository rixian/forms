// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Rixian.Extensions.Tokens;
using VendorHub.Forms;
using Xunit;
using Xunit.Abstractions;

public class FormsClientIntegrationTests
{
    private readonly ITestOutputHelper logger;

    public FormsClientIntegrationTests(ITestOutputHelper logger)
    {
        this.logger = logger;
    }

    [Fact]
    [Trait("TestCategory", "FailsInCloudTest")]
    public async System.Threading.Tasks.Task ListFormsAsync()
    {
        var tenantId = Guid.Parse("REPLACE_ME");
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddHttpClient("tls12")
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12,
            });

        serviceCollection.AddTokenClient(new TokenClientOptions
            {
                ClientId = "REPLACE_ME",
                ClientSecret = "REPLACE_ME",
                Authority = "https://identity.vendorhub.io/",
                Scope = "vendorhub.cloudfs vendorhub.forms",
            })
            .ConfigureHttpClient("tls12");

        serviceCollection
            .AddHttpClient("vendorhub", c => c.BaseAddress = new Uri("https://api.vendorhub.io"))
            .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12,
            });

        ServiceProvider services = serviceCollection.BuildServiceProvider();

        ITokenClient tokenClient = services.GetRequiredService<ITokenClientFactory>().GetTokenClient();
        ITokenInfo token = await tokenClient.GetTokenAsync().ConfigureAwait(false);
#pragma warning disable CA2000 // Dispose objects before losing scope
        HttpClient httpClient = services.GetRequiredService<IHttpClientFactory>().CreateClient("vendorhub");
#pragma warning restore CA2000 // Dispose objects before losing scope
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);
        IFormsClient client = new FormsClient(httpClient);
        System.Collections.Generic.ICollection<Form> forms = await client.ListFormsAsync(tenantId).ConfigureAwait(false);
    }

    [Fact]
    [Trait("TestCategory", "FailsInCloudTest")]
    public async System.Threading.Tasks.Task ListForms2Async()
    {
        var tenantId = Guid.Parse("REPLACE_ME");
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddFormsClient("REPLACE_ME", "REPLACE_ME", "vendorhub.forms");
        ServiceProvider services = serviceCollection.BuildServiceProvider();
        IFormsClient client = services.GetRequiredService<IFormsClient>();
        System.Collections.Generic.ICollection<Form> forms = await client.ListFormsAsync(tenantId).ConfigureAwait(false);
    }

    [Fact]
    public void ForClient_Created_Success()
    {
        Guid tenantId = Guid.Empty; // <-- REPLACE_ME
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddFormsClient("REPLACE_ME", "REPLACE_ME", "vendorhub.forms");
        ServiceProvider services = serviceCollection.BuildServiceProvider();
        IFormsClient client = services.GetRequiredService<IFormsClient>();

        client.Should().NotBeNull();
    }
}
