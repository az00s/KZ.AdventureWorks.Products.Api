using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace KZ.AdventureWorks.Products.Api.Models
{
    public partial class Product
    {
        public Product()
        {
            BillOfMaterialComponents = new HashSet<BillOfMaterial>();
            BillOfMaterialProductAssemblies = new HashSet<BillOfMaterial>();
            ProductCostHistories = new HashSet<ProductCostHistory>();
            ProductInventories = new HashSet<ProductInventory>();
            ProductListPriceHistories = new HashSet<ProductListPriceHistory>();
            ProductProductPhotos = new HashSet<ProductProductPhoto>();
            ProductReviews = new HashSet<ProductReview>();
            ProductVendors = new HashSet<ProductVendor>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
            SpecialOfferProducts = new HashSet<SpecialOfferProduct>();
            TransactionHistories = new HashSet<TransactionHistory>();
            WorkOrders = new HashSet<WorkOrder>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public bool? MakeFlag { get; set; }
        public bool? FinishedGoodsFlag { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public decimal? Weight { get; set; }
        public int DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryId { get; set; }
        public int? ProductModelId { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ProductModel ProductModel { get; set; }
        public virtual ProductSubcategory ProductSubcategory { get; set; }
        [NotMapped]
        public virtual UnitMeasure SizeUnitMeasureCodeNavigation { get; set; }
        [NotMapped]
        public virtual UnitMeasure WeightUnitMeasureCodeNavigation { get; set; }
        [NotMapped]
        public virtual ICollection<BillOfMaterial> BillOfMaterialComponents { get; set; }
        [NotMapped]
        public virtual ICollection<BillOfMaterial> BillOfMaterialProductAssemblies { get; set; }
        [NotMapped]
        public virtual ICollection<ProductCostHistory> ProductCostHistories { get; set; }
        [NotMapped]
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        [NotMapped]
        public virtual ICollection<ProductListPriceHistory> ProductListPriceHistories { get; set; }
        [NotMapped]
        public virtual ICollection<ProductProductPhoto> ProductProductPhotos { get; set; }
        [NotMapped]
        public virtual ICollection<ProductReview> ProductReviews { get; set; }
        [NotMapped]
        public virtual ICollection<ProductVendor> ProductVendors { get; set; }
        [NotMapped]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        [NotMapped]
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        [NotMapped]
        public virtual ICollection<SpecialOfferProduct> SpecialOfferProducts { get; set; }
        [NotMapped]
        public virtual ICollection<TransactionHistory> TransactionHistories { get; set; }
        [NotMapped]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
