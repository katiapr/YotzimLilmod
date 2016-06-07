//#region
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Diagnostics;
using System.Text;

//#endregion

namespace YotzimLilmod.MySQL
{
    internal sealed class ManageSql
    {
        
        private static OdbcConnection odbcConnection;
        private static OdbcCommand odbcCommand;
        private static OdbcDataReader dr;
        private ManageSql()
        {
        }
        private static void ConnectToDB(string connectionString)
        {
            odbcConnection = new OdbcConnection(connectionString);
            if (odbcConnection.State == ConnectionState.Closed)
            {
                odbcConnection.Open();
            }
        }
        public static OdbcDataReader ExecuteReader(string command, string connectionString)
        {
            var st = Stopwatch.StartNew();
            try
            {
                st.Start();
                ConnectToDB(connectionString);
                if (odbcConnection.State == ConnectionState.Open)
                {
                    odbcCommand = new OdbcCommand(command, odbcConnection);
                    dr = odbcCommand.ExecuteReader();
                    st.Stop();
                }
            }
            catch (OdbcException ex)
            {
                return null;
            }
            return dr;
        }

        /// <summary>
        /// Executes the sp.
        /// </summary>
        /// <param name="procedure_name">The procedure_name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static DataTable ExecuteSP(string procedure_name, string connectionString,
            List<MySqlParameter> parameters)
        {

            var st = Stopwatch.StartNew();
            try
            {
                if (parameters == null)
                    parameters = new List<MySqlParameter>();

                var cnx = new MySqlConnection(connectionString);

                cnx.Open();
                if (cnx.State == ConnectionState.Open)
                {
                    var adapter = new MySqlDataAdapter();
                    // Create a SQL command object
                    var cmdText = procedure_name;
                    var cmd = new MySqlCommand(cmdText, cnx);

                    // Set the command type to StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);
                    // Create and fill a DataSet
                    var ds = new DataSet();
                    adapter.SelectCommand = cmd;
                    st.Start();
                    adapter.Fill(ds);
                    st.Stop();
                    cnx.Close();

                    if (ds.Tables.Count == 1)
                        return ds.Tables[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static DataTable ExecuteSP(string procedure_name, string connectionString,
           List<MySqlParameter> parameters, int commandTimeout)
        {

            var st = Stopwatch.StartNew();
            try
            {
                if (parameters == null)
                    parameters = new List<MySqlParameter>();

                var cnx = new MySqlConnection(connectionString);

                cnx.Open();
                if (cnx.State == ConnectionState.Open)
                {
                    var adapter = new MySqlDataAdapter();
                    // Create a SQL command object
                    var cmdText = procedure_name;
                    var cmd = new MySqlCommand(cmdText, cnx);
                    cmd.CommandTimeout = commandTimeout;
                    // Set the command type to StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);
                    // Create and fill a DataSet
                    var ds = new DataSet();
                    adapter.SelectCommand = cmd;
                    st.Start();
                    adapter.Fill(ds);
                    st.Stop();
                    cnx.Close();

                    if (ds.Tables.Count == 1)
                        return ds.Tables[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="procedure_name">The procedure_name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="parameters">The parameters.</param>
        public static object ExecuteScalar(string procedure_name, string connectionString, List<MySqlParameter> parameters)
        {
            var st = Stopwatch.StartNew();
            object res = null;
            try
            {
                if (parameters == null)
                    parameters = new List<MySqlParameter>();

                var cnx = new MySqlConnection(connectionString);
                cnx.Open();
                if (cnx.State == ConnectionState.Open)
                {
                    var adapter = new MySqlDataAdapter();

                    // Create a SQL command object
                    var cmdText = procedure_name;
                    var cmd = new MySqlCommand(cmdText, cnx);

                    // Set the command type to StoredProcedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var param in parameters)
                        cmd.Parameters.Add(param);
                    res = cmd.ExecuteScalar();
                    st.Start();
                    st.Stop();
                    cnx.Close();

                }
                return res;
            }
            catch (OdbcException ex)
            {
                return null;
            }
        }
    }
}
