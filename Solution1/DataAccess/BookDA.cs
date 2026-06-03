using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public static class BookDA
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter sda;

        static BookDA()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["BookConnection"].ConnectionString);
            cmd = new SqlCommand();
            cmd.Connection = con;
            sda = new SqlDataAdapter();
        }

        /// <summary>
        /// 执行数据库的增删改操作
        /// </summary>
        /// <param name="sqlText">Sql语句或者存储过程名</param>
        /// <param name="commandType">cmd命令类型</param>
        /// <param name="paramNames">参数名数组</param>
        /// <param name="paramValues">参数值数组</param>
        /// <returns>返回数据库受影响的行数</returns>
        public static int ExcuteSqlCommand(string cmdText, CommandType commandType, string[] paramNames, object[] paramValues)
        {
            cmd.CommandText = cmdText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();
            if (paramNames != null)
                for (int i = 0; i < paramNames.Length; i++)
                {
                    cmd.Parameters.AddWithValue(paramNames[i], paramValues[i]);
                }
            if (con.State != ConnectionState.Open)
                con.Open();
            int n = cmd.ExecuteNonQuery();
            con.Close();
            return n;
        }

        /// <summary>
        /// 执行数据表的查询操作（返回查询的结果集）
        /// </summary>
        /// <param name="cmdText">sql命令或存储过程名</param>
        /// <param name="commandType">cmd命令类型</param>
        /// <param name="paramNames">参数名数组</param>
        /// <param name="paramValues">参数值数组</param>
        /// <returns>查询的数据表</returns>
        public static DataTable GetDataTable(string cmdText, CommandType commandType, string[] paramNames, object[] paramValues)
        {
            cmd.CommandText = cmdText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();
            if (paramNames != null)
                for (int i = 0; i < paramNames.Length; i++)
                {
                    cmd.Parameters.AddWithValue(paramNames[i], paramValues[i]);
                }
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        /// <summary>
        /// 执行包含输出参数的增删改操作（sql命令或存储过程）
        /// </summary>
        /// <param name="cmdText">sql命令或存储过程名</param>
        /// <param name="commandType">cmd命令类型</param>
        /// <param name="paramNames">参数名数组</param>
        /// <param name="paramValues">参数值数组</param>
        /// <param name="flag">输出型参数</param>
        /// <param name="sqlDbType">数据库中输出型参数类型</param>
        /// <returns>数据库中受影响的行数</returns>
        public static int ExcuteSqlCommand(string cmdText, CommandType commandType, string[] paramNames, object[] paramValues, out object flag, SqlDbType sqlDbType)
        {
            cmd.CommandText = cmdText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();
            if (paramNames != null)
                for (int i = 0; i < paramNames.Length; i++)
                {
                    cmd.Parameters.AddWithValue(paramNames[i], paramValues[i]);
                }
            cmd.Parameters.Add(new SqlParameter("@flag", sqlDbType));
            cmd.Parameters["@flag"].Direction = ParameterDirection.Output;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            int n = cmd.ExecuteNonQuery();
            flag = cmd.Parameters["@flag"].Value;
            con.Close();
            return n;
        }


        /// <summary>
        /// 执行数据表的查询操作（sql命令或存储过程），返回单一值。
        /// </summary>
        /// <param name="cmdText">sql命令或存储过程名</param>
        /// <param name="commandType">cmd命令类型</param>
        /// <param name="paramNames">参数名数组</param>
        /// <param name="paramValues">参数值数组</param>
        /// <returns>查询结果集中的首行首列值</returns>
        public static object ExecuteSqlCommand2(string cmdText, CommandType commandType,
                                         string[] paramNames, object[] paramValues) {
            cmd.CommandText = cmdText;
            cmd.CommandType = commandType;
            cmd.Parameters.Clear();

            if (paramNames != null) {
                for (int i = 0; i < paramNames.Length; i++) {
                    cmd.Parameters.AddWithValue(paramNames[i], paramValues[i] ?? DBNull.Value);
                }
            }

            if (con.State != ConnectionState.Open)
                con.Open();

            object result = cmd.ExecuteScalar();
            con.Close();
            return result;
        }
    }
}

