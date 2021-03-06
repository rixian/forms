﻿// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System.IO;

    /// <summary>
    /// A file to be transported via HTTP.
    /// </summary>
    public class HttpFile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpFile"/> class.
        /// </summary>
        public HttpFile()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpFile"/> class.
        /// </summary>
        /// <param name="data">The file data.</param>
        /// <param name="fileName">The file name.</param>
        /// <param name="contentType">The file content type.</param>
        public HttpFile(Stream data, string fileName, string contentType)
        {
            this.Data = data;
            this.FileName = fileName;
            this.ContentType = contentType;
        }

        /// <summary>
        /// Gets or sets the file content type.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the file name.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Gets or sets the file data.
        /// </summary>
        public Stream Data { get; set; }
    }
}
