using Microsoft.Data.SqlClient;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Threading;

namespace LineStatusClient.Common
{
    public static class SQLHelper<T> where T : class, new()
    {
        private static readonly string connectionString = Settings.connectionString;
        public static int Timeout = 2000;
        public static T ProcedureToModel(string procedureName, string[] paramName, object[] paramValue)
        {
            T model = new T();
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                SqlDataReader reader = mySqlCommand.ExecuteReader();
                model = reader.MapToSingle<T>();
            }
            catch
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return model;
        }

        public static List<T> ProcedureToList(string procedureName, string[] paramName, object[] paramValue)
        {
            List<T> lst = new List<T>();
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            SqlParameter sqlParam;
            mySqlConnection.Open();

            try
            {
                SqlCommand mySqlCommand = new SqlCommand(procedureName, mySqlConnection);
                mySqlCommand.CommandType = CommandType.StoredProcedure;
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        mySqlCommand.Parameters.Add(sqlParam);
                    }
                }
                SqlDataReader reader = mySqlCommand.ExecuteReader();
                lst = reader.MapToList<T>();
            }
            catch
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return lst;
        }

        public static T SqlToModel(string sql)
        {
            T model = new T();
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            mySqlConnection.Open();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand(sql, mySqlConnection);
                mySqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = mySqlCommand.ExecuteReader();
                model = reader.MapToSingle<T>();
            }
            catch
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return model;
        }

        public static List<T> SqlToList(string sql)
        {
            List<T> lst = new List<T>();
            SqlConnection mySqlConnection = new SqlConnection(connectionString);
            mySqlConnection.Open();
            try
            {
                SqlCommand mySqlCommand = new SqlCommand(sql, mySqlConnection);
                mySqlCommand.CommandType = CommandType.Text;
                SqlDataReader reader = mySqlCommand.ExecuteReader();
                lst = reader.MapToList<T>();
            }
            catch
            {
                throw;
            }
            finally
            {
                mySqlConnection.Close();
            }

            return lst;
        }

        public static void DeleteModelByID(Int64 id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            T model = new T();
            Type type = model.GetType();
            string tableName = type.Name.StartsWith("Model") ? type.Name : type.Name.Replace("Model", "");
            try
            {
                string sql = string.Format("DELETE FROM [{0}] WHERE ID = {1}", tableName, id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = Timeout;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
        public static void DeleteByAttribute(string name, Int64 value)
        {
            T model = new T();
            Type type = model.GetType();
            string tableName = type.Name.StartsWith("Model") ? type.Name : type.Name.Replace("Model", "");
            string sql = DBUtils.SQLDelete(tableName, name, value);
            ExcuteNonQuerySQL(sql);
        }

        public static int ExcuteNonQuerySQL(string sql)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 6000;
            try
            {
                cmd.Connection.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (SqlException se)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }

        public static T FindByID(Int64 id)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            T model = new T();
            Type type = model.GetType();
            string tableName = type.Name.StartsWith("Model") ? type.Name : type.Name.Replace("Model", "");
            try
            {
                string sql = string.Format("SELECT top 1 * FROM [{0}] with (nolock) WHERE ID = {1}", tableName, id);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = Timeout;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                model = reader.MapToSingle<T>();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                conn.Close();
            }
            return model;
        }

        public static List<T> FindByAttribute(string fieldName, object fieldValue)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<T> lst = new List<T>();
            T model = new T();
            Type type = model.GetType();
            string tableName = type.Name.StartsWith("Model") ? type.Name : type.Name.Replace("Model", "");
            try
            {
                string sql = DBUtils.SQLSelect(tableName, fieldName, fieldValue);
                //string sql = $"SELECT * FROM {tableName} with (nolock)  WHERE {fieldName} = {fieldValue}";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = Timeout;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lst = reader.MapToList<T>();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return lst;
        }

        public static List<T> FindByExpression(Expression exp)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<T> lst = new List<T>();
            T model = new T();
            Type type = model.GetType();
            string tableName = type.Name.StartsWith("Model") ? type.Name : type.Name.Replace("Model", "");
            try
            {
                string sql = DBUtils.SQLSelect(tableName, exp);
                SqlCommand cmd = new SqlCommand(sql, conn);
                ////cmd.CommandTimeout = Timeout;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lst = reader.MapToList<T>();
                reader.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }

            return lst;
        }

        public static List<T> FindAll()
        {
            SqlConnection conn = new SqlConnection(connectionString);
            List<T> lst = new List<T>();
            T model = new T();
            Type type = model.GetType();
            string tableName = type.Name.StartsWith("Model") ? type.Name : type.Name.Replace("Model", "");
            try
            {
                string sql = string.Format("SELECT * FROM [{0}] with (nolock)", tableName);
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = Timeout;
                cmd.CommandType = CommandType.Text;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lst = reader.MapToList<T>();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
                conn.Close();
            }

            return lst;
        }

        public static string SQLInsert(T model)
        {
            Type type = model.GetType();
            string tableName = type.Name.Contains("Model") ? type.Name : type.Name.Replace("Model", "");

            string Insert = "insert into " + tableName + " (";
            PropertyInfo[] pis = type.GetProperties();

            for (int i = 0; i < pis.Length; i++)
            {
                if (!pis[i].Name.Equals("ID"))
                {
                    Insert = Insert + pis[i].Name;
                    Insert = Insert + ",";
                }
            }
            Insert = Insert.Substring(0, Insert.Length - 1);
            Insert = Insert + ") values (";
            for (int i = 0; i < pis.Length; i++)
            {
                if (!pis[i].Name.Equals("ID"))
                {
                    Insert = Insert + "@";
                    Insert = Insert + pis[i].Name;
                    Insert = Insert + ",";
                }
            }
            Insert = Insert.Substring(0, Insert.Length - 1);
            Insert = Insert + ") Select Scope_Identity()";
            return Insert;
        }

        public static string SQLUpdate(T model, string[] whereColumns = null, string[] updateColumns = null)
        {
            Type type = model.GetType();
            string tableName = type.Name.Contains("Model") ? type.Name : type.Name.Replace("Model", "");
            string Update = "UPDATE " + tableName + " SET ";
            PropertyInfo[] pis = type.GetProperties();
            if (updateColumns == null)
            {

                for (int i = 0; i < pis.Length; i++)
                {
                    if (!pis[i].Name.Equals("ID"))
                    {
                        Update = Update + pis[i].Name;
                        Update = Update + "=@" + pis[i].Name;
                        Update = Update + ",";
                    }
                }
            }
            else
            {
                foreach (var column in updateColumns)
                {
                    Update += $" {column} = @{column} ";
                }
            }
            Update = Update.Substring(0, Update.Length - 1);
            if (type.GetProperty("ID") != null)
                Update = Update + " WHERE ID=" + type.GetProperty("ID").GetValue(model, null).ToString();
            else
            {
                if (whereColumns == null || whereColumns.Length == 0) throw new ArgumentException("Keys were not found.");
                Update += " WHERE ";
                foreach (var column in whereColumns)
                {
                    Update += $" {column} = @{column}Where AND ";
                }
                Update = Update.Substring(0, Update.Length - 5);
            }
            return Update;
        }

        public static void Insert(T model, string userName = "")
        {
            Type type = model.GetType();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = SQLInsert(model);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                PropertyInfo[] propertiesName = type.GetProperties();
                for (int i = 0; i < propertiesName.Length; i++)
                {
                    object value = propertiesName[i].GetValue(model, null);

                    if (!propertiesName[i].Name.Equals("ID") && !propertiesName[i].Name.Equals("iD"))
                    {
                        if (propertiesName[i].Name.ToLower().Equals("createdby") || propertiesName[i].Name.ToLower().Equals("updatedby"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.NVarChar).Value = userName;
                        }
                        else if (propertiesName[i].Name.ToLower().Equals("createddate") || propertiesName[i].Name.ToLower().Equals("updateddate"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.DateTime).Value = DateTime.Now;
                        }
                        else if (value != null)
                        {
                            if (propertiesName[i].PropertyType.Equals(typeof(DateTime)))
                            {
                                if ((DateTime)value == DateTime.MinValue)
                                    value = new DateTime(1900, 01, 01);
                            }
                            if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                            }
                            else
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, ConvertToSQLType(propertiesName[i].PropertyType)).Value = value;
                            }
                        }
                        else
                        {
                            if (propertiesName[i].PropertyType.Equals(typeof(DateTime?)))
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, ConvertToSQLType(propertiesName[i].PropertyType)).Value = DBNull.Value;
                            }
                            else
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, ConvertToSQLType(propertiesName[i].PropertyType)).Value = "";
                            }
                        }
                    }
                }

                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
                conn.Dispose();
            }
        }
        public static ResultQuery UpdateModel(T model)
        {
            ResultQuery r = new ResultQuery();
            r.TotalRow = 0;
            Type type = model.GetType();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = SQLUpdate(model);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandTimeout = Timeout;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                PropertyInfo[] propertiesName = type.GetProperties();
                for (int i = 0; i < propertiesName.Length; i++)
                {
                    SqlDbType dbType = ConvertToSQLType(propertiesName[i].PropertyType);
                    object value = propertiesName[i].GetValue(model, null);

                    if (propertiesName[i].Name.ToLower().Equals("updatedby"))
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.NVarChar).Value = (value ?? "");
                    }
                    else if (propertiesName[i].Name.ToLower().Equals("updateddate"))
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.DateTime).Value = DateTime.Now;
                    }
                    else if (propertiesName[i].Name.ToLower().Equals("userupdateid"))
                    {
                        cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Int).Value = (value ?? 0);
                    }
                    else if (value != null)
                    {
                        if (propertiesName[i].PropertyType.Equals(typeof(DateTime)))
                        {
                            if ((DateTime)value == DateTime.MinValue)
                                value = DateTime.MinValue;
                        }
                        if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = value;
                        }
                    }
                    else
                    {
                        if (propertiesName[i].PropertyType.Equals(typeof(DateTime?)))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = DBNull.Value;
                        }
                        else
                            cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = "";
                    }
                }
                conn.Open();
                r.TotalRow = cmd.ExecuteNonQuery();
                r.IsSuccess = true;
            }
            catch (Exception ex)
            {
                r.IsSuccess = false;
                r.ErrorText = ex.ToString();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
                conn.Dispose();
            }
            return r;
        }

        public static void Update(T model, string[] whereColumns = null, string[] updateColumns = null, string userName = "")
        {
            Type type = model.GetType();
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                string sql = SQLUpdate(model, whereColumns, updateColumns);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandTimeout = 60;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                PropertyInfo[] propertiesName = type.GetProperties();
                if (updateColumns == null)
                {
                    for (int i = 0; i < propertiesName.Length; i++)
                    {
                        SqlDbType dbType = ConvertToSQLType(propertiesName[i].PropertyType);
                        object value = propertiesName[i].GetValue(model, null);

                        if (propertiesName[i].Name.ToLower().Equals("updatedby"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.NVarChar).Value = userName;
                        }
                        else if (propertiesName[i].Name.ToLower().Equals("updateddate"))
                        {
                            cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.DateTime).Value = DateTime.Now;
                        }
                        else if (value != null)
                        {
                            if (propertiesName[i].PropertyType.Equals(typeof(DateTime)))
                            {
                                if ((DateTime)value == DateTime.MinValue)
                                    value = new DateTime(1900, 01, 01);
                            }
                            if (propertiesName[i].PropertyType.Name.Equals("Byte[]"))
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, SqlDbType.Image).Value = value;
                            }
                            else
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = value;
                            }
                        }
                        else
                        {
                            if (propertiesName[i].PropertyType.Equals(typeof(DateTime?)))
                            {
                                cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = DBNull.Value;
                            }
                            else
                                cmd.Parameters.Add("@" + propertiesName[i].Name, dbType).Value = "";
                        }
                    }
                }
                else
                {
                    foreach (var col in updateColumns)
                    {
                        PropertyInfo prop = type.GetProperty(col) ?? throw new ArgumentException($"Property '{col}' not found on type '{type}'.");
                        cmd.Parameters.Add("@" + col, ConvertToSQLType(prop.PropertyType)).Value = prop.GetValue(model);
                    }
                }

                if (whereColumns != null)
                {
                    foreach (var col in whereColumns)
                    {
                        PropertyInfo prop = type.GetProperty(col) ?? throw new ArgumentException($"Property '{col}' not found on type '{type}'.");
                        cmd.Parameters.Add($"@{col}WHERE", ConvertToSQLType(prop.PropertyType)).Value = prop.GetValue(model);
                    }
                }
                conn.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch
            {
                throw;
            }
            finally
            {
                if (conn.State != ConnectionState.Closed) conn.Close();
                conn.Dispose();
            }
        }

        public static bool DoesExist(T model, string[] columns)
        {
            string tableName = typeof(T).Name;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = SQLExist(tableName, columns);

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var column in columns)
                    {
                        var property = typeof(T).GetProperty(column);
                        if (property != null)
                        {
                            command.Parameters.Add($"@{column}", ConvertToSQLType(property.PropertyType)).Value = property.GetValue(model) ?? DBNull.Value;
                        }
                    }

                    object result = command.ExecuteScalar();
                    return result != null && (int)result > 0;
                }
            }
        }

        private static string SQLExist(string tableName, string[] columns)
        {
            var conditions = new List<string>();
            foreach (var column in columns)
            {
                conditions.Add($"{column} = @{column}");
            }
            string whereClause = string.Join(" AND ", conditions);

            return $"SELECT COUNT(*) FROM {tableName} WHERE {whereClause}";
        }

        public static SqlDbType ConvertToSQLType(Type type)
        {
            if (type == typeof(string))
            {
                return SqlDbType.NVarChar;
            }
            if (type == typeof(int))
            {
                return SqlDbType.Int;
            }
            if (type == typeof(short))
            {
                return SqlDbType.TinyInt;
            }
            if (type == typeof(long))
            {
                return SqlDbType.BigInt;
            }
            if (type == typeof(DateTime))
            {
                return SqlDbType.DateTime;
            }
            if (type == typeof(DateTime?))
            {
                return SqlDbType.DateTime;
            }
            if (type == typeof(long))
            {
                return SqlDbType.BigInt;
            }
            if (type == typeof(decimal))
            {
                return SqlDbType.Decimal;
            }
            if (type == typeof(byte[]))
            {
                return SqlDbType.Image;
            }
            if (type == typeof(Guid))
            {
                return SqlDbType.UniqueIdentifier;
            }
            if (type == typeof(byte[]))
            {
                return SqlDbType.VarBinary;
            }
            return SqlDbType.NVarChar;
        }
    }

    public class ResultQuery
    {
        public int ID { get; set; }
        public int TotalRow { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorText { get; set; }
    }
}