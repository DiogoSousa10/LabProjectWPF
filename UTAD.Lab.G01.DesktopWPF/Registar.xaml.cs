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
    /// Interaction logic for Registar.xaml
    /// </summary>
    public partial class Registar : Window
    {
        private App app;
        public Registar()
        {
            app = App.Current as App;
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            app._login.Show();
            this.Visibility = Visibility.Hidden;
        }

        private void btConfirmar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
