using System;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void reg_Load(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load_1(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(db.Class1.ConnectionString))
                {
                    connection.Open(); string sqlcommand = "SELECT * FROM [USER] WHERE [LOGIN] = @Login AND [Password]  = @Password;";
                    OleDbCommand dbCommand = new OleDbCommand(sqlcommand, connection); 
                    dbCommand.Parameters.AddWithValue("@Login", LogintextBox.Text);
                    dbCommand.Parameters.AddWithValue("@Password", PasswordtextBox.Text);
                    using (OleDbDataReader dataReader = dbCommand.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            MessageBox.Show($"Здраствуйте,{dataReader["firstName"]}"); this.Hide();
                            menu menu = new menu(); menu.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Неверный логин/пароль!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            reg newForm = new reg();
            newForm.Show();
        }
    }
}
    

