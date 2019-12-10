// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Net.Http;
    using System.Security.Authentication;
    using Rixian.Extensions.Tokens;
    using VendorHub.Forms;

    /// <summary>
    /// Extensions for adding IFormClient to the DI container.
    /// </summary>
    public static class VendorHubFormsClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the IFormsClient with the DI container.
        /// </summary>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="options">Configuration options for this client.</param>
        /// <returns>The updated IServiceCollection.</returns>
        public static IServiceCollection AddFormsClient(this IServiceCollection serviceCollection, FormsClientOptions options)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            if (options.TokenClientOptions is null)
            {
                throw new ArgumentOutOfRangeException(nameof(options));
            }

            // Configure the HttpClient for use by the ITokenClient.
            serviceCollection.AddHttpClient(FormsClientOptions.FormsTokenClientHttpClientName)
                .UseSslProtocols(SslProtocols.Tls12);

            // Configure the ITokenClient to use the previous HttpClient.
            serviceCollection
                .AddTokenClient(FormsClientOptions.FormsTokenClientName, options.TokenClientOptions)
                .UseHttpClient(FormsClientOptions.FormsTokenClientHttpClientName);

            // Configure the HttpClient with the ITokenClient for inserting tokens into the header.
            IHttpClientBuilder httpClientBuilder = serviceCollection
                .AddHttpClient(FormsClientOptions.FormsHttpClientName, c => c.BaseAddress = options.FormsApiUri)
                .UseSslProtocols(SslProtocols.Tls12)
                .UseApiVersion(options.ApiVersion ?? "2019-09-01", null)
                .UseTokenClient(FormsClientOptions.FormsTokenClientName)
                .AddTypedClient<IFormsClient, FormsClient>();

            if (!string.IsNullOrWhiteSpace(options.ApiKey))
            {
                httpClientBuilder.UseHeader(options.ApiKeyHeaderName ?? "Subscription-Key", options.ApiKey);
            }

            return serviceCollection;
        }
    }
}
