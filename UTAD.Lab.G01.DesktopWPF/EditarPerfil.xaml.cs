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
    /// Interaction logic for EditarPerfil.xaml
    /// </summary>
    public partial class EditarPerfil : Window
    {
        private App app;
        public EditarPerfil()
        {
            app = App.Current as App;
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            app._Main.Show();
            this.Visibility = Visibility.Hidden;
        }
    }
}
