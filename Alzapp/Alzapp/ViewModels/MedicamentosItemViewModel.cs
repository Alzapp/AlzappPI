using Alzapp.Models;
using Alzapp.Views;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using Xamarin.Forms;

namespace Alzapp.ViewModels
{
    public class MedicamentosItemViewModel : Medicamentos
    {
        public ICommand SelectMedicamentosCommand => new RelayCommand(SelectMedicamento);
        
        private async void SelectMedicamento()
        {
            MainViewModel.GetInstance().EditMedicamentos = new EditMedicamentosViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(new EditMedicamentosPage());
        }
        
    }
}
