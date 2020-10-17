using Cricarba.Storage.Definitions;
using Cricarba.Storage.Implementations;
using System;

namespace Cricarba.Storage.Fabric
{
    internal static class FileFabric
    {
        internal static IFile Create(StorageType type, string azureConnectionString = null, string azureBlobContainer = null)
        {
            switch (type)
            {
                case StorageType.SystemFile:
                    return new SystemFile();

                case StorageType.Azure:
                    if (azureConnectionString == null)
                        throw new ArgumentException("Azure Connection String not defined, is required", "azureConnectionString");
                    if (azureBlobContainer == null)
                        throw new ArgumentException("Azure Blob Container not defined, is required", "azureBlobContainer");

                    return new AzureFile(azureConnectionString, azureBlobContainer);

                default:
                    throw new ArgumentException("Type not defined", "type");
            }
        }
    }
}