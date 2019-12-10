// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class FormSubmission
    {
        [JsonProperty("formId")]
        public Guid FormId { get; set; }
        [JsonProperty("submissionId")]
        public Guid SubmissionId { get; set; }
        [JsonProperty("submittedOn")]
        public DateTimeOffset SubmittedOn { get; set; }
        [JsonProperty("fields")]
        public List<FormField> Fields { get; set; }
        [JsonProperty("attachments")]
        public List<FormAttachment> Attachments { get; set; }
    }
}
