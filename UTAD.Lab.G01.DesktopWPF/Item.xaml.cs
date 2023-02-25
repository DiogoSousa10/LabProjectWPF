using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UTAD.Lab.G01.DesktopWPF;
using UTAD.Lab.G01.Domain;

namespace UTAD.Lab.G01.DesktopWPF
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : Window
    {
        private App app;

        public Item()
        {
            app = App.Current as App;
            InitializeComponent();
            app.Model_List_cat.ItemCriadoComSucesso += Model_List_cat_ItemCriadoComSucesso;
            app.Model_List_cat.ListaEnviada += Model_List_cat_ListaEnviada;
            app.Model_List_cat.RemovidoComSucesso += Model_List_cat_RemovidoComSucesso;
            app.Model_List_cat.InsercaoComSucesso += Model_List_cat_InsercaoComSucesso;
            app.Model_List_cat.CategoriaEditada += Model_List_cat_CategoriaEditada;

        }

        private void Model_List_cat_CategoriaEditada(string aux, string nome)
        {
            int i = cb_cat.SelectedIndex;
            cb_cat.Items.Remove(aux);
            cb_cat.Items.Insert(i, nome);
        }

        private void Model_List_cat_InsercaoComSucesso(string aux)
        {
           cb_cat.Items.Add(aux);
        }

        private void Model_List_cat_RemovidoComSucesso(string aux)
        {
           cb_cat.Items.Remove(aux);
        }

        private void Model_List_cat_ListaEnviada(string nome_list)
        {
            tb_nomelist.Text = nome_list;
        }

        private void Model_List_cat_ItemCriadoComSucesso(string nome, string quant, string cat)
        {
            MessageBox.Show("Item criado com sucesso");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            app._categorias.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Model_List_cat.AdicionarItem(tb_nomelist.Text, tb_nome.Text, tb_quant.Text, cb_cat.Text);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Aviso", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(Categoria aux in app.Model_List_cat.Categorias)
            {
                cb_cat.Items.Add(aux.categoria);
            }
        }

        private void btEditar_Cat_Click(object sender, RoutedEventArgs e)
        {
            app._categorias.Show();
            this.Visibility = Visibility.Hidden;
            try
            {
                app.Model_List_cat.Categoria_Enviada(cb_cat.Text);
            }catch(ExcecaoInvalida ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        //public static implicit operator Item(ClassItem v)
        //{
        //   // throw new NotImplementedException();
        //}
    }
}
