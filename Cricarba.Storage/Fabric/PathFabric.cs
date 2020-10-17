using Cricarba.Storage.Definitions;
using Cricarba.Storage.Implementations;
using System;

namespace Cricarba.Storage.Fabric
{
    internal static class PathFabric
    {
        internal static IPath Create(StorageType type)
        {
            switch (type)
            {
                case StorageType.SystemFile:
                    return new SystemPath();

                case StorageType.Azure:
                    return new AzurePath();

                default:
                    throw new ArgumentException("Type not defined", "type");
            }
        }
    }
}