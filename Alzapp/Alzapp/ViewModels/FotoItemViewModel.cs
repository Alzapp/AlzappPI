using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class FotoItemViewModel : Foto
    {
        public ICommand SelectFotoCommand => new RelayCommand(this.SelectFoto);

        private async void SelectFoto()
        {
            MainViewModel.GetInstance().EditFoto = new EditFotoViewModel((Foto)this);
            await Application.Current.MainPage.Navigation.PushAsync(new EditFotoPage());
        }
    }
}
