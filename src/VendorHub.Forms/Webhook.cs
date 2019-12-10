// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using Newtonsoft.Json;

    public class Webhook : IEquatable<Webhook>
    {
        [JsonProperty("webhookId")]
        public Guid WebhookId { get; set; }

        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        [JsonProperty("notificationUri")]
        public string NotificationUri { get; set; }

        public bool Equals(Webhook other)
        {
            if (other is null)
            {
                return false;
            }

            return this.WebhookId == other.WebhookId
                && this.NotificationUri == other.NotificationUri
                && this.CreatedOn == other.CreatedOn;
        }
    }
}
