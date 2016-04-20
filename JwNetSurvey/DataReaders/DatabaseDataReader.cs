using System;
using System.Data.Common;

namespace JwNetSurvey
{

    /// <summary>
    /// This is a mock Database data reader class just to demonstrate how the data source can be replaced.
    /// </summary>
    class DatabaseDataReader : IDataReader
    {
        public DbConnection Connection { get; set; }
        protected DbDataReader DataReader { get; set; }
        public DbCommand Command { get; set; }
        public bool EndOfData { get; protected set; }

        public DatabaseDataReader(DbConnection connection, DbCommand command)
        {
            Connection = connection;
            Command = command;
        }

        public IDataReader Init()
        {
            Dispose();
            Connection.Open();
            DataReader = Command.ExecuteReader();
            return this;
        }

        public string ReadLine()
        {
            EndOfData = !DataReader.Read();
            if (EndOfData)
            {
                return null;
            }
            else
            {
                return DataReader.GetString(0);
            }
        }       

        public void Dispose()
        {
            try
            {
                if (DataReader != null && !DataReader.IsClosed)
                {
                    DataReader.Close();
                }
                if (Connection != null && Connection.State != System.Data.ConnectionState.Closed)
                {
                    Connection.Close();
                }
            }
            catch (Exception)
            {
            }
            finally {
                if (Connection != null) {
                    Connection.Dispose();
                }
            }

        }



    }
}
