using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace UTAD.Lab.G01.MobileDroid.ViewModels
{
    public class ListasModel : BaseViewModel
    {
        public ListasModel()
        {
            Title = "Listas";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));
        }

        public ICommand OpenWebCommand { get; }
    }
}