using MvvmCross.Forms.Views;
using Xamarin.Forms.Xaml;

namespace MvvmCrossNavigationTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecursionPage : MvxContentPage<RecursionPageViewModel>
    {
        public RecursionPage()
        {
            InitializeComponent();
        }
    }
}