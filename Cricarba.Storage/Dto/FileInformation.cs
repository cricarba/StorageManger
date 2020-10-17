// <copyright company="Aranda Software">
// © Todos los derechos reservados
// </copyright>

using System;

namespace Cricarba.Storage.Dto
{
    public class FileInformation
    {
        public DateTime CreationTime { get; internal set; }
        public DateTime CreationTimeUtc { get; internal set; }
        public string Extension { get; internal set; }
        public DateTime LastWriteTime { get; internal set; }
        public string Name { get; internal set; }
    }
}