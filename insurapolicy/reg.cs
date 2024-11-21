using insurapolicy.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insurapolicy
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }


        private void LoginForm_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            string login = LogintextBox.Text;
            string password = PasswordtextBox.Text;

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [User] WHERE Login = ? AND Password = ?";
                using (var command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);

                    int userCount = (int)command.ExecuteScalar();

                    if (userCount > 0)
                    {
                        menu menu = new menu();
                        this.Hide();
                        menu.Show();
                    }
                    else
                    {
                        lblError.Text = "Неверный email или пароль.";
                    }


                    {

                    }
                }
            }
        }

        private void LogintextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


