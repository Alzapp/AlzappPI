namespace Alzapp.ViewModels
{
    using Alzapp.Models;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System.IO;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class EditPersonaViewModel : BaseViewModel
    {
        public Persona Persona { get; set; }

        private MediaFile file;
        private MediaFile file2;
        private MediaFile file3;
        private ImageSource imageSource;
        private ImageSource imageSource2;
        private ImageSource imageSource3;
        public string borrarColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(123,0,0),rgb(123,0,0))";

        public string BorrarColor
        {
            get => borrarColor;
            set => SetValue(ref borrarColor, value);
        }

        public ImageSource ImageUrl
        {
            get => this.imageSource;
            set => this.SetValue(ref this.imageSource, value);
        }
        public ImageSource ImageUrl2
        {
            get => this.imageSource2;
            set => this.SetValue(ref this.imageSource2, value);
        }
        public ImageSource ImageUrl3
        {
            get => this.imageSource3;
            set => this.SetValue(ref this.imageSource3, value);
        }
        public string DireccionFoto { get; set; }
        public string DireccionFoto2 { get; set; }
        public string DireccionFoto3 { get; set; }

        public ICommand SaveCommand => new RelayCommand(Save);

        public ICommand DeleteCommand => new RelayCommand(Delete);

        public ICommand ChangeImageCommand => new RelayCommand(ChangeImage);
        public ICommand ChangeImage2Command => new RelayCommand(ChangeImage2);
        public ICommand ChangeImage3Command => new RelayCommand(ChangeImage3);
        public ICommand BackCommand => new RelayCommand(Back);

        public EditPersonaViewModel(Persona persona)
        {
            Persona = persona;
            DireccionFoto = Persona.ImageUrl;
            ImageUrl = DireccionFoto;
            DireccionFoto2 = Persona.ImageUrl2;
            ImageUrl2 = DireccionFoto2;
            if(DireccionFoto2== null)
            {
                ImageUrl2 = "noPhoto";
            }
            DireccionFoto3 = Persona.ImageUrl3;
            ImageUrl3 = DireccionFoto3;
            if (DireccionFoto3 == null)
            {
                ImageUrl3 = "noPhoto";
            }

        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(Persona.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar un Nombre.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Persona.Relacion))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar la Relacion que tiene con esta persona.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Persona.Domicilio))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar la Direccion.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Persona.Celular))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar el Celular.", "Aceptar");
                return;
            }

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = ReadFully(this.file.GetStream());
            }
            if (this.file2 != null)
            {
                imageArray = ReadFully(this.file2.GetStream());
            }
            if (this.file3 != null)
            {
                imageArray = ReadFully(this.file3.GetStream());
            }

            Persona persona = new Persona()
            {
                Id = Persona.Id,
                Nombre = Persona.Nombre,
                Relacion = Persona.Relacion,
                Celular = Persona.Celular,
                Domicilio = Persona.Domicilio,
                ImageUrl = DireccionFoto,
                ImageUrl2 = DireccionFoto2,
                ImageUrl3 = DireccionFoto3
            };
            await App.SQLiteDB.SavePersonaAsync(persona);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se actualizo de manera correcta la Persona", "Ok");
            MainViewModel.GetInstance().PersonaCuidador.RefreshPersonaList();
            MainViewModel.GetInstance().Persona.RefreshPersonaList();
            MainViewModel.GetInstance().PersonaCuidador = new PersonaCuidadorViewModel();
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void Delete()
        {

            var idPersona = Persona.Id;
            var persona = await App.SQLiteDB.GetPersonaByIdAsync(idPersona);
            if (persona != null)
            {
                await App.SQLiteDB.DeletePersonaAsync(persona);
                await Application.Current.MainPage.DisplayAlert("Persona", "Se elimino de manera exitosa", "Ok");
                MainViewModel.GetInstance().PersonaCuidador.DeletePersonaInList(idPersona);
                MainViewModel.GetInstance().Persona.DeletePersonaInList(idPersona);
                MainViewModel.GetInstance().PersonaCuidador = new PersonaCuidadorViewModel();
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
                this.ImageUrl = ImageSource.FromStream(() =>
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
                this.file2 = null;
                return;
            }

            if (this.file2 != null)
            {
                this.ImageUrl2 = ImageSource.FromStream(() =>
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
                this.file3 = null;
                return;
            }

            if (this.file3 != null)
            {
                this.ImageUrl3 = ImageSource.FromStream(() =>
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