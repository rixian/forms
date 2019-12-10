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

    public static partial class FormsClientExtensions
    {
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

        public static async Task<Result<ICollection<FormSubmission>>> ListSubmissionsResultAsync(this IFormsClient formsClient, Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
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
                        return Result.Create(await response.DeserializeJsonContentAsync<ICollection<FormSubmission>>().ConfigureAwait(false));
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
