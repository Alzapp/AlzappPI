using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class JuegoDeNumerosViewModel : BaseViewModel
    {
        public string colorFacil = "linear-gradient(45deg, rgba(22,43,22, 0.5) 0%, rgba(22,43,22, 0.5) 12.5%,rgba(33,54,28, 0.5) 12.5%, rgba(33,54,28, 0.5) 25%,rgba(28,83,25, 0.5) 25%, rgba(28,83,25, 0.5) 37.5%,rgba(33,114,22, 0.5) 37.5%, rgba(33,114,22, 0.5) 50%,rgba(37,144,20, 0.5) 50%, rgba(37,144,20, 0.5) 62.5%,rgba(36,175,17, 0.5) 62.5%, rgba(36,175,17, 0.5) 75%,rgba(14,205,24, 0.5) 75%, rgba(14,205,24, 0.5) 87.5%,rgba(13,236,11, 0.5) 87.5%, rgba(13,236,11, 0.5) 100%),linear-gradient(135deg, rgb(20,188,0) 0%, rgb(20,188,0) 12.5%,rgb(4,173,9) 12.5%, rgb(4,173,9) 25%,rgb(7,158,14) 25%, rgb(7,158,14) 37.5%,rgb(34,143,11) 37.5%, rgb(34,143,11) 50%,rgb(15,129,24) 50%, rgb(15,129,24) 62.5%,rgb(21,115,19) 62.5%, rgb(21,115,19) 75%,rgb(29,106,22) 75%, rgb(29,106,22) 87.5%,rgb(26,97,27) 87.5%, rgb(26,97,27) 100%)";
        public string colorMedio = "linear-gradient(45deg, rgba(43,42,22, 0.5) 0%, rgba(43,42,22, 0.5) 12.5%,rgba(54,52,28, 0.5) 12.5%, rgba(54,52,28, 0.5) 25%,rgba(83,79,25, 0.5) 25%, rgba(83,79,25, 0.5) 37.5%,rgba(114,109,22, 0.5) 37.5%, rgba(114,109,22, 0.5) 50%,rgba(144,134,20, 0.5) 50%, rgba(144,134,20, 0.5) 62.5%,rgba(175,165,17, 0.5) 62.5%, rgba(175,165,17, 0.5) 75%,rgba(205,204,14, 0.5) 75%, rgba(205,204,14, 0.5) 87.5%,rgba(236,221,11, 0.5) 87.5%, rgba(236,221,11, 0.5) 100%),linear-gradient(135deg, rgb(188,172,0) 0%, rgb(188,172,0) 12.5%,rgb(172,173,4) 12.5%, rgb(172,173,4) 25%,rgb(158,156,7) 25%, rgb(158,156,7) 37.5%,rgba(138,143,11, 0.98) 37.5%, rgba(138,143,11, 0.98) 50%,rgb(129,126,15) 50%, rgb(129,126,15) 62.5%,rgb(115,115,19) 62.5%, rgb(115,115,19) 75%,rgb(106,97,22) 75%, rgb(106,97,22) 87.5%,rgb(97,93,26) 87.5%, rgb(97,93,26) 100%)";
        public string colorDificil = "linear-gradient(45deg, rgba(43,22,22, 0.5) 0%, rgba(43,22,22, 0.5) 12.5%,rgba(54,28,28, 0.5) 12.5%, rgba(54,28,28, 0.5) 25%,rgba(83,25,25, 0.5) 25%, rgba(83,25,25, 0.5) 37.5%,rgba(114,22,22, 0.5) 37.5%, rgba(114,22,22, 0.5) 50%,rgba(144,20,20, 0.5) 50%, rgba(144,20,20, 0.5) 62.5%,rgba(175,17,17, 0.5) 62.5%, rgba(175,17,17, 0.5) 75%,rgba(205,14,14, 0.5) 75%, rgba(205,14,14, 0.5) 87.5%,rgba(236,11,11, 0.5) 87.5%, rgba(236,11,11, 0.5) 100%),linear-gradient(135deg, rgb(188,0,0) 0%, rgb(188,0,0) 12.5%,rgb(173,4,4) 12.5%, rgb(173,4,4) 25%,rgb(158,7,7) 25%, rgb(158,7,7) 37.5%,rgb(143,11,11) 37.5%, rgb(143,11,11) 50%,rgb(129,15,15) 50%, rgb(129,15,15) 62.5%,rgb(115,19,19) 62.5%, rgb(115,19,19) 75%,rgb(106,22,22) 75%, rgb(106,22,22) 87.5%,rgb(97,26,26) 87.5%, rgb(97,26,26) 100%)";

        public string ColorFacil
        {
            get => colorFacil;
            set => SetValue(ref colorFacil, value);
        }
        public string ColorMedio
        {
            get => colorMedio;
            set => SetValue(ref colorMedio, value);
        }
        public string ColorDificil
        {
            get => colorDificil;
            set => SetValue(ref colorDificil, value);
        }

        public ICommand JuegoFacilCommand => new RelayCommand(JuegoFacil);
        public ICommand JuegoMedioCommand => new RelayCommand(JuegoMedio);
        public ICommand JuegoDificilCommand => new RelayCommand(JuegoDificil);
        public ICommand BackCommand => new RelayCommand(Back);

        public JuegoDeNumerosViewModel()
        {
        }

        private async void JuegoFacil()
        {
            MainViewModel.GetInstance().JuegoNumeros3x3 = new JuegoNumeros3x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros3x3Page());
        }
        private async void JuegoMedio()
        {
            MainViewModel.GetInstance().JuegoNumeros4x3 = new JuegoNumeros4x3ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros4x3Page());
        }

        private async void JuegoDificil()
        {
            MainViewModel.GetInstance().JuegoNumeros4x4 = new JuegoNumeros4x4ViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegoNumeros4x4Page());
        }
        
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
