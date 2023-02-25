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
using System.ComponentModel.DataAnnotations;

namespace UTAD.Lab.G01.DesktopWPF
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private App app;
        public LoginWindow()
        {
            app = App.Current as App;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var email = new EmailAddressAttribute();
            if (new EmailAddressAttribute().IsValid(tb_email.Text) && !(pb_psswd.Password == ""))
            {
                app._Main.Show(); 
                this.Close();
            }
            else
            {
                MessageBox.Show("ERRO", "Campos nao validos", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            } 


            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            app._Registar.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btOffline_Click(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            app._Main.Show();
            
            

        }
    }
}
