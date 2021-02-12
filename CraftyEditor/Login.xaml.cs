using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace CraftyEditor
{
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
