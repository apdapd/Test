using DB_WorkEntity.SqlConnection;
using Domain;
using System;
using System.Configuration;
using DB_WorkEntity.Entity;
using DB_WorkEntity;

namespace ClassLibraryBL
{
    public static class ConnectionFactory
    {
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Test1"].ConnectionString;
           // @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\VStudio\AllTests\Test.mdf;Integrated Security=True";

        public static IConnection GetConnection(ConnectionType type)
        {
            switch (type)
            {
                case ConnectionType.SqlConnection:
                    {
                        return new Connection(ConnectionString);                        
                    }
                case ConnectionType.Entity:
                    {
                        return new EntityConnection();
                    }
                default:
                    throw new Exception("Для этого типа не придумали реализацию");
            }
        }
    }
}
