namespace DesktopHelper.Classes
{
    public static class Enumerations
    {
        /// <summary>
        /// A comprehensive list of pages.
        /// </summary>
        /// <remarks>
        /// When updating this, make certain to update the MainWindowViewModel.GetPageEnumerationType
        /// and MainWindowViewModel.GetPageUserControlType conversion methods.
        /// </remarks>
        public enum Page
        {
            None = 0,
            DirectoryContents,
            NIC,
            Time
        }

        /// <summary>
        /// List of ways to move a page out of view, and a new one into view.
        /// </summary>
        public enum PageTransitionType
        {
            None = 0,

            Fade,

            /// <summary>
            /// Slide to the left.
            /// </summary>
            Slide,

            /// <summary>
            /// Slide to the left.
            /// </summary>
            SlideAndFade,

            Grow,
            GrowAndFade,
            Flip,
            FlipAndFade,
            Spin,
            SpinAndFade,

            /// <summary>
            /// Slide to the right.
            /// </summary>
            SlideBack,

            /// <summary>
            /// Slide to the right.
            /// </summary>
            SlideBackAndFade,

            Up,

            UpAndFade,

            Down,

            DownAndFade
        }
    }
}
