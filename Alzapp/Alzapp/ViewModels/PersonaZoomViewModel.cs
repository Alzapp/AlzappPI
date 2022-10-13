
namespace Alzapp.ViewModels
{
    using Alzapp.Models;
    using GalaSoft.MvvmLight.Command;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Xamarin.Essentials;
    using Xamarin.Forms;

    public class PersonaZoomViewModel : BaseViewModel
    {
        public Persona Persona { get; set; }

        private ImageSource imageUrl;

        public List<PersonaLista> PersonaList { get; set; }

        public ImageSource ImageUrl
        {
            get => this.imageUrl;
            set => this.SetValue(ref this.imageUrl, value);
        }
        public string DireccionFoto { get; set; }

        public ICommand LlamarCommand => new RelayCommand(Llamar);

        public ICommand UbicacionCommand => new RelayCommand(Ubicacion);
        public ICommand BackCommand => new RelayCommand(Back);


        public PersonaZoomViewModel(Persona persona)
        {
            Persona = persona;
            DireccionFoto = Persona.ImageUrl;
            ImageUrl = DireccionFoto;
            PersonaList = new List<PersonaLista>()
            {
                new PersonaLista() { Imagenes = Persona.ImageUrl },
                new PersonaLista() { Imagenes = Persona.ImageUrl2 },
                new PersonaLista() { Imagenes = Persona.ImageUrl3}};

        }


        private void Llamar()
        {
            PhoneDialer.Open(Persona.Celular);
        }
        private async void Ubicacion()
        {
            var address = Persona.Domicilio;
            var locations = await Geocoding.GetLocationsAsync(address);
            var location = locations?.FirstOrDefault();

            var lat = location.Latitude;
            var lng = location.Longitude;
            await Map.OpenAsync(lat, lng, new MapLaunchOptions
            {
                Name = "Casa de " + Persona.Nombre,
                NavigationMode = NavigationMode.None
            });

        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
