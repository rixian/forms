// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Extensions.Errors;

    public static partial class FormsClientExtensions
    {
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

        public static async Task<ICollection<FormSubmission>> ListSubmissionsAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            Result<ICollection<FormSubmission>> result = await formsClient.ListSubmissionsResultAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            if (result.IsResult)
            {
                return result.Value;
            }

            throw ApiException.Create(result.Error);
        }

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
