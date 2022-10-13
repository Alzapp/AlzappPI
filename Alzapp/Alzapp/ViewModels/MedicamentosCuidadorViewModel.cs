using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class MedicamentosCuidadorViewModel : BaseViewModel
    {
        private ObservableCollection<MedicamentosItemViewModel> medicamentos;
        private List<Medicamentos> myMedicamentos;
        public ObservableCollection<MedicamentosItemViewModel> Medicamentoss
        {
            get => medicamentos;
            set => SetValue(ref medicamentos, value);
        }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }
        public ICommand RefreshCommand => new RelayCommand(RefreshMedicamentosList);
        public ICommand BackCommand => new RelayCommand(Back);
        public ICommand AddMedicamentosCommand => new RelayCommand(AddMedicamentos);
        public MedicamentosCuidadorViewModel()
        {
            IsRefreshing = true;
            llenarDatos();
            IsRefreshing = false;
        }

        public async void llenarDatos()
        {
            IsRefreshing = true;
            await Task.Delay(2000);
            myMedicamentos = await App.SQLiteDB.GetMedicamentosAsync();

            Medicamentoss = new ObservableCollection<MedicamentosItemViewModel>(myMedicamentos.Select(p => new MedicamentosItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Hora = p.Hora,
                Titulo = p.Titulo,
                Mensaje = p.Mensaje,
                ImageUrl = p.ImageUrl,
                Cantidad = p.Cantidad,
                Unidad = p.Unidad,
                TimePicker = p.TimePicker,
                DatePicker = p.DatePicker,
                IdNotificacion = p.IdNotificacion


            })
            .OrderBy(p => p.Dia)
            .OrderBy(p => p.Hora)            
            .ToList());
            IsRefreshing = false;
        }
        public async void RefreshMedicamentosList()
        {
            IsRefreshing = true;
            await Task.Delay(2000);
            myMedicamentos = await App.SQLiteDB.GetMedicamentosAsync();

            Medicamentoss = new ObservableCollection<MedicamentosItemViewModel>(myMedicamentos.Select(p => new MedicamentosItemViewModel

            {
                Id = p.Id,
                Dia = p.Dia,
                Hora = p.Hora,
                Titulo = p.Titulo,
                Mensaje = p.Mensaje,
                ImageUrl = p.ImageUrl,
                Cantidad = p.Cantidad,
                Unidad = p.Unidad,
                TimePicker = p.TimePicker,
                DatePicker = p.DatePicker,
                IdNotificacion = p.IdNotificacion

            })
            .OrderBy(p => p.Dia)
            .OrderBy(p => p.Hora)            
            .ToList());
            IsRefreshing = false;
        }
        public void DeleteMedicamentosInList(int medicamentoId)
        {
            var sacarMedicamento = myMedicamentos.Where(p => p.Id == medicamentoId).FirstOrDefault();
            if (sacarMedicamento != null)
            {
                myMedicamentos.Remove(sacarMedicamento);
            }

            RefreshMedicamentosList();

        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void AddMedicamentos()
        {
            MainViewModel.GetInstance().AddMedicamentos = new AddMedicamentosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AddMedicamentosPage());
        }
    }
}
