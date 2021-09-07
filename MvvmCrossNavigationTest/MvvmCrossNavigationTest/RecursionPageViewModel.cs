using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace MvvmCrossNavigationTest
{
    public class RecursionPageViewModel : MvxViewModel<Parameter, Parameter>
    {
        private readonly IMvxNavigationService _navigationService;

        public Parameter Parameter { get; set; }
        public ICommand NavigateCommand { get; }
        public ICommand CloseCommand { get; }
        public ICommand ModalNavigateCommand { get; }

        public RecursionPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new MvxAsyncCommand<int>(Navigate);
            ModalNavigateCommand = new MvxAsyncCommand(ModalNavigate);
            CloseCommand = new MvxAsyncCommand(Close);
        }

        private async Task Close()
        {
            await _navigationService.Close(this, Parameter);
        }

        private async Task Navigate(int number)
        {
            var parameter = await _navigationService.Navigate<RecursionPageViewModel, Parameter, Parameter>(new Parameter(number + 1));
        }

        private async Task ModalNavigate()
        {
            var obj = await _navigationService.Navigate<ModalPageViewModel, object>();
        }

        public override void Prepare(Parameter parameter)
        {
            Parameter = parameter;
        }
    }

    public class Parameter
    {
        public int Number { get; set; }

        public Parameter(int number = 1)
        {
            Number = number;
        }
    }
}