

namespace Alzapp.ViewModels
{
    using Alzapp.Models;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System.IO;
    using System.Windows.Input;
    using Xamarin.Forms;
    public class EditFotoViewModel : BaseViewModel
    {
        private MediaFile file;
        private ImageSource imageUrl;
        public string borrarColor = "linear-gradient(45deg, transparent 0%, transparent 27%,rgba(214, 214, 214,0.06) 27%, rgba(214, 214, 214,0.06) 38%,transparent 38%, transparent 100%),linear-gradient(45deg, transparent 0%, transparent 39%,rgba(214, 214, 214,0.06) 39%, rgba(214, 214, 214,0.06) 68%,transparent 68%, transparent 100%),linear-gradient(90deg, transparent 0%, transparent 74%,rgba(214, 214, 214,0.06) 74%, rgba(214, 214, 214,0.06) 79%,transparent 79%, transparent 100%),linear-gradient(90deg, rgb(123,0,0),rgb(123,0,0))";

        public string BorrarColor
        {
            get => borrarColor;
            set => SetValue(ref borrarColor, value);
        }

        public ImageSource ImageUrl
        {
            get => this.imageUrl;
            set => this.SetValue(ref this.imageUrl, value);
        }

        public Foto Foto { get; set; }

        public string DireccionFoto { get; set; }
        
        public ICommand SaveCommand => new RelayCommand(Save);

        public ICommand DeleteCommand => new RelayCommand(Delete);

        public ICommand ChangeImageCommand => new RelayCommand(this.ChangeImage);
        public ICommand BackCommand => new RelayCommand(Back);


        public EditFotoViewModel(Foto foto)
        {
            Foto = foto;
            DireccionFoto = Foto.ImageUrl;
            ImageUrl = DireccionFoto;
        }

        private async void Save()
        {
            if (string.IsNullOrEmpty(Foto.Name))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar la descripción de la Foto.", "Aceptar");
                return;
            }
            if (string.IsNullOrEmpty(Foto.Etapa))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Debes ingresar la Etapa.", "Aceptar");
                return;
            }

            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = ReadFully(this.file.GetStream());
            }


            Foto foto = new Foto()
            {
                Id = Foto.Id,
                Name = Foto.Name,
                Etapa = Foto.Etapa,
                ImageUrl = DireccionFoto
            };


            await App.SQLiteDB.SaveFotoAsync(foto);
            await Application.Current.MainPage.DisplayAlert("Registro", "Se actualizo de manera correcta la Foto", "Ok");
            if (foto.Etapa == "Infancia")
            {
                MainViewModel.GetInstance().Infancia.RefreshFotosList();
            }
            if (foto.Etapa == "Adolescencia")
            {
                MainViewModel.GetInstance().Adolescencia.RefreshFotosList();
            }
            if (foto.Etapa == "Adultez")
            {
                MainViewModel.GetInstance().Adultez.RefreshFotosList();
            }
            if (foto.Etapa == "Presente")
            {
                MainViewModel.GetInstance().Presente.RefreshFotosList();
            }
            if (foto.Etapa == "MomentosEspeciales")
            {
                MainViewModel.GetInstance().MomentosEspeciales.RefreshFotosList();
            }
            MainViewModel.GetInstance().FotoCuidador.RefreshFotosList();

            await Application.Current.MainPage.Navigation.PopAsync();
        }

        private async void Delete()
        {
            var idFoto = Foto.Id;
            var foto = await App.SQLiteDB.GetFotoByIdAsync(idFoto);
            if (foto != null)
            {
                await App.SQLiteDB.DeleteFotoAsync(foto);
                await Application.Current.MainPage.DisplayAlert("Foto", "Se elimino de manera exitosa", "Ok");
                MainViewModel.GetInstance().FotoCuidador.DeleteFotoInList(idFoto);

                if (foto.Etapa == "Infancia")
                {
                    MainViewModel.GetInstance().Infancia.DeleteFotoInList(idFoto);
                }
                if (foto.Etapa == "Adolescencia")
                {
                    MainViewModel.GetInstance().Adolescencia.DeleteFotoInList(idFoto);
                }
                if (foto.Etapa == "Adultez")
                {
                    MainViewModel.GetInstance().Adultez.DeleteFotoInList(idFoto);
                }
                if (foto.Etapa == "Presente")
                {
                    MainViewModel.GetInstance().Presente.DeleteFotoInList(idFoto);
                }
                if (foto.Etapa == "MomentosEspeciales")
                {
                    MainViewModel.GetInstance().MomentosEspeciales.DeleteFotoInList(idFoto);
                }

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
