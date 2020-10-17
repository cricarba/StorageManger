// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cricarba.Storage.Definitions;
using Cricarba.Storage.Fabric;

namespace Cricarba.Storage
{
    public class Path
    {
        private readonly IPath _path;

        public Path(StorageType repositoryType)
        {
            _path = PathFabric.Create(repositoryType);
        }

        public string CreatePathFile(string container, string fileName)
        {
            return _path.CreatePathFile(container, fileName);
        }

        public string CreatePathFolder(string container, string uniqueIdentifier = null, string systemBasePath = null)
        {
            return _path.CreatePath(container, systemBasePath, uniqueIdentifier);
        }

        public string GetFileNameWithoutExtension(string fileName)
        {
            return _path.GetFileNameWithoutExtension(fileName);
        }
    }
}