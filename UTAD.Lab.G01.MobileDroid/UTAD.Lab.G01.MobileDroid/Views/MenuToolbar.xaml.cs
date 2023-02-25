using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UTAD.Lab.G01.MobileDroid.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuToolbar : ContentPage
    {
        public MenuToolbar()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("ToolBarItem", "Menu Ativado", "Ok");
        }
    }
}