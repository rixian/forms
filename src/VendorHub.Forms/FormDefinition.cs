// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FormDefinition
    {
        [JsonProperty("formId")]
        public Guid FormId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("fields")]
        public List<FormFieldDefinition> Fields { get; set; }
    }
}
