using System;
using System.Data;
using System.Windows;
using MySql.Data.MySqlClient;

namespace CraftyEditor.Class
{
    public class Datable
    {
        private MySqlConnection connection;
        private MySqlDataAdapter adapter;
        private DataTable data;

        private string host, username, password, database;

        private string cstring;

        public Datable(string h, string usr, string pwd, string dtb)
        {
            host = h;
            username = usr;
            password = pwd;
            database = dtb;
        }

        public void request(string query, string sortBy = "")
        {
            try
            {
                cstring = "server=" + host + "; uid=" + username + "; pwd=" + password + ";database=" + database + "; ";
                connection = new MySqlConnection(cstring);
                adapter = new MySqlDataAdapter(query, connection);

                data = new DataTable();
                adapter.Fill(data);

                if (sortBy != "") data.DefaultView.Sort = sortBy;
            }
            catch(MySqlException e) { MessageBox.Show(e.ToString()); }
        }

        public ref DataTable fetch() { return ref data; }
    }
}
