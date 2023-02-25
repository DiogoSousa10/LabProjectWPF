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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UTAD.Lab.G01.DesktopWPF;
using UTAD.Lab.G01.Domain;

namespace UTAD.Lab.G01.DesktopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        private App app;

       

        public MainWindow()
        {
            app = App.Current as App;
            InitializeComponent();

            app.Model_List_cat.ListaCriadaComSucesso += Model_List_cat_ListaCriadaComSucesso1;
            app.Model_List_cat.ItemCriadoComSucesso += Model_List_cat_ItemCriadoComSucesso;
            app.Model_List_cat.ListaCarregada += Model_List_cat_ListaCarregada;
            app.Model_List_cat.ListaSalvada += Model_List_cat_ListaSalvada;
            app.Model_List_cat.ListaApagada += Model_List_cat_ListaApagada;
            app.Model_List_cat.ListaEditada += Model_List_cat_ListaEditada;
            app.Model_List_cat.ListaSelecionada += Model_List_cat_ListaSelecionada;
        }

        private void Model_List_cat_ListaSelecionada(int i)
        {
            if (list_view_Items.Items.Count != 0)
            {
                list_view_Items.Items.Clear();
            }

            foreach (ClassItem aux in app.Model_List_cat.Listas[i].lista)
            {
                list_view_Items.Items.Add(aux);
            }
        }

        private void Model_List_cat_ListaEditada(string aux, string nome_list)
        {
            int i= lb_lists.SelectedIndex;
            lb_lists.Items.Remove(aux);
            lb_lists.Items.Insert(i, nome_list);
        }

        private void Model_List_cat_ListaApagada()
        {
            lb_lists.Items.RemoveAt(lb_lists.SelectedIndex);
        }

        private void Model_List_cat_ListaSalvada()
        {
            MessageBox.Show("Listas Salvadas Com Sucesso");
        }

        private void Model_List_cat_ListaCarregada()
        {
            lb_lists.Items.Clear();
            foreach (Lista aux in app.Model_List_cat.Listas)
            {
                
                lb_lists.Items.Add(aux.Nome);
            }
            MessageBox.Show("Listas Carregadas Com Sucesso");
        }

        private void Model_List_cat_ItemCriadoComSucesso(string nome, string quant, string cat)
        {
            ClassItem aux = new ClassItem(nome,quant,cat);
            list_view_Items.Items.Add(aux);
            
        }

        private void Model_List_cat_ListaCriadaComSucesso1(string nome, string desc)
        {
            lb_lists.Items.Add(nome);
            txtDesc.Text = desc;
        }


       



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    //Item janela = new Item();
        //    //if (janela.ShowDialog() == true)
        //    //{

        //    //}
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = lb_lists.SelectedItem.ToString();

                app.Model_List_cat.ListaEnviada2(nome);
                if(String.IsNullOrEmpty(nome) == false)
                {
                    app._Items.Show();
                }
            }catch(ExcecaoInvalida ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btEditarPerfil_Click(object sender, RoutedEventArgs e)
        {
            app._edit.Show();   
        }


        private void btLogout_Click(object sender, RoutedEventArgs e)
        {
           
           app._login.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            app._List.Show();
            this.Visibility =Visibility.Hidden;
        }

        private void btSalvar_Dados_Click(object sender, RoutedEventArgs e)
        {
            app.Model_List_cat.Save_Listas();
        }

        private void btCarregar_Dados_Click(object sender, RoutedEventArgs e)
        {
            app.Model_List_cat.Listas.Clear();
            app.Model_List_cat.Load_Listas();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Model_List_cat.ListaEnviada2(lb_lists.SelectedItem.ToString());
                if(lb_lists.SelectedItem.ToString() != null)
                {
                    app._List.Show();
                    this.Visibility = Visibility.Hidden;
                }
            }catch(ExcecaoInvalida ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btApagar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string nome = lb_lists.SelectedItem.ToString();
                app.Model_List_cat.Apagar_Lista(nome);
            }catch(ExcecaoInvalida aux)
            {
                MessageBox.Show(aux.Message);
            }
        }

        private void btEditarInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                app.Model_List_cat.Editar_Lista(lb_lists.SelectedItem.ToString(), lb_lists.SelectedItem.ToString(), txtDesc.Text);
                btEditarInfo.IsEnabled = false;
            }
            catch (ExcecaoInvalida ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDesc_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lb_lists.SelectedIndex >= 0)
            {
                btEditarInfo.IsEnabled = true;
            }
        }

        private void lb_lists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            app.Model_List_cat.Lista_Selecionada(lb_lists.SelectedItem.ToString());
        }
    }
}
