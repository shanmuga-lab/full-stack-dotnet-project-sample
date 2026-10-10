using System;
using OnlineStoreModel.Models.TypeModels;
using OnlineStoreModel.ServiceContracts;
using OnlineStoreRepository;

namespace OnlineStoreService;

public class TypeService : ITypeService
{
    private readonly TypeRepository _typeRepository;

    public TypeService(TypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }

    public void AddType(AddTypeModel addTypeModel)
    {
        if (addTypeModel == null)
        {
            throw new Exception("AddTypeModel is null.");
        }
        this._typeRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        TypeModel type = new TypeModel
        {
            Id = Guid.NewGuid(),
            Name = addTypeModel.Name
        };
        this._typeRepository.Types.Add(type);
        this._typeRepository.SaveChanges();
    }

    public void DeleteType(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Type ID is null or empty.");
        }
        TypeModel? typeToDelete = this._typeRepository.Types.FirstOrDefault(t => t.Id == id);
        if (typeToDelete == null)
        {
            throw new Exception($"Type with ID {id} not found.");
        }
        this._typeRepository.Types.Remove(typeToDelete);
        this._typeRepository.SaveChanges();
    }

    public ModifyTypeModel GetTypeById(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new Exception("Type ID is null or empty.");
        }
        this._typeRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        TypeModel? type = this._typeRepository.Types.FirstOrDefault(t => t.Id == id);
        if (type == null)
        {
            throw new Exception($"Type with ID {id} not found.");
        }
        ModifyTypeModel modifyTypeModel = new ModifyTypeModel
        {
            Id = type.Id,
            Name = type.Name
        };
        return modifyTypeModel;
    }

    public List<TypeModel> ListTypes()
    {
        return this._typeRepository.Types.ToList();
    }

    public void ModifyType(ModifyTypeModel modifyTypeModel, Guid id)
    {
        if (modifyTypeModel == null)
        {
            throw new Exception("ModifyTypeModel is null.");
        }
        this._typeRepository.Database.EnsureCreated(); // Ensure the database is created before querying
        TypeModel typeToModify = new TypeModel
        {
            Id = id,
            Name = modifyTypeModel.Name
        };
        this._typeRepository.Types.Update(typeToModify);
        this._typeRepository.SaveChanges();
    }
}
