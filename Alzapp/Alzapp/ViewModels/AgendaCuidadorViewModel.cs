using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class AgendaCuidadorViewModel : BaseViewModel
    {
        private ObservableCollection<AgendaItemViewModel> agendas;
        private List<Agenda> myAgendas;
        private bool isRefreshing;
        public ObservableCollection<AgendaItemViewModel> Agendas
        {
            get => agendas;
            set => SetValue(ref agendas, value);
        }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }
        public ICommand RefreshCommand => new RelayCommand(RefreshAgendaList);
        public ICommand BackCommand => new RelayCommand(Back);
        public ICommand AddAgendaCommand => new RelayCommand(AddAgenda);
        public AgendaCuidadorViewModel()
        {
            llenarDatos();
        }
        public async void llenarDatos()
        {
            IsRefreshing = true;
            this.myAgendas = await App.SQLiteDB.GetAgendaAsync();

            this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Manana = p.Manana,
                Tarde = p.Tarde,
                Noche = p.Noche,
                Actividad = "",
                Actividad2 = ""


            })
            .OrderBy(p => p.Dia)
            .ToList());
            IsRefreshing = false;
        }

        public async void RefreshAgendaList()
        {
            IsRefreshing = true;
            await Task.Delay(2000);
            myAgendas = await App.SQLiteDB.GetAgendaAsync();
            this.Agendas = new ObservableCollection<AgendaItemViewModel>(myAgendas.Select(p => new AgendaItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Manana = p.Manana,
                Tarde = p.Tarde,
                Noche = p.Noche,
                Actividad = "",
                Actividad2 = ""
            })
            .OrderBy(p => p.Dia)
            .ToList());
            IsRefreshing = false;
        }

        public void DeleteAgendaInList(int agendaId)
        {
            var sacarAgenda = this.myAgendas.Where(p => p.Id == agendaId).FirstOrDefault();
            if (sacarAgenda != null)
            {
                this.myAgendas.Remove(sacarAgenda);
            }

            this.RefreshAgendaList();
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void AddAgenda()
        {
            MainViewModel.GetInstance().AddAgenda = new AddAgendaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AddAgendaPage());
        }
    }
}