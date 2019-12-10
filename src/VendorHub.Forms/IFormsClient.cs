// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the VendorHub Forms API client.
    /// </summary>

    public interface IFormsClient
    {
        Task<HttpResponseMessage> CreateFormHttpResponseAsync(CreateFormRequest request, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> CreateWebhookHttpResponseAsync(Guid formId, CreateWebhookRequest request, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> DeleteWebhookHttpResponseAsync(Guid formId, Guid webhookId, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> GetAllFormStatisticsHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> GetFormHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> GetFormStatisticsHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> GetSubmissionAttachmentHttpResponseAsync(Guid formId, Guid submissionId, string attachmentName, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> GetSubmissionHttpResponseAsync(Guid formId, Guid submissionId, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> ListFormsHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> ListSubmissionsHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> ListWebhooksHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);
        Task<HttpResponseMessage> SubmitFormHttpResponseAsync(Guid formId, IEnumerable<KeyValuePair<string, string>> fields, IEnumerable<KeyValuePair<string, HttpFile>> attachments, Guid tenantId, CancellationToken cancellationToken = default);
    }
}
