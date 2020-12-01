﻿// -------------------------------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See LICENSE in the repo root for license information.
// -------------------------------------------------------------------------------------------------

using EnsureThat;

namespace Microsoft.Health.Fhir.Core.Features.Search.Expressions
{
    /// <summary>
    /// Represents a not expression where an <see cref="Expression"/> is negated.
    /// </summary>
    public class NotExpression : Expression
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotExpression"/> class.
        /// </summary>
        /// <param name="expression">The expression to negate.</param>
        public NotExpression(Expression expression)
        {
            EnsureArg.IsNotNull(expression, nameof(expression));

            NegatedExpression = expression;
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        public Expression NegatedExpression { get; }

        public override TOutput AcceptVisitor<TContext, TOutput>(IExpressionVisitor<TContext, TOutput> visitor, TContext context)
        {
            EnsureArg.IsNotNull(visitor, nameof(visitor));

            return visitor.VisitNot(this, context);
        }

        public override string ToString()
        {
            return $"(NOT {NegatedExpression})";
        }
    }
}