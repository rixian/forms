// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using Newtonsoft.Json;

    public class CreateWebhookRequest
    {
        [JsonProperty("notificationUri")]
        public string NotificationUri { get; set; }
    }
}
