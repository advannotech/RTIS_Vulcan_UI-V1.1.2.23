using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTIS_Vulcan_UI.Classes
{
    class DirectQueries
    {
        public static string getDatabasesWinAuth(string server)
        {
            try
            {
                string returnString = string.Empty;
                string sqlString = "Data Source=" + server + "; Integrated Security=True;";
                SqlConnection conn = new SqlConnection(sqlString);
                conn.Open();
                DataTable dbs = conn.GetSchema("Databases");
                foreach (DataRow db in dbs.Rows)
                {
                    if (db["database_name"].ToString() != string.Empty)
                    {
                        returnString += db["database_name"].ToString() + "~";
                    }
                }

                if (returnString != string.Empty)
                {
                    return "1*" + returnString;
                }
                else
                {
                    return "0*No databases were found on this server";
                }
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string getDatabasesSQLAuth(string server, string username, string password)
        {
            try
            {
                string returnString = string.Empty;
                string sqlString = "Data Source=" + server + ";" + "user ID=" + username + ";" + "password=" + password + ";Max Pool Size=99999;";
                SqlConnection conn = new SqlConnection(sqlString);
                conn.Open();
                DataTable dbs = conn.GetSchema("Databases");
                foreach (DataRow db in dbs.Rows)
                {
                    if (db["database_name"].ToString() != string.Empty)
                    {
                        returnString += db["database_name"].ToString() + "~";
                    }
                }

                if (returnString != string.Empty)
                {
                    return "1*" + returnString;
                }
                else
                {
                    return "0*No databases were found on this server";
                }
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string testConnSQLAuth(string server, string database, string username, string password)
        {
            try
            {
                string SQLString = "Data Source=" + server + ";" + "Initial Catalog=" + database +
                ";" + "user ID=" + username + ";" + "password=" + password + ";Max Pool Size=99999;";
                SqlConnection conn = new SqlConnection(SQLString);
                conn.Open();
                conn.Close();
                return "1";
            }
            catch (Exception)
            {
                return "-1";
            }
        }
        public static string testConnWinAuth(string server)
        {
            try
            {
                string SQLString = "Data Source=" + server + "; Integrated Security=True;";
                SqlConnection conn = new SqlConnection(SQLString);
                conn.Open();
                conn.Close();
                return "1";
            }
            catch (Exception)
            {
                return "-1";
            }
        }

        #region Stock Take
        public static string RTString = "Data Source=" + GlobalVars.SQLServer + "; Initial Catalog=" + GlobalVars.RTDB + "; user ID=" + GlobalVars.SqlUser + "; password=" + GlobalVars.SqlPass + ";Max Pool Size=99999;";
        public static DataTable stDT = new DataTable();
        public static DataTable stDTEnquiry = new DataTable();
        public static string UI_GetRTStockTakeLines(string stNum)
        {
            try
            {
                string returnData = string.Empty;
                SqlConnection conn = new SqlConnection(RTString);
                SqlCommand comm = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[vw_GetStockTakeVariances] 
                                                                WHERE [vw_GetStockTakeVariances].[cInvCountNo] = '{0}' 
                                                                ORDER BY
                                                                CASE WHEN([vw_GetStockTakeVariances].[gcSystem] - [vw_GetStockTakeVariances].[gcCounted]) < 0 THEN [vw_GetStockTakeVariances].[gcCounted]
                                                                WHEN([vw_GetStockTakeVariances].[gcCounted] - [vw_GetStockTakeVariances].[gcSystem]) < 0 THEN [vw_GetStockTakeVariances].[gcCounted] END DESC", stNum), conn);
                //comm.Parameters.Add(new SqlParameter("@1", stNum));
                conn.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("gclineID"));
                dt.Columns.Add(new DataColumn("gcItemCode"));
                dt.Columns.Add(new DataColumn("gcBarcode"));
                dt.Columns.Add(new DataColumn("gcItemDesc"));
                dt.Columns.Add(new DataColumn("gcBin"));
                dt.Columns.Add(new DataColumn("gcLot"));
                dt.Columns.Add(new DataColumn("gcCounted"));
                dt.Columns.Add(new DataColumn("gcCounted2"));
                dt.Columns.Add(new DataColumn("gcSystem"));
                dt.Columns.Add(new DataColumn("gcVarience"));
                dt.Columns.Add(new DataColumn("gcWhseCode"));
                dt.Columns.Add(new DataColumn("gcWhseName"));
                dt.Columns.Add(new DataColumn("gcIsCounted"));
                dt.Columns.Add(new DataColumn("gcOnST", typeof(bool)));

                using (SqlDataAdapter sda = new SqlDataAdapter(comm.CommandText, conn))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@1", stNum);
                    sda.Fill(dt);
                }
                stDT = dt;
                conn.Dispose();
                conn.Close();
                return "1*Success";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid attempt to read when no data is present.")
                {
                    return "0*No lines";
                }
                else
                {
                    return "-1*" + ex.Message;
                }
            }
        }

        public static string UI_GetRTEnquiryLines(string stNum)
        {
            try
            {
                string returnData = string.Empty;
                SqlConnection conn = new SqlConnection(RTString);
                SqlCommand comm = new SqlCommand(@"SELECT
                                                e.[iLineID] AS [gclineID]
                                                ,e.[vItemCode] AS [gcItemCode]
                                                , s.[Description_1] AS [gcItemDesc]
                                                , e.[vLotDescription] AS [gcLot]
                                                , e.[dQty1] AS [gcCounted]
                                                , e.[dQty1] AS [gcCounted2]
                                                , e.[vUserAdded] AS [gcUser]
                                                , e.[dtAdded] AS [gcDate]
                                                FROM [RTIS_InvCountLines_Enquiry] e
                                                INNER JOIN[" + GlobalVars.EvoDB + @"].[dbo].[StkItem] s ON s.[Code] = e.[vItemCode]
                                                WHERE e.[vStNumber] = @1  ", conn);
                comm.Parameters.Add(new SqlParameter("@1", stNum));
                conn.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("gclineID"));
                dt.Columns.Add(new DataColumn("gcItemCode"));
                dt.Columns.Add(new DataColumn("gcItemDesc"));
                dt.Columns.Add(new DataColumn("gcLot"));
                dt.Columns.Add(new DataColumn("gcCounted"));
                dt.Columns.Add(new DataColumn("gcCounted2"));
                dt.Columns.Add(new DataColumn("gcUser"));
                dt.Columns.Add(new DataColumn("gcDate"));

                using (SqlDataAdapter sda = new SqlDataAdapter(comm.CommandText, conn))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@1", stNum);
                    sda.Fill(dt);
                }
                stDTEnquiry = dt;
                conn.Dispose();
                conn.Close();
                return "1*Success";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid attempt to read when no data is present.")
                {
                    return "0*No lines";
                }
                else
                {
                    return "-1*" + ex.Message;
                }
            }
        }
        public static string UI_GetRTStockTakeArchiveLines(string stNum)
        {
            try
            {
                string returnData = string.Empty;
                SqlConnection conn = new SqlConnection(RTString);
                SqlCommand comm = new SqlCommand(string.Format(@"SELECT * FROM [dbo].[vw_GetStockTakeVariancesArchives] 
                                                                WHERE [vw_GetStockTakeVariancesArchives].[cInvCountNo] = '{0}' 
                                                                ORDER BY
                                                                CASE WHEN([vw_GetStockTakeVariancesArchives].[gcSystem] - [vw_GetStockTakeVariancesArchives].[gcCounted]) < 0 THEN [vw_GetStockTakeVariancesArchives].[gcCounted]
                                                                WHEN([vw_GetStockTakeVariancesArchives].[gcCounted] - [vw_GetStockTakeVariancesArchives].[gcSystem]) < 0 THEN [vw_GetStockTakeVariancesArchives].[gcCounted] END DESC", stNum), conn);
                //comm.Parameters.Add(new SqlParameter("@1", stNum));
                conn.Open();

                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("gclineID"));
                dt.Columns.Add(new DataColumn("gcItemCode"));
                dt.Columns.Add(new DataColumn("gcBarcode"));
                dt.Columns.Add(new DataColumn("gcItemDesc"));
                dt.Columns.Add(new DataColumn("gcBin"));
                dt.Columns.Add(new DataColumn("gcLot"));
                dt.Columns.Add(new DataColumn("gcCounted"));
                dt.Columns.Add(new DataColumn("gcCounted2"));
                dt.Columns.Add(new DataColumn("gcSystem"));
                dt.Columns.Add(new DataColumn("gcVarience"));
                dt.Columns.Add(new DataColumn("gcWhseCode"));
                dt.Columns.Add(new DataColumn("gcWhseName"));
                dt.Columns.Add(new DataColumn("gcOnST", typeof(bool)));

                using (SqlDataAdapter sda = new SqlDataAdapter(comm.CommandText, conn))
                {
                    sda.SelectCommand.Parameters.AddWithValue("@1", stNum);
                    sda.Fill(dt);
                }
                stDT = dt;
                conn.Dispose();
                conn.Close();
                return "1*Success";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Invalid attempt to read when no data is present.")
                {
                    return "0*No lines";
                }
                else
                {
                    return "-1*" + ex.Message;
                }
            }
        }
        #endregion
    }
}
