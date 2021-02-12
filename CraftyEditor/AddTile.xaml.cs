using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace CraftyEditor
{
    /// <summary>
    /// Logique d'interaction pour AddTile.xaml
    /// </summary>
    public partial class AddTile : Window
    {
        private Window parent;

        private BitmapImage bitmapimage;

        private int unit;

        private int xValue, yValue;
        private string xText, yText;

        public AddTile(MainWindow prt)
        {
            InitializeComponent();

            this.MouseDown += (s, e) => DragMove();
            this.Topmost = true;

            unit = 32;

            parent = prt;
        }
        private void AddTile_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            this.Visibility = Visibility.Hidden;
        }

        private void x_PreviewTextInput(object sender, TextCompositionEventArgs e) { checkCoordinateValues(e); }

        private void y_PreviewTextInput(object sender, TextCompositionEventArgs e) { checkCoordinateValues(e); }

        private void tileset_TextChanged(object sender, EventArgs e) { cropImage(); }

        private void x_TextChanged(object sender, EventArgs e) { cropImage(); }

        private void y_TextChanged(object sender, EventArgs e) { cropImage(); }

        private void AddTileConfirm_Click(object sender, RoutedEventArgs e)
        {
            //add to database
            //dont forget to update main form
            //...
        }

        private void AddTileClose_Click(object sender, RoutedEventArgs e) { this.Close(); }

        private void cropImage()
        {
            checkCoordinateValues();

            if (File.Exists(getTilesetPath()))
            {
                if(int.TryParse(xText, out _) && int.TryParse(yText, out _))
                {
                    bitmapimage = new BitmapImage(new Uri(getTilesetPath()));
                    tile_image.Source = new CroppedBitmap(bitmapimage, new Int32Rect(xValue, yValue, unit, unit));
                }
            }

        }

        private void checkCoordinateValues(TextCompositionEventArgs e = null)
        {
            if(e != null)
            {
                Regex regex = new Regex("[^0-9]+");
                e.Handled = regex.IsMatch(e.Text);
            }

            if(this.xtext == null)
            {
                xValue = 0;
                xText = "0";
            }
            else
            {
                if (this.xtext.Text != "" && int.Parse(this.xtext.Text) >= 0)
                {
                    xValue = int.Parse(this.xtext.Text);
                    xText = xValue.ToString();
                }
            }

            if (this.ytext == null)
            {
                yValue = 0;
                yText = "0";
            }
            else
            {
                if (this.ytext.Text != "" && int.Parse(this.ytext.Text) >= 0)
                {
                    yValue = int.Parse(this.ytext.Text);
                    yText = yValue.ToString();
                }
            }

        }

        private string getTilesetPath() {
            if (File.Exists(System.IO.Path.GetFullPath("Assets/Tilesets/" + tileset.Text.ToString() + ".png")))
                return System.IO.Path.GetFullPath("Assets/Tilesets/" + tileset.Text.ToString() + ".png");
            else return "";
        }

        BitmapImage BitmapToImageSource(Bitmap bitmap)
        {
            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                bitmapimage = new BitmapImage();
                bitmapimage.BeginInit();
                bitmapimage.StreamSource = memory;
                bitmapimage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapimage.EndInit();

                return bitmapimage;
            }
        }
    }
}
