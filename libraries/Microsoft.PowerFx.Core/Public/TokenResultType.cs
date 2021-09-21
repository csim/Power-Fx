﻿//------------------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

namespace Microsoft.PowerFx.Core
{
    /// <summary>
    /// Token result type (this matches formula bar token type defined in PowerAppsTheme.ts)
    /// </summary>
    public enum TokenResultType
    {
        Boolean,
        Keyword,
        Function,
        Number,
        Operator,
        HostSymbol,
        Variable
    }
}