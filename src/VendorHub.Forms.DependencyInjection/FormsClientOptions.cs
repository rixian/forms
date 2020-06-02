// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using Rixian.Extensions.Tokens;

    /// <summary>
    /// Options for configuring an instance of IFormsClientOptions.
    /// </summary>
    public class FormsClientOptions
    {
        /// <summary>
        /// Logical name for the HttpClient configured to call the VendorHub Forms Api.
        /// </summary>
        public const string FormsHttpClientName = "rixian_forms";

        /// <summary>
        /// Logical name for the ITokenClient that provides access tokens for calling the VendorHub Forms Api.
        /// </summary>
        public const string FormsTokenClientName = "rixian_forms_token";

        /// <summary>
        /// Logical name for the HttpClient configured for use by the VendorHub Forms ITokenClient.
        /// </summary>
        public const string FormsTokenClientHttpClientName = "rixian_oidc";

        /// <summary>
        /// Gets or sets the options for the ITokenClient.
        /// </summary>
        public ClientCredentialsTokenClientOptions TokenClientOptions { get; set; }

        /// <summary>
        /// Gets or sets the uri of the Forms api endpoint.
        /// </summary>
        public Uri FormsApiUri { get; set; }

        /// <summary>
        /// Gets or sets the api key used for the Forms api.
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the header name used for passing the api key. Defaults to 'Subscription-Key'.
        /// </summary>
        public string ApiKeyHeaderName { get; set; } = "Subscription-Key";

        /// <summary>
        /// Gets or sets the version of the Forms api. Defaults to '2019-09-01'.
        /// </summary>
        public string ApiVersion { get; set; } = "2019-09-01";
    }
}
