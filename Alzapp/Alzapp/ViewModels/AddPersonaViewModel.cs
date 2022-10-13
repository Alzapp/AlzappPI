using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class AddPersonaViewModel : BaseViewModel
    {
        private MediaFile file;
        private MediaFile file2;
        private MediaFile file3;
        private ImageSource imageSource;
        private ImageSource imageSource2;
        private ImageSource imageSource3;

        public ImageSource ImageSource
        {
            get => this.imageSource;
            set => this.SetValue(ref this.imageSource, value);
        }
        public ImageSource ImageSource2
        {
            get => this.imageSource2;
            set => this.SetValue(ref this.imageSource2, value);
        }
        public ImageSource ImageSource3
        {
            get => this.imageSource3;
            set => this.SetValue(ref this.imageSource3, value);
        }

        public string SaveColor = "linear-gradient(78deg, rgba(96, 96, 96, 0.04) 0%, rgba(96, 96, 96, 0.04) 35%,rgba(220, 220, 220, 0.04) 35%, rgba(220, 220, 220, 0.04) 100%),linear-gradient(150deg, rgba(83, 83, 83, 0.04) 0%, rgba(83, 83, 83, 0.04) 71%,rgba(6, 6, 6, 0.04) 71%, rgba(6, 6, 6, 0.04) 100%),linear-gradient(311deg, rgba(203, 203, 203, 0.04) 0%, rgba(203, 203, 203, 0.04) 58%,rgba(3, 3, 3, 0.04) 58%, rgba(3, 3, 3, 0.04) 100%),linear-gradient(137deg, rgba(110, 110, 110, 0.04) 0%, rgba(110, 110, 110, 0.04) 11%,rgba(226, 226, 226, 0.04) 11%, rgba(226, 226, 226, 0.04) 100%),linear-gradient(90deg, rgb(215, 19, 84),rgb(234, 119, 123))";


        public string Nombre { get; set; }

        public string Domicilio { get; set; }
        public string Relacion { get; set; }
        public string Celular { get; set; }
        public string DireccionFoto { get; set; }
        public string DireccionFoto2 { get; set; }
        public string DireccionFoto3 { get; set; }

        public ICommand SaveCommand => new RelayCommand(Save);
        public ICommand ChangeImageCommand => new RelayCommand(this.ChangeImage);
        public ICommand ChangeImage2Command => new RelayCommand(this.ChangeImage2);
        public ICommand ChangeImage3Command => new RelayCommand(this.ChangeImage3);
        public ICommand BackCommand => new RelayCommand(Back);

        public AddPersonaViewModel()
        {
            this.imageSource = "noPhoto";
            this.imageSource2 = "noPhoto";
            this.imageSource3 = "noPhoto";
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Nombre.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Relacion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar la Relacion que tiene con esta persona.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Domicilio))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar la Direccion.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Celular))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar el Celular.", "Aceptar");
                return;
            }

            byte[] imageArray = null;
            byte[] imageArray2 = null;
            byte[] imageArray3 = null;
            if (this.file != null)
            {
                imageArray = ReadFully(this.file.GetStream());
            }
            if (this.file2 != null)
            {
                imageArray2 = ReadFully(this.file2.GetStream());
            }
            if (this.file3 != null)
            {
                imageArray3 = ReadFully(this.file3.GetStream());
            }
            var persona = new Persona
            {
                Relacion = this.Relacion,
                Nombre = this.Nombre,
                Domicilio = this.Domicilio,
                Celular = this.Celular,
                ImageUrl = DireccionFoto,
                ImageUrl2 = DireccionFoto2,
                ImageUrl3 = DireccionFoto3
            };
            await App.SQLiteDB.SavePersonaAsync(persona);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se guardo de manera exitosa la Persona", "Ok");
            MainViewModel.GetInstance().PersonaCuidador.RefreshPersonaList();
            MainViewModel.GetInstance().PersonaCuidador.RefreshPersonaList();
            await Application.Current.MainPage.Navigation.PopAsync();
            
            //await App.Navigator.PopAsync();






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
        private async void ChangeImage2()
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
                this.file2 = null;
                return;
            }

            if (source == "Desde Camara")
            {
                this.file2 = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                        Name = "test2.jpg",
                        PhotoSize = PhotoSize.Full,
                    }
                );
                if (this.file2 != null)
                {
                    DireccionFoto2 = file2.Path;
                }
            }

            if (source == "Desde Galeria")
            {
                this.file2 = await CrossMedia.Current.PickPhotoAsync();

                if (this.file2 != null)
                {
                    DireccionFoto2 = file2.Path;
                }
            }

            if (source == null)
            {
                this.file = null;
                return;
            }

            if (this.file2 != null)
            {
                this.ImageSource2 = ImageSource.FromStream(() =>
                {
                    var stream = file2.GetStream();
                    return stream;
                });
                DireccionFoto2 = file2.Path;
            }


        }
        private async void ChangeImage3()
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
                this.file3 = null;
                return;
            }

            if (source == "Desde Camara")
            {
                this.file3 = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Pictures",
                        Name = "test3.jpg",
                        PhotoSize = PhotoSize.Full,
                    }
                );
                if (this.file3 != null)
                {
                    DireccionFoto3 = file3.Path;
                }
            }

            if (source == "Desde Galeria")
            {
                this.file3 = await CrossMedia.Current.PickPhotoAsync();

                if (this.file3 != null)
                {
                    DireccionFoto3 = file3.Path;
                }

            }

            if (source == null)
            {
                this.file = null;
                return;
            }

            if (this.file3 != null)
            {
                this.ImageSource3 = ImageSource.FromStream(() =>
                {
                    var stream = file3.GetStream();
                    return stream;
                });
                DireccionFoto3 = file3.Path;
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