using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Input;
using DesktopHelper.Classes;

namespace DesktopHelper.ViewModels
{
    public class NicPageViewModel : NotifyObject
    {
        #region Private Members

        private string m_SelectedIpAddress = string.Empty;

        #endregion Private Members

        #region Public Members

        public static RoutedCommand CopyIpAddressCommand = new RoutedCommand();

        #endregion Public Members

        #region constructor

        public NicPageViewModel()
        { }

        #endregion constructor

        #region Public Properties

        public List<string> NicNames { get; } = new();

        public string SelectedIpAddress
        {
            get { return m_SelectedIpAddress; }

            set
            {
                if (string.IsNullOrWhiteSpace(m_SelectedIpAddress) ||
                    m_SelectedIpAddress != value)
                {
                    m_SelectedIpAddress = value;

                    RaisePropertyChanged(nameof(SelectedIpAddress));
                }
            }
        }

        #endregion Public Properties

        #region Public Methods

        internal void LoadNicList()
        {
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                NicNames.Add("Network not available");

                return;
            }

            var ipAddresses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (var ip in ipAddresses)
            {
                // Get the IPv4 addresses
                // Use "InterNetworkV6" for IPv6
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    NicNames.Add(ip.ToString());
                }
            }
        }

        internal bool CanCopyIpAddress()
        {
            return string.IsNullOrWhiteSpace(m_SelectedIpAddress) != true;
        }

        #endregion Public Methods
    }
}
