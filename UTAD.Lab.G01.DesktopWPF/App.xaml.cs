using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UTAD.Lab.G01.Domain;
using UTAD.Lab.G01.DesktopWPF;


namespace UTAD.Lab.G01.DesktopWPF
{

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Model Model_List_cat { get; private set; }



        //INSTANCIAR VIEWS
        public Registar _Registar { get; private set; }
        public ListaWindow _List { get; private set; }

        public MainWindow _Main { get; private set; }
        public CategoriaWindow _categorias { get; private set; }
        public EditarPerfil _edit { get; private set; }

        public LoginWindow _login { get; private set; }

        public Item _Items { get; private set; }





        public App()
        {
            Model_List_cat = new Model();
            _Registar = new Registar();
            _List = new ListaWindow();
            _Main = new MainWindow();
            _categorias = new CategoriaWindow();
            _edit = new EditarPerfil();
            _Items = new Item();
            _login = new LoginWindow();
        }

    }
}
