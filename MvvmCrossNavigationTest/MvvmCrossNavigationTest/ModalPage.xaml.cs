using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;

namespace MvvmCrossNavigationTest
{
    [MvxModalPresentation(PresentationStyle = MvxFormsModalPresentationStyle.OverFullScreen, WrapInNavigationPage = false, Animated = false)]
    public partial class ModalPage : MvxContentPage<ModalPageViewModel>
    {
        public ModalPage()
        {
            InitializeComponent();
        }
    }
}