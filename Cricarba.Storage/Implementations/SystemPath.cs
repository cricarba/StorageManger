using Cricarba.Storage.Definitions;

namespace Cricarba.Storage.Implementations
{
    internal class SystemPath : IPath
    {
        public string CreatePath(string containerName, string basePath, string UniqueIdentifier = null)
        {
            return string.IsNullOrEmpty(UniqueIdentifier) ?
                    System.IO.Path.Combine(basePath, containerName) :
                     System.IO.Path.Combine(basePath, containerName, UniqueIdentifier);
        }

        public string CreatePathFile(string container, string fileName)
        {
            return System.IO.Path.Combine(container, fileName);
        }

        public string GetFileNameWithoutExtension(string fileName)
        {
            return System.IO.Path.GetFileNameWithoutExtension(fileName);
        }
    }
}