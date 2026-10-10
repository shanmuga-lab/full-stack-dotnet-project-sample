using OnlineStoreModel.Models.ProductModels;
using OnlineStoreModel.ServiceContracts;
using OnlineStoreRepository;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
namespace OnlineStoreService;

public class ProductService : IProductService
{
    private readonly ProductRepository _productRepository;
    private readonly IBrandService _brandService;
    private readonly ITypeService _typeService;
    private readonly IAzureBlobService _azureBlobService;

    public ProductService(ProductRepository productRepository, IBrandService brandService, ITypeService typeService, IAzureBlobService azureBlobService)
    {
        _productRepository = productRepository;
        _brandService = brandService;
        _typeService = typeService;
        _azureBlobService = azureBlobService;
    }

    public async Task CreateProductAsync(CreateProductModel createProductModel)
    {
        string ImageUrl = string.Empty;
        string ImageName = string.Empty;
        if(createProductModel.UploadImage != null)
        {
            (ImageUrl, ImageName) = await this._azureBlobService.UploadImageAsync(createProductModel.UploadImage);
        }
        
        ProductModel productModel = new ProductModel
        {
            Id = new Guid(),
            ProductName = createProductModel.ProductName,
            ProductDescription = createProductModel.ProductDescription,
            BrandId = createProductModel.BrandId,
            TypeId = createProductModel.TypeId,
            ImageName = ImageName,
            ImageUrl = ImageUrl,
            ProductPrice = createProductModel.ProductPrice,
            GST = 18,
            TotalPrice = CalculateTotalPrice(createProductModel.ProductPrice, 18)
        };
        await this._productRepository.Products.AddAsync(productModel);
        await this._productRepository.SaveChangesAsync();
    }

    private decimal CalculateTotalPrice(int productPrice, int gst)
    {
        return (decimal) (productPrice * gst / 100) + productPrice;
    }

    public void DeleteProduct(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("Product ID cannot be empty.");
        }
        ProductModel? productModel = this._productRepository.Products.Where(p => p.Id == id).FirstOrDefault();
        if (productModel == null)
        {
            throw new ArgumentException("Product not found.");
        }
        this._azureBlobService.DeleteImageAsync(productModel.ImageName);
        this._productRepository.Products.Remove(productModel);
        this._productRepository.SaveChanges();
    }

    public List<ListProductModel> GetAllProducts()
    {
        
        return _productRepository.Products.Select(p => new ListProductModel
        {
            Id = p.Id,
            ProductName = p.ProductName,
            ProductDescription = p.ProductDescription,
            BrandName = this._brandService.GetBrandById(p.BrandId).Name ?? string.Empty,
            TypeName = this._typeService.GetTypeById(p.TypeId).Name ?? string.Empty,
            ImageName = p.ImageName,
            ImageUrl = p.ImageUrl,
            ProductPrice = p.ProductPrice,
            GST = p.GST,
            TotalPrice = p.TotalPrice
        }).ToList();
    }

    public UpdateProductModel GetProductById(Guid id)
    {
        if (id == Guid.Empty) {
            throw new Exception("Product ID cannot be empty.");
        }
        ProductModel? productModel = this._productRepository.Products.Where(p => p.Id == id).FirstOrDefault();
        if (productModel == null)
        {
            throw new ArgumentException("Product not found.");
        }
        return new UpdateProductModel
        {
            Id = productModel.Id,
            ProductName = productModel.ProductName,
            ProductDescription = productModel.ProductDescription,
            BrandId = productModel.BrandId,
            TypeId = productModel.TypeId,
            ImageUrl = productModel.ImageUrl,
            ProductPrice = productModel.ProductPrice
        };
    }

    public async Task UpdateProductAsync(UpdateProductModel updateProductModel)
    {
        if (updateProductModel == null)
        {
            throw new ArgumentNullException(nameof(updateProductModel));
        }

        ProductModel? productModel = this._productRepository.Products.Where(p => p.Id == updateProductModel.Id).FirstOrDefault();
        if (productModel == null)
        {
            throw new ArgumentException("Product not found.");
        }

        string ImageUrl = productModel.ImageUrl;
        string ImageName = productModel.ImageName;
        if (updateProductModel.UploadImage != null)
        {
            (ImageUrl, ImageName) = await this._azureBlobService.UploadImageAsync(updateProductModel.UploadImage);
            this._azureBlobService.DeleteImageAsync(productModel.ImageName);
        }

        productModel.ProductName = updateProductModel.ProductName;
        productModel.ProductDescription = updateProductModel.ProductDescription;
        productModel.BrandId = updateProductModel.BrandId;
        productModel.TypeId = updateProductModel.TypeId;
        productModel.ImageName = ImageName;
        productModel.ImageUrl = ImageUrl;
        productModel.ProductPrice = updateProductModel.ProductPrice;
        productModel.GST = 18;
        productModel.TotalPrice = CalculateTotalPrice(updateProductModel.ProductPrice, 18);

        this._productRepository.Products.Update(productModel);
        await this._productRepository.SaveChangesAsync();
    }
}
