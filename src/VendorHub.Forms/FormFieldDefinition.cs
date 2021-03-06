﻿// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using Newtonsoft.Json;

    /// <summary>
    /// The definition of a form field.
    /// </summary>
    public class FormFieldDefinition
    {
        /// <summary>
        /// Gets or sets the form field name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the form field type.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
