// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Extensions.Errors;
    using Rixian.Extensions.Http.Client;

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
        /// <returns>The result or an error.</returns>
        public static async Task<Result<FormDefinition>> CreateFormResultAsync(this IFormsClient formsClient, CreateFormRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.CreateFormHttpResponseAsync(request, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<FormDefinition>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Creates a new form specific webhook.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="request">The request body.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<Webhook>> CreateWebhookResultAsync(this IFormsClient formsClient, Guid formId, CreateWebhookRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.CreateWebhookHttpResponseAsync(formId, request, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<Webhook>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Deletes a specific webhook for a form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="webhookId">The ID of the requested webhook.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result> DeleteWebhookResultAsync(this IFormsClient formsClient, Guid formId, Guid webhookId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.DeleteWebhookHttpResponseAsync(formId, webhookId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Default;
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Gets the submission statistics for all forms.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<IReadOnlyDictionary<DateTimeOffset, int>>> GetAllFormStatisticsResultAsync(this IFormsClient formsClient, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.GetAllFormStatisticsHttpResponseAsync(tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<IReadOnlyDictionary<DateTimeOffset, int>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Gets a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<FormDefinition>> GetFormResultAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.GetFormHttpResponseAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<FormDefinition>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Gets the submission statistics for a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<IReadOnlyDictionary<DateTimeOffset, int>>> GetFormStatisticsResultAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.GetFormStatisticsHttpResponseAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<IReadOnlyDictionary<DateTimeOffset, int>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
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
        /// <returns>The result or an error.</returns>
        public static async Task<Result<HttpFile>> GetSubmissionAttachmentResultAsync(this IFormsClient formsClient, Guid formId, Guid submissionId, string attachmentName, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.GetSubmissionAttachmentHttpResponseAsync(formId, submissionId, attachmentName, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return new HttpFile
                        {
                            Data = await response.Content.ReadAsStreamAsync().ConfigureAwait(false),
                            ContentType = response.Content?.Headers?.ContentType?.MediaType,
                            FileName = response.Content?.Headers?.ContentDisposition?.FileName,
                        };
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Gets a particular form submission.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="submissionId">The ID of the requested submission.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<FormSubmission>> GetSubmissionResultAsync(this IFormsClient formsClient, Guid formId, Guid submissionId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.GetSubmissionHttpResponseAsync(formId, submissionId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<FormSubmission>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Lists all forms for a particular tenant.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<ICollection<FormDefinition>>> ListFormsResultAsync(this IFormsClient formsClient, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.ListFormsHttpResponseAsync(tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<FormDefinition>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Lists the submissions for a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<ICollection<FormSubmissionSummary>>> ListSubmissionsResultAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.ListSubmissionsHttpResponseAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<FormSubmissionSummary>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }

        /// <summary>
        /// Lists the webhooks for a particular form.
        /// </summary>
        /// <param name="formsClient">The IFormsClient to use.</param>
        /// <param name="formId">The ID of the requested form.</param>
        /// <param name="tenantId">The ID of the requested tenant.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The result or an error.</returns>
        public static async Task<Result<ICollection<Webhook>>> ListWebhooksResultAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.ListWebhooksHttpResponseAsync(formId, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<Webhook>>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
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
        /// <returns>The result or an error.</returns>
        public static async Task<Result<FormSubmission>> SubmitFormResultAsync(this IFormsClient formsClient, Guid formId, IEnumerable<KeyValuePair<string, string>> fields, IEnumerable<KeyValuePair<string, HttpFile>> attachments, Guid tenantId, CancellationToken cancellationToken = default)
        {
            if (formsClient is null)
            {
                throw new ArgumentNullException(nameof(formsClient));
            }

            HttpResponseMessage response = await formsClient.SubmitFormHttpResponseAsync(formId, fields, attachments, tenantId, cancellationToken).ConfigureAwait(false);

            using (response)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        return Result.Create(await response.DeserializeJsonContentAsync<FormSubmission>().ConfigureAwait(false));
                    case HttpStatusCode.NoContent:
                        return default;
                    case HttpStatusCode.BadRequest:
                    case HttpStatusCode.InternalServerError:
                        {
                            ErrorResponse errorResponse = await response.DeserializeJsonContentAsync<ErrorResponse>().ConfigureAwait(false);
                            return errorResponse.Error;
                        }

                    default:
                        return await UnexpectedStatusCodeError.CreateAsync(response, $"{nameof(IFormsClient)}.{nameof(CreateFormResultAsync)}").ConfigureAwait(false);
                }
            }
        }
    }
}
