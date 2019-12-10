// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Request object used for creating webhooks.
    /// </summary>
    public class CreateWebhookRequest
    {
        /// <summary>
        /// Gets or sets the webhook URI.
        /// </summary>
        [JsonProperty("notificationUri")]
        public Uri NotificationUri { get; set; }
    }
}
