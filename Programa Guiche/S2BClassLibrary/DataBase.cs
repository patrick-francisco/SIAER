using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SIAERClassLibrary
{
    public abstract class DataBase
    {
        #region ConnectionString

        //public static readonly string CONN_STRING = @"Data Source=siaerserver;Initial Catalog=SIAER;Integrated Security=True";
       // public static readonly string CONN_STRING = @"Data Source=vmsiaer01;Initial Catalog=SIAERTESTE;Integrated Security=True";
        public static readonly string CONN_STRING = @"Data Source=VMSIAER01;Initial Catalog=SIAERTESTE;Integrated Security=True";
        
        #endregion

        #region ExecuteNonQuery
        public static int ExecuteNonQuery(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                try
                {
                    PrepareParameters(cmdParms);
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    return val;
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw (ex);
                }
            }
        }
        public static int ExecuteNonQuery(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareParameters(cmdParms);
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }
        #endregion

        #region ExecuteNonQueryCmd
        public static SqlCommand ExecuteNonQueryCmd(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                try
                {
                    PrepareParameters(cmdParms);
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    int val = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw (ex);
                }
            }
            return cmd;
        }
        public static SqlCommand ExecuteNonQueryCmd(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareParameters(cmdParms);
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            int val = cmd.ExecuteNonQuery();
            return cmd;
        }
        #endregion

        #region ExecuteReader
        public static SqlDataReader ExecuteReader(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlDataReader dr = null;
            SqlConnection conn = new SqlConnection(CONN_STRING);
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                conn.Close();
                conn.Dispose();
                throw (ex);
            }
            return dr;
        }
        public static SqlDataReader ExecuteReader(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlDataReader dr = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareParameters(cmdParms);
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                dr = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return dr;
        }
        #endregion

        #region ExecuteReaderDs
        public static DataSet ExecuteReaderDs(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    PrepareParameters(cmdParms);
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw (ex);
                }
            }
            return ds;
        }
        public static DataSet ExecuteReaderDs(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand();
                PrepareParameters(cmdParms);
                PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                cmd.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return ds;
        }
        #endregion

        #region ExecuteScalar
        public static object ExecuteScalar(CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            object obj = new object();
            using (SqlConnection conn = new SqlConnection(CONN_STRING))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    PrepareParameters(cmdParms);
                    PrepareCommand(cmd, conn, null, cmdType, cmdText, cmdParms);
                    obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw (ex);
                }
            }
            return obj;
        }
        public static object ExecuteScalar(SqlTransaction trans, CommandType cmdType, string cmdText, params SqlParameter[] cmdParms)
        {
            SqlCommand cmd = new SqlCommand();
            PrepareParameters(cmdParms);
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParms);
            object obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return obj;
        }
        #endregion

        #region PrepareCommand
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();

            cmd.Connection = conn;
            cmd.CommandText = cmdText;

            if (trans != null)
                cmd.Transaction = trans;

            cmd.CommandType = cmdType;

            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    if (cmd.Parameters.Contains(parm))
                        cmd.Parameters[parm.ParameterName] = parm;
                    else
                        cmd.Parameters.Add(parm);
                }
            }
        }
        #endregion

        #region PrepareParameters
        private static void PrepareParameters(SqlParameter[] cmdParms)
        {
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                {
                    if ((parm.DbType.Equals(DbType.AnsiString) || parm.DbType.Equals(DbType.AnsiStringFixedLength)) && parm.Value != DBNull.Value)
                    {
                        parm.Value = RemoveQuote(parm.Value.ToString());
                        if (parm.Value.ToString() == String.Empty)
                            parm.Value = DBNull.Value;
                    }
                }
            }
        }
        #endregion

        #region RemoveQuote
        private static string RemoveQuote(string text)
        {
            text = text.Replace("'", String.Empty);
            text = text.Replace("\"", String.Empty);
            text = text.Replace("´", String.Empty);
            return text;
        }
        #endregion
    }
}