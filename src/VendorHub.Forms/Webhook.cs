// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a webhook.
    /// </summary>
    public class Webhook : IEquatable<Webhook>
    {
        /// <summary>
        /// Gets or sets the webhook ID.
        /// </summary>
        [JsonProperty("webhookId")]
        public Guid WebhookId { get; set; }

        /// <summary>
        /// Gets or sets the webhook creation date.
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the webhook notification URI.
        /// </summary>
        [JsonProperty("notificationUri")]
        public Uri NotificationUri { get; set; }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Webhook);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // Overflow is fine, just wrap
            unchecked
            {
                int hash = 17;

                hash = (hash * 486187739) + this.WebhookId.GetHashCode();
                hash = (hash * 486187739) + this.CreatedOn.GetHashCode();
                if (this.NotificationUri != null)
                {
                    hash = (hash * 486187739) + this.NotificationUri.GetHashCode();
                }

                return hash;
            }
        }
    }
}
