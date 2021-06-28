using static DesktopHelper.Classes.Enumerations;

namespace DesktopHelper.Classes
{
    public class SelectionItem
    {
        #region Public Properties

        public string Text { get; private set; }

        public Page Page { get; private set; }

        #endregion Public Properties

        public SelectionItem(string text, Page page)
        {
            Text = text;
            Page = page;
        }

    }
}
