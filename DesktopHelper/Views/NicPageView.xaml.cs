using System.Windows;
using System.Windows.Input;
using DesktopHelper.ViewModels;

namespace DesktopHelper.Views
{
    /// <summary>
    /// Interaction logic for NicPageView.xaml
    /// </summary>
    public partial class NicPageView : BasePageView
    {
        #region Private Members

        private NicPageViewModel m_ViewModel;

        #endregion Private Members

        #region constructor

        public NicPageView(MainWindowViewModel parentVM) : base(parentVM)
        {
            m_ViewModel = new NicPageViewModel();

            DataContext = m_ViewModel;

            InitializeComponent();
        }

        #endregion constructor

        #region Private Methods

        private void NicPageView_Loaded(object sender, RoutedEventArgs e)
        {
            m_ViewModel.LoadNicList();
        }

        private void CopyIpAddressCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = m_ViewModel is not null && m_ViewModel.CanCopyIpAddress();
        }

        private void CopyIpAddressCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Clipboard.SetText(m_ViewModel.SelectedIpAddress, TextDataFormat.Text);

            SetStatusText($"Copied \"{m_ViewModel.SelectedIpAddress}\".");
        }

        #endregion Private Methods
    }
}
