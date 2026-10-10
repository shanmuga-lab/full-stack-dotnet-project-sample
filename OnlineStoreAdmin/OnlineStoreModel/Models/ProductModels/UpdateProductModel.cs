using System;
using Microsoft.AspNetCore.Http;

namespace OnlineStoreModel.Models.ProductModels;

public class UpdateProductModel
{
    public Guid Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public Guid BrandId { get; set; }
    public Guid TypeId { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public IFormFile UploadImage { get; set; } = null!;
    public int ProductPrice { get; set; }
}
