using OnlineStoreModel.Models.BrandModels;
using OnlineStoreModel.ServiceContracts;
using OnlineStoreRepository;

namespace OnlineStoreService;

public class BrandService : IBrandService
{
    private readonly BrandRepository _brandRepository;

    public BrandService(BrandRepository brandRepository)
    {
        this._brandRepository = brandRepository;   
    }

    public void AddBrand(AddBrandModel addBrandModel)
    {
        if (addBrandModel == null)
        {
            throw new Exception("AddBrandModel is null.");
        }
        this._brandRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        BrandModel brand = new BrandModel
        {
            Id = Guid.NewGuid(),
            Name = addBrandModel.Name
        };
        this._brandRepository.Brands.Add(brand);
        this._brandRepository.SaveChanges();
    }

    public void DeleteBrand(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Brand ID is null or empty.");
        }
        this._brandRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        var brandToDelete = this._brandRepository.Brands.Where(b => b.Id == id).FirstOrDefault();
        if (brandToDelete == null)
        {
            throw new Exception($"Brand with ID {id} not found.");
        }
        this._brandRepository.Brands.Remove(brandToDelete);
        this._brandRepository.SaveChanges();
    }

    public List<BrandModel> ListBrands()
    {
        this._brandRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        List<BrandModel> brandModels = this._brandRepository.Brands.ToList();

        return brandModels;
    }

    public void ModifyBrand(ModifyBrandModel modifyBrandModel, Guid id)
    {
        if (modifyBrandModel == null)
        {
            throw new Exception("ModifyBrandModel is null.");
        }
        this._brandRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        BrandModel brandModel = new BrandModel
        {
            Id = id,
            Name = modifyBrandModel.Name
        };
        this._brandRepository.Brands.Update(brandModel);
        this._brandRepository.SaveChanges();
    }
    
    public ModifyBrandModel GetBrandById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Brand ID is null or empty.");
        }
        this._brandRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        BrandModel? brand = this._brandRepository.Brands.Where(b => b.Id == id).FirstOrDefault();
        if (brand == null)
        {
            throw new Exception($"Brand with ID {id} not found.");
        }
        return new ModifyBrandModel
        {
            Id = brand.Id,
            Name = brand.Name
        };
    }
}
