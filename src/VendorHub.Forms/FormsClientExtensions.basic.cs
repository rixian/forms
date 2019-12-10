// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Extensions.Errors;

    /// <summary>
    /// Extensions for the VendorHub Forms Api client.
    /// </summary>
    public static partial class FormsClientExtensions
    {
        /// <summary>
        /// Creates a new forms.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="request">The request body.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The new form definition.</returns>
        public static async Task<FormDefinition> CreateFormAsync(this IFormsClient formsClient, CreateFormRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<FormDefinition> result = await formsClient.CreateFormResultAsync(request, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Creates a new form specific webhook.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="request">The request body.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The new webhook.</returns>
        public static async Task<Webhook> CreateWebhookAsync(this IFormsClient formsClient, Guid formId, CreateWebhookRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<Webhook> result = await formsClient.CreateWebhookResultAsync(formId, request, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Deletes a specific webhook for a form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="webhookId">The ID of the requested webhook.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>Returns nothing.</returns>
        public static async Task DeleteWebhookAsync(this IFormsClient formsClient, Guid formId, Guid webhookId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result result = await formsClient.DeleteWebhookResultAsync(formId, webhookId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsError)
            {
                throw ApiException.Create(result.Error);
            }
        }

        /// <summary>
        /// Gets the submission statistics for all forms.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The form submission statistics.</returns>
        public static async Task<IReadOnlyDictionary<DateTimeOffset, int>> GetAllFormStatisticsAsync(this IFormsClient formsClient, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<IReadOnlyDictionary<DateTimeOffset, int>> result = await formsClient.GetAllFormStatisticsResultAsync(tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Gets a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The form definition.</returns>
        public static async Task<FormDefinition> GetFormAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<FormDefinition> result = await formsClient.GetFormResultAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Gets the submission statistics for a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The form submission statistics.</returns>
        public static async Task<IReadOnlyDictionary<DateTimeOffset, int>> GetFormStatisticsAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<IReadOnlyDictionary<DateTimeOffset, int>> result = await formsClient.GetFormStatisticsResultAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Gets a particular form submission attachment.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="submissionId">The ID of the requested submission.</param>
        /// <param name="attachmentName">The name of the attachment.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The submission attachment data.</returns>
        public static async Task<HttpFile> GetSubmissionAttachmentAsync(this IFormsClient formsClient, Guid formId, Guid submissionId, string attachmentName, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<HttpFile> result = await formsClient.GetSubmissionAttachmentResultAsync(formId, submissionId, attachmentName, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Gets a particular form submission.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="submissionId">The ID of the requested submission.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The form submission.</returns>
        public static async Task<FormSubmission> GetSubmissionAsync(this IFormsClient formsClient, Guid formId, Guid submissionId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<FormSubmission> result = await formsClient.GetSubmissionResultAsync(formId, submissionId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Lists all forms for a particular tenant.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The list of forms.</returns>
        public static async Task<ICollection<FormDefinition>> ListFormsAsync(this IFormsClient formsClient, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<ICollection<FormDefinition>> result = await formsClient.ListFormsResultAsync(tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Lists the submissions for a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The list of form submissions.</returns>
        public static async Task<ICollection<FormSubmissionSummary>> ListSubmissionsAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<ICollection<FormSubmissionSummary>> result = await formsClient.ListSubmissionsResultAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Lists the webhooks for a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The list of webhooks.</returns>
        public static async Task<ICollection<Webhook>> ListWebhooksAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<ICollection<Webhook>> result = await formsClient.ListWebhooksResultAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

        /// <summary>
        /// Submits a new form to VendorHub.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="fields">The text fields to submit.</param>
        /// <param name="attachments">The files to attach.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The new form submission.</returns>
        public static async Task<FormSubmission> SubmitFormAsync(this IFormsClient formsClient, Guid formId, IEnumerable<KeyValuePair<string, string>> fields, IEnumerable<KeyValuePair<string, HttpFile>> attachments, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<FormSubmission> result = await formsClient.SubmitFormResultAsync(formId, fields, attachments, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }
    }
}
