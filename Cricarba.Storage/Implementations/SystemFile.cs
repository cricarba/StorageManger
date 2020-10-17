using Cricarba.Storage.Definitions;
using System.IO;
using System.Threading.Tasks;

namespace Cricarba.Storage.Implementations
{
    internal class SystemFile : IFile
    {
        public void CopyTo(string fileSource, string fileDestination)
        {
            System.IO.File.Copy(fileSource, fileDestination);
        }

        public void Delete(string filePath)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            file.Delete();
        }

        public async Task<bool> Exists(string filePath)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(filePath);
            return await Task.Run(() => file.Exists);
        }

        public async Task<Stream> GetFile(string filePath)
        {
            FileStream input = await Task.Run(() => new FileStream(filePath, FileMode.Open));
            return input;
        }

        public void MoveTo(string fileSource, string fileDestination)
        {
            System.IO.File.Move(fileSource, fileDestination);
        }

        public void Upload(string fileSource, string fileDestination)
        {
            System.IO.FileInfo file = new System.IO.FileInfo(fileSource);
            System.IO.File.Move(fileSource, $"{fileDestination}/{file.Name}");
        }
    }
}