

namespace Alzapp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Views;
    using Xamarin.Forms;

    public class FotoViewModel
    {
        public ICommand InfanciaCommand => new RelayCommand(Infancia);
        public ICommand AdolescenciaCommand => new RelayCommand(Adolescencia);
        public ICommand AdultezCommand => new RelayCommand(Adultez);
        public ICommand PresenteCommand => new RelayCommand(Presente);
        public ICommand MomentosEspecialesCommand => new RelayCommand(MomentosEspeciales);
        public ICommand BackCommand => new RelayCommand(Back);
        private async void Infancia()
        {
            MainViewModel.GetInstance().Infancia = new InfanciaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new InfanciaPage());
        }
        private async void Adolescencia()
        {
            MainViewModel.GetInstance().Adolescencia = new AdolescenciaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AdolescenciaPage());
        }
        private async void Adultez()
        {
            MainViewModel.GetInstance().Adultez = new AdultezViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AdultezPage());
        }
        private async void Presente()
        {
            MainViewModel.GetInstance().Presente = new PresenteViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PresentePage());
        }
        private async void MomentosEspeciales()
        {
            MainViewModel.GetInstance().MomentosEspeciales = new MomentosEspecialesViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MomentosEspecialesPage());
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
