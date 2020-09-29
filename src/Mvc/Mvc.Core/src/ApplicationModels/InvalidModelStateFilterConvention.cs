// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Microsoft.AspNetCore.Mvc.ApplicationModels
{
    /// <summary>
    /// An <see cref="IActionModelConvention"/> that adds a <see cref="IFilterMetadata"/>
    /// to <see cref="ActionModel"/> that responds to invalid <see cref="ActionContext.ModelState"/>
    /// </summary>
    public class InvalidModelStateFilterConvention : IActionModelConvention
    {
        private readonly ModelStateInvalidFilterFactory _filterFactory = new ModelStateInvalidFilterFactory();

        /// <inheritdoc />
        public void Apply(ActionModel action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (!ShouldApply(action))
            {
                return;
            }

            action.Filters.Add(_filterFactory);
        }

        /// <summary>
        /// Called to determine whether the action should apply.
        /// </summary>
        /// <param name="action">The action in question.</param>
        /// <returns>True if the action should apply.</returns>
        protected virtual bool ShouldApply(ActionModel action) => true;
    }
}