﻿using System;
using System.Configuration;

namespace Merchello.Core.Configuration.Outline
{
    public class TypeFieldElement : ConfigurationElement
    {

        /// <summary>
        /// Gets/sets the alias (key) value for the datatypefield collection element.  Presumably this is an enum value.
        /// </summary>
        /// <remarks>
        /// This corresponds to the alias field in the merchDbTypeField table
        /// </remarks>
        [ConfigurationProperty("alias", IsKey = true)]
        public string Alias
        {
            get { return (string)this["alias"]; }
            set { this["alias"] = value; }
        }

        /// <summary>
        /// Gets/sets the descriptive name associated with the referenced type field.  ex. InvoiceItemTypes -> Product, Shipping, Tax, Credit
        /// </summary>
        /// <remarks>
        /// This corresponds to the name field in the merchDbTypeField table
        /// </remarks>
        [ConfigurationProperty("descriptiveName", IsRequired = false)]
        public string Name
        {
            get { return (string)this["descriptiveName"]; }
            set { this["descriptiveName"] = value; }
        }

        /// <summary>
        /// Gets/sets the guid associated with the referenced type field.  
        /// </summary>
        /// <remarks>
        /// This corresponds to the 'key' database column in the merchDbTypefield table
        /// </remarks>
        [ConfigurationProperty("typeKey", IsRequired = true)]
        public Guid TypeKey
        {
            get { return new Guid(this["typeKey"].ToString()); }
            set { this["typeKey"] = value; }
        }



    }
}
