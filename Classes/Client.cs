using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RTIS_Vulcan_UI.Classes
{
    static class Client
    {
        private const string TYPE_SIGNATURE = "SIGN";
        private const string TYPE_PALLETLABEL = "PALLETLABEL";
        private const string APPROVE_CMS_DOC = "*APPROVECMSDOCUMENT*";
        private const string SEND_LABEL_TO_SERVER = "*SENDPALLETLABELTOSERVER*";

        public static string SendFileToServer(string fileType, string filePath, string command, string fileName, params string[] args)
        {
            string arguments = string.Join("|", args);
            command = command + "@" + arguments;
            string Filename = filePath;
            TcpClient tcpClient = new TcpClient(GlobalVars.ServerIP, 32018);
            FileStream fs = new FileStream(Filename, FileMode.Open);
            try
            {
                int bufferSize = 2048;
                byte[] buffer = null;
                byte[] header = null;

                //bool read = true;
                int bufferCount = Convert.ToInt32(Math.Ceiling((double)fs.Length / (double)bufferSize));

                tcpClient.SendTimeout = 600000;
                tcpClient.ReceiveTimeout = 600000;

                string headerStr = "Content-length:" + fs.Length.ToString() + "#Command:" + command + "#Filename:" + fileName + "#Filetype:" + fileType + "#";
                header = new byte[bufferSize];
                Array.Copy(Encoding.ASCII.GetBytes(headerStr), header, Encoding.ASCII.GetBytes(headerStr).Length);

                tcpClient.Client.Send(header);

                for (int i = 0; i < bufferCount; i++)
                {
                    buffer = new byte[bufferSize];
                    int size = fs.Read(buffer, 0, bufferSize);
                    tcpClient.Client.Send(buffer, size, SocketFlags.Partial);
                }

                //START RECEIVE
                string ServerResponse = string.Empty;
                var receivebytes = new byte[2048];
                var length = tcpClient.Client.Receive(receivebytes);
                ServerResponse = Encoding.ASCII.GetString(receivebytes);
                return ServerResponse.Trim('\0');
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
            finally
            {
                fs.Close();
                tcpClient.Client.Close();
                tcpClient.Client.Dispose();
            }
        }

        #region Core
        public static string TestConn(string ip, string port)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(ip);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(port));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*TEST*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        public static string GetUsernames()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETUSERNAMES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UserLogin(string userInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UILOGIN*@" + userInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetActiveModules()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETACTIVEMODULES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetActiveModuleUserPerms(string permInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETUSERPERMISSIONS*@" + permInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetActiveLabelTypes(string userName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETACTIVELABElTYPES*@" + userName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getPermissionsHasLabel(string permissionName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPERMISSIONHASLABEL*@" + permissionName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetActiveLabels(string permission)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETACTIVELABELS*@" + permission);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string SavePermLabels(string labelInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SAVEMODULELABELCONFIGS*@" + labelInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPermLabelsNew(string permPCInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPERMLABELSNEW*@" + permPCInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Role Management
        public static string GetAllRoles()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETALLROLES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        //GET ALREADY SELECTED PO

        public static string GetSelectedPO(string VendorName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSELECTEDPOs*@" + VendorName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }


        //GET AVAILABLE ORDER NUMBERS FROM SAGE
        public static string GetAvailablePOs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETACTIVEPOs*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }


        public static string GetAvailablePermissions()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETACTIVEPERMISSIONS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string AddRole(string roleInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ADDROLE*@" + roleInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateRole(string roleInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEROLE*@" + roleInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string RemoveRole(string roleID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REMOVEROLE*@" + roleID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ToggleRoleActivity(string roleInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*TOGGLROLEACTIVE*@" + roleInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region User Management
        public static string getAllUsers()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETUSERS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetActiveRoles()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETACTIVEROLES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetRolePermisssions(string roleName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETROLEPERMISSIONS*@" + roleName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetEvoAgents()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETEVOAGENTS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string AddUser(string UserInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ADDUSER*@" + UserInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateUser(string UserInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEUSER*@" + UserInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string RemoveUser(string UserID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REMOVEUSER*@" + UserID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ToggleUserActive(string UserID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*TOGGLEUSERACTIVE*@" + UserID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Warehouse Transfers

        #region Warehouse Management (Outgoing)
        public static string getWhtProcs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                using (Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    byte[] sendbytes = new byte[21];
                    byte[] receivebytes = new byte[3];
                    ASCIIEncoding ascenc = new ASCIIEncoding();


                    //Send start request
                    DataClient.SendTimeout = 60000;
                    DataClient.ReceiveTimeout = 60000;
                    DataClient.Connect(ServerEP);

                    sendbytes = ascenc.GetBytes("*GETPROCNAMES*@");
                    DataClient.Send(sendbytes);

                    receivebytes = new byte[131073];
                    int length = DataClient.Receive(receivebytes);
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                    }

                    DataClient.Close();
                    return ServerDetails;
                }
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetWhtProcLokkups(string procName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWHSELOOKUPSFORPROC*@" + procName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string setWhseLookupEnabled(string whseString)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SETWAREHOUSESELECTED*@" + whseString);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Warehouse Management (Receiving)
        public static string getWhtProcsRec()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPROCNAMESREC*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetWhtProcLookupsRec(string procName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWHSELOOKUPSFORPROCREC*@" + procName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string setWhseLookupEnabledRec(string whseString)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SETWAREHOUSESELECTEDREC*@" + whseString);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Warehouse Transfer Management
        public static string getAllProcWhses(string procName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPROCESSLOCATIONS*@" + procName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getAllProcWhsesRec(string procName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPROCESSLOCATIONSREC*@" + procName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getAllWhsesForConfig()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETALLEVOWHSESFORCONFIG*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string addWhseProcRef(string info)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ADDPROCWHSEREF*@" + info);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string deleteWhseProcRef(string info)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REMOVEPROCWHSEREF*@" + info);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getFGtransferRequestLines(string transferInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETFGWHTREQUESTS*@" + transferInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string transferFGItem(string id)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*POSTFGWHT*@" + id);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getFGtransferReportLines(string transferInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETFGWHTREPORTS*@" + transferInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        //PRE REWRITE
        public static string getAllWhtProcs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETALLTRANSFERPROCESSES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getWhseTransferLines(string transferInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWHTTRANSFERLINES*@" + transferInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getWhseTransferLinesAll(string transferInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWHTRANSFERLINESALL*@" + transferInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getWhseTransferLinesPosted(string transferInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWHTRANSFERLINESPOSTED*@" + transferInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetGridOverride()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETGRIDOVERRIDEPASSWORD*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-1*Cannot connect to server";
            }
        }
        public static string updateWhseTransferLine(string transferInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEWHSETRANSFERLINE*@" + transferInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string updateWhseTransferLinesPending()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*WHTSETFAILEDTOPENDING*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string processPendingLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*PROCESSPENDINGWHTS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #endregion

        #region Purchase Orders

        #region CMS
        public static string AddCMSValue(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*ADDCMSVALUE*@" + data); //
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSItems()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSITEMS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSUOMs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSUOMS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string DeleteCMSValue(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                UTF8Encoding ascenc = new UTF8Encoding();

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes =  UTF8Encoding.UTF8.GetBytes("*DELETECMSITEM*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSHeaders()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETITEMCMSHEADERS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSItemsAdd()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSITEMSADD*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSUOMsAdd()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSUOMSADD*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CreateCMSDocument(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*ADDCMSDOCUMENT*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSApprovals()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETITEMCMSAPPROVALS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSApprovalLines(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSAPPROVALLINES*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ApproveCMSDoc(string path, string fileName, string itemCode, string username, string lineID, string stockLink, string version)
        {
            return SendFileToServer(TYPE_SIGNATURE, path, APPROVE_CMS_DOC, fileName, itemCode, username, lineID, stockLink, version);
        }
        public static string GetCMSApprovalImage(string code)
        {
            IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                //DataClient.SendTimeout = 30000;
                //DataClient.ReceiveTimeout = 30000;

                DataClient.Connect(ServerEP);
                sendbytes = ascenc.GetBytes("*GETCMSAPPROVALIMAGE*@" + code);
                DataClient.Send(sendbytes);

                if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\");
                }

                using (var output = File.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\" + code + ".png"))
                {
                    var buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = DataClient.Receive(buffer)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                }

                DataClient.Close();
                return "1*Success";
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-1*Cannot connect to server:" + System.Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSApprovalLinesVeiw(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSAPPROVALLINESVIEW*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string RejectCMSDocument(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*REJECTCMSDOCUMENT*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSApprovalLinesEdit(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSEDITLINES*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CreateNewDocVersion(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*CREATENEWDOCVERSION*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string EditExistingDocument(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*EDITEXISTINGDOCUMENT*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetCMSArchiveHeaders()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSARCHIVEHEADERS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static Task<string> GetCMSArchiveImage(string id, string code)
        {
            return Task.Run(() => { IPAddress ServerIPAddress = null;
            ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
            IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
            Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                //DataClient.SendTimeout = 30000;
                //DataClient.ReceiveTimeout = 30000;

                DataClient.Connect(ServerEP);
                sendbytes = ascenc.GetBytes("*GETCMSARCHIVEIMAGE*@" + id + "|" + code);
                DataClient.Send(sendbytes);

                if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\"))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\");
                }

                if (File.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\" + code + ".png"))
                {
                    File.Delete(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\" + code + ".png");
                }

                using (var output = File.Create(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\RSC\Signatures\" + code + ".png"))
                {
                    var buffer = new byte[1024];
                    int bytesRead;
                    while ((bytesRead = DataClient.Receive(buffer)) > 0)
                    {
                        output.Write(buffer, 0, bytesRead);
                    }
                }

                DataClient.Close();
                return "1*Success";
            }
            catch (Exception ex)
            {
                DataClient.Close();
                return "-1*Cannot connect to server:" + System.Environment.NewLine + ex.Message;
            }});
        }
        public static string GetCMSArchiveLines(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*GETCMSARCHIVELINES*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string DeleteCMSDocument(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = UTF8Encoding.UTF8.GetBytes("*DELETECMSDOCUMENT*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073]; //131073
                int length = DataClient.Receive(receivebytes);
                ServerDetails = UTF8Encoding.UTF8.GetString(receivebytes).Trim('\0');;

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region PO Admin

        //GET ALL POS
        public static string GetLinkLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOVENDORLINKS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetEvoPOVendors()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETEVOPOVENDORS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string SetVendorLookup(string vendorInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SETVENDORLOOKUP*@" + vendorInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string SetVendorPOLick(string vendorInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SETVENDORPOLINK*@" + vendorInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }


        public static string LinkPONtoVendor(string vendorInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*LINKPOTOVENDOR*@" + vendorInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        #endregion

        #region PO Receiving
        public static string GetLinkedVendors()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETLINKEDVENDORS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetLinkedPOs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETLINKEDPOS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string ReprintVendorPOLines(string vendor)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REPRINTVENDORPOLINES*@" + vendor);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }




        public static string GetVendorPOLines(string vendor)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETVENDORPOLINES*@" + vendor);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }



        public static string getPOIreprint(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOLINESFORREPRINT*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }


        public static string getPOLinesreprint(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOLINESREPRINT*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }



        public static string GetreprintPOLines(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETREPRINTPOLINES*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string ReprintPOLines(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REPRINTPOLINES*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }


        public static string GetPOLines(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOLINES*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string printPOLabels(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                using (Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    byte[] sendbytes = new byte[20];
                    byte[] receivebytes = new byte[2];
                    ASCIIEncoding ascenc = new ASCIIEncoding();


                    //Send start request
                    //DataClient.SendTimeout = 60000;
                    //DataClient.ReceiveTimeout = 120000;
                    DataClient.Connect(ServerEP);

                    sendbytes = ascenc.GetBytes("*PRINTPOLABELSAUTO*@" + orderNum);
                    DataClient.Send(sendbytes);

                    receivebytes = new byte[131073];
                    int length = DataClient.Receive(receivebytes);
                    int count = length;
                    while (length != 0)
                    {
                        for (int i = 0; i <= length - 1; i++)
                        {
                            ServerDetails += Convert.ToChar(receivebytes[i]);
                            count = count - 1;
                        }
                        count = DataClient.Receive(receivebytes);
                        length = count;
                    }

                    DataClient.Close();
                    return ServerDetails;
                }
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string printPOLabelsNo(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*PRINTPOLABELSNOLOTAUTO*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string removeInvalidLabels(string orderNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REMOVEINVALIDLABELS*@" + orderNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string postNewPOLines(string info)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[20];
                byte[] receivebytes = new byte[2];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                //DataClient.SendTimeout = 60000;
                //DataClient.ReceiveTimeout = 120000;
                DataClient.Connect(ServerEP);
                System.Threading.Thread.Sleep(2000);
                sendbytes = ascenc.GetBytes("*POSTPOLINESNEW*@" + info);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;             
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getLabelPrintInfo(string poNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOLABELINFO*@" + poNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string reprintPOLabelLot(string poItemInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REPRINTPOLABELSLOT*@" + poItemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string reprintPOLabelNoLot(string poItemInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REPRINTPOLABELSNOLOT*@" + poItemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion
        #endregion

        #region RM Manufacture

        public static string GetPPLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOWDERPREPLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdatePPManufacture(string LineID, string UserName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEPPMANUFACTURED*@" + LineID + "|" + UserName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetFSlurryLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETFRESHSLURRYLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateFSManufacture(string LineID, string UserName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEFSMANUFACTURED*@" + LineID + "|" + UserName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Production Planning

        public static string GetPowderPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOWDERPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetZECT1PlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETZECT1PLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetZECT2PlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETZECT2PLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetAWPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETAWPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetSelectCSPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSELECTCSPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetSelectSPPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSELECTSPPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string InsertZectPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTZECTPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string InsertAWPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTAWPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }


        }

        public static string InsertPowderPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTPOWDERPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string UpdateZectPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEZECTPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdatePowderPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEPOWDERPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string UpdateAWPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEAWPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        #endregion

        #region PGM Planning

        public static string GetVWPGMPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETVWPGMPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetTOYOTAFSPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTOYOTAFSPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetTOYOTAPPPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTOYOTAPPPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetTOYOTAAWPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTOYOTAAWPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetSelectCSPPGMPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSELECTCSPPGMPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string GetSelectPGMPlanningLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSELECTPGMPLANNINGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string InsertVWPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTVWPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string InsertTFSPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTTFSPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string InsertTPPPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTTPPPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string InsertTAWPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*INSERTTAWPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string UpdateVWPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEVWPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateTFSPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATETFSPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateTPPPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATETPPPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateTAWPlanning(string Line)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATETAWPLANNING*@" + Line);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        #endregion

        #region PGM Manufacture
        public static string GetPGMJobRows(string rowCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPGMJOBROWS*@" + rowCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPGMJobsByDate(string rowCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPGMJOBSBYDATE*@" + rowCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPGMContainers(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPGMCONTAINERS*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPGMMFLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPGMMFLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdatePGMContainerManufacture(string itemInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIMANUFPGMCONTAINER*@" + itemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdatePGMManufacture(string LineID, string UserName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEPGMMANUFACTURED*@" + LineID + "|" + UserName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        #endregion

        #region Powder Prep
        public static string GetPowderPrepRecordsByDate(string powderDates)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPOWDERPREPRECORDSBYDATE*@" + powderDates);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Fresh Slurry
        public static string GetFreshSlurryRecordsByDate(string powderDates)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETFRESHSLURRYRECORDSBYDATE*@" + powderDates);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Mixed Slurries

        #region View Records
        public static string getMixedSlurryLines(string lineCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();

                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETALLMIXEDSLURRIS*@" + lineCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getMixxedSlurryTankInformation(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMIXEDSLURRYTANKINFO*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getMixedSlurryMobileTankInformation(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMIXEDSLURRYMOBILETANKINFO*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getMixedSlurryInputs(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTANKSLURRIES*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getMixedSlurryChemicals(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTANKCHEMICALS*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string closeMixedSlurryTank(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*CLOSEMIXEDSLURRYTANK*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string closeMixedSlurryMobileTank(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*CLOSEMIXEDSLURRYMOBILETANK*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Manufacture
        public static string GetMixedSlurriesFormManufacture()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMIXEDSLURRIESFORMANUFACTURE*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetMixedSlurryTankInfoManufacture(string lineID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMIXEDSLURRYTANKINFOMANUFACTURE*@" + lineID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetMixedSlurryMobileTankInfoManufacture(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMIXEDSLURRYMOBILETANKINFOMANUFACTURE*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetMixedSlurryInputsManuf(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTANKSLURRIESMANUFACTURE*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetMixedSlurryChemicalsManuf(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETTANKCHEMICALSMANUFACTURE*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseTankManuf(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSETANK*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseBuffTankManuf(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSEBUFFTANK*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseMobileTankManuf(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSEMOBILETANK*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetMixedSlurryDecantManuf(string lineId)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETDECATEDTANKSMANUFACTURE*@" + lineId);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetNPLPercentages()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETNPLPERCENTAGES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdateNPLPercentage(string chemInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*EDITNPLPERCENTAGE*@" + chemInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetMixedSlurryID()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMIXEDSLURRYJOURNALID*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string SaveMixedSlurryID(string id)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SAVEDMIXEDSLURRYJOURNALID*@" + id);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureMixedSlurry(string slurryInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREMIXEDSLURRY*@" + slurryInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Chemical Management
        public static string GetAllMSChemicals()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETEXISTINGCHEMICALS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string AddMSChemical(string name)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ADDNEWCHEMICAL*@" + name);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string RemoveMSChemical(string id)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*DELETECHEMICAL*@" + id);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #endregion

        #region ZECT
        public static string getZectCatalysts()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLZECTCATALYSTS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getCatalystRaws(string catalystCode)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETZECTCATALYSTRAWS*@" + catalystCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getZectRMs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLZECTRMS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string addCatalystLink(string catalystInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UISAVEZECTRM*@" + catalystInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string removeCatalystLink(string catalystInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIREMOVEZECTRM*@" + catalystInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string getZectJobs(string lineCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETZECTJOBS*@" + lineCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getZectJobInputs(string lineCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETZECTJOBINPUTS*@" + lineCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getZectJobOutputs(string headerID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETZECTJOBOUTPUTS*@" + headerID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region A&W 
        public static string getAWCatalysts()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLAWCATALYSTS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getAWCatalystRaws(string catalystCode)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETAWCATALYSTRAWS*@" + catalystCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getAWRMs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLAWRMS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string addPGMLink(string catalystInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UISAVEAWRM*@" + catalystInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string removeAWLink(string catalystInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIREMOVEAWRM*@" + catalystInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string getAWJobs(string dates)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETAWJOBS*@" + dates);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getAWJobInputs(string lineCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETAWJOBINPUTS*@" + lineCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getAWJobOutputs(string lineCount)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETAWJOBOUTPUTS*@" + lineCount);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Canning
        public static string getCanningCatalysts()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLCANNINGCATALYSTS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getCanningCatalystRaws(string catalystCode)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETCANNINGCATALYSTRAWS*@" + catalystCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getCanningRMs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLCANNINGRMS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string addCanningRMLink(string catalystInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UISAVECANNINGRM*@" + catalystInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string removeCanningLink(string catalystInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIREMOVECANNINGRM*@" + catalystInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getCanningRecords(string searchInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETCANNINGRECORDS*@" + searchInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region FG Printing
        public static string getFGLabelInfo(string itemCode)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETFGLABELINFO*@" + itemCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string saveFGLabels(string labelInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SAVEFGLABELS*@" + labelInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Auto Manufacture

        #region PGM
        public static string GetPGMManufactureLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPGMHEADERSTOMANUFACTURE*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPGMManufactureContainers(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPGMLINESTOMANUFACTURE*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufacturePGMContainer(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREPGMCONTAINER*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufacturePGMBatch(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREPGMBATCH*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string EditPGMContainer(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*PGMEDITCONTAINERUI*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdatePGMRemainder(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEPGMREMAINDER*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufacturePGMBatchManual(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SETPGMMANUFACTUREDMANUAL*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Powder Prep
        public static string GetPowderManufactureLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWAITINGPOWDERS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string EditPowderWeight(string powderInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*EDITPOWDERQTY*@" + powderInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufacturePowder(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREPOWDER*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManuallyClosePowder(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSEPOWDER*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Fresh Slurry

        #region Input
        public static string GetAllFreshSlurriesForRM()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETALLFRESHSLURRIES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetFreshSlurriesRMs(string code)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETFRESHSLURRYRAWS*@" + code);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetAllFreshSlurriesRMs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIGETALLFRESHSLURRYRMS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string addFreshSlurryLink(string slurryInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UISAVEFRESHSLURRYRM*@" + slurryInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string removeFreshSlurryLink(string slurryInformation)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UIREMOVEFRESHSLURRYRM*@" + slurryInformation);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        public static string GetFSManufactureLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETWAITINGFREShSLURRIES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureFreshSlurry(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREFRESHSLURRY*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseFreshSlurry(string pgmInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALCLOSEFRESHSLURRY*@" + pgmInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Records
        public static string GetAutoManufRecordsByDate(string dates)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETAUTOMANUFACTURERECORDS*@" + dates);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Zect
        public static string GetZECTManufactureJobs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETZECTHEADERSTOMANUFACTURE*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetZECTManufacturePallets(string jobID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETZECtPALLETLINES*@" + jobID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureZectPallet(string palletInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREZECTPALLET*@" + palletInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureZectBatch(string zectInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREZECTBATCH*@" + zectInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseZectBatch(string zectInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSEJOB*@" + zectInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region AW
        public static string GetAWManufactureJobs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETAWHEADERSTOMANUFACTURE*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetAWManufacturePallets(string jobID)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETAWPALLETLINES*@" + jobID);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureAWPallet(string palletInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREAWPALLET*@" + palletInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureAWBatch(string palletInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTUREAWBATCH*@" + palletInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseAWBatch(string palletInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSEAW*@" + palletInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Canning
        public static string GetCanningManufactureLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETCANNINGLINESTOMANUFACTURE*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ManufactureCanningPallet(string palletInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUFACTURECANNINGPALLET*@" + palletInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string CloseCanningPallet(string palletInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*MANUALLYCLOSECANNING*@" + palletInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Configuration
        public static string GetConfigLocs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETCONFIGLOCS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetManufWhses()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETMANUFWHSES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string SaveManufWhses(string data)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SAVEMANUFLOCATIONS*@" + data);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Temp 
        //
        public static string ProcessAutoManufactures()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*PROCESSAUTOMANUFACTURE*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #endregion

        #region FG Manufacture

        public static string GetZECT1FGLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETZECT1FGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetZECT2FGLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETZECT2FGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetAWFGLines()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETAWFGLINES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string UpdateZECTALLFGManufacture(string LineID, string UserName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEZECTALLFGMANUFACTURED*@" + LineID + "|" + UserName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        public static string UpdateAWFGManufacture(string LineID, string UserName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEAWFGMANUFACTURED*@" + LineID + "|" + UserName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }

        #endregion

        #region Dispatch
        public static string GetDispatchUnqs()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSOUNQBARCODES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ClearDispatchUnqs(string soNumber)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*CLEARSOUNQS*@" + soNumber);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Stock Take
        public static string GetEvoStockTakes()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETEVOSTOCKTAKES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ImportEvoStockTake(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*IMPORTSTOCKITEMS*@" + stNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetRTStockTakes()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETRTSTOCKTAKES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetSTLineTickets(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETINVCOUNTLINETICKETS*@" + stNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetSTLineTicketsArchive(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETINVCOUNTLINETICKETSARCHIVE*@" + stNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ReverseTicketRT2D(string ticketInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REVERSESTOCKTAKETICKETRT2D*@" + ticketInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ReverseTicketPallet(string ticketInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REVERSESTOCKTAKETICKETPALLET*@" + ticketInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ReverseTicketRMPallet(string ticketInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REVERSESTOCKTAKETICKETRMPALLET*@" + ticketInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ReverseTicket(string ticketInfo)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REVERSESTOCKTAKETICKET*@" + ticketInfo);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getExportFormats()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETEXPORTFORMATS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string getExportFormatString(string formatName)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETEXPORTFORMATSTRING*@" + formatName);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string saveExportFormat(string sendString)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SAVEEXPORTFORMAT*@" + sendString);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string updateExportFormat(string sendString)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*UPDATEEXPORTFORMAT*@" + sendString);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string deleteExportFormat(string sendString)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*DELETEEXPORTFORMAT*@" + sendString);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetSTReportInfo(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[20];
                byte[] receivebytes = new byte[2];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                //DataClient.SendTimeout = 60000;
                //DataClient.ReceiveTimeout = 120000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSTREPORTINFO*@" + stNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                //                receivebytes = new byte[147483591];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }


                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetSTReportInfoArchive(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[20];
                byte[] receivebytes = new byte[2];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                //DataClient.SendTimeout = 60000;
                //DataClient.ReceiveTimeout = 120000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETSTREPORTINFOARCHIVE*@" + stNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                //                receivebytes = new byte[147483591];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }


                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ArchiveStockTakeWithTickets(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[20];
                byte[] receivebytes = new byte[2];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                //DataClient.SendTimeout = 60000;
                //DataClient.ReceiveTimeout = 120000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*ARCHIVESTOCKTAKEANDVALIDATION*@" + stNum);
                DataClient.Send(sendbytes);

                //receivebytes = new byte[147483591];
                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                int count = length;
                while (length != 0)
                {
                    for (int i = 0; i <= length - 1; i++)
                    {
                        ServerDetails += Convert.ToChar(receivebytes[i]);
                        count = count - 1;
                    }
                    count = DataClient.Receive(receivebytes);
                    length = count;
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetArchiveRTStockTakes()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETARCHIVEDRTSTOCKTAKES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string RemoveStockTake(string stNum)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REMOVESTOCKTAKEWITHVALIDATION*@" + stNum);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion

        #region Palletizing
        public static string GetPalletPrintSettings()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETPRINTSETTINGS*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string UpdatePalletPrintSettings(string printer, string label)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*SAVEPALLETPRINTSETTINGS*@" + printer + "|" + label);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string SendPalletLabelToServer(string path, string fileName)
        {
            return SendFileToServer(TYPE_PALLETLABEL, path, APPROVE_CMS_DOC, fileName);
        }
        public static string GetItemCodes_Palletizing()
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETITEMCODES*@");
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetItemLots_Palletizing(string itemCode)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETITEMLOTS*@" + itemCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPallets(string byDate, string from, string to)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETLINESALL*@" + byDate + "|" + from + "|" + to);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPalletsByItem(string itemCode, string byDate, string from, string to)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETLINESBYITEM*@" + itemCode + "|" + byDate + "|" + from + "|" + to);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPalletsByLot(string itemCode, string lotNumber, string byDate, string from, string to)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETLINESBYLOT*@" + itemCode + "|" + lotNumber + "|" + byDate + "|" + from + "|" + to);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string GetPalletLines(string id)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*GETPALLETLINES*@" + id);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        public static string ReprintPalletLabel(string palletCode)
        {
            try
            {
                string ServerDetails = "";

                IPAddress ServerIPAddress = null;
                ServerIPAddress = IPAddress.Parse(GlobalVars.ServerIP);
                IPEndPoint ServerEP = new IPEndPoint(ServerIPAddress, Convert.ToInt32(GlobalVars.ServerPort));
                Socket DataClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                byte[] sendbytes = new byte[21];
                byte[] receivebytes = new byte[3];
                ASCIIEncoding ascenc = new ASCIIEncoding();


                //Send start request
                DataClient.SendTimeout = 60000;
                DataClient.ReceiveTimeout = 60000;
                DataClient.Connect(ServerEP);

                sendbytes = ascenc.GetBytes("*REPRINTPALLETLABEL*@" + palletCode);
                DataClient.Send(sendbytes);

                receivebytes = new byte[131073];
                int length = DataClient.Receive(receivebytes);
                for (int i = 0; i <= length - 1; i++)
                {
                    ServerDetails += Convert.ToChar(receivebytes[i]);
                }

                DataClient.Close();
                return ServerDetails;
            }
            catch (Exception ex)
            {
                return "-2*Cannot connect to server: " + Environment.NewLine + Environment.NewLine + ex.Message;
            }
        }
        #endregion
    }
}
