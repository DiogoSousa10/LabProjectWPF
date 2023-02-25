using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace UTAD.Lab.G01.MobileDroid.Views
{
    internal class ListViewModel2
    {

        public ICommand AddItemsCommand => new Command(AddItem);

        public ICommand RemoveItemsCommand => new Command(RemoveItem);

        public ICommand UpdateItemsCommand => new Command(UpdateItem);

        public ObservableCollection<string> Items { get; set; }
        public ObservableCollection<string> ItQuantidade { get; set; }
        public string ItemName { get; set; }
        public string ItemQuantidade { get; set; }
        public string SelectItem { get; set; }



        public void RemoveItem()
        {
            Items.Remove(SelectItem);
        }

        public ListViewModel2()
        {

            Items = new ObservableCollection<string>();
            ItQuantidade = new ObservableCollection<string>();
            // Items.Add("Arroz");
        }

        public void AddItem()
        {
            Items.Add(ItemName);
            Items.Add(ItemQuantidade);

        }
        public void UpdateItem()
        {
            int newIndex = Items.IndexOf(SelectItem);
            Items.Remove(SelectItem);

            Items.Add(ItemName);
            int oldIndex = Items.IndexOf(ItemName);
        }
    }


    
   
}
