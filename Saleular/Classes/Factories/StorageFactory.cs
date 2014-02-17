using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saleular.Interfaces;
using Saleular.Interfaces.Factories;

namespace Saleular.Classes.Factories
{
    public class StorageFactory : IStorageFactory
    {
        public enum StorageType
        {
            Session,
            Sql
        }

        public IStorage CreateStorage(StorageType storageType)
        {
            switch (storageType)
            {
                case StorageType.Session:
                    return new SessionStorage();

                case StorageType.Sql:
                    return new SQLStorage();

                default:
                    return new SessionStorage();
            }
        }
    }
}