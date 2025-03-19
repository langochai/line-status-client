using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;

namespace LineStatusClient.Common
{
    public static class SQLUtilities
    {
        private static readonly IDictionary<Type, ICollection<PropertyInfo>> _Properties = new Dictionary<Type, ICollection<PropertyInfo>>();

        public class Status
        {
            public int key { get; set; }
            public string text { get; set; }

            public Status()
            {
            }

            public Status(int key, string text)
            {
                this.key = key;
                this.text = text;
            }
        }

        /// <summary>
        /// Convert object to string
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string ToString(object x)
        {
            try
            {
                return Convert.ToString(x);
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Convert object to int
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static int ToInt(object x)
        {
            try
            {
                return Convert.ToInt32(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert object to float
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static float ToFloat(object x)
        {
            try
            {
                return Convert.ToSingle(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert object to decimal
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static decimal ToDecimal(object x)
        {
            try
            {
                return Convert.ToDecimal(x);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Convert object to bool
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static bool ToBoolean(object x)
        {
            try
            {
                return Convert.ToBoolean(x);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convert object to Datetime VN
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static DateTime? ToDateVN(object x)
        {
            string date = "";
            if (x != null)
            {
                date = x.ToString();
            }
            try
            {
                try
                {
                    return DateTime.Parse(date, new CultureInfo("vi-VN", true));
                }
                catch
                {
                    return DateTime.Parse(date, new CultureInfo("fr-FR", true));
                }
            }
            catch
            {
                return null;
            }
        }

        public static string DateTimeOffsetToTimeString(object input)
        {
            try
            {
                if (input is DateTimeOffset dto)
                    return dto.ToString("HH:mm:ss");

                if (input is DateTime dt)
                    return dt.ToString("HH:mm:ss");

                if (input is string str)
                {
                    if (DateTimeOffset.TryParse(str, out var parsedDto))
                        return parsedDto.ToString("HH:mm:ss");

                    if (DateTime.TryParse(str, out var parsedDt))
                        return parsedDt.ToString("HH:mm:ss");
                }

                if (input is long ticks)
                {
                    var dateTime = new DateTimeOffset(ticks, TimeSpan.Zero);
                    return dateTime.ToString("HH:mm:ss");
                }
            }
            catch
            {
                return null;
            }
            return null;
        }



        public static DateTimeOffset? ToDateTimeOffset(object input, TimeSpan? defaultOffset = null)
        {
            try
            {
                if (input == null)
                    return null;

                if (input is DateTimeOffset dto)
                    return dto;

                if (input is DateTime dt)
                    return new DateTimeOffset(dt, defaultOffset ?? TimeSpan.Zero);

                if (input is TimeSpan time)
                    return new DateTimeOffset(DateTime.Today.Add(time), defaultOffset ?? TimeSpan.Zero);

                if (input is long ticks)
                    return new DateTimeOffset(ticks, defaultOffset ?? TimeSpan.Zero);

                if (input is string str)
                {
                    // Thử parse theo DateTimeOffset
                    if (DateTimeOffset.TryParse(str, out DateTimeOffset parsedDto))
                        return parsedDto;

                    // Thử parse theo DateTime
                    if (DateTime.TryParse(str, out DateTime parsedDt))
                        return new DateTimeOffset(parsedDt, defaultOffset ?? TimeSpan.Zero);

                    // Trường hợp chuỗi chỉ chứa "HH:mm:ss"
                    if (TimeSpan.TryParse(str, out TimeSpan parsedTime))
                        return new DateTimeOffset(DateTime.Today.Add(parsedTime), defaultOffset ?? TimeSpan.Zero);
                }
            }
            catch (Exception)
            {
                return null; // Trả về null nếu không thể ép kiểu
            }
            return null;
        }






        /// <summary>
        /// Convert DataTable to List object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            try
            {
                List<T> data = new List<T>();
                foreach (DataRow row in dt.Rows)
                {
                    T item = GetItem<T>(row);
                    data.Add(item);
                }
                return data;
            }
            catch
            {
                throw;
            }
        }

        private static T GetItem<T>(DataRow dr)
        {
            string columnName = "";
            try
            {
                Type temp = typeof(T);
                T obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in dr.Table.Columns)
                {
                    foreach (PropertyInfo pro in temp.GetProperties())
                    {
                        if (pro.Name.ToUpper() == column.ColumnName.ToUpper())
                        {
                            columnName = column.ColumnName;
                            var value = Convert.IsDBNull(dr[column.ColumnName]) ? null : dr[column.ColumnName];
                            pro.SetValue(obj, value, null);
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                return obj;
            }
            catch
            {
                throw;
            }
        }

        public static void ExcuteProcedure(string storeProcedureName, string[] paramName, object[] paramValue)
        {
            var cn = new SqlConnection(Settings.connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(storeProcedureName, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                SqlParameter sqlParam;
                cn.Open();
                if (paramName != null)
                {
                    for (int i = 0; i < paramName.Length; i++)
                    {
                        sqlParam = new SqlParameter(paramName[i], paramValue[i]);
                        cmd.Parameters.Add(sqlParam);
                    }
                }
                cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Execute a SQL command.<br></br> 
        /// Note: Add parameters if Microsoft.Data.SqlClient version &lt; 3.0, otherwise string interpolation is acceptable.
        /// </summary>
        /// <param name="strSQL">SQL query to execute.</param>
        public static void ExcuteSQL(string strSQL)
        {
            SqlConnection cn = new SqlConnection(Settings.connectionString);
            try
            {
                SqlCommand cmd = new SqlCommand(strSQL, cn);
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 0;
                cn.Open();
                cmd.CommandText = strSQL;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }

        public static object ExecuteScalarQuery(string query, string[] paramNames, object[] paramValues)
        {
            paramNames = paramNames ?? new string[0];
            paramValues = paramValues ?? new object[0];
            if (paramNames.Length != paramValues.Length)
            {
                throw new ArgumentException("Parameter names and values count must match.");
            }

            using (SqlConnection mySqlConnection = new SqlConnection(Settings.connectionString))
            {
                mySqlConnection.Open();
                try
                {
                    using (SqlCommand mySqlCommand = new SqlCommand(query, mySqlConnection))
                    {
                        for (int i = 0; i < paramNames.Length; i++)
                        {
                            mySqlCommand.Parameters.AddWithValue(paramNames[i], paramValues[i]);
                        }

                        return mySqlCommand.ExecuteScalar();
                    }
                }
                catch
                {
                    throw;
                }
            }
        }

        public static int GetUniqueIdentity()
        {
            using (var connection = new SqlConnection(Settings.connectionString))
            {
                connection.Open();

                // Kiểm tra xem máy đã có identity chưa
                using (var command = new SqlCommand("SELECT Id FROM IdentityManager WHERE MachineName = @MachineName", connection))
                {
                    command.Parameters.AddWithValue("@MachineName", Environment.MachineName);
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        return (int)result; // Trả về ID đã cấp
                    }
                }

                // Nếu chưa có, tạo mới
                using (var command = new SqlCommand("INSERT INTO IdentityManager (MachineName) OUTPUT INSERTED.Id VALUES (@MachineName)", connection))
                {
                    command.Parameters.AddWithValue("@MachineName", Environment.MachineName);
                    return (int)command.ExecuteScalar(); // Lấy ID mới
                }
            }
        }

        /// <summary>
        /// Use this shit if the current time of DB is not correctly set
        /// </summary>
        /// <returns>Current time of database</returns>
        public static DateTime GetDate()
        {
            return Convert.ToDateTime(ExecuteScalarQuery("SELECT GETDATE()", null, null));
        }
    }
}