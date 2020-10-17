// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using Cricarba.Storage.Definitions;
using Cricarba.Storage.Dto;
using Cricarba.Storage.Fabric;
using System.IO;

namespace Cricarba.Storage
{
    public class File : FileInformation
    {
        private readonly IFile _file;

        public File(StorageType repositoryType, string azureConnectionString = null, string azureBlobContainer = null)
        {
            _file = FileFabric.Create(repositoryType, azureConnectionString, azureBlobContainer);
        }

        internal File()
        {
        }

        /// <summary>
        /// <para>
        /// Azure: Copia un blob de una contenedor de Azure a otro
        /// </para>
        /// <para>
        /// Sistema de Archivos:  Copia un archivo de una carpeta a otra
        /// </para>
        /// </summary>
        /// <param name="source">
        /// <para>
        /// Azure:
        ///     Nombre del blob a copiar </para>
        /// <para> Sistema de Archivos:
        ///     Ruta del archivo a copiar</para>
        /// </param>
        /// <param name="destination">
        /// Azure:
        ///     Nombre del contendor de destino
        /// Sistema de Archivos:
        ///     Ruta de destino del archivo
        /// </param>
        public void CopyTo(string source, string destination)
        {
            _file.CopyTo(source, destination);
        }

        /// <summary>
        /// <list type="bullet">
        /// <item>
        /// <term>Azure</term>
        /// <description>Elimina un blob de un contenedor</description>
        /// </item>
        /// <item>
        /// <term>Sistema de Archivos</term>
        /// <description>Elimina un archivo de una carpeta</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="filePath">
        /// <list type="bullet">
        /// <item>
        /// <term>Azure</term>
        /// <description>No necesario</description>
        /// </item>
        /// <item>
        /// <term>Sistema de Archivos</term>
        /// <description>Ruta del archivo a eliminar</description>
        /// </item>
        /// </list>
        /// </param>
        public void Delete(string filePath)
        {
            _file.Delete(filePath);
        }

        public bool Exists(string filePath)
        {
            return _file.Exists(filePath).Result;
        }

        public Stream GetFile(string filePath)
        {
            return _file.GetFile(filePath).Result;
        }

        public void MoveTo(string fileSource, string fileDestination)
        {
            _file.MoveTo(fileSource, fileDestination);
        }

        public void Upload(string source, string destination)
        {
            _file.Upload(source, destination);
        }
    }
}