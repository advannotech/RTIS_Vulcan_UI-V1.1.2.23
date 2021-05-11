using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Diagnostics;
using System.Threading;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_UI.Classes
{
    class SQLite
    {
        public static string InitSettingsDB()
        {
            try
            {
                bool dbFound = false;
                if (Directory.Exists(GlobalVars.RSCFolder) == false || File.Exists(GlobalVars.SettingsDB) == false)
                {
                    dbFound = false;
                    try
                    {
                        Directory.CreateDirectory(GlobalVars.RSCFolder);
                    }
                    catch (Exception)
                    { }
                    string created = CreateSettingsTable(GlobalVars.SettingsDB);
                    switch (created.Split('*')[0])
                    {
                        case "1":
                            string insertString = "ServerIP|192.168.1.1~";
                            insertString += "ServerPort|62017~";
                            insertString += "SQLServer|-Enter Server Name-~";
                            insertString += "SQLDatabase|-Enter Database-~";
                            insertString += "EvoDatabase|-Enter Database-~";
                            insertString += "XperDatabase|-Enter Database-~";
                            insertString += "SQLUser|-Enter Username-~";
                            insertString += "SQLPassword|-Enter Password-~";
                            insertString += "SQLAuth|false~";
                            insertString += "POLabel|~";
                            insertString += "POPrinter|~";
                            insertString += "RTISUser|Reltech~";
                            insertString += "ZectLabelSyncLoc|~";
                            insertString += "Zect1Label|~";
                            insertString += "Zect2Label|~";
                            insertString += "AWLabelSyncLoc|~";
                            insertString += "AWLabel|~";
                            insertString += "RememberPOLot|false~";
                            insertString += "LastPOLot|~";
                            insertString += "LastPOLotRemembered|~";
                            insertString += "PGMMManufLines|1000~";

                            insertString += "ToyBoxLabel|~";
                            insertString += "ToyBoxPrinter|~";
                            insertString += "ToyPalletLabel|~";
                            insertString += "ToyPalletPrinter|~";
                            insertString += "VWBoxLabel|~";
                            insertString += "VWBoxPrinter|~";
                            insertString += "VWPalletLabel|~";
                            insertString += "VWPalletPrinter|~";
                            insertString += "PalletLabelQty|1~";

                            string rtPass = Cypher.Encrypt("RTIS@332017");
                            switch (rtPass.Split('*')[0])
                            {
                                case "1":
                                    rtPass = rtPass.Remove(0, 2);
                                    insertString += "RTISPass|" + rtPass;
                                    string inserted = InsertSettings(insertString, GlobalVars.SettingsDB);
                                    switch (inserted.Split('*')[0])
                                    {
                                        case "1":
                                            string settings = GetSettings(GlobalVars.SettingsDB);
                                            switch (settings.Split('*')[0])
                                            {
                                                case "1":
                                                    settings = settings.Remove(0, 2);
                                                    string settingsSet = SetSettings(settings, GlobalVars.SettingsDB);
                                                    switch (settingsSet.Split('*')[0])
                                                    {
                                                        case "1":
                                                            return "0*Initial Startup Detected" + Environment.NewLine + Environment.NewLine + "Please set up the application";
                                                        case "-1":
                                                            return settingsSet;
                                                        default:
                                                            StackTrace st4 = new StackTrace(0, true);
                                                            string msgStr4 = "Unexpected error storing settings";
                                                            string infoStr4 = "Unexpected error storing settings";
                                                            return returnErrorST(st4, msgStr4, infoStr4);
                                                    }
                                                case "-1":
                                                    return settings;
                                                default:
                                                    StackTrace st3 = new StackTrace(0, true);
                                                    string msgStr3 = "Unexpected error getting settings";
                                                    string infoStr3 = "Unexpected error getting settings";
                                                    return returnErrorST(st3, msgStr3, infoStr3);
                                            }
                                        case "-1":
                                            return inserted;
                                        default:
                                            StackTrace st2 = new StackTrace(0, true);
                                            string msgStr2 = "Unexpected error setting up the settings file";
                                            string infoStr2 = "Unexpected error setting up the settings file";
                                            return returnErrorST(st2, msgStr2, infoStr2);
                                    }
                                case "-1":
                                    return rtPass;
                                default:
                                    StackTrace st5 = new StackTrace(0, true);
                                    string msgStr5 = "Unexpected encryption error";
                                    string infoStr5 = "Unexpected encryption error";
                                    return returnErrorST(st5, msgStr5, infoStr5);
                            }
                        case "-1":
                            return created;                            
                        default:
                            StackTrace st = new StackTrace(0, true);
                            string msgStr = "Unexpected error creating the settings file";
                            string infoStr = "Unexpected error creating the settings file";
                            return returnErrorST(st, msgStr, infoStr);
                    }
                }
                else
                {
                    string settings = GetSettings(GlobalVars.SettingsDB);
                    switch (settings.Split('*')[0])
                    {
                        case "1":
                            settings = settings.Remove(0, 2);
                            string settingsSet = SetSettings(settings, GlobalVars.SettingsDB);
                            switch (settingsSet.Split('*')[0])
                            {
                                case "1":
                                    return "1*Success";
                                case "-1":
                                    return settingsSet;
                                default:
                                    StackTrace st = new StackTrace(0, true);
                                    string msgStr = "Unexpected error storing settings";
                                    string infoStr = "Unexpected error storing settings";
                                    return returnErrorST(st, msgStr, infoStr);
                            }
                        case "-1":
                            return settings;
                        default:
                            StackTrace st2 = new StackTrace(0, true);
                            string msgStr2 = "Unexpected error getting settings";
                            string infoStr2 = "Unexpected error getting settings";
                            return returnErrorST(st2, msgStr2, infoStr2);
                            
                    }
                }
                
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string CreateSettingsTable(string db)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = "Data Source = " + db;
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand();
                comm.Connection = conn;
                comm.CommandText = "CREATE TABLE [Settings]" +
                                   "(" +
                                   "[SettingName] NVARCHAR(128) NOT NULL," +
                                   "[Value] NVARCHAR(128)" +
                                    ")";
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                conn.Dispose();
                return "1*Success";
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string InsertSettings(string settings, string db)
        {
            try
            {
                string[] allSetting = settings.Split('~');
                string insertCommand = string.Empty;
                foreach (var item in allSetting)
                {
                    insertCommand += "INSERT INTO [Settings] ([SettingName], [Value]) VALUES ('" + item.Split('|')[0] + "', '" + item.Split('|')[1] + "');";
                }
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = @"Data Source = " + db;
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand();
                comm.Connection = conn;
                comm.CommandText = insertCommand;
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                conn.Dispose();
                return "1*Success";
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string GetSettings(string db)
        {
            try
            {
                string returnString = string.Empty;
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = "Data Source = " + db;
                SQLiteCommand comm = new SQLiteCommand();
                comm.Connection = conn;
                comm.CommandText = "SELECT [SettingName], [Value] FROM [Settings]";
                conn.Open();
                SQLiteDataReader rdr = comm.ExecuteReader();
                while (rdr.Read())
                {
                    returnString += Convert.ToString(rdr[0]) + "|" + Convert.ToString(rdr[1]) + "~";
                }
                comm.Dispose();
                conn.Close();
                conn.Dispose();
                if (returnString != string.Empty)
                {
                    return "1*" + returnString;
                }
                else
                {
                    return "-1*No settings were found";
                }
                
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string SetSettings(string settings, string db)
        {
            try
            {
                string[] allSettings = settings.Split('~');
                foreach (string setting in allSettings)
                {
                    if (setting != string.Empty)
                    {
                        string settingName = setting.Split('|')[0];
                        string settingValue = setting.Split('|')[1];
                        switch (settingName)
                        {
                            case "ServerIP":
                                GlobalVars.ServerIP = settingValue;
                                break;
                            case "ServerPort":
                                GlobalVars.ServerPort = settingValue;
                                break;
                            case "SQLServer":
                                GlobalVars.SQLServer = settingValue;
                                break;
                            case "SQLDatabase":
                                GlobalVars.RTDB = settingValue;
                                break;
                            case "EvoDatabase":
                                GlobalVars.EvoDB = settingValue;
                                break;
                            case "XperDatabase":
                                GlobalVars.XperDB = settingValue;
                                break;
                            case "SQLUser":
                                GlobalVars.SqlUser = settingValue;
                                break;
                            case "SQLPassword":
                                if (settingValue != "-Enter Password-")
                                {
                                    string passSql = Cypher.Decrypt(settingValue);
                                    switch (passSql.Split('*')[0])
                                    {
                                        case "1":
                                            passSql = passSql.Remove(0, 2);
                                            GlobalVars.SqlPass = passSql;
                                            break;
                                        case "-1":
                                            return passSql;
                                        default:
                                            StackTrace st = new StackTrace(0, true);
                                            string msgStr = "Unexpected decryption error";
                                            string infoStr = "Unexpected decryption error";
                                            return ExHandler.returnErrorST(st, msgStr, infoStr);
                                    }
                                }
                                else
                                {
                                    GlobalVars.SqlPass = settingValue;
                                }
                                break;
                            case "SQLAuth":
                                GlobalVars.SqlAuth = Convert.ToBoolean(settingValue);
                                break;
                            case "POLabel":
                                if (settingValue != string.Empty)
                                {
                                    GlobalVars.poLabelName = settingValue;
                                    GlobalVars.POLabel = XtraReport.FromFile(GlobalVars.RSCFolder + @"\Labels\" + settingValue, true);
                                }
                                break;
                            case "POPrinter":
                                GlobalVars.POPrinter = settingValue;
                                break;
                            case "RTISUser":
                                GlobalVars.RTUser = settingValue;
                                break;
                            case "RTISPass":
                                string pass = Cypher.Decrypt(settingValue);
                                switch (pass.Split('*')[0])
                                {
                                    case "1":
                                        pass = pass.Remove(0, 2);
                                        GlobalVars.RTPass = pass;
                                        break;
                                    case "-1":
                                        return pass;
                                    default:
                                        StackTrace st = new StackTrace(0, true);
                                        string msgStr = "Unexpected decryption error";
                                        string infoStr = "Unexpected decryption error";
                                        return ExHandler.returnErrorST(st, msgStr, infoStr);
                                }                                
                                break;
                            case "ZectLabelSyncLoc":
                                GlobalVars.zectSyncLoc = settingValue;
                                break;
                            case "Zect1Label":
                                GlobalVars.zect1Label = settingValue;
                                break;
                            case "Zect2Label":
                                GlobalVars.zect2Label = settingValue;
                                break;
                            case "AWLabelSyncLoc":
                                GlobalVars.AWSyncLoc = settingValue;
                                break;
                            case "AWLabel":
                                GlobalVars.AWLabel = settingValue;
                                break;
                            case "RememberPOLot":
                                GlobalVars.RememberPOLot = Convert.ToBoolean(settingValue);
                                break;
                            case "LastPOLot":
                                GlobalVars.LastPOLot = settingValue;
                                break;
                            case "LastPOLotRemembered":
                                GlobalVars.LastPOLotRemebered = settingValue;
                                break;
                            case "PGMMManufLines":
                                GlobalVars.PGMLineCount = settingValue;
                                break;
                            case "ToyBoxLabel":
                                if (settingValue != string.Empty)
                                {
                                    GlobalVars.boxLabelName_Toyota = settingValue;
                                    GlobalVars.boxLabel_Toyota = XtraReport.FromFile(GlobalVars.RSCFolder + @"\Labels\" + settingValue, true);
                                }
                                break;
                            case "ToyBoxPrinter":
                                GlobalVars.boxPrinter_Toyota = settingValue;
                                break;

                            case "ToyPalletLabel":
                                if (settingValue != string.Empty)
                                {
                                    GlobalVars.palletLabelName_Toyota = settingValue;
                                    GlobalVars.palletLabel_Toyota = XtraReport.FromFile(GlobalVars.RSCFolder + @"\Labels\" + settingValue, true);
                                }
                                break;
                            case "ToyPalletPrinter":
                                GlobalVars.palletPrinter_Toyota = settingValue;
                                break;

                            case "VWBoxLabel":
                                if (settingValue != string.Empty)
                                {
                                    GlobalVars.boxLabelName_VW = settingValue;
                                    GlobalVars.boxLabel_VW = XtraReport.FromFile(GlobalVars.RSCFolder + @"\Labels\" + settingValue, true);
                                }
                                break;
                            case "VWBoxPrinter":
                                GlobalVars.boxPrinter_VW = settingValue;
                                break;

                            case "VWPalletLabel":
                                if (settingValue != string.Empty)
                                {
                                    GlobalVars.palletLabelName_VW = settingValue;
                                    GlobalVars.palletLabel_VW = XtraReport.FromFile(GlobalVars.RSCFolder + @"\Labels\" + settingValue, true);
                                }
                                break;
                            case "VWPalletPrinter":
                                GlobalVars.palletPrinter_VW = settingValue;
                                break;
                            case "PalletLabelQty":
                                GlobalVars.palletLabelQty = settingValue;
                                break;

                        }
                    }                    
                }
                return "1*Success";
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string UpdateSettings(string query, string db)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = "Data Source = " + db;
                SQLiteCommand comm = new SQLiteCommand();
                comm.Connection = conn;
                comm.CommandText = query;
                conn.Open();
                comm.ExecuteNonQuery();
                comm.Dispose();
                conn.Close();
                conn.Dispose();
                return "1*Success";
            }
            catch (Exception ex)
            {
                return ExHandler.returnErrorEX(ex);
            }
        }
        public static string returnErrorST(StackTrace st, string msgStr, string infoStr)
        {
            StackFrame sf = new StackFrame();
            sf = st.GetFrame(0);
            string file = sf.GetFileName();
            string line = sf.GetFileLineNumber().ToString();
            string name = sf.GetFileName().ToString();
            string meth = sf.GetMethod().ToString();
            infoStr += Environment.NewLine + Environment.NewLine + "Method:" + Environment.NewLine + meth + Environment.NewLine + Environment.NewLine + "File: " + Environment.NewLine + name + Environment.NewLine + Environment.NewLine + "Line Number: " + Environment.NewLine + line;
            return "-1*" + msgStr + "|" + infoStr;
        }
        public string returnErrorStr()
        {
            return "-1";
        }
    }
}
