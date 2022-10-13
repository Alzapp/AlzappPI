
namespace Alzapp.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Models;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System.IO;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AddFotoViewModel : BaseViewModel
    {
        private MediaFile file;
        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get => this.imageSource;
            set => this.SetValue(ref this.imageSource, value);
        }


        public string Name { get; set; }

        public string Etapa { get; set; }

        public string DireccionFoto { get; set; }

        public string SaveColor = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";

        public ICommand SaveCommand => new RelayCommand(this.Save);
        public ICommand ChangeImageCommand => new RelayCommand(this.ChangeImage);
        public ICommand BackCommand => new RelayCommand(Back);


        public AddFotoViewModel()
        {

            this.imageSource = "noPhoto";
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar una descripción de la foto.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(this.Etapa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar una Etapa.", "Aceptar");
                return;
            }

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = ReadFully(this.file.GetStream());
            }

            var foto = new Foto
            {
                Name = this.Name,
                Etapa = this.Etapa,
                ImageUrl = DireccionFoto
            };

            await App.SQLiteDB.SaveFotoAsync(foto);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se guardo de manera exitosa el recuerdo en la etapa " + Etapa, "Ok");
            MainViewModel.GetInstance().FotoCuidador.RefreshFotosList();

            if (this.Etapa == "Infancia")
            {
                MainViewModel.GetInstance().Infancia.RefreshFotosList();
            }
            if (this.Etapa == "Adolescencia")
            {
                MainViewModel.GetInstance().Adolescencia.RefreshFotosList();
            }
            if (this.Etapa == "Adultez")
            {
                MainViewModel.GetInstance().Adultez.RefreshFotosList();
            }
            if (this.Etapa == "Presente")
            {
                MainViewModel.GetInstance().Presente.RefreshFotosList();
            }
            if (this.Etapa == "MomentosEspeciales")
            {
                MainViewModel.GetInstance().MomentosEspeciales.RefreshFotosList();
            }

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
                        PhotoSize = PhotoSize.Full,
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
        public async void Back()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
