using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DAK_MVC.Models
{
    public class DataAccess
    {
        private string m_ConnectionString;
        private int m_Timeout;

        public int TimeOut { get; private set; }

        public DataAccess()
        {
            m_ConnectionString = ConfigurationManager.ConnectionStrings["CSConnString"].ConnectionString;
         
            try
            {
                m_Timeout =5000;//System.Convert.ToInt32(Globals.GetConfig("CommandTimeOut"));
            }
            catch
            {
                m_Timeout = 0;
            }

        }
        protected int ExecuteNonQuery(SqlCommand cmd)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    cmd.Connection = cn;
                    cmd.CommandTimeout = TimeOut;
                    return cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + cmd.CommandText + ": " + ex.Message);
                return -1;
            }
        }

        protected SqlDataReader ExecuteReader(SqlCommand cmd)
        {
            return ExecuteReader(cmd, CommandBehavior.Default);
        }

        protected SqlDataReader ExecuteReader(SqlCommand cmd, CommandBehavior behavior)
        {
            return cmd.ExecuteReader(behavior);
        }

        protected object ExecuteScalar(SqlCommand cmd)
        {
            return cmd.ExecuteScalar();
        }
        public DataSet ExecuteDataset(string strSQL)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = Globals.g_CommandTimeOut;
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataSet dst = new DataSet();
                    adap.Fill(dst);
                    return dst;
                }
            }
            catch (System.Exception e)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + e.Message);
                return null;
            }
        }

        public DataSet ExecuteDataset(string[] strSQL)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    DataSet dst = new DataSet();
                    foreach (string sql in strSQL)
                    {
                        SqlCommand cmd = new SqlCommand(sql, cn);
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = Globals.g_CommandTimeOut;
                        SqlDataAdapter adap = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adap.Fill(dt);
                        dst.Tables.Add(dt);
                    }
                    return dst;
                }
            }
            catch (System.Exception e)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + e.Message);
                return null;
            }
        }

        protected DataSet ExecuteDataset_Store(string strSQL, SqlParameter[] sqlParams)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = TimeOut;

                    foreach (SqlParameter param in sqlParams)
                        cmd.Parameters.Add(param);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    DataSet dst = new DataSet();
                    adap.Fill(dst);
                    return dst;
                }
            }
            catch (Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
            }
            return null;

        }

        protected bool ExecuteNonQuery(string strSQL)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = TimeOut;
                    return cmd.ExecuteNonQuery() >= 0;
                }
            }
            catch (Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
                return false;
            }
        }
        protected bool ExecuteNonQuery(string strSQL, SqlParameter[] sqlParams)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = TimeOut;
                    foreach (SqlParameter param in sqlParams)
                        cmd.Parameters.Add(param);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
                return false;
            }
        }
        protected SqlDataReader ExecuteReader(string strSQL)
        {
            try
            {
                SqlConnection cn = new SqlConnection(m_ConnectionString);
                cn.Open();
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = TimeOut;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                //WriteLog:
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
                return null;
                //throw;
            }
            catch
            {
                return null;
            }
        }
        protected object ExecuteScalar(string strSQL)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = TimeOut;
                    return cmd.ExecuteScalar();
                }
            }
            catch (System.Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
                return null;
            }
        }

        protected object ExecuteScalar_Store(string strSQL, SqlParameter[] cmdParams)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = TimeOut;

                    for (int i = 0; i < cmdParams.Length; i++)
                        cmd.Parameters.Add(cmdParams[i]);

                    return cmd.ExecuteScalar();
                }
            }
            catch (System.Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
                return null;
            }
        }

        public bool ExecuteProcedure(string procName, SqlParameter[] cmdParams)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(procName, cn);
                    cmd.CommandTimeout = TimeOut;
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter myParm = cmd.Parameters.Add("@RetValue", SqlDbType.Int);
                    myParm.Direction = ParameterDirection.ReturnValue;
                    for (int i = 0; i < cmdParams.Length; i++)
                        cmd.Parameters.Add(cmdParams[i]);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - Procedure: " + ex.Message);
                return false;
            }
        }

        protected SqlDataReader ExecuteReader_Store(string strSQL, SqlParameter[] sqlParams)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(m_ConnectionString))
                {
                    cn.Open();
                    SqlCommand cmd = new SqlCommand(strSQL, cn);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = TimeOut;
                    foreach (SqlParameter param in sqlParams)
                        cmd.Parameters.Add(param);
                    return cmd.ExecuteReader();
                }
            }
            catch (Exception ex)
            {
                Globals.WriteLog_New("ErrorSQL.log", DateTime.UtcNow.ToString() + " - " + strSQL + ": " + ex.Message);
                return null;
            }
        }
    }
}