using CraftyEditor.Class;
using System.Windows;
using System.Windows.Input;

namespace CraftyEditor
{
    public partial class Login : Window
    {
        private Window parent;
        private Datable database;

        public Login(MainWindow prt)
        {
            InitializeComponent();

            /*Request(string host, string username, string password, string database, string query, string sortBy)*/

            this.Topmost = true;
            parent = prt;
        }

        public void Show(ref Datable dtb) { base.Show(); database = dtb; }

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

            database.request("select * from users where username = \"" + username.Text + "\" and password = \"" + password.Text + "\"");
            MessageBox.Show(database.fetch().ToString());

            //...

            return false;
        }
    }
}
