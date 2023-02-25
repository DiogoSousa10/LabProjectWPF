using System;
using System.Collections.Generic;
using System.ComponentModel;
using UTAD.Lab.G01.MobileDroid.Models;
using UTAD.Lab.G01.MobileDroid.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UTAD.Lab.G01.MobileDroid.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}