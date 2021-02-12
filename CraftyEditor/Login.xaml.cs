using Fare;
using System;
using System.Collections.Generic;
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
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Login : Window
    {
        private Window parent;

        public Login(MainWindow prt)
        {
            InitializeComponent();
            this.Topmost = true;
            parent = prt;
        }

        private void username_PreviewTextInput(object sender, TextCompositionEventArgs e) { }

        private void LoginClose_Click(object sender, System.ComponentModel.CancelEventArgs e) {  }
        private void LoginClose_Click(object sender, RoutedEventArgs e) { this.Close();  }

        private void LoginConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (connexion())
            {
                parent.Visibility = Visibility.Visible;
                this.Visibility = Visibility.Hidden;
            }
        }

        private bool connexion()
        {
            //...
            return false;
        }
    }
}
