// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.PowerFx.Core.Localization;
using Microsoft.PowerFx.Core.Utils;

namespace Microsoft.PowerFx.Core.Lexer.Tokens
{
    internal class ErrorToken : Token
    {
        private readonly object[] _resourceKeyFormatStringArgs;

        // May produce null, if there is no available detail for this error token.
        public ErrorResourceKey? DetailErrorKey { get; }

        // Args for ErrorResourceKey("UnexpectedCharacterToken")'s format string used in UnexpectedCharacterTokenError/LexError inside Lexer.cs.
        public object[] ResourceKeyFormatStringArgs => _resourceKeyFormatStringArgs;

        public ErrorToken(Span span)
            : this(span, null)
        { }

        public ErrorToken(Span span, ErrorResourceKey? detailErrorKey)
            : base(TokKind.Error, span)
        {
            Contracts.AssertValueOrNull(detailErrorKey);

            DetailErrorKey = detailErrorKey;
        }

        public ErrorToken(Span span, ErrorResourceKey? detailErrorKey, params object[] args)
            : base(TokKind.Error, span)
        {
            Contracts.AssertValueOrNull(detailErrorKey);
            Contracts.AssertValueOrNull(args);

            DetailErrorKey = detailErrorKey;
            _resourceKeyFormatStringArgs = args;
        }

        /// <summary>
        /// Copy Ctor for ErrorToken used by Clone
        /// </summary>
        /// <param name="tok">The token to be copied</param>
        /// <param name="newSpan">The new span</param>
        private ErrorToken(ErrorToken tok, Span newSpan)
            : this(newSpan, tok.DetailErrorKey)
        {
        }

        public override Token Clone(Span ts)
        {
            return new ErrorToken(this, ts);
        }

        public override bool Equals(Token that)
        {
            Contracts.AssertValue(that);

            if (that is not ErrorToken other)
                return false;

            return DetailErrorKey?.Key == other.DetailErrorKey?.Key && base.Equals(other) && Enumerable.SequenceEqual(_resourceKeyFormatStringArgs, other.ResourceKeyFormatStringArgs);
        }
    }
}