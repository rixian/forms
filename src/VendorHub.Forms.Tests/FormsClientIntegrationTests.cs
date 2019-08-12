// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
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

    private const string ClientId = "REPLACE_ME";
    private const string ClientSecret = "REPLACE_ME";
    private const string Authority = "https://identity.vendorhub.io/";
    private const string Scope = "vendorhub.cloudfs vendorhub.forms";
    private const string ApiEndpoint = "https://api.vendorhub.io";
    private const string TenantId = "REPLACE_ME";

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
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Authority = Authority,
                Scope = Scope,
            })
            .ConfigureHttpClient("tls12");

        serviceCollection
            .AddHttpClient("vendorhub", c => c.BaseAddress = new Uri(ApiEndpoint))
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
        var tenantId = Guid.Parse(TenantId);
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddFormsClient(ClientId, ClientSecret, Scope);
        ServiceProvider services = serviceCollection.BuildServiceProvider();
        IFormsClient client = services.GetRequiredService<IFormsClient>();

        //Form form = await client.CreateFormAsync(tenantId, new CreateFormRequest
        //{
        //    Name = "TestForm",
        //    Fields = new List<FormFields>
        //    {
        //        new FormFields
        //        {
        //            Name = "Name",
        //            Type = "string",
        //        },
        //        new FormFields
        //        {
        //            Name = "Age",
        //            Type = "int",
        //        },
        //    },
        //}).ConfigureAwait(false);
        //form.Should().NotBeNull();

        //form = await client.GetFormAsync(tenantId, form.FormId).ConfigureAwait(false);
        //form.Should().NotBeNull();

        var form = await client.GetFormAsync(tenantId, Guid.Parse("REPLACE_ME")).ConfigureAwait(false);
        form.Should().NotBeNull();

        SubmissionDetailed submission = await client.SubmitFormAsync(
            tenantId,
            form.FormId,
            new Dictionary<string, string>
            {
                ["Name"] = "Test",
                ["Age"] = "30",
            },
            new Dictionary<string, FileParameter>
            {
                ["ProfilePicture"] = new FileParameter(File.OpenRead("350x350.png"), "test.png", "image/png"),
            }).ConfigureAwait(false);
        submission.Should().NotBeNull();

        submission = await client.GetSubmissionAsync(tenantId, form.FormId, submission.SubmissionId).ConfigureAwait(false);
        submission.Should().NotBeNull();

#pragma warning disable CA2000 // Dispose objects before losing scope
        FileResponse attachment = await client.GetSubmissionAttachmentAsync(tenantId, form.FormId, submission.SubmissionId, "ProfilePicture").ConfigureAwait(false);
#pragma warning restore CA2000 // Dispose objects before losing scope
        attachment.Should().NotBeNull();

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
