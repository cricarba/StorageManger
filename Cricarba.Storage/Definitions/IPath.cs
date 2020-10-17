namespace Cricarba.Storage.Definitions
{
    internal interface IPath
    {
        string CreatePath(string containerName, string basePath, string UniqueIdentifier = null);

        string CreatePathFile(string container, string fileName);

        string GetFileNameWithoutExtension(string fileName);
    }
}