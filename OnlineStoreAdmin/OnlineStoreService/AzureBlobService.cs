using System;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using OnlineStoreModel.ServiceContracts;

namespace OnlineStoreService;

public class AzureBlobService : IAzureBlobService
{
    private readonly IConfiguration _configuration;
    private readonly BlobServiceClient _blobServiceClient;
    private readonly BlobContainerClient _blobContainerClient;

    public AzureBlobService(IConfiguration configuration)
    {
        _configuration = configuration;
        var containerName = _configuration["AzureBlobStorage:ContainerName"];
        var connectionString = _configuration["AzureBlobStorage:ConnectionString"];
        _blobServiceClient = new BlobServiceClient(connectionString);
        _blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        _blobContainerClient.CreateIfNotExists();
    }
    public void DeleteImageAsync(string fileName)
    {
        var blobClient = _blobContainerClient.GetBlobClient(fileName);
        blobClient.DeleteIfExistsAsync();
    }

    public async Task<(string fileUrl, string fileName)> UploadImageAsync(IFormFile file)
    {
        string extension = Path.GetExtension(file.FileName);
        string uniqueFileName = $"{Guid.NewGuid()}{extension}";

        var blobClient = _blobContainerClient.GetBlobClient(uniqueFileName);

        var blobHttpHeaders = new BlobHttpHeaders
        {
            ContentType = file.ContentType
        };

        using var stream = file.OpenReadStream();

        await blobClient.UploadAsync(stream, blobHttpHeaders);

        return (blobClient.Uri.ToString(), uniqueFileName);
    }
}
