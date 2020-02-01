// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    private const string ClientId = "REPLACE_ME";
    private const string ClientSecret = "REPLACE_ME";
    private const string Authority = "http://localhost:32773/";
    private const string Scope = "vendorhub.forms";
    private const string ApiEndpoint = "https://api.vendorhub.io";
    private const string TenantId = "REPLACE_ME";

    private readonly ITestOutputHelper logger;
    private readonly IFormsClient client;

    public FormsClientIntegrationTests(ITestOutputHelper logger)
    {
        this.logger = logger;

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddFormsClient(new FormsClientOptions
        {
            FormsApiUri = new Uri(ApiEndpoint),
            TokenClientOptions = new TokenClientOptions
            {
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Scope = Scope,
                Authority = Authority,
            },
        });
        ServiceProvider services = serviceCollection.BuildServiceProvider();
        this.client = services.GetRequiredService<IFormsClient>();
    }

    [Fact]
    [Trait("TestCategory", "FailsInCloudTest")]
    public async System.Threading.Tasks.Task ListFormsAsync()
    {
        var tenantId = Guid.Parse(TenantId);
        ICollection<FormDefinition> forms = await this.client.ListFormsAsync(tenantId).ConfigureAwait(false);
    }

    [Fact]
    [Trait("TestCategory", "FailsInCloudTest")]
    public async System.Threading.Tasks.Task ListFormSubmissionsAsync()
    {
        var tenantId = Guid.Parse(TenantId);
        ICollection<FormDefinition> forms = await this.client.ListFormsAsync(tenantId).ConfigureAwait(false);
        FormDefinition form = forms.First();

        ICollection<FormSubmissionSummary> submissions = await this.client.ListSubmissionsAsync(tenantId, form.FormId).ConfigureAwait(false);
        FormSubmissionSummary submissionInfo = submissions.FirstOrDefault(s => s.AttachmentCount > 0);
        FormSubmission submission = await this.client.GetSubmissionAsync(tenantId, form.FormId, submissionInfo.SubmissionId).ConfigureAwait(false);
    }

    [Fact]
    [Trait("TestCategory", "FailsInCloudTest")]
    public async System.Threading.Tasks.Task ListForms2Async()
    {
        var tenantId = Guid.Parse(TenantId);
        FormDefinition form = await this.client.CreateFormAsync(
            new CreateFormRequest
            {
                Name = "TestForm",
                Fields = new List<FormFieldDefinition>
                {
                    new FormFieldDefinition
                    {
                        Name = "Name",
                        Type = "string",
                    },
                    new FormFieldDefinition
                    {
                        Name = "Age",
                        Type = "int",
                    },
                },
            },
            tenantId).ConfigureAwait(false);
        form.Should().NotBeNull();

        form = await this.client.GetFormAsync(tenantId, form.FormId).ConfigureAwait(false);
        form.Should().NotBeNull();

        FormSubmission submission = await this.client.SubmitFormAsync(
            form.FormId,
            new Dictionary<string, string>
            {
                ["Name"] = "Test",
                ["Age"] = "30",
            },
            new Dictionary<string, HttpFile>
            {
                ["ProfilePicture"] = new HttpFile(File.OpenRead("350x350.png"), "test.png", "image/png"),
            },
            tenantId).ConfigureAwait(false);
        submission.Should().NotBeNull();

        submission = await this.client.GetSubmissionAsync(tenantId, form.FormId, submission.SubmissionId).ConfigureAwait(false);
        submission.Should().NotBeNull();

#pragma warning disable CA2000 // Dispose objects before losing scope
        HttpFile attachment = await this.client.GetSubmissionAttachmentAsync(form.FormId, submission.SubmissionId, "ProfilePicture", tenantId).ConfigureAwait(false);
#pragma warning restore CA2000 // Dispose objects before losing scope
        attachment.Should().NotBeNull();

        ICollection<FormDefinition> forms = await this.client.ListFormsAsync(tenantId).ConfigureAwait(false);
    }

    [Fact]
    public void ForClient_Created_Success()
    {
        Guid tenantId = Guid.Empty; // <-- REPLACE_ME

        this.client.Should().NotBeNull();
    }
}
