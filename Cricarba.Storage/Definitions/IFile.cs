// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using System.IO;
using System.Threading.Tasks;

namespace Cricarba.Storage.Definitions
{
    internal interface IFile
    {
        void CopyTo(string fileSource, string fileDestination);

        void Delete(string filePath);

        Task<bool> Exists(string filePath);

        Task<Stream> GetFile(string filePath);

        void MoveTo(string fileSource, string fileDestination);

        void Upload(string fileSource, string fileDestination);
    }
}