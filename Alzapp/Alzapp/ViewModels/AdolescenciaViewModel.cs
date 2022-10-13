

namespace Alzapp.ViewModels
{
    using Alzapp.Models;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AdolescenciaViewModel : BaseViewModel
    {
        private List<Foto> myFotos;
        private ObservableCollection<FotoItemViewModel> fotos;
        private bool isRefreshing;

        public ObservableCollection<FotoItemViewModel> Fotos
        {
            get => fotos;
            set => SetValue(ref fotos, value);
        }
        public bool IsRefreshing
        {
            get => isRefreshing;
            set => SetValue(ref isRefreshing, value);
        }

        public ICommand BackCommand => new RelayCommand(Back);
        public ICommand RefreshCommand => new RelayCommand(RefreshFotosList);

        public AdolescenciaViewModel()
        {
            llenarDatos();
        }

        private async void llenarDatos()
        {
            IsRefreshing = true;

            myFotos = await App.SQLiteDB.GetFotosAsync();
            Fotos = new ObservableCollection<FotoItemViewModel>(myFotos.Select(p => new FotoItemViewModel

            {
                Id = p.Id,
                Name = p.Name,
                Etapa = p.Etapa,
                ImageUrl = p.ImageUrl
            })
            .OrderBy(p => p.Name)
            .Where(e => e.Etapa == "Adolescencia")
            .ToList());

            IsRefreshing = false;

        }


        public void DeleteFotoInList(int fotoId)
        {
            var sacarFoto = myFotos.Where(p => p.Id == fotoId).FirstOrDefault();
            if (sacarFoto != null)
            {
                myFotos.Remove(sacarFoto);
            }

            RefreshFotosList();
        }

        public async void RefreshFotosList()
        {
            IsRefreshing = true;
            await Task.Delay(2000);
            myFotos = await App.SQLiteDB.GetFotosAsync();
            Fotos = new ObservableCollection<FotoItemViewModel>(myFotos.Select(p => new FotoItemViewModel

            {
                Id = p.Id,
                Name = p.Name,
                Etapa = p.Etapa,
                ImageUrl = p.ImageUrl
            })
            .OrderBy(p => p.Name)
            .Where(e => e.Etapa == "Adolescencia")
            .ToList());
            IsRefreshing = false;
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
