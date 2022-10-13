using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class PersonaItemViewModel : Persona
    {
        public ICommand SelectPersonaCommand => new RelayCommand(SelectPersona);
        public ICommand SelectPersonaZoomCommand => new RelayCommand(SelectPersonaZoom);

        private async void SelectPersona()
        {
            MainViewModel.GetInstance().EditPersona = new EditPersonaViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new EditPersonaPage());
        }
        private async void SelectPersonaZoom()
        {
            MainViewModel.GetInstance().PersonaZoom = new PersonaZoomViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new PersonaZoomPage());
        }
    }
}
