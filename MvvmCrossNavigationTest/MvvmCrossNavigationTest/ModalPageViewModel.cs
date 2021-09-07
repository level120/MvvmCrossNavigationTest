using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationTest
{
    public class ModalPageViewModel : MvxViewModelResult<object>
    {
        private readonly IMvxNavigationService _navigationService;

        public ICommand CloseCommand { get; }

        public ModalPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            CloseCommand = new MvxAsyncCommand<object>(CloseAndReturn);
        }

        private async Task CloseAndReturn(object obj)
        {
            await _navigationService.Close(this, obj);
        }
    }
}