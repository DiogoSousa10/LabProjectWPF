using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTAD.Lab.G01.MobileDroid.Models;
using UTAD.Lab.G01.MobileDroid.ViewModels;
using UTAD.Lab.G01.MobileDroid.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UTAD.Lab.G01.MobileDroid.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ItemsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}