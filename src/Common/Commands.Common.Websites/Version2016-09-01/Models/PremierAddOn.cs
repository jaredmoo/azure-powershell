// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.WebSites.Version2016_09_01.Models
{
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Premier add-on.
    /// </summary>
    [Rest.Serialization.JsonTransformation]
    public partial class PremierAddOn : Resource
    {
        /// <summary>
        /// Initializes a new instance of the PremierAddOn class.
        /// </summary>
        public PremierAddOn()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the PremierAddOn class.
        /// </summary>
        /// <param name="location">Resource Location.</param>
        /// <param name="id">Resource Id.</param>
        /// <param name="name">Resource Name.</param>
        /// <param name="kind">Kind of resource.</param>
        /// <param name="type">Resource type.</param>
        /// <param name="tags">Resource tags.</param>
        /// <param name="sku">Premier add on SKU.</param>
        /// <param name="product">Premier add on Product.</param>
        /// <param name="vendor">Premier add on Vendor.</param>
        /// <param name="premierAddOnName">Premier add on Name.</param>
        /// <param name="premierAddOnLocation">Premier add on Location.</param>
        /// <param name="premierAddOnTags">Premier add on Tags.</param>
        /// <param name="marketplacePublisher">Premier add on Marketplace
        /// publisher.</param>
        /// <param name="marketplaceOffer">Premier add on Marketplace
        /// offer.</param>
        public PremierAddOn(string location, string id = default(string), string name = default(string), string kind = default(string), string type = default(string), IDictionary<string, string> tags = default(IDictionary<string, string>), string sku = default(string), string product = default(string), string vendor = default(string), string premierAddOnName = default(string), string premierAddOnLocation = default(string), IDictionary<string, string> premierAddOnTags = default(IDictionary<string, string>), string marketplacePublisher = default(string), string marketplaceOffer = default(string))
            : base(location, id, name, kind, type, tags)
        {
            Sku = sku;
            Product = product;
            Vendor = vendor;
            PremierAddOnName = premierAddOnName;
            PremierAddOnLocation = premierAddOnLocation;
            PremierAddOnTags = premierAddOnTags;
            MarketplacePublisher = marketplacePublisher;
            MarketplaceOffer = marketplaceOffer;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets premier add on SKU.
        /// </summary>
        [JsonProperty(PropertyName = "properties.sku")]
        public string Sku { get; set; }

        /// <summary>
        /// Gets or sets premier add on Product.
        /// </summary>
        [JsonProperty(PropertyName = "properties.product")]
        public string Product { get; set; }

        /// <summary>
        /// Gets or sets premier add on Vendor.
        /// </summary>
        [JsonProperty(PropertyName = "properties.vendor")]
        public string Vendor { get; set; }

        /// <summary>
        /// Gets or sets premier add on Name.
        /// </summary>
        [JsonProperty(PropertyName = "properties.name")]
        public string PremierAddOnName { get; set; }

        /// <summary>
        /// Gets or sets premier add on Location.
        /// </summary>
        [JsonProperty(PropertyName = "properties.location")]
        public string PremierAddOnLocation { get; set; }

        /// <summary>
        /// Gets or sets premier add on Tags.
        /// </summary>
        [JsonProperty(PropertyName = "properties.tags")]
        public IDictionary<string, string> PremierAddOnTags { get; set; }

        /// <summary>
        /// Gets or sets premier add on Marketplace publisher.
        /// </summary>
        [JsonProperty(PropertyName = "properties.marketplacePublisher")]
        public string MarketplacePublisher { get; set; }

        /// <summary>
        /// Gets or sets premier add on Marketplace offer.
        /// </summary>
        [JsonProperty(PropertyName = "properties.marketplaceOffer")]
        public string MarketplaceOffer { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}