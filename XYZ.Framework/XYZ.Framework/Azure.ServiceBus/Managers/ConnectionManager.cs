using System;

namespace XYZ.Framework.Azure.ServiceBus.Managers
{
    public class ConnectionManager: IConnectionManager
    {
        private string _connectionString;

        public ConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }
}
