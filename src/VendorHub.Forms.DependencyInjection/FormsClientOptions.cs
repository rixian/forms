// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace Microsoft.Extensions.DependencyInjection
{
    using System;
    using Rixian.Extensions.Tokens;

    /// <summary>
    /// Options for configuring an instance of IFormsClient.
    /// </summary>
    public class FormsClientOptions
    {
        /// <summary>
        /// Gets or sets the options for the ITokenClient.
        /// </summary>
        public TokenClientOptions TokenClientOptions { get; set; }

        /// <summary>
        /// Gets or sets the uri of the forms api endpoint.
        /// </summary>
        public Uri FormsApiUri { get; set; }
    }
}
