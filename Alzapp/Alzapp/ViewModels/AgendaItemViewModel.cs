
namespace Alzapp.ViewModels
{
    using Alzapp.Views;
    using GalaSoft.MvvmLight.Command;
    using Models;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AgendaItemViewModel : Agenda
    {
        public ICommand SelectAgendaCommand => new RelayCommand(this.SelectAgenda);

        private async void SelectAgenda()
        {
            MainViewModel.GetInstance().EditAgenda = new EditAgendaViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new EditAgendaPage());
        }

    }
}
