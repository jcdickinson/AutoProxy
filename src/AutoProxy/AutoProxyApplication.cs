using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AutoProxy
{
    /// <summary>
    /// Represents the AutoProxy application.
    /// </summary>
    public class AutoProxyApplication : ApplicationContext
    {
        private NotifyIcon _notify;
        private SettingsWindow _window;
        private List<Profile> _profiles;
        private string _lastProfile = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoProxyApplication" /> class.
        /// </summary>
        public AutoProxyApplication()
        {
            _profiles = new List<Profile>();
            LoadSettings();

            NetworkChange.NetworkAddressChanged += NetworkChange_NetworkAddressChanged;

            _notify = new NotifyIcon();
            _notify.Icon = Properties.Resources.proxy;
            _notify.Text = "AutoProxy: starting...";
            _notify.Visible = true;

            _notify.Click += _notify_Click;

            Pulse();
        }

        void _notify_Click(object sender, EventArgs e)
        {
            if (_window != null)
            {
                _window.Show();
                return;
            }

            using (_window = new SettingsWindow(_profiles, _lastProfile))
            {
                switch (_window.ShowDialog())
                {
                    case DialogResult.Abort:
                        Application.Exit();
                        break;
                    case DialogResult.OK:
                        _profiles = _window.Profiles;
                        SaveSettings();
                        Pulse();
                        break;
                }
            }
            _window = null;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ApplicationContext" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _notify.Visible = false;
                _notify.Dispose();
            }
            base.Dispose(disposing);
        }

        private void LoadSettings()
        {
            var profiles = Properties.Settings.Default.Profiles;
            if (string.IsNullOrWhiteSpace(profiles))
            {
                _profiles.Add(CreateDefaultProfile());
            }
            else
            {
                var doc = XDocument.Parse(profiles);
                foreach (var elem in doc.Root.Elements())
                {
                    var prof = new Profile();
                    prof.ParseElement(elem);
                    _profiles.Add(prof);
                }
            }
        }

        private void SaveSettings()
        {
            var elem = new XElement("profiles");
            foreach (var prof in _profiles)
                elem.Add(prof.CreateElement());
            var data = elem.ToString();
            Properties.Settings.Default.Profiles = data;
            Properties.Settings.Default.Save();
        }

        private Profile CreateDefaultProfile()
        {
            var prof = new Profile();
            prof.Name.Value = "(Default)";
            return prof;
        }

        void NetworkChange_NetworkAddressChanged(object sender, EventArgs e)
        {
            Pulse();
        }

        private void Pulse()
        {
            foreach (var iface in NetworkInterface.GetAllNetworkInterfaces().Where(x => x.OperationalStatus == OperationalStatus.Up))
            {
                var ip = iface.GetIPProperties();
                var ipv4 = ip.GetIPv4Properties();
                if (ip.DhcpServerAddresses.Count > 0 &&
                    ip.GatewayAddresses.Count > 0 &&
                    !ipv4.IsAutomaticPrivateAddressingActive &&
                    ipv4.IsDhcpEnabled)
                {
                    var ipAddr = ip.UnicastAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                    var gw = ip.GatewayAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();

                    if (ipAddr != null)
                    {
                        var addrBytes = ipAddr.Address.GetAddressBytes();
                        var maskBytes = ipAddr.IPv4Mask.GetAddressBytes();

                        var prof = MatchNetwork(ipAddr, gw, addrBytes, maskBytes);
                        if (prof != null)
                        {
                            ApplyProfile(prof);
                            return;
                        }
                    }
                }
            }

            var def = _profiles.Where(x => x.IsDefault).FirstOrDefault();
            if (def != null)
                ApplyProfile(def);
        }

        private Profile MatchNetwork(UnicastIPAddressInformation ipAddr, GatewayIPAddressInformation gw, byte[] addrBytes, byte[] maskBytes)
        {
            var maxConfidence = 0;
            Profile result = null;

            foreach (var item in _profiles)
            {
                var confidence = 6;

                if (item.Subnet.Value == null)
                    confidence -= 1;
                else if (!item.Subnet.Value.Equals(ipAddr.IPv4Mask))
                    confidence = 0;

                if (item.IPAddress.Value == null)
                {
                    confidence -= 1;
                }
                else
                {
                    var compBytes = item.IPAddress.Value.GetAddressBytes();
                    for (var i = 0; i < compBytes.Length; i++)
                    {
                        if ((addrBytes[i] & maskBytes[i]) !=
                            (compBytes[i] & maskBytes[i]))
                        {
                            confidence = 0;
                            break;
                        }
                    }
                }

                if (item.Gateway.Value == null)
                    confidence -= 1;
                else if (!item.Gateway.Value.Equals(gw.Address))
                    confidence = 0;

                confidence = Math.Max(0, confidence);
                if (confidence > maxConfidence)
                {
                    maxConfidence = confidence;
                    result = item;
                }
            }

            return result;
        }

        private void ApplyProfile(Profile prof)
        {
            using (var settings = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings", true))
            using (var connection = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Internet Settings\Connections", true))
            {
                if (prof.EnableAutomaticScript)
                    settings.SetValue("AutoConfigURL", prof.AutomaticScript.Value);
                else if (settings.GetValueNames().Contains("AutoConfigURL"))
                    settings.DeleteValue("AutoConfigURL");

                if (prof.EnableProxy)
                {
                    settings.SetValue("ProxyEnable", 1);

                    Tuple<string, string, int>[] items;
                    if (prof.UseSameProxyForAllProtocols)
                    {
                        if (!string.IsNullOrWhiteSpace(prof.HttpServer.Value))
                        {
                            if (prof.HttpPort.Value <= 0)
                                settings.SetValue("ProxyServer", string.Format(CultureInfo.InvariantCulture, "{0}:80", prof.HttpServer.Value));
                            else
                                settings.SetValue("ProxyServer", string.Format(CultureInfo.InvariantCulture, "{0}:{1}", prof.HttpServer.Value, prof.HttpPort.Value));
                        }
                        else if (settings.GetValueNames().Contains("ProxyServer"))
                        {
                            settings.DeleteValue("ProxyServer");
                        }
                    }
                    else
                    {
                        items = new[] {
                            Tuple.Create("http", prof.HttpServer.Value, prof.HttpPort.Value),
                            Tuple.Create("https", prof.SecureServer.Value, prof.SecurePort.Value),
                            Tuple.Create("ftp", prof.FtpServer.Value, prof.FtpPort.Value),
                            Tuple.Create("socks", prof.SocksServer.Value, prof.SocksPort.Value)};

                        var sb = new StringBuilder();
                        foreach (var item in items)
                        {
                            if (sb.Length != 0)
                                sb.Append(";");
                            if (!string.IsNullOrWhiteSpace(item.Item2))
                            {
                                if (item.Item3 <= 0)
                                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}:80", item.Item1, item.Item2);
                                else
                                    sb.AppendFormat(CultureInfo.InvariantCulture, "{0}={1}:{2}", item.Item1, item.Item2, item.Item3);
                            }
                        }
                        if (sb.Length > 0)
                        {
                            settings.SetValue("ProxyServer", sb.ToString());
                        }
                        else if (settings.GetValueNames().Contains("ProxyServer"))
                        {
                            settings.DeleteValue("ProxyServer");
                        }
                    }

                    var local = prof.BypassLocal.Value ? "<local>" : null;
                    var bypass = string.IsNullOrWhiteSpace(prof.BypassPatterns.Value) ? local : prof.BypassPatterns.Value + ";" + local;

                    if (!string.IsNullOrWhiteSpace(bypass))
                        settings.SetValue("ProxyOverride", bypass);
                    else if (settings.GetValueNames().Contains("ProxyOverride"))
                        settings.DeleteValue("ProxyOverride");
                }
                else
                {
                    settings.SetValue("ProxyEnable", 0);
                }

                var cs = ConnectionSettings.Read((byte[])connection.GetValue("DefaultConnectionSettings"));
                cs.Counter++;

                cs.AutodetectScript = (string)settings.GetValue("AutoConfigURL", "");
                if (!string.IsNullOrWhiteSpace(cs.AutodetectScript))
                    cs.Autodetect |= Autodetect.AutoConfig;
                else
                    cs.Autodetect &= ~Autodetect.AutoConfig;

                // No registry backer.
                if (prof.EnableAutomatic)
                    cs.Autodetect |= Autodetect.AutoDetect;
                else
                    cs.Autodetect &= ~Autodetect.AutoDetect;

                cs.ProxyServer = (string)settings.GetValue("ProxyServer", "");
                if ((int)settings.GetValue("ProxyEnable", 0) == 1)
                    cs.Autodetect |= Autodetect.Manual;
                else
                    cs.Autodetect &= ~Autodetect.Manual;

                cs.ExtraData = (string)settings.GetValue("ProxyOverride", "");

                connection.SetValue("DefaultConnectionSettings", cs.Write());
            }

            NativeMethods.RefreshInternetOptions();

            _lastProfile = prof.Name;
            _notify.Text = "AutoProxy: " + _lastProfile;
        }
    }
}
