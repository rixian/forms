// Copyright (c) Rixian. All rights reserved.
// Licensed under the Apache License, Version 2.0 license. See LICENSE file in the project root for full license information.

namespace VendorHub.Forms
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for the VendorHub Forms API client.
    /// </summary>
    public partial interface IFormsClient
    {
        /// <summary>
        /// Submits a form with data and attachments.
        /// </summary>
        /// <param name="tenantId">The tenantId of the form owner.</param>
        /// <param name="formId">The form id.</param>
        /// <param name="fields">The named fields to include in the form submission.</param>
        /// <param name="attachments">The named attchments to include in the form submission.</param>
        /// <param name="cancellationToken">The CancellationToken.</param>
        /// <returns>The submission details.</returns>
        Task<SubmissionDetailed> SubmitFormAsync(Guid tenantId, Guid formId, IEnumerable<KeyValuePair<string, string>> fields, IEnumerable<KeyValuePair<string, FileParameter>> attachments, CancellationToken cancellationToken = default(CancellationToken));
    }
}
