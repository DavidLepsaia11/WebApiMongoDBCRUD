﻿namespace WebApiMongoDBCRUD.Models
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string StudentCollectionName { get; set; } = string.Empty;
        public string DatabaseName { get ; set; } = string.Empty;
        public string ConnectionString { get; set ; } = string.Empty;
    }
}
