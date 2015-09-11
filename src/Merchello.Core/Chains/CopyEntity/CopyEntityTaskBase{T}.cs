﻿namespace Merchello.Core.Chains.CopyEntity
{
    using Merchello.Core.Models.EntityBase;
    using Merchello.Core.Services;

    using Umbraco.Core;

    /// <summary>
    /// The copy entity task base.
    /// </summary>
    /// <typeparam name="T">
    /// The type of <see cref="IEntity"/>
    /// </typeparam>
    public abstract class CopyEntityTaskBase<T> : IAttemptChainTask<T>
        where T : class, IEntity
    {
        /// <summary>
        /// The _merchello context.
        /// </summary>
        private readonly IMerchelloContext _merchelloContext;

        /// <summary>
        /// The original entity
        /// </summary>
        private readonly T _original;

        /// <summary>
        /// Initializes a new instance of the <see cref="CopyEntityTaskBase{T}"/> class.
        /// </summary>
        /// <param name="merchelloContext">
        /// The merchello context.
        /// </param>
        /// <param name="original">
        /// The original.
        /// </param>
        protected CopyEntityTaskBase(IMerchelloContext merchelloContext, T original)
        {
            Mandate.ParameterNotNull(merchelloContext, "merchelloContext");
            Mandate.ParameterNotNull(original, "orginal");
            _merchelloContext = merchelloContext;
            _original = original;
        }

        /// <summary>
        /// Gets the original entity
        /// </summary>
        protected T Original
        {
            get
            {
                return _original;
            }
        }

        /// <summary>
        /// Gets the <see cref="IServiceContext"/>.
        /// </summary>
        protected IServiceContext Services
        {
            get
            {
                return _merchelloContext.Services;
            }
        }

        /// <summary>
        /// Performs the task.
        /// </summary>
        /// <param name="entity">
        /// The <see cref="IEntity"/> argument.
        /// </param>
        /// <returns>
        /// The <see cref="Attempt{T}"/>.
        /// </returns>
        public abstract Attempt<T> PerformTask(T entity);

    }
}