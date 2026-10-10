using System;
using OnlineStoreModel.Models.BrandModels;

namespace OnlineStoreModel.ServiceContracts;

public interface IBrandService
{
    List<BrandModel> ListBrands();
    void DeleteBrand(Guid id);
    void AddBrand(AddBrandModel addBrandModel);
    ModifyBrandModel GetBrandById(Guid id);
    void ModifyBrand(ModifyBrandModel modifyBrandModel, Guid id);
}