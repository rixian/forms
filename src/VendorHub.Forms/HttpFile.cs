// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System.IO;

    public class HttpFile
    {
        public HttpFile()
        {
        }

        public HttpFile(Stream data, string fileName, string contentType)
        {
            this.Data = data;
            this.FileName = fileName;
            this.ContentType = contentType;
        }

        public string ContentType { get; set; }
        public string FileName { get; set; }
        public Stream Data { get; set; }
    }
}
