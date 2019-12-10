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
        /// <summary>
        /// Creates a new forms.
        /// </summary>
        /// <param name="request">The request body.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CreateFormHttpResponseAsync(CreateFormRequest request, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new form specific webhook.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="request">The request body.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> CreateWebhookHttpResponseAsync(Guid formId, CreateWebhookRequest request, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a specific webhook for a form.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="webhookId">The ID of the requested webhook.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> DeleteWebhookHttpResponseAsync(Guid formId, Guid webhookId, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the submission statistics for all forms.
        /// </summary>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetAllFormStatisticsHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a particular form.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetFormHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the submission statistics for a particular form.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetFormStatisticsHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a particular form submission attachment.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="submissionId">The ID of the requested submission.</param>
        /// <param name="attachmentName">The name of the attachment.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetSubmissionAttachmentHttpResponseAsync(Guid formId, Guid submissionId, string attachmentName, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a particular form submission.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="submissionId">The ID of the requested submission.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> GetSubmissionHttpResponseAsync(Guid formId, Guid submissionId, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists all forms for a particular tenant.
        /// </summary>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListFormsHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the submissions for a particular form.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListSubmissionsHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Lists the webhooks for a particular form.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> ListWebhooksHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Submits a new form to VendorHub.
        /// </summary>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="fields">The text fields to submit.</param>
        /// <param name="attachments">The files to attach.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The raw HttpResponseMessage.</returns>
        Task<HttpResponseMessage> SubmitFormHttpResponseAsync(Guid formId, IEnumerable<KeyValuePair<string, string>> fields, IEnumerable<KeyValuePair<string, HttpFile>> attachments, Guid tenantId, CancellationToken cancellationToken = default);
    }
}
