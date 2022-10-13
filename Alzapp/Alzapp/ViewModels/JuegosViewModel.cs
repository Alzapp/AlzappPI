

namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class JuegosViewModel : BaseViewModel
    {
               
        public string colorNumeros = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";
        public string colorParejas = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(0,0,0),rgb(0,0,0))";
        public string ColorNumeros
        {
            get => colorNumeros;
            set => SetValue(ref colorNumeros, value);
        }
        public string ColorParejas
        {
            get => colorParejas;
            set => SetValue(ref colorParejas, value);
        }

        public ICommand JuegoDeParejasCommand => new RelayCommand(JuegoDeParejas);
        public ICommand JuegoDeNumerosCommand => new RelayCommand(JuegoDeNumeros);
        public ICommand BackCommand => new RelayCommand(Back);

        public JuegosViewModel()
        {
        }

        private async void JuegoDeParejas()
        {
            MainViewModel.GetInstance().JuegoDeParejas = new JuegoDeParejasViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoDeParejasPage());
        }
        private async void JuegoDeNumeros()
        {
            MainViewModel.GetInstance().JuegoDeNumeros = new JuegoDeNumerosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoDeNumerosPage());
        }

        private async void JuegoNumeros4x3()
        {
            MainViewModel.GetInstance().JuegoNumeros4x3 = new JuegoNumeros4x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros4x3Page());
        }
        private async void JuegoNumeros4x4()
        {
            MainViewModel.GetInstance().JuegoNumeros4x4 = new JuegoNumeros4x4ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros4x4Page());
        }
        private async void Juego2x2()
        {
            MainViewModel.GetInstance().JuegoMemoria2x2 = new Juego2x2ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria2x2Page());
        }
        private async void Juego3x2()
        {
            MainViewModel.GetInstance().JuegoMemoria3x2 = new Juego3x2ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria3x2Page());
        }
        private async void Juego4x2()
        {
            MainViewModel.GetInstance().JuegoMemoria4x2 = new Juego4x2ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria4x2Page());
        }
        private async void Juego4x3()
        {
            MainViewModel.GetInstance().JuegoMemoria4x3 = new Juego4x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria4x3Page());
        }
        private async void Juego4x4()
        {
            MainViewModel.GetInstance().JuegoMemoria4x4 = new Juego4x4ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoMemoria4x4Page());
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
