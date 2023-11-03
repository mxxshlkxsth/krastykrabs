using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string pass = textBox2.Text;

            if ((login == "user") && (pass == "user"))
            {
                Form users = new Form1();
                users.Show();
                users.FormClosed += new FormClosedEventHandler(form_FormClosed);
                this.Hide();
            }
            else if ((login == "admin") && (pass == "admin"))
            {
                Form users = new FormAdmin();
                users.Show();
                users.FormClosed += new FormClosedEventHandler(form_FormClosed);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }

        }


    }
}
