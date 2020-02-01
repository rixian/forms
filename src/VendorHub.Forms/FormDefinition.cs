// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

#pragma warning disable CA2227 // Collection properties should be read only
namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Defines a form.
    /// </summary>
    public class FormDefinition
    {
        /// <summary>
        /// Gets or sets the form ID.
        /// </summary>
        [JsonProperty("formId")]
        public Guid FormId { get; set; }

        /// <summary>
        /// Gets or sets the form name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the form creation date.
        /// </summary>
        [JsonProperty("createdOn")]
        public DateTimeOffset CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the form fields.
        /// </summary>
        [JsonProperty("fields")]
        public List<FormFieldDefinition> Fields { get; set; }
    }
}
#pragma warning restore CA2227 // Collection properties should be read only
