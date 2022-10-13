//Controlador de la vista Principal

namespace Alzapp.ViewModels
{
    using Alzapp.Models;
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Threading;
    using System.Windows.Input;
    using Xamarin.Essentials;
    using Xamarin.Forms;
    using Xamarin.Forms.OpenWhatsApp;

    public class PrincipalViewModel
    {
        CancellationTokenSource cts;
        public ICommand PersonaCommand => new RelayCommand(Persona);
        public ICommand AgendaCommand => new RelayCommand(Agenda);
        public ICommand FotoCommand => new RelayCommand(Foto);
        public ICommand JuegoCommand => new RelayCommand(Juego);
        public ICommand CuidadorCommand => new RelayCommand(Cuidador);
        public ICommand UbicarCommand => new RelayCommand(Ubicar);
        public ICommand MedicamentosCommand => new RelayCommand(Medicamentos);
        
        private async void Persona()
        {
            MainViewModel.GetInstance().Persona = new PersonaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new PersonaPage());
        }
        private async void Agenda()
        {
            MainViewModel.GetInstance().Agenda = new AgendaViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new AgendaPage());
        }
        private async void Foto()
        {
            MainViewModel.GetInstance().Foto = new FotoViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new FotoPage());
        }
        private async void Juego()
        {
            MainViewModel.GetInstance().Juegos = new JuegosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new JuegosPage());
        }

        private async void Ubicar()
        {
            if (Application.Current.Properties.ContainsKey("nombreCuidador"))
            {
                if (Application.Current.Properties.ContainsKey("celularCuidador"))
                {
                    string nombreCuidador = Application.Current.Properties["nombreCuidador"] as string;
                    bool enviar = await Application.Current.MainPage.DisplayAlert("¿Te perdiste?", "Deseas enviar una notificacion a " + nombreCuidador, "Si" , "No");
                    if (enviar == true)
                    {
                        string numeroCuidador = Application.Current.Properties["celularCuidador"] as string;
                        if (numeroCuidador != null)
                        {
                            var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(1));
                            cts = new CancellationTokenSource();
                            var location = await Geolocation.GetLocationAsync(request, cts.Token);

                            if (location != null)
                            {
                                string Mensaje = "Me perdi, veni a buscarme estoy en: " + "https://www.google.com/maps/place/" + location.Latitude + location.Longitude;
                                string Numero = numeroCuidador;
                                Chat.Open(Numero, Mensaje);
                            }
                        }
                        return;
                    }
                    else
                    {
                        return;
                    };
                    
                }
                return;
            }
            return;
            


            //var idSOS = 100;
            //var sos = await App.SQLiteDB.GetSOSByIdAsync(idSOS);
            //Sos = sos;
            //if (Sos != null)
            //{
            //    if(Sos.CelularCuidador != null)
            //    {
            //        var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            //        cts = new CancellationTokenSource();
            //        var location = await Geolocation.GetLocationAsync(request, cts.Token);

            //        if (location != null)
            //        {
            //            string Mensaje = "Me perdi, veni a buscarme estoy en: " + "https://www.google.com/maps/place/" + location.Latitude + location.Longitude;
            //            string Numero = Sos.CelularCuidador;
            //            Chat.Open(Numero, Mensaje);
            //        }

            //        return;
            //    }
            //    return;
            //}
            //return;
        }
        private async void Cuidador()
        {
            //MainViewModel.GetInstance().Configuracion = new ConfiguracionViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new ConfiguracionPage());
            string result = await Application.Current.MainPage.DisplayPromptAsync("ACCESO EXCLUSIVO PARA EL CUIDADOR", "Inserte Contraseña");

            if (result == "2021")
            {
                MainViewModel.GetInstance().Configuracion = new ConfiguracionViewModel();
                await Application.Current.MainPage.Navigation.PushAsync(new ConfiguracionPage());
                return;
            }
            if (result == null)
            {
                return;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Contraseña incorrecta",
                    "Ok");
                return;

            }
        }
        private async void Medicamentos()
        {
            MainViewModel.GetInstance().Medicamentos = new MedicamentosViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new MedicamentosPage());
        }
    }
}
