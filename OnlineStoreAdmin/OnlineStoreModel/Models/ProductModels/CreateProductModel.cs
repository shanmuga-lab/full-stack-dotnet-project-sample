using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace OnlineStoreModel.Models.ProductModels;

public class CreateProductModel
{
    [Required(ErrorMessage ="Product Name is mandatory")]
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public Guid BrandId { get; set; }
    public Guid TypeId { get; set; }
    public IFormFile UploadImage { get; set; } = null!;
    public int ProductPrice { get; set; }
}
