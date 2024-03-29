﻿using System;

namespace receivePixel.Services
{
    public class MongoDBStorageConfig : IStorageConfig
    {
        public string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("ConnectionString")
                    ?? throw new NullReferenceException();
        }

        public string DatabaseName()
        {
            return Environment.GetEnvironmentVariable("DatabaseName")
                    ?? throw new NullReferenceException();
        }
    }
}