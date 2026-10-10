using System;
using OnlineStoreModel.Models.ProductModels;

namespace OnlineStoreModel.ServiceContracts;

public interface IProductService
{
    List<ListProductModel> GetAllProducts();
    UpdateProductModel GetProductById(Guid id);
    Task CreateProductAsync(CreateProductModel createProductModel);
    Task UpdateProductAsync(UpdateProductModel updateProductModel);
    void DeleteProduct(Guid id);
}
