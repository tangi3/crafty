using CraftyEditor.Class;
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

namespace CraftyEditor
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //load from database :
        private Dictionary<int, Tile> tiles;

        private AddTile AddTileForm;

        private Login LoginForm;

        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.MouseDown += (s, e) => DragMove();

            tiles = new Dictionary<int, Tile>();
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Application.Current.Shutdown(); }

        private void Button_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void OpenAddTile()
        {
            if (AddTileForm != null) { AddTileForm.Close(); AddTileForm = null; }

            if (LoginForm != null) { LoginForm.Close(); LoginForm = null; }

            AddTileForm = new AddTile(this);
            AddTileForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AddTileForm.Show();
        }

        private void OpenLogin()
        {
            if(LoginForm != null) { LoginForm.Close(); LoginForm = null; }

            if(AddTileForm != null) { AddTileForm.Close(); AddTileForm = null; }

            LoginForm = new Login(this);
            LoginForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            LoginForm.Show();
        }

        private void AddTile_Click(object sender, RoutedEventArgs e) { OpenAddTile(); }

        private void Login_Click(object sender, RoutedEventArgs e) { OpenLogin(); }
    }
}
