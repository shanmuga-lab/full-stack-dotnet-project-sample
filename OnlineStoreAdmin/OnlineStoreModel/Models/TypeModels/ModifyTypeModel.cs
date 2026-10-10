using System;

namespace OnlineStoreModel.Models.TypeModels;

public class ModifyTypeModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
