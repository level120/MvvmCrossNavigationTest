using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationTest
{
    public class MainPageViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;

        public ICommand NavigateCommand { get; }
        public ICommand ModalNavigateCommand { get; }

        public MainPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new MvxAsyncCommand(Navigate);
            ModalNavigateCommand = new MvxAsyncCommand(ModalNavigate);
        }

        private async Task Navigate()
        {
            var parameter = await _navigationService.Navigate<RecursionPageViewModel, Parameter, Parameter>(new Parameter());
        }

        private async Task ModalNavigate()
        {
            var obj = await _navigationService.Navigate<ModalPageViewModel, object>();
        }
    }
}