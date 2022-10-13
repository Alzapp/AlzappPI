using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using Plugin.LocalNotification;
using Plugin.LocalNotification.EventArgs;
using Plugin.LocalNotification.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class AddMedicamentosViewModel : BaseViewModel
    {
        private readonly NotificationSerializer _notificationSerializer;

        private MediaFile file;
        private ImageSource imageSource;
        public ImageSource ImageSource
        {
            get => this.imageSource;
            set => this.SetValue(ref this.imageSource, value);
        }

        public string SaveColor = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";

        public DateTime DatePicker { get; set; }
        public TimeSpan TimePicker { get; set; }
        //public Boolean SwitchRepeat { get; set; }

        public string Dia { get; set; }

        public string Hora { get; set; }
        public string Titulo { get; set; }

        public string Mensaje { get; set; }
        public string Unidad { get; set; }
        public string Cantidad { get; set; }
        public string DireccionFoto { get; set; }
        public int IdNotificacion { get; set; }
        
        public ICommand SaveCommand => new RelayCommand(Save);
        public ICommand ChangeImageCommand => new RelayCommand(this.ChangeImage);
        public ICommand BackCommand => new RelayCommand(Back);
        public AddMedicamentosViewModel()
        {
            _notificationSerializer = new NotificationSerializer();

            DatePicker = DateTime.Today;
            TimePicker = DateTime.Now.TimeOfDay.Add(TimeSpan.FromSeconds(10));


            this.imageSource = "noPhoto";

            //cuando se va a mostrar notificación, esto permite modificarla
            LocalNotificationCenter.Current.NotificationReceiving = OnNotificationReceiving;

            //se dispara cuando se recibe la notificación. en iOS, este evento se activa solo cuando la aplicación está en primer plano
            LocalNotificationCenter.Current.NotificationReceived += ShowCustomAlertFromNotification;

            //se dispara cuando se toca la acción emergente de notificación
            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;


        }
        private async void Save()
        {
            
            if (string.IsNullOrEmpty(Titulo))
            {
                await Application.Current.MainPage.DisplayAlert("Faltan Datos", "Ingrese un Titulo", "Ok");
                return;
            }
            if (string.IsNullOrEmpty(Mensaje))
            {
                await Application.Current.MainPage.DisplayAlert("Faltan Datos", "Ingrese un Mensaje", "Ok");
                return;
            }
            

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = ReadFully(this.file.GetStream());
            }


            var title = Titulo;
            var Description = Mensaje;
            Dia = DatePicker.ToString("dd/MM/yyyy");
            Hora = TimePicker.ToString("hh") + ":" + TimePicker.ToString("mm");
            string notificationId = DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("hh") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            IdNotificacion = Int32.Parse(notificationId);

            var medicamentos = new Medicamentos
            {
                Dia = this.Dia,
                Hora = this.Hora,
                Titulo = this.Titulo,
                Mensaje = this.Mensaje,
                ImageUrl = DireccionFoto,
                Unidad = this.Unidad,
                Cantidad = this.Cantidad,
                DatePicker = this.DatePicker,
                TimePicker = this.TimePicker,
                IdNotificacion = this.IdNotificacion

            };
            
            var list = new List<string>
            {
                typeof(MedicamentosPage).FullName,
                IdNotificacion.ToString(),
                title,
                Description
            };
            var serializeReturningData = _notificationSerializer.Serialize(list);
            //var imageStream = GetType().Assembly.GetManifestResourceStream("Alzapp.alzapp.png");
            //byte[] imageBytes = null;
            //if (imageStream != null)
            //{
            //    using (var ms = new MemoryStream())
            //    {
            //        await imageStream.CopyToAsync(ms);
            //        imageBytes = ms.ToArray();
            //    }
            //}
            var request = new NotificationRequest
            {
                NotificationId = IdNotificacion,
                Title = title,
                Subtitle = "Medicamento",
                Description = Description,
                BadgeNumber = 1,
                ReturningData = serializeReturningData,
                //Image =
                //{
                //    Binary = imageBytes
                //},
                CategoryType = NotificationCategoryType.Event,
                Android =
                {
                    IconLargeName =
                    {
                        ResourceName = "alzapp",
                    },
                    IconSmallName =
                    {
                        ResourceName = "AlzappSmall.png"
                    }

                }


            };
            var notifyDateTime = DatePicker.Date.Add(TimePicker); ;
            if (notifyDateTime <= DateTime.Now)
            {
                notifyDateTime = DateTime.Now.AddSeconds(1);
            }
            request.Schedule.NotifyAutoCancelTime = DateTime.Now.AddMinutes(5);
            request.Schedule.NotifyTime = notifyDateTime;
            //if (SwitchRepeat == true)
            //{
            //    request.Schedule.RepeatType = NotificationRepeat.TimeInterval;
            //    request.Schedule.NotifyRepeatInterval = TimeSpan.FromDays (1);
            //}
            try
            {
                var ff = await LocalNotificationCenter.Current.Show(request);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }



            await App.SQLiteDB.SaveMedicamentosAsync(medicamentos);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se guardo de manera exitosa el Medicamento", "Ok");
            MainViewModel.GetInstance().MedicamentosCuidador.RefreshMedicamentosList();
            MainViewModel.GetInstance().Medicamentos.RefreshMedicamentosList();
            await Application.Current.MainPage.Navigation.PopAsync();


        }
        private async void ChangeImage()
        {
            await CrossMedia.Current.Initialize();

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "¿De donde quieres seleccionar la imagen?",
                "Cancelar",
                null,
                "Desde Galeria",
                "Desde Camara");

            if (source == "Cancelar")
            {
                this.file = null;
                return;
            }

            if (source == "Desde Camara")
            {
                this.file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Full
                    }
                );
                if (this.file != null)
                {
                    DireccionFoto = file.Path;
                }
            }

            if (source == "Desde Galeria")
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();

                if (this.file != null)
                {
                    DireccionFoto = file.Path;
                }

            }

            if (source == null)
            {
                this.file = null;
                return;
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
                DireccionFoto = file.Path;
            }


        }
        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
        private Task<NotificationEventReceivingArgs> OnNotificationReceiving(NotificationRequest request)
        {
            request.Title = $"{request.Title}";

            return Task.FromResult(new NotificationEventReceivingArgs
            {
                Handled = false,
                Request = request                
            });

        }
        private void ShowCustomAlertFromNotification(NotificationEventArgs e)
        {
            if (e.Request is null)
            {
                return;
            }

            System.Diagnostics.Debug.WriteLine(e);

            Device.BeginInvokeOnMainThread(() =>
            {

                Application.Current.MainPage.DisplayAlert(e.Request.Title, "Recuerda tomar la Pastilla", "OK");

            });
        }
        private async void Current_NotificationActionTapped(NotificationActionEventArgs e)
        {

            if (e.IsDismissed)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert(e.Request.Title, "Recuerda tomar la Pastilla", "OK");
                    MainViewModel.GetInstance().Medicamentos = new MedicamentosViewModel();
                    Application.Current.MainPage.Navigation.PushAsync(new MedicamentosPage());
                });
                return;
            }

            if (e.IsTapped)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Application.Current.MainPage.DisplayAlert(e.Request.Title, "Recuerda tomar la Pastilla", "OK");
                    MainViewModel.GetInstance().Medicamentos = new MedicamentosViewModel();
                    Application.Current.MainPage.Navigation.PushAsync(new MedicamentosPage());
                });
                return;

            }

            switch (e.ActionId)
            {
                case 2000000:

                    await Application.Current.MainPage.DisplayAlert(e.Request.Title, "Hello Button was Tapped", "OK");

                    break;

                case 101:
                    LocalNotificationCenter.Current.Cancel(e.Request.NotificationId);
                    break;
            }
        }





        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
