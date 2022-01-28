﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.PowerFx.Core.Entities
{
    internal interface IExternalOptionSet<T> : IExternalEntity, IDisplayMapped<int>
    {
        string Name { get; }

        bool IsBooleanValued { get; }

        string RelatedEntityName { get; }
    }
}