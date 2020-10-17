using Cricarba.Storage.Definitions;

namespace Cricarba.Storage.Implementations
{
    internal class AzurePath : IPath
    {
        public string CreatePath(string containerName, string basePath, string UniqueIdentifier = null) => string.IsNullOrEmpty(UniqueIdentifier) ? containerName : $"{containerName}{UniqueIdentifier}";

        public string CreatePathFile(string container, string fileName)
        {
            return fileName;
        }

        public string GetFileNameWithoutExtension(string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}