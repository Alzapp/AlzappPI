//Controlador de la vista Configuracion

namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ConfiguracionViewModel
    {
        public ICommand PersonaCuidadorCommand => new RelayCommand(PersonaCuidador);
        public ICommand AgendaCuidadorCommand => new RelayCommand(AgendaCuidador);
        public ICommand FotoCuidadorCommand => new RelayCommand(FotoCuidador);
        public ICommand MedicamentosCuidadorCommand => new RelayCommand(MedicamentosCuidador);
        public ICommand SOSCuidadorCommand => new RelayCommand(SOSCuidador);
        public ICommand BackCommand => new RelayCommand(Back);


        //CAMBIAR LAS VIEWS
        private async void PersonaCuidador()
        {
            MainViewModel.GetInstance().Persona = new PersonaViewModel();
            MainViewModel.GetInstance().PersonaCuidador = new PersonaCuidadorViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PersonaCuidadorPage());
        }
        private async void AgendaCuidador()
        {
            MainViewModel.GetInstance().AgendaAyer = new AgendaAyerViewModel();
            MainViewModel.GetInstance().AgendaCuidador = new AgendaCuidadorViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AgendaCuidadorPage());
        }

        private async void FotoCuidador()
        {
            MainViewModel.GetInstance().Infancia = new InfanciaViewModel();
            MainViewModel.GetInstance().Adolescencia = new AdolescenciaViewModel();
            MainViewModel.GetInstance().Adultez = new AdultezViewModel();
            MainViewModel.GetInstance().Presente = new PresenteViewModel();
            MainViewModel.GetInstance().MomentosEspeciales = new MomentosEspecialesViewModel();
            MainViewModel.GetInstance().FotoCuidador = new FotoCuidadorViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new FotoCuidadorPage());
        }
        private async void MedicamentosCuidador()
        {
            MainViewModel.GetInstance().Medicamentos = new MedicamentosViewModel();
            MainViewModel.GetInstance().MedicamentosCuidador = new MedicamentosCuidadorViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MedicamentosCuidadorPage());
        }
        private async void SOSCuidador()
        {
            MainViewModel.GetInstance().SOS = new SOSViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new SOSPage());
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
