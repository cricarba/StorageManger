using Cricarba.Storage.Definitions;
using Cricarba.Storage.Dto;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Cricarba.Storage.Implementations
{
    internal class SystemDirectory : IDirectory
    {
        private readonly string _path;

        public SystemDirectory(string path)
        {
            _path = path;
        }

        public async Task<DirectoryInformation> CreateIfNotExists()
        {
            DirectoryInfo directory;
            if (Directory.Exists(_path))
            {
                directory = await Task.Run(() => new DirectoryInfo(_path));
            }
            else
            {
                directory = await Task.Run(() => Directory.CreateDirectory(_path));
            }

            return new DirectoryInformation { Name = directory.FullName, Exists = directory.Exists, Root = directory.Root.FullName };
        }

        public async Task<bool> Exists()
        {
            return await Task.Run(() => Directory.Exists(_path));
        }

        public async Task<List<File>> GetFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(_path);
            var filesSys = await Task.Run(() => dir.GetFiles());
            List<File> files = new List<File>();
            foreach (var file in filesSys)
            {
                files.Add(new File
                {
                    Name = file.Name,
                    CreationTime = file.CreationTime,
                    CreationTimeUtc = file.CreationTimeUtc,
                    LastWriteTime = file.LastWriteTime,
                    Extension = file.Extension
                });
            }
            return files;
        }
    }
}