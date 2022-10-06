using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BateEkranDeneme.Classes
{
    public interface IDBManager
    {
        DataProvider ProviderType
        {
            get;
            set;
        }
        string ConnectionString
        {
            get;
            set;
        }
        IDbConnection Connection
        {
            get;
            set;
        }
        IDbTransaction Transaction
        {
            get;
            set;
        }
        IDbCommand Command
        {
            get;
            set;
        }
        ConnectionState ConnectionState
        {
            get;
            set;
        }

        IDbDataParameter[] Parameters
        {
            get;
            set;
        }

        IDataReader DataReader
        {
            get;
            set;
        }
        void Open();
        void BeginTransaction();
        void CommitTransaction();
        void CreateParameters(int paramsCount);
        void AddParameters(int index, string paramName, object objValue);
        void AddParameters(int index, string paramName, object objValue, DbType dataType);
        void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection);
        IDataReader ExecuteReader(CommandType commandType, string commandText);
        DataSet ExecuteDataSet(CommandType commandType, string commandText);
        object ExecuteScalar(CommandType commandType, string commandText);
        int ExecuteNonQuery(CommandType commandType, string commandText);
        void CloseReader();
        void Close();
        void Dispose();
        void RoolBackTransaction();
    }
}
