namespace Alzapp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class EditAgendaViewModel : BaseViewModel
    {

        public Agenda Agenda { get; set; }
        public string borrarColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(123,0,0),rgb(123,0,0))";
        public string BorrarColor
        {
            get => borrarColor;
            set => SetValue(ref borrarColor, value);
        }
        public string ActividadUno { get; set; }
        public string ActividadDos { get; set; }

        public ICommand SaveCommand => new RelayCommand(Save);

        public ICommand DeleteCommand => new RelayCommand(Delete);
        public ICommand BackCommand => new RelayCommand(Back);

        public EditAgendaViewModel(Agenda agenda)
        {
            Agenda = agenda;
            ActividadUno = Agenda.Actividad;

            ActividadDos = Agenda.Actividad2;

            if (ActividadUno == null)
            {
                ActividadUno = "";
            }
            if (ActividadDos == null)
            {
                ActividadDos = "";
            }

        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(Agenda.Dia))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes seleccionar un día de la semana.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Agenda.Manana) && string.IsNullOrEmpty(Agenda.Tarde) && string.IsNullOrEmpty(Agenda.Noche))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Deber ingresar una Actividad.", "Aceptar");
                return;
            }


            Agenda agenda = new Agenda()
            {
                Id = Agenda.Id,
                Dia = Agenda.Dia,
                Manana = Agenda.Manana,
                Tarde = Agenda.Tarde,
                Noche = Agenda.Noche,
                Actividad = ActividadUno,
                Actividad2 = ActividadDos
            };
            await App.SQLiteDB.SaveAgendaAsync(agenda);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se actualizo de manera correcta la Agenda", "Ok");
            //MainViewModel.GetInstance().AgendaCuidador.RefreshAgendaList();
            //MainViewModel.GetInstance().Agenda.RefreshAgendaList();

            await Application.Current.MainPage.Navigation.PopAsync();


        }

        private async void Delete()
        {


            var idAgenda = Agenda.Id;
            var agenda = await App.SQLiteDB.GetAgendaByIdAsync(idAgenda);
            if (agenda != null)
            {
                await App.SQLiteDB.DeleteAgendaAsync(agenda);
                await Application.Current.MainPage.DisplayAlert("Agenda", "Se elimino de manera exitosa", "Ok");
                //MainViewModel.GetInstance().AgendaCuidador.DeleteAgendaInList(idAgenda);
                //MainViewModel.GetInstance().Agenda.DeleteAgendaInList(idAgenda);

                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
