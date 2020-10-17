using Cricarba.Storage.Definitions;
using Cricarba.Storage.Dto;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cricarba.Storage.Implementations
{
    internal class AzureDirectoy : IDirectory
    {
        private readonly string _blobContainer;
        private readonly string _connectionString;
        private readonly CloudBlobContainer cloudBlobContainer;

        public AzureDirectoy(string connectionString, string blobContainer)
        {
            _connectionString = connectionString;
            _blobContainer = blobContainer;
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();
            cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainer);
        }

        public async Task<DirectoryInformation> CreateIfNotExists()
        {
            await Task.Run(() => cloudBlobContainer.CreateIfNotExistsAsync());
            return new DirectoryInformation { Name = cloudBlobContainer.Name, Exists = true };
        }

        public async Task<bool> Exists()
        {
            return await cloudBlobContainer.ExistsAsync();
        }

        public async Task<List<File>> GetFiles()
        {
            List<File> files = new List<File>();
            if (await cloudBlobContainer.ExistsAsync())
            {
                BlobResultSegment items = await cloudBlobContainer.ListBlobsSegmentedAsync(new BlobContinuationToken());
                foreach (CloudBlockBlob blobItem in items.Results.OfType<CloudBlockBlob>())
                {
                    files.Add(new File(Fabric.StorageType.Azure, _connectionString, _blobContainer)
                    {
                        Name = blobItem.Name,
                        LastWriteTime = blobItem.Properties.LastModified.HasValue ? blobItem.Properties.LastModified.Value.UtcDateTime : new System.DateTime(),
                        CreationTimeUtc = blobItem.Properties.Created.HasValue ? blobItem.Properties.Created.Value.UtcDateTime : new System.DateTime(),
                        CreationTime = blobItem.Properties.Created.HasValue ? blobItem.Properties.Created.Value.DateTime : new System.DateTime(),
                    });
                }
            }
            return files;
        }
    }
}