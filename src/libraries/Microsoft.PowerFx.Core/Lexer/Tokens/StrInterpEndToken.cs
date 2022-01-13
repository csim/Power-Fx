﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using Microsoft.PowerFx.Core.Localization;
using Microsoft.PowerFx.Core.Utils;

namespace Microsoft.PowerFx.Core.Lexer.Tokens
{
    internal class StrInterpEndToken : Token
    {
        public StrInterpEndToken(Span span)
            : base(TokKind.StrInterpEnd, span)
        {
        }

        public override string ToString()
        {
            return "\"";
        }

        public override Token Clone(Span ts)
        {
            return new StrInterpEndToken(ts);
        }

        public override bool Equals(Token that)
        {
            Contracts.AssertValue(that);

            if (!(that is StrInterpEndToken))
            {
                return false;
            }

            return base.Equals(that);
        }
    }
}
