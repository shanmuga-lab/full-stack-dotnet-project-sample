using System;
using OnlineStoreModel.Models.TypeModels;

namespace OnlineStoreModel.ServiceContracts;

public interface ITypeService
{
    List<TypeModel> ListTypes();
    void AddType(AddTypeModel addTypeModel);
    void ModifyType(ModifyTypeModel modifyTypeModel, Guid id);
    void DeleteType(Guid id);
    ModifyTypeModel GetTypeById(Guid id);
}
