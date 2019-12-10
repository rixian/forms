// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A summary of a particular form submission.
    /// </summary>
    public class FormSubmissionSummary
    {
        /// <summary>
        /// Gets or sets the form ID.
        /// </summary>
        [JsonProperty("formId")]
        public Guid FormId { get; set; }

        /// <summary>
        /// Gets or sets the submission ID.
        /// </summary>
        [JsonProperty("submissionId")]
        public Guid SubmissionId { get; set; }

        /// <summary>
        /// Gets or sets the submission date.
        /// </summary>
        [JsonProperty("submittedOn")]
        public DateTimeOffset SubmittedOn { get; set; }

        /// <summary>
        /// Gets or sets the submission field count.
        /// </summary>
        [JsonProperty("fieldCount")]
        public int FieldCount { get; set; }

        /// <summary>
        /// Gets or sets the submission attachment count..
        /// </summary>
        [JsonProperty("attachmentCount")]
        public int AttachmentCount { get; set; }
    }
}
