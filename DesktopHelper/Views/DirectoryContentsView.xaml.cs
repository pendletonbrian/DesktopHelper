using DesktopHelper.ViewModels;

namespace DesktopHelper.Views
{
    /// <summary>
    /// Interaction logic for DirectoryContentsView.xaml
    /// </summary>
    public partial class DirectoryContentsView : BasePageView
    {
        public DirectoryContentsView(MainWindowViewModel parentVM) : base(parentVM)
        {
            InitializeComponent();
        }
    }
}
