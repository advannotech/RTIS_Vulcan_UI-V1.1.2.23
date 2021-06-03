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
                SqlCommand comm = new SqlCommand(@"SELECT
	                                                il.[idInvCountLines] AS [gclineID]
	                                                ,s.[Code] AS [gcItemCode]
	                                                , s.[Bar_Code] AS [gcBarcode]
	                                                , s.[Description_1] AS [gcItemDesc]
	                                                , b.[cBinLocationName] AS [gcBin]
	                                                , l.[cLotDescription] AS [gcLot]
	                                                , ROUND(il.[fCountQty], 4) AS [gcCounted]
	                                                , ROUND(il.[fCountQty2], 4) AS [gcCounted2]
	                                                , ROUND(il.[fSystemQty], 4) AS [gcSystem]
	                                                , CASE WHEN(il.[fCountQty] = il.[fCountQty2])  
		                                                THEN CAST([dbo].[fn_CalculateVariance]([dbo].[fn_GetDifference](il.[fCountQty],il.[fSystemQty]), [dbo].[fn_GetTolerance](s.[ItemGroup]))AS VARCHAR(50))
	                                                ELSE 'SV: ' + CAST([dbo].[fn_GetDifference](il.[fCountQty],il.[fSystemQty]) AS VARCHAR(50)) END AS [gcVarience]
	                                                , w.[Code] AS [gcWhseCode]
	                                                , w.[Name] AS [gcWhseName]
	                                                , il.[bIsCounted] AS [gcIsCounted]
	                                                , il.[bOnST] AS [gcOnST]
	                                                FROM[RTIS_InvCountLines] il
	                                                INNER JOIN[RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID]
	                                                INNER JOIN [" + GlobalVars.EvoDB + @"].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID]
	                                                INNER JOIN [" + GlobalVars.EvoDB + @"].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID]
	                                                LEFT JOIN [" + GlobalVars.EvoDB + @"].[dbo].[_etblLotTracking] l ON il.[iLotTrackingID] = l.[idLotTracking]
	                                                LEFT JOIN [" + GlobalVars.EvoDB + @"].[dbo].[_btblBINLocation] b ON il.[iBinLocationId] = b.[idBinLocation]
	                                                WHERE i.[cInvCountNo] = @1  
	                                                ORDER BY
	                                                CASE WHEN(il.[fSystemQty] - il.[fCountQty]) < 0 THEN il.[fCountQty]
	                                                WHEN(il.[fCountQty] - il.[fSystemQty]) < 0 THEN il.[fCountQty] END DESC", conn);
                comm.Parameters.Add(new SqlParameter("@1", stNum));
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
                SqlCommand comm = new SqlCommand(@"SELECT
                                                 il.[idInvCountLines] AS [gclineID]
                                                ,s.[Code] AS [gcItemCode]
                                                , s.[Bar_Code] AS [gcBarcode]
                                                , s.[Description_1] AS [gcItemDesc]
                                                , b.[cBinLocationName] AS [gcBin]
                                                , l.[cLotDescription] AS [gcLot]
                                                , ROUND(il.[fCountQty], 4) AS [gcCounted]
                                                , ROUND(il.[fCountQty2], 4) AS [gcCounted2]
                                                , ROUND(il.[fSystemQty], 4) AS [gcSystem]
                                                , CASE WHEN(ROUND(il.[fCountQty], 4) = ROUND(il.[fCountQty2], 4)) THEN CAST(ROUND(il.[fCountQty], 4) - ROUND(il.[fSystemQty], 4) AS VARCHAR(50)) ELSE 'SV: ' + CAST(ROUND(il.[fCountQty], 4) - ROUND(il.[fCountQty2], 4) AS VARCHAR(50)) END AS [gcVarience]
                                                , w.[Code] AS [gcWhseCode]
                                                , w.[Name] AS [gcWhseName]
                                                , il.[bOnST] AS [gcOnST]
                                                FROM [RTIS_InvCountArchiveLines] il
                                                INNER JOIN [RTIS_InvCount] i ON i.[idInvCount] = [iInvCountID]
                                                INNER JOIN [" + GlobalVars.EvoDB + @"].[dbo].[StkItem] s ON s.[StockLink] = il.[iStockID]
                                                INNER JOIN[" + GlobalVars.EvoDB + @"].[dbo].[WhseMst] w ON w.[WhseLink] = il.[iWarehouseID]
                                                LEFT JOIN[" + GlobalVars.EvoDB + @"].[dbo].[_etblLotTracking] l ON l.[idLotTracking] = il.[iLotTrackingID]
                                                LEFT JOIN[" + GlobalVars.EvoDB + @"].[dbo].[_btblBINLocation] b ON il.[iBinLocationId] = b.[idBinLocation]
                                                WHERE i.[cInvCountNo] = @1", conn);
                comm.Parameters.Add(new SqlParameter("@1", stNum));
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
