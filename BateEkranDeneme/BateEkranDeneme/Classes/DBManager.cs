using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace BateEkranDeneme.Classes
{
    public sealed class DBManager : IDBManager, IDisposable
    {
        private IDbConnection iDbConnection;
        private IDbTransaction iDbTransaction = null;
        private IDbCommand iDbCommand;
        private IDataReader iDataReader;
        private IDbDataParameter[] iDbParameters = null;
        private DataProvider providerType;
        public string strConnection;

        public DBManager()
        {
        }

        public DBManager(DataProvider providerType)
        {
            ProviderType = providerType;
        }

        public DBManager(DataProvider providerType, string connectionString)
        {
            ProviderType = providerType;
            strConnection = connectionString;
        }

        public DataProvider ProviderType
        {
            get { return providerType; }
            set { providerType = value; }
        }

        public string ConnectionString
        {
            get { return strConnection; }
            set { strConnection = value; }
        }
        public IDbConnection Connection
        {
            get { return iDbConnection; }
            set { iDbConnection = value; }
        }

        public IDbTransaction Transaction
        {
            get { return iDbTransaction; }
            set { iDbTransaction = value; }
        }

        public ConnectionState ConnectionState
        {
            get { return Connection.State; }
        }

        public IDbCommand Command
        {
            get { return iDbCommand; }
            set { iDbCommand = value; }
        }

        public IDbDataParameter[] Parameters
        {
            get { return iDbParameters; }
            set { iDbParameters = value; }
        }

        public IDataReader DataReader
        {
            get { return iDataReader; }
            set { iDataReader = value; }
        }

        public void Open()
        {
            //create connection
            Connection = DBManagerFactory.GetConnection(ProviderType);
            Connection.ConnectionString = ConnectionString;
            //check the connection state
            if (Connection.State != ConnectionState.Open)
                Connection.Open();
            Command = DBManagerFactory.GetCommand(ProviderType);
            Command.CommandTimeout = 0; // alican
        }


        public void Close()
        {
            if (Connection != null && Connection.State != ConnectionState.Closed)
                Connection.Close();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Close();
            Command = null;
            Connection = null;
            Transaction = null;
        }

        public void CreateParameters(int paramsCount)
        {
            Parameters = DBManagerFactory.GetParameters(ProviderType, paramsCount);
        }

        public void AddParameters(int index, string paramName, object objValue)
        {
            if (index < Parameters.Length)
            {
                Parameters[index].ParameterName = paramName;
                Parameters[index].Value = objValue;
            }
        }

        public void AddParameters(int index, string paramName, object objValue, DbType dataType)
        {
            if (index < Parameters.Length)
            {
                Parameters[index].ParameterName = paramName;
                Parameters[index].Value = objValue;
                Parameters[index].DbType = dataType;
            }
        }

        public void AddParameters(int index, string paramName, object objValue, ParameterDirection paramDirection)
        {
            if (index < Parameters.Length)
            {
                Parameters[index].ParameterName = paramName;
                Parameters[index].Value = objValue;
                Parameters[index].Direction = paramDirection;
            }
        }

        public void BeginTransaction()
        {
            if (Transaction == null)
            {
                //this.Transaction = DBManagerFactory.GetTransaction(this.ProviderType);
                Transaction = Connection.BeginTransaction();
            }

            Command.Transaction = Transaction;
        }

        public void CommitTransaction()
        {
            if (Transaction != null)
                Transaction.Commit();
            Transaction = null;
        }

        public void RoolBackTransaction()
        {
            if (Transaction != null)
                Transaction.Rollback();
            Transaction = null;
        }

        public void CloseReader()
        {
            if (DataReader != null)
                DataReader.Close();
        }

        public IDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            Command = DBManagerFactory.GetCommand(ProviderType);
            Command.CommandTimeout = 0; // alican
            PrepareCommand(commandType, commandText);
            DataReader = Command.ExecuteReader();
            Command.Parameters.Clear();
            return DataReader;
        }

        private void PrepareCommand(CommandType commandType, string commandText)
        {
            Command.Connection = Connection;
            Command.CommandText = commandText;
            Command.CommandType = commandType;

            if (Transaction != null)
                Command.Transaction = Transaction;

            if (Parameters != null)
                AttachParameters();
        }

        private void AttachParameters()
        {
            foreach (IDbDataParameter idbParameter in Parameters)
            {
                if (idbParameter.Direction == ParameterDirection.InputOutput && idbParameter.Value == null)
                    idbParameter.Value = DBNull.Value;

                Command.Parameters.Add(idbParameter);
            }
        }

        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            Command = DBManagerFactory.GetCommand(ProviderType);
            Command.CommandTimeout = 0; // alican
            PrepareCommand(commandType, commandText);
            IDbDataAdapter dataAdapter = DBManagerFactory.GetDataAdapter(ProviderType);
            dataAdapter.SelectCommand = Command;
            DataSet dataSet = new DataSet();
            dataAdapter.Fill(dataSet);
            Command.Parameters.Clear();
            return dataSet;
        }

        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            Command = DBManagerFactory.GetCommand(ProviderType);
            Command.CommandTimeout = 0; // alican
            PrepareCommand(commandType, commandText);
            object returnValue = Command.ExecuteScalar();
            Command.Parameters.Clear();
            return returnValue;
        }

        public int ExecuteNonQuery(CommandType commandType, string commandText)
        {
            int affectedRows = 0;
            Command = DBManagerFactory.GetCommand(ProviderType);
            Command.CommandTimeout = 0; // alican
            PrepareCommand(commandType, commandText);
            affectedRows = Command.ExecuteNonQuery();
            Command.Parameters.Clear();
            return affectedRows;
        }



        ConnectionState IDBManager.ConnectionState
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
