// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public partial class FormsClient : IFormsClient
    {
        public async Task<SubmissionDetailed> SubmitFormAsync(Guid tenantId, Guid formId, IDictionary<string, string> fields, IDictionary<string, FileParameter> attachments, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (tenantId == null)
            {
                throw new ArgumentNullException(nameof(tenantId));
            }

            if (formId == null)
            {
                throw new ArgumentNullException(nameof(formId));
            }

            var urlBuilder_ = new StringBuilder();
            urlBuilder_.Append("tenants/{tenantId}/forms/{formId}/submissions");
            urlBuilder_.Replace("{tenantId}", Uri.EscapeDataString(this.ConvertToString(tenantId, System.Globalization.CultureInfo.InvariantCulture)));
            urlBuilder_.Replace("{formId}", Uri.EscapeDataString(this.ConvertToString(formId, System.Globalization.CultureInfo.InvariantCulture)));

            System.Net.Http.HttpClient client_ = this._httpClient;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    var boundary_ = Guid.NewGuid().ToString();
                    var content_ = new System.Net.Http.MultipartFormDataContent(boundary_);
                    content_.Headers.Remove("Content-Type");
                    content_.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary_);

                    if (fields != null)
                    {
                        foreach (KeyValuePair<string, string> field in fields)
                        {
#pragma warning disable CA2000 // Dispose objects before losing scope
                            content_.Add(new System.Net.Http.StringContent(this.ConvertToString(field.Value, System.Globalization.CultureInfo.InvariantCulture)), field.Key);
#pragma warning restore CA2000 // Dispose objects before losing scope
                        }
                    }

                    if (attachments != null)
                    {
                        foreach (KeyValuePair<string, FileParameter> attachment in attachments)
                        {
                            if (attachment.Value != null)
                            {
#pragma warning disable CA2000 // Dispose objects before losing scope
                                var content_fileFoo_ = new System.Net.Http.StreamContent(attachment.Value.Data);
#pragma warning restore CA2000 // Dispose objects before losing scope
                                if (!string.IsNullOrEmpty(attachment.Value.ContentType))
                                {
                                    content_fileFoo_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse(attachment.Value.ContentType);
                                }

                                content_.Add(content_fileFoo_, attachment.Key, attachment.Value.FileName ?? attachment.Key);
                            }
                        }
                    }

                    request_.Content = content_;
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                    this.PrepareRequest(client_, request_, urlBuilder_);
                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new Uri(url_, UriKind.RelativeOrAbsolute);
                    this.PrepareRequest(client_, request_, url_);

                    System.Net.Http.HttpResponseMessage response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (KeyValuePair<string, IEnumerable<string>> item_ in response_.Content.Headers)
                            {
                                headers_[item_.Key] = item_.Value;
                            }
                        }

                        this.ProcessResponse(client_, response_);

                        var status_ = ((int)response_.StatusCode).ToString(System.Globalization.CultureInfo.InvariantCulture);
                        if (status_ == "200")
                        {
                            ObjectResponseResult<SubmissionDetailed> objectResponse_ = await this.ReadObjectResponseAsync<SubmissionDetailed>(response_, headers_).ConfigureAwait(false);
                            return objectResponse_.Object;
                        }
                        else
                        if (status_ != "200" && status_ != "204")
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + (int)response_.StatusCode + ").", (int)response_.StatusCode, responseData_, headers_, null);
                        }

                        return default(SubmissionDetailed);
                    }
                    finally
                    {
                        if (response_ != null)
                        {
                            response_.Dispose();
                        }
                    }
                }
            }
            finally
            {
            }
        }
    }

    /*
    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.0.4.0 (NJsonSchema v10.0.21.0 (Newtonsoft.Json v11.0.0.0))")]
    public partial class FileParameter
    {
        public FileParameter(System.IO.Stream data)
            : this (data, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName)
            : this (data, fileName, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName, string contentType)
        {
            Data = data;
            FileName = fileName;
            ContentType = contentType;
        }

        public System.IO.Stream Data { get; private set; }

        public string FileName { get; private set; }

        public string ContentType { get; private set; }
    }
     */
}
