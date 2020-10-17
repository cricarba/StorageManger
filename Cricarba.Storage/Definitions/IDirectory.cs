using Cricarba.Storage.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cricarba.Storage.Definitions
{
    internal interface IDirectory
    {
        Task<DirectoryInformation> CreateIfNotExists();

        Task<bool> Exists();

        Task<List<File>> GetFiles();
    }
}