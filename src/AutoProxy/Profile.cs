using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace AutoProxy
{
    public class Profile
    {
        public bool IsDefault
        {
            get
            {
                return Name == "(Default)";
            }
        }

        public Pointer<string> Name
        {
            get;
            private set;
        }

        #region Automatic
        public Pointer<bool> EnableAutomatic
        {
            get;
            private set;
        }

        public Pointer<bool> EnableAutomaticScript
        {
            get;
            private set;
        }

        public Pointer<string> AutomaticScript
        {
            get;
            private set;
        } 
        #endregion

        #region Proxy
        public Pointer<bool> EnableProxy
        {
            get;
            private set;
        }

        public Pointer<bool> UseSameProxyForAllProtocols
        {
            get;
            private set;
        }

        public Pointer<string> HttpServer
        {
            get;
            private set;
        }

        public Pointer<int> HttpPort
        {
            get;
            private set;
        }

        public Pointer<string> SecureServer
        {
            get;
            private set;
        }

        public Pointer<int> SecurePort
        {
            get;
            private set;
        }

        public Pointer<string> FtpServer
        {
            get;
            private set;
        }

        public Pointer<int> FtpPort
        {
            get;
            private set;
        }

        public Pointer<string> SocksServer
        {
            get;
            private set;
        }

        public Pointer<int> SocksPort
        {
            get;
            private set;
        } 
        #endregion

        #region Bypass
        public Pointer<bool> BypassLocal
        {
            get;
            private set;
        }

        public Pointer<string> BypassPatterns
        {
            get;
            private set;
        } 
        #endregion

        #region Detection
        public Pointer<IPAddress> IPAddress
        {
            get;
            private set;
        }

        public Pointer<IPAddress> Subnet
        {
            get;
            private set;
        }

        public Pointer<IPAddress> Gateway
        {
            get;
            private set;
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Profile" /> class.
        /// </summary>
        public Profile()
        {
            Name = new Pointer<string>();
            EnableAutomatic = new Pointer<bool>();
            EnableAutomaticScript = new Pointer<bool>();
            AutomaticScript = new Pointer<string>();
            EnableProxy = new Pointer<bool>();
            UseSameProxyForAllProtocols = new Pointer<bool>(true);
            HttpServer = new Pointer<string>();
            HttpPort = new Pointer<int>();
            SecureServer = new Pointer<string>();
            SecurePort = new Pointer<int>();
            FtpServer = new Pointer<string>();
            FtpPort = new Pointer<int>();
            SocksServer = new Pointer<string>();
            SocksPort = new Pointer<int>();
            BypassLocal = new Pointer<bool>();
            BypassPatterns = new Pointer<string>();
            IPAddress = new Pointer<IPAddress>();
            Subnet = new Pointer<IPAddress>();
            Gateway = new Pointer<IPAddress>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Profile" /> class.
        /// </summary>
        public Profile(Profile profile)
        {
            Name = new Pointer<string>(profile.Name);
            EnableAutomatic = new Pointer<bool>(profile.EnableAutomatic);
            EnableAutomaticScript = new Pointer<bool>(profile.EnableAutomaticScript);
            AutomaticScript = new Pointer<string>(profile.AutomaticScript);
            EnableProxy = new Pointer<bool>(profile.EnableProxy);
            UseSameProxyForAllProtocols = new Pointer<bool>(profile.UseSameProxyForAllProtocols);
            HttpServer = new Pointer<string>(profile.HttpServer);
            HttpPort = new Pointer<int>(profile.HttpPort);
            SecureServer = new Pointer<string>(profile.SecureServer);
            SecurePort = new Pointer<int>(profile.SecurePort);
            FtpServer = new Pointer<string>(profile.FtpServer);
            FtpPort = new Pointer<int>(profile.FtpPort);
            SocksServer = new Pointer<string>(profile.SocksServer);
            SocksPort = new Pointer<int>(profile.SocksPort);
            BypassLocal = new Pointer<bool>(profile.BypassLocal);
            BypassPatterns = new Pointer<string>(profile.BypassPatterns);
            IPAddress = new Pointer<IPAddress>(profile.IPAddress);
            Subnet = new Pointer<IPAddress>(profile.Subnet);
            Gateway = new Pointer<IPAddress>(profile.Gateway);
        }

        public XElement CreateElement()
        {
            return
                new XElement("profile", new XAttribute("name", Name.Value),
                    new XElement("auto", new XAttribute("enable", EnableAutomatic.Value), new XAttribute("scripted", EnableAutomaticScript.Value), new XAttribute("script", AutomaticScript.Value ?? "")),
                    new XElement("proxy", new XAttribute("enable", EnableProxy.Value), new XAttribute("copy", UseSameProxyForAllProtocols.Value),
                        new XElement("http", new XAttribute("server", HttpServer.Value ?? ""), new XAttribute("port", HttpPort.Value)),
                        new XElement("secure", new XAttribute("server", SecureServer.Value ?? ""), new XAttribute("port", SecurePort.Value)),
                        new XElement("ftp", new XAttribute("server", FtpServer.Value ?? ""), new XAttribute("port", FtpPort.Value)),
                        new XElement("socks", new XAttribute("server", SocksServer.Value ?? ""), new XAttribute("port", SocksPort.Value))),
                    new XElement("bypass", new XAttribute("local", BypassLocal.Value), new XText(BypassPatterns.Value ?? "")),
                    new XElement("detection", new XAttribute("ip", ToString(IPAddress.Value)), new XAttribute("subnet", ToString(Subnet.Value)), new XAttribute("gateway", ToString(Gateway.Value)))
                );
        }

        private string ToString(IPAddress addr)
        {
            if (addr == null)
                return "";
            else
                return addr.ToString();
        }

        public void ParseElement(XElement profile)
        {
            Name.Value = (string)profile.Attribute("name");

            EnableAutomatic.Value = (bool)profile.Element("auto").Attribute("enable");
            EnableAutomaticScript.Value = (bool)profile.Element("auto").Attribute("scripted");
            AutomaticScript.Value = (string)profile.Element("auto").Attribute("script");

            EnableProxy.Value = (bool)profile.Element("proxy").Attribute("enable");
            UseSameProxyForAllProtocols.Value = (bool)profile.Element("proxy").Attribute("copy");

            HttpServer.Value = (string)profile.Element("proxy").Element("http").Attribute("server");
            HttpPort.Value = (int)profile.Element("proxy").Element("http").Attribute("port");
            SecureServer.Value = (string)profile.Element("proxy").Element("secure").Attribute("server");
            SecurePort.Value = (int)profile.Element("proxy").Element("secure").Attribute("port");
            FtpServer.Value = (string)profile.Element("proxy").Element("ftp").Attribute("server");
            FtpPort.Value = (int)profile.Element("proxy").Element("ftp").Attribute("port");
            SocksServer.Value = (string)profile.Element("proxy").Element("socks").Attribute("server");
            SocksPort.Value = (int)profile.Element("proxy").Element("socks").Attribute("port");

            BypassLocal.Value = (bool)profile.Element("bypass").Attribute("local");
            BypassPatterns.Value = (string)profile.Element("bypass").Value;

            IPAddress = ToIP(profile.Element("detection").Attribute("ip"));
            Subnet = ToIP(profile.Element("detection").Attribute("subnet"));
            Gateway = ToIP(profile.Element("detection").Attribute("gateway"));
        }

        private static IPAddress ToIP(XAttribute attr)
        {
            IPAddress addr;
            if (!System.Net.IPAddress.TryParse(attr.Value, out addr))
                addr = null;
            return addr;
        }

        public override string ToString()
        {
            return Name.Value;
        }
    }
}
