using System;
using Microsoft.AspNetCore.Http;

namespace OnlineStoreModel.ServiceContracts;

public interface IAzureBlobService
{
    Task<(string fileUrl, string fileName)> UploadImageAsync(IFormFile file);
    void DeleteImageAsync(string fileName);
}
