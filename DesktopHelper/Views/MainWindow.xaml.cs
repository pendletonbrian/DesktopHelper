using System;
using System.Windows;
using DesktopHelper.Classes;
using DesktopHelper.ViewModels;

namespace DesktopHelper.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        #region Private Members

        private readonly MainWindowViewModel m_ViewModel;
        private bool disposedValue;

        #endregion Private Members

        #region constructor

        public MainWindow()
        {
            InitializeComponent();

            m_ViewModel = new MainWindowViewModel(pageTransitionControl);

            DataContext = m_ViewModel;
        }

        #endregion constructor

        #region Public Methods

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Public Methods

        #region Private Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)

                    m_ViewModel?.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MainWindow()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        private void ChangePageCommand_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;

            e.Handled = true;
        }

        private void ChangePageCommand_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                var selectedPage = (Enumerations.Page)e.Parameter;

                m_ViewModel.ShowNextPage(selectedPage,
                    null,
                    Enumerations.PageTransitionType.FlipAndFade);
            }
            catch (Exception ex)
            {
                MessageBox.Show(this,
                    $"There was an exception: {ex.Message}",
                    MainWindowViewModel.STR_DEFAULT_TITLE_TEXT,
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        #endregion Private Methods
    }
}
