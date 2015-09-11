﻿namespace Merchello.Core.Chains.CopyEntity.Product
{
    using System.Linq;

    using Merchello.Core.Models;

    /// <summary>
    /// The copy product task base.
    /// </summary>
    internal abstract class CopyProductTaskBase : CopyEntityTaskBase<IProduct>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CopyProductTaskBase"/> class.
        /// </summary>
        /// <param name="merchelloContext">
        /// The merchello context.
        /// </param>
        /// <param name="original">
        /// The original.
        /// </param>
        protected CopyProductTaskBase(IMerchelloContext merchelloContext, IProduct original)
            : base(merchelloContext, original)
        {
        }

        /// <summary>
        /// Gets the original variant matching the newly generated one.
        /// </summary>
        /// <param name="entitiesVariant">
        /// The entities variant.
        /// </param>
        /// <returns>
        /// The <see cref="IProductVariant"/>.
        /// </returns>
        protected IProductVariant GetOrignalMatchingVariant(IProductVariant entitiesVariant)
        {
            var skus = entitiesVariant.Attributes.Select(x => x.Sku).ToArray();

            return Original.ProductVariants.FirstOrDefault(x => x.Attributes.All(y => skus.Contains(y.Sku)));
        }
    }
}