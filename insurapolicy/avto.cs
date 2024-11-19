﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insurapolicy
{
    public partial class avto : Form
    {
        public avto()
        {
            InitializeComponent();
            try
            {
                List<string> roles = new List<string>();

                using (OleDbConnection connection = new OleDbConnection(db.Class1.ConnectionString))
                {
                    connection.Open();

                    string sql = "SELECT [NameOfRole] FROM UsersRole;";

                    OleDbCommand oleDbCommand = new OleDbCommand(sql, connection);

                    using (OleDbDataReader reader = oleDbCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(reader["NameOfRole"].ToString());
                        }
                    }
                }

                RoleComboBox.DataSource = roles;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void RegButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(db.Class1.ConnectionString))
                {
                    connection.Open();

                    string sqlExpression = "INSERT INTO [User] ([IdUserRole], [FirstName], [Login], [Password]) " +
                        "VALUES (@Role, @Name, @Login, @Password);";
                    OleDbCommand sqlCommand = new OleDbCommand(sqlExpression, connection);
                    sqlCommand.Parameters.AddWithValue("@Role", RoleComboBox.SelectedIndex + 1);
                    sqlCommand.Parameters.AddWithValue("@Name", NameTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Login", LoginTextBox.Text);
                    sqlCommand.Parameters.AddWithValue("@Password", PasswordTextBox.Text);

                    int number = sqlCommand.ExecuteNonQuery();
                    if (number >= 1)
                    {
                        MessageBox.Show("Успешная регистрация!");

                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка регистрации!");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void avto_Load(object sender, EventArgs e)
        {

        }
    }
}