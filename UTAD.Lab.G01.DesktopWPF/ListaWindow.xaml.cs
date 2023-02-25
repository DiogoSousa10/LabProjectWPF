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

namespace UTAD.Lab.G01.DesktopWPF
{
    /// <summary>
    /// Interaction logic for ListaWindow.xaml
    /// </summary>
    public partial class ListaWindow : Window
    {
        private App app;
        public ListaWindow()
        {
            app = App.Current as App;
            InitializeComponent();

            app.Model_List_cat.ListaCriadaComSucesso += Model_List_cat_ListaCriadaComSucesso;
            app.Model_List_cat.ListaEnviada += Model_List_cat_ListaEnviada;
        }

        private void Model_List_cat_ListaEnviada(string nome_list)
        {
            txtLista.Text = nome_list;
            btAdiconar.Content = "Salvar Alterações";
        }

        private void Model_List_cat_ListaCriadaComSucesso(string nome, string desc)
        {
            MessageBox.Show("Lista criada com sucesso");
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            app._Main.Show();
            btAdiconar.Content = "Adicionar Lista";
            txtLista.Text = "";
            this.Visibility = Visibility.Hidden;
        }

        private void btAdiconar_Click(object sender, RoutedEventArgs e)
        {
            if (btAdiconar.Content.ToString() == "Adicionar Lista")
            {
                app.Model_List_cat.CreateList(txtNome.Text, txtDescrição.Text);
                txtLista.Text = "";
                txtNome.Text = "";
                txtDescrição.Text = "";
            }
            else
            {
                app.Model_List_cat.Editar_Lista(txtLista.Text, txtNome.Text, txtDescrição.Text);
                txtNome.Text = "";
                txtDescrição.Text = "";
                app._Main.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
