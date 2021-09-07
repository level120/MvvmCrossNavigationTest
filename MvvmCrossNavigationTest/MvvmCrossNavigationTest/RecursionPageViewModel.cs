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

        public RecursionPageViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new MvxAsyncCommand<int>(Navigate);
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