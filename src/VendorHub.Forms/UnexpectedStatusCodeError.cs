// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Rixian.Extensions.Errors;

    /// <summary>
    /// Standard error for unexpected status codes returned from an HTTP request.
    /// </summary>
    public class UnexpectedStatusCodeError : Error
    {
        private UnexpectedStatusCodeError()
        {
        }

        /// <summary>
        /// Gets the content of the faulted response.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the server provided reason phrase of the faulted response.
        /// </summary>
        public string ReasonPhrase { get; private set; }

        /// <summary>
        /// Gets the status code of the faulted response.
        /// </summary>
        public HttpStatusCode StatusCode { get; private set; }

        /// <summary>
        /// Creates a new instance of an UnexpectedStatusCodeError.
        /// </summary>
        /// <param name="response">The HttpResponseMessage to convert to an error.</param>
        /// <param name="target">The target of the error.</param>
        /// <returns>The new UnexpectedStatusCodeError.</returns>
        public static async Task<UnexpectedStatusCodeError> CreateAsync(HttpResponseMessage response, string target)
        {
            if (response is null)
            {
                throw new ArgumentNullException(nameof(response));
            }

            var error = new UnexpectedStatusCodeError();
            error.Code = "UnexpectedStatusCode";
            error.Target = target;
            error.Message = $"The HTTP status code of the response was not expected ({(int)response.StatusCode}).";

            if (response.Content != null)
            {
                var stringContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                error.Content = stringContent;
            }

            error.ReasonPhrase = response.ReasonPhrase;
            error.StatusCode = response.StatusCode;

            return error;
        }
    }
}
