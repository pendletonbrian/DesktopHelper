using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Input;
using DesktopHelper.Classes;

namespace DesktopHelper.ViewModels
{
    public class MainWindowViewModel : NotifyObject, IDisposable
    {
        #region Public Members

        public static RoutedCommand ChangePageCommand = new();

        /// <summary>
        /// The base string to display in the title bar.
        /// </summary>
        internal const string STR_DEFAULT_TITLE_TEXT = "Desktop helper";

        #endregion Public Members

        #region Private Members

        /// <summary>
        /// How long, in seconds, to display the status bar message.
        /// </summary>
        private const int MAX_STATUS_MSG_COUNT = 8;

        /// <summary>
        /// The current number of seconds for which the timer has been counting.
        /// </summary>
        private int m_MessageTimerCount;

        /// <summary>
        /// The timer for the status message.
        /// </summary>
        private readonly Timer m_StatusMsgTimer = new();

        /// <summary>
        /// Text to display in status bar.
        /// </summary>
        private string m_StatusText = string.Empty;

        /// <summary>
        /// Text to display in the title bar.
        /// </summary>
        private string m_TitleText = string.Empty;

        /// <summary>
        /// Shows/runs the progress bar.
        /// </summary>
        private bool m_ShowProgressBar = false;

        /// <summary>
        /// Used by IDisposable.
        /// </summary>
        private bool disposedValue;

        /// <summary>
        /// The control in the main area.
        /// </summary>
        private readonly Classes.WpfPageTransitions.PageTransition m_PageTransitionControl;

        #endregion Private Members

        #region Public Properties

        /// <summary>
        /// Shows/runs the progress bar.
        /// </summary>
        public bool ShowProgressBar
        {
            get => m_ShowProgressBar;

            set
            {
                if (m_ShowProgressBar.Equals(value) == false)
                {
                    m_ShowProgressBar = value;

                    RaisePropertyChanged(nameof(ShowProgressBar));
                }
            }
        }

        public string StatusText
        {
            get => m_StatusText;

            set
            {
                if (m_StatusText.Equals(value, StringComparison.Ordinal) == false)
                {
                    m_StatusText = value;

                    RaisePropertyChanged(nameof(StatusText));
                }
            }
        }

        /// <summary>
        /// The text to display in the title bar.
        /// </summary>
        public string TitleText
        {
            get => m_TitleText;

            set
            {
                if (m_TitleText is null ||
                    m_TitleText.Equals(value, StringComparison.Ordinal) == false)
                {
                    m_TitleText = value;

                    RaisePropertyChanged(nameof(TitleText));
                }
            }
        }

        /// <summary>
        /// List of items to show on the left hand side bar.
        /// </summary>
        public List<SelectionItem> SelectionItems { get; } = new();

        #endregion Public Properties

        #region constructor

        public MainWindowViewModel(Classes.WpfPageTransitions.PageTransition transitionControl)
        {
            TitleText = STR_DEFAULT_TITLE_TEXT;

            m_StatusMsgTimer.Interval = 1000;
            m_StatusMsgTimer.Elapsed += MsgTimer_Elapsed;

            m_PageTransitionControl = transitionControl;

            SelectionItems.Add(new SelectionItem("Directory Contents", Enumerations.Page.DirectoryContents));
            SelectionItems.Add(new SelectionItem("NIC", Enumerations.Page.NIC));
            SelectionItems.Add(new SelectionItem("Time", Enumerations.Page.Time));
        }

        #endregion constructor

        #region Private Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~MainWindowViewModel()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        private void MsgTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (MAX_STATUS_MSG_COUNT <= (++m_MessageTimerCount))
            {
                m_StatusMsgTimer.Stop();
                StatusText = string.Empty;
            }
        }

        #endregion Private Methods

        #region Public Methods

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Sets the status message at the bottom of the form.
        /// </summary>
        /// <param name="msg">The message to be shown.</param>
        /// <param name="autoRemove">
        /// Whether or not to automatically remove the message after a set period of time.
        /// </param>
        internal void SetStatusMessage(string msg, bool autoRemove = true)
        {
            StatusText = msg;

            if (autoRemove)
            {
                m_MessageTimerCount = 0;

                m_StatusMsgTimer.Start();
            }
        }

        /// <summary>
        /// Appends the given text to the base title text.
        /// </summary>
        /// <param name="txt"></param>
        internal void SetTitleText(string txt)
        {
            TitleText = string.Format("{0} {1}", STR_DEFAULT_TITLE_TEXT, txt);
        }

        /// <summary>
        /// Adds a new user control page to the stack, then shows the page.
        /// </summary>
        /// <param name="pageType"></param>
        /// <param name="additionalData"></param>
        /// <param name="transitionType"></param>
        internal void ShowNextPage(Enumerations.Page pageType,
            object additionalData = null,
            Enumerations.PageTransitionType transitionType = Enumerations.PageTransitionType.SlideAndFade)
        {
            UserControl newPage = null;

            switch (pageType)
            {
                case Enumerations.Page.None:
                    break;

                case Enumerations.Page.DirectoryContents:
                    break;

                case Enumerations.Page.NIC:
                    
                    break;

                case Enumerations.Page.Time:
                    break;

                default:
                    throw new Exception($"Unhandled case: {pageType}");
            }

            if (newPage is null)
            {
                return;
            }

            m_PageTransitionControl.ShowPage(newPage);
            m_PageTransitionControl.TransitionType = transitionType;
        }

        #endregion Public Methods

    }
}
