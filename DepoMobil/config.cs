#region Using directives

using System;
using System.Xml;
using System.IO;
using System.Data;
using System.Data.SqlServerCe;

#endregion

namespace DepoMobil
{
    enum XmlNodes
    {
        DatabaseName,
        DatabaseUserName,
        DatabasePwd,
        DatabaseServer,
        PlasiyerKodu,
        PDAKodu,
        GPRS
    }

    public class Config
    {
        string _Database = string.Empty;
        string _Server = string.Empty;
        string _Uid = string.Empty;
        string _Pwd = string.Empty;
        string _PlasiyerKodu = string.Empty;
        string _PDAKodu = string.Empty;
        string _OnlineIp = string.Empty;
        string _GPRS = string.Empty;
        const string file = "config.xml";

        public SqlCeConnection CeConn = new SqlCeConnection("data source=ankara.sdf");
        XmlDocument Doc = new XmlDocument();

        public Config()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public bool IsDbExist
        {
            get
            {
                return File.Exists("ankara.sdf");
            }
        }

        public bool IsConfigured
        {
            get
            {
                return File.Exists(file);
            }
        }

        public string ConnectionString
        {
            get
            {
                if (isOffline)
                    return "DataBase=" + DataBase + ";uid='" + Uid + "';pwd='" + Pwd + "';Server=" + _Server + "";
                else
                    return "DataBase=" + DataBase + ";uid='" + Uid + "';pwd='" + Pwd + "';Server=" + _OnlineIp + "";
            }
        }

        public void SetProertyes()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(file);
            XmlNodeList nl = xmlDoc.ChildNodes[1].ChildNodes;

            for (int i = 0; i < nl.Count; i++)
            {
                switch (nl[i].Name)
                {
                    case "DatabaseName":
                        _Database = nl[i].InnerText;
                        break;
                    case "DatabasePwd":
                        _Pwd = nl[i].InnerText;
                        break;
                    case "DatabaseServer":
                        _Server = nl[i].InnerText;
                        break;
                    case "DatabaseUserName":
                        _Uid = nl[i].InnerText;
                        break;
                    case "PlasiyerKodu":
                        _PlasiyerKodu = nl[i].InnerText.ToString();
                        break;
                    case "PDAKodu":
                        _PDAKodu = nl[i].InnerText.ToString();
                        break;
                    case "OnlineIp":
                        _OnlineIp = nl[i].InnerText;
                        break;
                    case "GPRS":
                        _GPRS = nl[i].InnerText;
                        break;
                }

            }

        }

        public void CreateConfigFile(string Database, string Server, string Uid,
                    string Pwd, string PlasiyerKodu, string onlieip, string GPRS)
        {

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<Conifg>\r\n" +
                "	<DatabaseName>" + Database + "</DatabaseName>\r\n" +
                "	<DatabaseUserName>" + Uid + "</DatabaseUserName>\r\n" +
                "	<DatabasePwd>" + Pwd + "</DatabasePwd>\r\n" +
                "	<DatabaseServer>" + Server + "</DatabaseServer>\r\n" +
                "	<PlasiyerKodu>" + PlasiyerKodu + "</PlasiyerKodu>\r\n" +
                "	<PDAKodu>" + PDAKodu + "</PDAKodu>\r\n" +
                "	<OnlineIp>" + onlieip + "</OnlineIp>\r\n" +
                "	<GPRS>" + GPRS + "</GPRS>\r\n" +

                "</Conifg>";
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(xml);
            sw.Close();
        }

        public string DataBase
        {
            get
            {
                return _Database;
            }
        }
        public string Server
        {
            get
            {
                return _Server;
            }
        }
        public string Uid
        {
            get
            {
                return _Uid;
            }
        }
        public string Pwd
        {
            get
            {
                return _Pwd;
            }
        }
        public string PlasiyerKodu
        {
            get
            {
                return _PlasiyerKodu;
            }
        }
        public string PDAKodu
        {
            get
            {
                return _PDAKodu;
            }
        }
        public string OnlineIp
        {
            get
            {
                return _OnlineIp;
            }
        }
        public string GPRS
        {
            get
            {
                return _GPRS;
            }
        }

        public bool isOffline = true;
    }
}
