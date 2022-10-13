using Alzapp.Models;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class AddAgendaViewModel : BaseViewModel
    {

        public string Dia { get; set; }

        public string Manana { get; set; }
        public string Tarde { get; set; }
        public string Noche { get; set; }
        public string Actividad { get; set; }
        public string Actividad2 { get; set; }

        public string SaveColor = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";

        public ICommand SaveCommand => new RelayCommand(Save);
        public ICommand BackCommand => new RelayCommand(Back);

        public AddAgendaViewModel()
        {
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(Dia))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes seleccionar un día de la semana.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Manana) && string.IsNullOrEmpty(Tarde) && string.IsNullOrEmpty(Noche))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Deber ingresar una Actividad.", "Aceptar");
                return;
            }



            var agenda = new Agenda
            {
                Dia = this.Dia,
                Manana = this.Manana,
                Tarde = this.Tarde,
                Noche = this.Noche,
                Actividad = "",
                Actividad2 = ""
            };
            await App.SQLiteDB.SaveAgendaAsync(agenda);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se guardo de manera exitosa la Actividad del dia " + Dia, "Ok");
            MainViewModel.GetInstance().AgendaAyer.RefreshAgendaList();
            MainViewModel.GetInstance().AgendaCuidador.RefreshAgendaList();
            //MainViewModel.GetInstance().Agenda.RefreshAgendaList();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
