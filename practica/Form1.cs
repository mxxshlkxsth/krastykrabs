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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void countryButton_Click(object sender, EventArgs e)
        {
            Form formlogin = new countryForm();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void nationButton_Click(object sender, EventArgs e)
        {
            Form formlogin = new nationForm();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void populationButton_Click(object sender, EventArgs e)
        {
            Form formlogin = new popuForm();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
    }
}
