using Alzapp.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class PersonaViewModel : BaseViewModel
    {
        private ObservableCollection<PersonaItemViewModel> personas;
        private List<Persona> myPersonas;
        private bool isRefreshing;
        public ObservableCollection<PersonaItemViewModel> Personas
        {
            get => personas;
            set => SetValue(ref personas, value);
        }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }
        public ICommand BackCommand => new RelayCommand(Back);
        public ICommand RefreshCommand => new RelayCommand(RefreshPersonaList);
        public PersonaViewModel()
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
    }



}
