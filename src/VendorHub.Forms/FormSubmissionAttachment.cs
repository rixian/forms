// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    /// <summary>
    /// Defines a form submission attachment.
    /// </summary>
    public class FormSubmissionAttachment
    {
        /// <summary>
        /// Gets or sets the form submission attachment name.
        /// </summary>
        public string AttachmentName { get; set; }

        /// <summary>
        /// Gets or sets the form submission attachment file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the form submission attachment file length.
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Gets or sets the form submission attachment file content type.
        /// </summary>
        public string ContentType { get; set; }
    }
}
