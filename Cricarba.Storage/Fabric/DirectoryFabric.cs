using Cricarba.Storage.Definitions;
using Cricarba.Storage.Implementations;
using System;

namespace Cricarba.Storage.Fabric
{
    internal static class DirectoryFabric
    {
        internal static IDirectory Create(StorageType type, string pathOrContainer, string azureConnectionString = null)
        {
            if (string.IsNullOrEmpty(pathOrContainer))
                throw new ArgumentException("Path or Azure blob container not defined, is required", "pathOrContainer");

            switch (type)
            {
                case StorageType.SystemFile:
                    return new SystemDirectory(pathOrContainer);

                case StorageType.Azure:

                    if (azureConnectionString == null)
                        throw new ArgumentException("Azure Connection String not defined, is required", "azureConnectionString");

                    return new AzureDirectoy(azureConnectionString, pathOrContainer);

                default:
                    throw new ArgumentException("Type not defined", "type");
            }
        }
    }
}