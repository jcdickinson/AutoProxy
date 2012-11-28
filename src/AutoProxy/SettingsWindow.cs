using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoProxy
{
    public partial class SettingsWindow : Form
    {
        private List<Profile> _profiles;
        private HashSet<string> _controlsInError = new HashSet<string>();

        public List<Profile> Profiles
        {
            get { return _profiles; }
        }

        public SettingsWindow()
        {
            this.Font = SystemFonts.DialogFont;
            InitializeComponent();
            titleLabel.Font = new Font(SystemFonts.DialogFont.FontFamily, titleLabel.Font.Size, FontStyle.Bold);
        }

        public SettingsWindow(IEnumerable<Profile> profiles, string lastProfile)
            : this()
        {
            profileLabel.Text = "Active profile: " + lastProfile;
            _profiles = new List<Profile>();
            foreach (var item in profiles)
            {
                var newItem = new Profile(item);
                _profiles.Add(newItem);
                profilesComboBox.Items.Add(newItem);
                if (newItem.IsDefault)
                    profilesComboBox.SelectedItem = newItem;
            }
        }

        private void profilesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profile = profilesComboBox.SelectedItem as Profile;
            if (profile != null)
            {
                addButton.Enabled = false;
                removeButton.Enabled = !profile.IsDefault;

                SetupCheckBox(profile.EnableAutomatic, automaticCheckBox);
                SetupCheckBox(profile.EnableAutomaticScript, scriptCheckBox);
                SetupTextBox(profile.AutomaticScript, scriptTextBox);

                SetupCheckBox(profile.EnableProxy, useProxyCheckBox);
                SetupCheckBox(profile.UseSameProxyForAllProtocols, sameProxyCheckBox);

                SetupTextBox(profile.HttpServer, httpServerTextBox);
                SetupTextBox(profile.HttpPort, httpPortTextBox);
                SetupTextBox(profile.SecureServer, secureServerTextBox);
                SetupTextBox(profile.SecurePort, securePortTextBox);
                SetupTextBox(profile.FtpServer, ftpServerTextBox);
                SetupTextBox(profile.FtpPort, ftpPortTextBox);
                SetupTextBox(profile.SocksServer, socksServerTextBox);
                SetupTextBox(profile.SocksPort, socksPortTextBox);

                SetupCheckBox(profile.BypassLocal, bypassCheckBox);
                SetupTextBox(profile.BypassPatterns, bypassTextBox);

                SetupTextBox(profile.IPAddress, ipTextBox);
                SetupTextBox(profile.Subnet, subnetTextBox);
                SetupTextBox(profile.Gateway, gatewayTextBox);

            }
            else
            {
                removeButton.Enabled = false;
                addButton.Enabled = true;
            }
        }

        private void profilesComboBox_TextUpdate(object sender, EventArgs e)
        {
            var profile = profilesComboBox.SelectedItem as Profile;
            if (profile == null || profile.Name.Value != profilesComboBox.Text)
            {
                addButton.Enabled = !string.IsNullOrWhiteSpace(profilesComboBox.Text);
                removeButton.Enabled = false;
            }
            else
            {
                profilesComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void SetupTextBox(IPointer pointer, TextBox textBox)
        {
            textBox.TextChanged -= textBox_TextChanged;
            textBox.TextChanged += textBox_TextChanged;
            textBox.Tag = pointer;

            if (pointer.Value == null || (pointer.Value is int && (int)pointer.Value == 0))
                textBox.Text = "";
            else
                textBox.Text = pointer.Value.ToString();
        }

        void textBox_TextChanged(object sender, EventArgs e)
        {
            var tb = (TextBox)sender;
            var str = tb.Tag as Pointer<string>;
            if (str == null)
            {
                var i = tb.Tag as Pointer<int>;
                if (i == null)
                {
                    var ip = tb.Tag as Pointer<IPAddress>;
                    if (ip == null)
                    {
                    }
                    else
                    {
                        IPAddress v = null;
                        if (tb.Text == "" || IPAddress.TryParse(tb.Text, out v))
                        {
                            ip.Value = v;
                            ValidationStatus(tb, null);
                        }
                        else
                        {
                            ValidationStatus(tb, "Must be an IP address.");
                        }
                    }
                }
                else
                {
                    var v = 0;
                    if (tb.Text == "" || int.TryParse(tb.Text, NumberStyles.None, CultureInfo.CurrentUICulture, out v))
                    {
                        i.Value = v;
                        ValidationStatus(tb, null);
                    }
                    else
                    {
                        ValidationStatus(tb, "Must be a number.");
                    }
                }
            }
            else
            {
                str.Value = tb.Text;
            }
        }

        private void SetupCheckBox(Pointer<bool> pointer, CheckBox checkBox)
        {
            checkBox.CheckedChanged -= checkBox_CheckedChanged;
            checkBox.CheckedChanged += checkBox_CheckedChanged;
            checkBox.Tag = pointer;

            checkBox.Checked = pointer.Value;
        }

        void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            ((Pointer<bool>)((CheckBox)sender).Tag).Value = ((CheckBox)sender).Checked;
        }

        private void scriptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scriptTextBox.Enabled = scriptCheckBox.Checked;
        }

        private void proxyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sameProxyCheckBox.Enabled = useProxyCheckBox.Checked;
            httpServerTextBox.Enabled = httpPortTextBox.Enabled = useProxyCheckBox.Checked;

            secureServerTextBox.Enabled = securePortTextBox.Enabled =
            ftpServerTextBox.Enabled = ftpPortTextBox.Enabled =
            socksServerTextBox.Enabled = socksPortTextBox.Enabled =
                !sameProxyCheckBox.Checked && useProxyCheckBox.Checked;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var profile = new Profile();
            profile.Name.Value = profilesComboBox.Text;
            _profiles.Add(profile);
            profilesComboBox.Items.Add(profile);
            profilesComboBox.SelectedItem = profile;
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var prof = profilesComboBox.SelectedItem as Profile;
            if (prof != null && !prof.IsDefault)
            {
                _profiles.Remove(prof);
                profilesComboBox.Items.Remove(prof);

                foreach (var item in _profiles)
                {
                    if (item.IsDefault)
                    {
                        profilesComboBox.SelectedItem = item;
                        return;
                    }
                }
            }
        }

        private void currentButton_Click(object sender, EventArgs e)
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
                    if (ipAddr != null)
                    {
                        var addrBytes = ipAddr.Address.GetAddressBytes();
                        var maskBytes = ipAddr.IPv4Mask.GetAddressBytes();
                        for (var i = 0; i < addrBytes.Length; i++)
                            addrBytes[i] &= maskBytes[i];

                        ipTextBox.Text = new IPAddress(addrBytes).ToString();
                        subnetTextBox.Text = ipAddr.IPv4Mask.ToString();
                    }
                    else
                    {
                        ipTextBox.Text = "";
                        subnetTextBox.Text = "";
                    }

                    var gw = ip.GatewayAddresses.Where(x => x.Address.AddressFamily == AddressFamily.InterNetwork).FirstOrDefault();
                    if (gw != null)
                        gatewayTextBox.Text = gw.Address.ToString();
                    else
                        gatewayTextBox.Text = "";
                    break;
                }
            }
        }

        private void ValidationStatus(Control control, string message)
        {
            errorProvider.SetError(control, message);
            if (message == null)
                _controlsInError.Remove(control.Name);
            else
                _controlsInError.Add(control.Name);
            okButton.Enabled = _controlsInError.Count == 0;
        }

        private void githubPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/jcdickinson/AutoProxy");
        }
    }
}
