// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Polly;
    using Rixian.Extensions.Http.Client;

    /// <summary>
    /// Client for the VendorHub Forms Api.
    /// </summary>
    public class FormsClient : IFormsClient
    {
        private readonly HttpClient httpClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormsClient"/> class.
        /// </summary>
        /// <param name="httpClient">The HttpClient to use for all requests.</param>
        public FormsClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        /// <summary>
        /// Gets or sets the policy for the CreateForm http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> CreateFormPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListForms http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> ListFormsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetForm http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> GetFormPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetAllFormStatistics http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> GetAllFormStatisticsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetFormStatistics http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> GetFormStatisticsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the SubmitForm http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> SubmitFormPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListWebhooks http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> ListWebhooksPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the ListSubmissions http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> ListSubmissionsPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetSubmission http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> GetSubmissionPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the GetSubmissionAttachment http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> GetSubmissionAttachmentPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the CreateWebhook http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> CreateWebhookPolicy { get; set; }

        /// <summary>
        /// Gets or sets the policy for the DeleteWebhook http request.
        /// </summary>
        protected IAsyncPolicy<HttpResponseMessage> DeleteWebhookPolicy { get; set; }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CreateFormHttpResponseAsync(CreateFormRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms")
                .ReplaceToken("{tenantId}", tenantId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithContentJson(request)
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewCreateFormAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CreateFormPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListFormsHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("/tenants/{tenantId}/forms")
                .ReplaceToken("{tenantId}", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListFormsAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListFormsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetFormHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetFormAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetFormPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetAllFormStatisticsHttpResponseAsync(Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/stats")
                .ReplaceToken("{tenantId}", tenantId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetAllFormStatisticsAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetAllFormStatisticsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetFormStatisticsHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/stats")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetFormStatisticsAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetFormStatisticsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> SubmitFormHttpResponseAsync(Guid formId, IEnumerable<KeyValuePair<string, string>> fields, IEnumerable<KeyValuePair<string, HttpFile>> attachments, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/submissions")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            IMultipartFormContentBuilder contentBuilder = requestBuilder.WithMultipartFormContent();

            if (fields != null)
            {
                foreach (KeyValuePair<string, string> field in fields)
                {
                    contentBuilder = contentBuilder.WithString(field.Key, field.Value);
                }
            }

            if (attachments != null)
            {
                foreach (KeyValuePair<string, HttpFile> attachment in attachments)
                {
                    HttpFile file = attachment.Value;
                    if (file == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(attachments), Properties.Resources.NullAttachmentErrorMessage);
                    }

                    contentBuilder = contentBuilder.WithFile(attachment.Key, file.Data, file.FileName, file.ContentType);
                }
            }

            requestBuilder = await this.PreviewSubmitFormAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.SubmitFormPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListWebhooksHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/webhooks")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListWebhooksAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListWebhooksPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> ListSubmissionsHttpResponseAsync(Guid formId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/submissions")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewListSubmissionsAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.ListSubmissionsPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetSubmissionHttpResponseAsync(Guid formId, Guid submissionId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/submissions/{submissionId}")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ReplaceToken("{submissionId}", submissionId)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetSubmissionAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetSubmissionPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> GetSubmissionAttachmentHttpResponseAsync(Guid formId, Guid submissionId, string attachmentName, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/submissions/{submissionId}/attachments/{attachmentName}")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ReplaceToken("{submissionId}", submissionId)
                .ReplaceToken("{attachmentName}", attachmentName)
                .ToRequest()
                .WithHttpMethod().Get()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewGetSubmissionAttachmentAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.GetSubmissionAttachmentPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> CreateWebhookHttpResponseAsync(Guid formId, CreateWebhookRequest request, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/webhooks")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ToRequest()
                .WithHttpMethod().Post()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewCreateWebhookAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.CreateWebhookPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> DeleteWebhookHttpResponseAsync(Guid formId, Guid webhookId, Guid tenantId, CancellationToken cancellationToken = default)
        {
            IHttpRequestMessageBuilder requestBuilder = UrlBuilder
                .Create("tenants/{tenantId}/forms/{formId}/webhooks/{webhookId}")
                .ReplaceToken("{tenantId}", tenantId)
                .ReplaceToken("{formId}", formId)
                .ReplaceToken("{webhookId}", webhookId)
                .ToRequest()
                .WithHttpMethod().Delete()
                .WithAcceptApplicationJson();

            requestBuilder = await this.PreviewDeleteWebhookAsync(requestBuilder, cancellationToken).ConfigureAwait(false);
            HttpResponseMessage response = await this.SendRequestWithPolicy(requestBuilder, this.DeleteWebhookPolicy, cancellationToken).ConfigureAwait(false);
            return response;
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to CreateForm.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCreateFormAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ListForms.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListFormsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetForm.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetFormAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetAllFormStatistics.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetAllFormStatisticsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetFormStatistics.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetFormStatisticsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to SubmitForm.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewSubmitFormAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ListWebhooks.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListWebhooksAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to ListSubmissions.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewListSubmissionsAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetSubmission.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetSubmissionAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to GetSubmissionAttachment.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewGetSubmissionAttachmentAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to CreateWebhook.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewCreateWebhookAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        /// <summary>
        /// Optional method for configuring the HttpRequestMessage before sending the call to DeleteWebhook.
        /// </summary>
        /// <param name="httpRequestMessageBuilder">The IHttpRequestMessageBuilder.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>The updated IHttpRequestMessageBuilder.</returns>
        protected virtual Task<IHttpRequestMessageBuilder> PreviewDeleteWebhookAsync(IHttpRequestMessageBuilder httpRequestMessageBuilder, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(httpRequestMessageBuilder);
        }

        private async Task<HttpResponseMessage> SendRequestWithPolicy(IHttpRequestMessageBuilder requestBuilder, IAsyncPolicy<HttpResponseMessage> policy = null, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = requestBuilder.Request;
            using (request)
            {
                Task<HttpResponseMessage> SendRequest(CancellationToken ct)
                {
                    return this.httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, ct);
                }

                if (policy != null)
                {
                    HttpResponseMessage response = await policy.ExecuteAsync(SendRequest, cancellationToken).ConfigureAwait(false);
                    return response;
                }
                else
                {
                    HttpResponseMessage response = await SendRequest(cancellationToken).ConfigureAwait(false);
                    return response;
                }
            }
        }
    }
}
