using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CraftyEditor
{
    /// <summary>
    /// Logique d'interaction pour AddTile.xaml
    /// </summary>
    public partial class AddTile : Window
    {
        private Window parent;

        private Image finalImage;
        private BitmapImage img;
        private string path;

        public AddTile(MainWindow prt)
        {
            InitializeComponent();

            parent = prt;
        }
        private void AddTile_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void x_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void y_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void tileset_TextChanged(object sender, EventArgs e)
        {
            path = System.IO.Path.GetFullPath("Assets/Tilesets/" + tileset.Text.ToString() + ".png");

            if (File.Exists(path))
            {
                MessageBox.Show(path.ToString());

                finalImage = new Image();
                finalImage.Width = 128;

                img = new BitmapImage();
                img.BeginInit();
                img.UriSource = new Uri(path);
                img.EndInit();

                tile_image.Source = img;
            }
        }

        private void x_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                //...
            }
        }

        private void y_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(path))
            {
                //...
            }
        }

        private void AddTileConfirm_Click(object sender, RoutedEventArgs e)
        {
            //...
        }
    }
}
