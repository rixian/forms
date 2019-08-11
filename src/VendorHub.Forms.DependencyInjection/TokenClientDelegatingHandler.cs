// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms.DependencyInjection
{
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Rixian.Extensions.Tokens;

    /// <summary>
    /// Delegating handler that inserts Bearer tokens using an ITokenClient.
    /// </summary>
    internal class TokenClientDelegatingHandler : HttpClientHandler
    {
        private readonly ITokenClient tokenClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="TokenClientDelegatingHandler"/> class.
        /// </summary>
        /// <param name="tokenClient">The ITokenClient.</param>
        public TokenClientDelegatingHandler(ITokenClient tokenClient)
        {
            this.tokenClient = tokenClient;
        }

        /// <inheritdoc/>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            ITokenInfo token = await this.tokenClient.GetTokenAsync().ConfigureAwait(false);
            request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token.AccessToken);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
