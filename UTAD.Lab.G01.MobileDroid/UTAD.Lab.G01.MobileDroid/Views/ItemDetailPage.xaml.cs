using System.ComponentModel;
using UTAD.Lab.G01.MobileDroid.ViewModels;
using Xamarin.Forms;

namespace UTAD.Lab.G01.MobileDroid.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}