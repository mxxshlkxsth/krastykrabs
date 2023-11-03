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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void countryButton_Click(object sender, EventArgs e)
        {
            Form formlogin = new AdminCountry();
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
            Form formlogin = new NationAdmin();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void populationButton_Click(object sender, EventArgs e)
        {
            Form formlogin = new PopuAdmin();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
    }
}
