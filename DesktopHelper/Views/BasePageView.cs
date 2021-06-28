using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DesktopHelper.ViewModels;

namespace DesktopHelper.Views
{
    public class BasePageView : UserControl
    {
        #region Private Members

        private MainWindowViewModel m_MainWindowVM;

        #endregion Private Members

        #region constructors

        public BasePageView()
        {
            Loaded += BasePageView_Loaded;
        }

        public BasePageView(MainWindowViewModel parentVM) : this()
        {
            m_MainWindowVM = parentVM;
        }

        #endregion constructors

        #region Private Methods

        private void BasePageView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (m_MainWindowVM is null)
            {
                return;
            }

            m_MainWindowVM.SetStatusMessage(string.Empty, false);
        }

        #endregion Private Methods

    }
}
