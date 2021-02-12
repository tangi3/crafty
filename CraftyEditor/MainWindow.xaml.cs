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

        public MainWindow()
        {
            InitializeComponent();

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            this.MouseDown += (s, e) => DragMove();

            tiles = new Dictionary<int, Tile>();

            AddTileForm = new AddTile(this);

            AddTileForm.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e) { Application.Current.Shutdown(); }

        private void AddTileButton_Click(object sender, RoutedEventArgs e)
        {
            AddTileForm.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
