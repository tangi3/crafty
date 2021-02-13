﻿using CraftyEditor.Class;
using System.Collections.Generic;
using System.Windows;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace CraftyEditor
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Datable database;

        public string host = "localhost";
        public string username = "root";
        public string password = "";
        public string dtb = "crafty";

        //load from database :
        private Dictionary<int, Tile> tiles;

        private AddTile AddTileForm;

        private Login LoginForm;

        public MainWindow()
        {
            InitializeComponent();

            database = new Datable(host, username, password, dtb);

            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            //this.MouseDown += (s, e) => DragMove();

            tiles = new Dictionary<int, Tile>();

            if (database.logged == false) { OpenLogin(); }
        }

        private void GlRender(object sender, System.EventArgs e)
        {
            //...
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
            LoginForm.Show(ref database);
        }

        private void AddTile_Click(object sender, RoutedEventArgs e) { if (database.logged) OpenAddTile(); }

        private void Login_Click(object sender, RoutedEventArgs e) { OpenLogin(); }
    }
}
