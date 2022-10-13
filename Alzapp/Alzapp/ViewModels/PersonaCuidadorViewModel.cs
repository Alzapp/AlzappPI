namespace Alzapp.ViewModels
{
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

    public class PersonaCuidadorViewModel : BaseViewModel
    {
        private ObservableCollection<PersonaItemViewModel> personas;
        private List<Persona> myPersonas;

        public ObservableCollection<PersonaItemViewModel> Personas
        {
            get => personas;
            set => SetValue(ref personas, value);
        }
        private bool isRefreshing;
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }
        public ICommand RefreshCommand => new RelayCommand(RefreshPersonaList);
        public ICommand BackCommand => new RelayCommand(Back);
        public ICommand AddPersonaCommand => new RelayCommand(AddPersona);
        public PersonaCuidadorViewModel()
        {
            llenarDatos();
        }

        public async void llenarDatos()
        {
            IsRefreshing = true;
            myPersonas = await App.SQLiteDB.GetPersonasAsync();

            Personas = new ObservableCollection<PersonaItemViewModel>(myPersonas.Select(p => new PersonaItemViewModel

            {
                Id = p.Id,
                Nombre = p.Nombre,
                Domicilio = p.Domicilio,
                Celular = p.Celular,
                Relacion = p.Relacion,
                ImageUrl = p.ImageUrl,
                ImageUrl2 = p.ImageUrl2,
                ImageUrl3 = p.ImageUrl3


            })
            .OrderBy(p => p.Nombre)
            .ToList());
            IsRefreshing = false;
        }

        public async void RefreshPersonaList()
        {
            IsRefreshing = true;
            await Task.Delay(2000);
            myPersonas = await App.SQLiteDB.GetPersonasAsync();
            Personas = new ObservableCollection<PersonaItemViewModel>(myPersonas.Select(p => new PersonaItemViewModel

            {
                Id = p.Id,
                Nombre = p.Nombre,
                Domicilio = p.Domicilio,
                Celular = p.Celular,
                Relacion = p.Relacion,
                ImageUrl = p.ImageUrl,
                ImageUrl2 = p.ImageUrl2,
                ImageUrl3 = p.ImageUrl3
            })
            .OrderBy(p => p.Nombre)
            .ToList());
            IsRefreshing = false;
        }

        public void DeletePersonaInList(int personaId)
        {
            var sacarPersona = myPersonas.Where(p => p.Id == personaId).FirstOrDefault();
            if (sacarPersona != null)
            {
                myPersonas.Remove(sacarPersona);
            }

            RefreshPersonaList();
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        public async void AddPersona()
        {
            MainViewModel.GetInstance().Persona = new PersonaViewModel();
            MainViewModel.GetInstance().PersonaCuidador = new PersonaCuidadorViewModel();
            MainViewModel.GetInstance().AddPersona = new AddPersonaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AddPersonaPage());
        }
    }
}