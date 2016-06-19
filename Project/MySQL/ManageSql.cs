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
        /// <summary>
        /// The ODBC connection
        /// </summary>
        private static OdbcConnection odbcConnection;
        /// <summary>
        /// The ODBC command
        /// </summary>
        private static OdbcCommand odbcCommand;
        /// <summary>
        /// The dr
        /// </summary>
        private static OdbcDataReader dr;

        /// <summary>
        /// Prevents a default instance of the <see cref="ManageSql"/> class from being created.
        /// </summary>
        private ManageSql()
        {
        }

        /// <summary>
        /// Connects to database.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        private static void ConnectToDB(string connectionString)
        {
            odbcConnection = new OdbcConnection(connectionString);
            if (odbcConnection.State == ConnectionState.Closed)
            {
                odbcConnection.Open();
            }
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
                //Console.WriteLine("KO;SQL GENERAL FAILURE:" + ex.Message + ex.InnerException + ";SQL Query Time : " +
                //                  st.ElapsedMilliseconds + " " + procedure_name + " " + FormatSqlParams(parameters));
                //if (Logger.Instance.IsFatalEnabled)
                //    Logger.Instance.Fatal("KO;SQL GENERAL FAILURE:" + ex.Message + ";SQL Query Time : " +
                //                          st.ElapsedMilliseconds);
                //throw ex;
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

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="procedure_name">The procedure_name.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(string procedure_name, string connectionString,
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
                    return ds;
                }
                return null;
            }
            catch (OdbcException ex)
            {
                return null;
            }
        }

        /// <summary>
        ///     Formats the SQL params.
        /// </summary>
        /// <param name="sqlParams">The SQL params.</param>
        /// <returns></returns>
        private static string FormatSqlParams(List<MySqlParameter> sqlParams)
        {
            var sb = new StringBuilder();
            foreach (var item in sqlParams)
            {
                sb.Append(item.Value).Append("^$^");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Executes the dynamic SQL.
        /// </summary>
        /// <param name="cmdText">The command text.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <returns></returns>
        internal static DataTable ExecuteDynamicSQL(string cmdText, string connectionString)
        {
            var st = Stopwatch.StartNew();
            try
            {
                var cnx = new MySqlConnection(connectionString);
                cnx.Open();
                if (cnx.State == ConnectionState.Open)
                {
                    var adapter = new MySqlDataAdapter();

                    // Create a SQL command object
                    var cmd = new MySqlCommand(cmdText, cnx);

                    // Set the command type to StoredProcedure
                    cmd.CommandType = CommandType.Text;

                    // Create and fill a DataSet
                    var ds = new DataSet();
                    adapter.SelectCommand = cmd;
                    st.Start();
                    adapter.Fill(ds);
                    st.Stop();
                    cnx.Close();
                    return ds.Tables.Count == 1 ? ds.Tables[0] : null;
                }
                return null;
            }
            catch (OdbcException ex)
            {
                return null;
            }
        }
    }
}
