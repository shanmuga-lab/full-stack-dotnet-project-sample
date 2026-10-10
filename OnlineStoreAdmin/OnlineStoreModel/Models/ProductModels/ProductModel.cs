using System;

namespace OnlineStoreModel.Models.ProductModels;

public class ProductModel
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public Guid BrandId { get; set; }
    public Guid TypeId { get; set; }
    public string ImageName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public int ProductPrice { get; set; }
    public int GST { get; set; }
    public decimal TotalPrice { get; set; }
}
