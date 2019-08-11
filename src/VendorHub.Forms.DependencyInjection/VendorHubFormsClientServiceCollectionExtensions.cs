// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using System.Net.Http;
    using System.Security.Authentication;
    using Rixian.Extensions.Tokens;
    using VendorHub.Forms;
    using VendorHub.Forms.DependencyInjection;

    /// <summary>
    /// Extensions for adding IFormClient to the DI container.
    /// </summary>
    public static class VendorHubFormsClientServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the IFormClient with the DI container.
        /// </summary>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="clientId">The client id.</param>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="scope">The scope.</param>
        /// <returns>The updated IserviceCollection.</returns>
        public static IServiceCollection AddFormsClient(this IServiceCollection serviceCollection, string clientId, string clientSecret, string scope = null)
        {
            return serviceCollection.AddFormsClient(new FormsClientOptions
            {
                FormsApiUri = new Uri("https://api.vendorhub.io"),
                TokenClientOptions = new TokenClientOptions
                {
                    ClientId = clientId,
                    ClientSecret = clientSecret,
                    Authority = "https://identity.vendorhub.io/",
                    Scope = scope,
                },
            });
        }

        /// <summary>
        /// Registers the IFormClient with the DI container.
        /// </summary>
        /// <param name="serviceCollection">The IServiceCollection.</param>
        /// <param name="options">Configuration options for this client.</param>
        /// <returns>The updated IserviceCollection.</returns>
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

            serviceCollection.AddHttpClient("vendorhub_oidc")
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
                {
                    SslProtocols = SslProtocols.Tls12,
                });
            serviceCollection
                .AddTokenClient("vendorhub_forms_token", options.TokenClientOptions)
                .ConfigureHttpClient("vendorhub_oidc");

            serviceCollection
                .AddHttpClient("vendorhub_forms", c => c.BaseAddress = options.FormsApiUri)
                .ConfigurePrimaryHttpMessageHandler((svc) =>
                {
                    ITokenClientFactory tokenClientFacotry = svc.GetRequiredService<ITokenClientFactory>();
                    ITokenClient tokenClient = tokenClientFacotry.GetTokenClient("vendorhub_forms_token");
                    return new TokenClientDelegatingHandler(tokenClient)
                    {
                        SslProtocols = SslProtocols.Tls12,
                    };
                })
                .AddTypedClient<IFormsClient, FormsClient>();

            return serviceCollection;
        }
    }
}
