// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cricarba.Storage.Definitions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace Cricarba.Storage.Implementations
{
    internal class AzureFile : IFile
    {
        private readonly CloudStorageAccount _cloudStorageAccount;
        private readonly CloudBlobContainer cloudBlobContainer;

        public AzureFile(string connectionString, string blobContainer)
        {
            _cloudStorageAccount = CloudStorageAccount.Parse(connectionString);
            CloudBlobClient cloudBlobClient = _cloudStorageAccount.CreateCloudBlobClient();
            cloudBlobContainer = cloudBlobClient.GetContainerReference(blobContainer);
        }

        public async void CopyTo(string fileSource, string fileDestination)
        {
            CloudBlobClient cloudBlobClientDestination = _cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer cloudBlobContainerDestination = cloudBlobClientDestination.GetContainerReference(fileDestination);
            CloudBlockBlob blockBlobDestination = cloudBlobContainerDestination.GetBlockBlobReference(fileSource);
            CloudBlockBlob blockBlobSource = cloudBlobContainer.GetBlockBlobReference(fileSource);

            Stream input = new MemoryStream();
            await blockBlobSource.DownloadToStreamAsync(input);
            await blockBlobDestination.UploadFromStreamAsync(input);
        }

        public void Delete(string filePath)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
            blockBlob.DeleteIfExistsAsync();
        }

        public async Task<bool> Exists(string filePath)
        {
            string fileName = System.IO.Path.GetFileName(filePath);
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
            return await blockBlob.ExistsAsync();
        }

        public async Task<Stream> GetFile(string filePath)
        {
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(filePath);
            Stream input = new MemoryStream();
            await blockBlob.DownloadToStreamAsync(input);
            return input;
        }

        public void MoveTo(string fileSource, string fileDestination)
        {
            CopyTo(fileSource, fileDestination);
        }

        public void Upload(string fileSource, string fileDestination)
        {
            string fileName = System.IO.Path.GetFileName(fileSource);
            CloudBlockBlob blockBlob = cloudBlobContainer.GetBlockBlobReference(fileName);
            using (FileStream uploadFileStream = System.IO.File.OpenRead(fileSource))
            {
                blockBlob.UploadFromStreamAsync(uploadFileStream);
                uploadFileStream.Close();
            }
        }
    }
}