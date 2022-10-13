using Alzapp.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.OpenWhatsApp;

namespace Alzapp.ViewModels
{
    public class SOSViewModel : BaseViewModel
    {
        //CancellationTokenSource cts;

        public string CelularCuidador { get; set; }
        public string NombreCuidador { get; set; }

        public string SaveColor = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";

        public ICommand SaveCommand => new RelayCommand(Save);

        public ICommand DeleteCommand => new RelayCommand(Delete);

        public ICommand BackCommand => new RelayCommand(Back);
        public SOSViewModel()
        {
            if (Application.Current.Properties.ContainsKey("mostrarCuidador"))
            {
                string numeroCuidador = Application.Current.Properties["mostrarCuidador"] as string;
                if (numeroCuidador != null)
                {
                    CelularCuidador = numeroCuidador;
                }
            }
            if (Application.Current.Properties.ContainsKey("nombreCuidador"))
            {
                string nombreCuidador = Application.Current.Properties["nombreCuidador"] as string;
                if (nombreCuidador != null)
                {
                    NombreCuidador = nombreCuidador;
                }
            }

        }
        private async void Save()
        {
            if (string.IsNullOrEmpty(this.NombreCuidador))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Nombre.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.CelularCuidador))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Celular.", "Aceptar");
                return;
            }
            string celularCuidador ="+549" + CelularCuidador;
            string nombreCuidador = NombreCuidador;
            Application.Current.Properties["nombreCuidador"] = nombreCuidador;
            Application.Current.Properties["celularCuidador"] = celularCuidador;
            Application.Current.Properties["mostrarCuidador"] = CelularCuidador;
            await Application.Current.MainPage.DisplayAlert("Registro", "Se actualizo el número del Cuidador", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();

            //if (string.IsNullOrEmpty(CelularCuidador))
            //{
            //    await Application.Current.MainPage.DisplayAlert("Error", "Ingresa un Número de Celular", "Accept");
            //    return;
            //}

            //var sos = new SOS
            //{
            //    Id= 100,
            //    CelularCuidador = this.CelularCuidador

            //};

            //await App.SQLiteDB.SaveSOSAsync(sos);
            //await Application.Current.MainPage.DisplayAlert("Registro", "Se actualizo el número del Cuidador", "Ok");
            //MainViewModel.GetInstance().Principal.RefreshSOSList();
            //await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void Delete()
        {
            Application.Current.Properties["nombreCuidador"] = null;
            Application.Current.Properties["celularCuidador"] = null;
            Application.Current.Properties["mostrarCuidador"] = null;
            await Application.Current.MainPage.DisplayAlert("Borrar", "Se elimino el número del Cuidador", "Ok");
            await Application.Current.MainPage.Navigation.PopAsync();
            //var sos = new SOS
            //{
            //    Id = 100,
            //    CelularCuidador = "null"

            //};

            //await App.SQLiteDB.SaveSOSAsync(sos);
            //await Application.Current.MainPage.DisplayAlert("Borrar", "Se elimino el número del Cuidador", "Ok");
            //MainViewModel.GetInstance().Principal.DeleteSOSInList();
            //await Application.Current.MainPage.Navigation.PopAsync();
            //var idSOS = 100;
            //var sos = await App.SQLiteDB.GetSOSByIdAsync(idSOS);


            //if (sos != null)
            //{
            //    if (sos.CelularCuidador != null)
            //    {
            //        var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
            //        cts = new CancellationTokenSource();
            //        var location = await Geolocation.GetLocationAsync(request, cts.Token);

            //        if (location != null)
            //        {
            //            string Mensaje = "Me perdi, veni a buscarme estoy en: " + "https://www.google.com/maps/place/" + location.Latitude + location.Longitude;
            //            string Numero = sos.CelularCuidador;
            //            Chat.Open(Numero, Mensaje);
            //        }

            //        return;
            //    }
            //    return;
            //}
            //return;
        }
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
