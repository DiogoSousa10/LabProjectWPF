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
using UTAD.Lab.G01.Domain;

namespace UTAD.Lab.G01.DesktopWPF
{
    /// <summary>
    /// Interaction logic for CategoriaWindow.xaml
    /// </summary>
    public partial class CategoriaWindow : Window
    {
        private App app;
        public CategoriaWindow()
        {
            app = App.Current as App;
            InitializeComponent();
            app.Model_List_cat.RemovidoComSucesso += Model_List_cat_RemovidoComSucesso;
            app.Model_List_cat.InsercaoComSucesso += Model_List_cat_InsercaoComSucesso;
            app.Model_List_cat.CatEnviada += Model_List_cat_CatEnviada;
        }

        private void Model_List_cat_CatEnviada(string nome_cat)
        {
            txtCatRecebida.IsEnabled = true;
            txtCatRecebida.Text = nome_cat;
            cbEliminar.IsEnabled = false;
            btEliminar.IsEnabled = false;
            btAdicionar.Content = "Salvar Alteração";
        }

        private void Model_List_cat_InsercaoComSucesso(string aux)
        { 
            cbEliminar.Items.Add(aux);
            txtCategoria.Text = "";
        }

        private void Model_List_cat_RemovidoComSucesso(string aux)
        {
            cbEliminar.Items.Remove(aux);
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            app._Items.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btEliminar_Click(object sender, RoutedEventArgs e)
        {
            string texto = cbEliminar.Text;

            try
            {
                app.Model_List_cat.RemoveCat(texto);
            }
            catch(ExcecaoInvalida erro)
            {
                MessageBox.Show(erro.Message);
            }

        }

        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (btAdicionar.Content.ToString() == "Adicionar")
            {
                string texto = txtCategoria.Text;

                try
                {

                    app.Model_List_cat.AdicionarCategoria(texto);
                }
                catch (ExcecaoInvalida erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
            else
            {
                try
                {
                    app.Model_List_cat.Editar_Categoria(txtCatRecebida.Text,txtCategoria.Text);
                    this.Visibility = Visibility.Hidden;
                    app._Items.Show();
                }catch (ExcecaoInvalida erro)
                {
                    MessageBox.Show(erro.Message);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach(Categoria aux in app.Model_List_cat.Categorias)
            {
                cbEliminar.Items.Add(aux.categoria);
            }
        }
    }
    }

