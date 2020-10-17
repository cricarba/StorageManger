using Cricarba.Storage.Definitions;
using Cricarba.Storage.Dto;
using Cricarba.Storage.Fabric;
using System.Collections.Generic;

namespace Cricarba.Storage
{
    public class Container
    {
        private readonly IDirectory _directory;

        public Container(StorageType type, string pathOrContainer, string azureConnectionString = null)
        {
            _directory = DirectoryFabric.Create(type, pathOrContainer.Trim().ToLower(), azureConnectionString);
        }

        /// <summary>
        /// Crea un directorio si no existe
        /// </summary>
        /// <returns></returns>
        public DirectoryInformation CreateIfNotExists()
        {
            return _directory.CreateIfNotExists().Result;
        }

        public bool Exists()
        {
            return _directory.Exists().Result;
        }

        public List<File> GetFiles()
        {
            return _directory.GetFiles().Result;
        }
    }
}