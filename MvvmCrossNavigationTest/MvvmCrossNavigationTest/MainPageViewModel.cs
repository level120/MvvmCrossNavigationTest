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

        public MainPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new MvxAsyncCommand(Navigate);
        }

        private async Task Navigate()
        {
            var parameter = await _navigationService.Navigate<RecursionPageViewModel, Parameter, Parameter>(new Parameter());
        }
    }
}