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
    public class EditMedicamentosViewModel : BaseViewModel
    {
        //private readonly NotificationSerializer _notificationSerializer;
        public Medicamentos Medicamentos { get; set; }

        public string borrarColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(123,0,0),rgb(123,0,0))";

        public string BorrarColor
        {
            get => borrarColor;
            set => SetValue(ref borrarColor, value);
        }

        private MediaFile file;
        private ImageSource imageUrl;
        public DateTime DatePicker { get; set; }
        public TimeSpan TimePicker { get; set; }
        //public Boolean SwitchRepeat { get; set; }
        public string Dia { get; set; }

        public string Hora { get; set; }
        public ImageSource ImageUrl
        {
            get => this.imageUrl;
            set => this.SetValue(ref this.imageUrl, value);
        }
        public string DireccionFoto { get; set; }
        public int IdNotificacion { get; set; }
        

        public ICommand SaveCommand => new RelayCommand(Save);

        public ICommand DeleteCommand => new RelayCommand(Delete);

        public ICommand ChangeImageCommand => new RelayCommand(ChangeImage);
        public ICommand BackCommand => new RelayCommand(Back);

        public EditMedicamentosViewModel(Medicamentos medicamentos)
        {
            Medicamentos = medicamentos;
            DireccionFoto = Medicamentos.ImageUrl;
            ImageUrl = DireccionFoto;
            if (DireccionFoto == null)
            {
                ImageUrl = "noPhoto";
            }
            //cuando se va a mostrar notificación, esto permite modificarla
            LocalNotificationCenter.Current.NotificationReceiving = OnNotificationReceiving;

            //se dispara cuando se recibe la notificación. en iOS, este evento se activa solo cuando la aplicación está en primer plano
            LocalNotificationCenter.Current.NotificationReceived += ShowCustomAlertFromNotification;

            //se dispara cuando se toca la acción emergente de notificación
            LocalNotificationCenter.Current.NotificationActionTapped += Current_NotificationActionTapped;
        }
        private async void Save()
        {
            if (string.IsNullOrEmpty(Medicamentos.Dia))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Día.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Medicamentos.Hora))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar una Hora.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Medicamentos.Titulo))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Titulo.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Medicamentos.Mensaje))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Mensaje.", "Aceptar");
                return;
            }            

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = ReadFully(this.file.GetStream());
            }

            var title = Medicamentos.Titulo;
            var Description = Medicamentos.Mensaje;
            Dia = DatePicker.ToString("dd/MM/yyyy");
            Hora = TimePicker.ToString("hh") + ":" + TimePicker.ToString("mm");

            var medicamentos = new Medicamentos
            {
                Id = Medicamentos.Id,
                Dia = Medicamentos.Dia,
                Hora = Medicamentos.Hora,
                Titulo = Medicamentos.Titulo,
                Mensaje = Medicamentos.Mensaje,
                ImageUrl = DireccionFoto,
                Unidad = Medicamentos.Unidad,
                Cantidad = Medicamentos.Cantidad,
                DatePicker = Medicamentos.DatePicker,
                TimePicker = Medicamentos.TimePicker,
                IdNotificacion = Medicamentos.IdNotificacion

            };

            //var list = new List<string>
            //{
            //    typeof(MedicamentosPage).FullName,
            //    Medicamentos.IdNotificacion.ToString(),
            //    title,
            //    Description
            //};
            //var serializeReturningData = _notificationSerializer.Serialize(list);

            //var imageStream = GetType().Assembly.GetManifestResourceStream(DireccionFoto);
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
                NotificationId = Medicamentos.IdNotificacion,
                Title = title,
                Subtitle = "Medicamento",
                Description = Description,
                BadgeNumber = 1,
                //ReturningData = serializeReturningData,
                //Image =
                //{
                //    ResourceName = DireccionFoto
                //    //ResourceName = "alzapp"
                //    //Binary = imageBytes
                //},
                CategoryType = NotificationCategoryType.Event,
                Android =
                {
                    IconLargeName =
                    {
                        ResourceName = "alzapp"
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
            request.Schedule.NotifyAutoCancelTime = notifyDateTime.AddMinutes(5);
            request.Schedule.NotifyTime = notifyDateTime;            
            //if (SwitchRepeat == true)
            //{
            //    request.Schedule.RepeatType = NotificationRepeat.TimeInterval;
            //    request.Schedule.NotifyRepeatInterval = TimeSpan.FromDays(1);
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
        private async void Delete()
        {
            var idMedicamento = Medicamentos.Id;
            var titleMedicamento = Medicamentos.Titulo;
            var descripcionMedicamento = Medicamentos.Mensaje;
            var medicamento = await App.SQLiteDB.GetMedicamentosByIdAsync(idMedicamento);
            if (medicamento != null)
            {
                await App.SQLiteDB.DeleteMedicamentosAsync(medicamento);
                var request = new NotificationRequest
                {
                    NotificationId = Medicamentos.IdNotificacion,
                    Title = "Se elimino la alarma :",
                    Subtitle = titleMedicamento,
                    Description = descripcionMedicamento,
                    BadgeNumber = 1,

                    CategoryType = NotificationCategoryType.Event

                };

                var notifyDateTime = DateTime.Now.AddSeconds(0);                
                request.Schedule.NotifyAutoCancelTime = notifyDateTime;
                request.Schedule.NotifyTime = notifyDateTime;                
                try
                {
                    var ff = await LocalNotificationCenter.Current.Show(request);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                }
                await Application.Current.MainPage.DisplayAlert("Medicamentos", "Se elimino de manera exitosa", "Ok");
                MainViewModel.GetInstance().MedicamentosCuidador.DeleteMedicamentosInList(idMedicamento);
                MainViewModel.GetInstance().Medicamentos.DeleteMedicamentosInList(idMedicamento);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
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

            if (source == "Cancel")
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
                        PhotoSize = PhotoSize.Full,
                    }
                );
                DireccionFoto = file.Path;
            }

            else
            {
                this.file = await CrossMedia.Current.PickPhotoAsync();
                DireccionFoto = file.Path;

            }

            if (this.file != null)
            {
                this.ImageUrl = ImageSource.FromStream(() =>
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
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
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
    }
}
