using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UTAD.Lab.G01.MobileDroid.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            //abrir a janela para adicionar items
            DisplayAlert("Atualizado", "Atualizado com sucesso ", "Ok");

        }


        private async void Adicionar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListView());
        }
    }
}