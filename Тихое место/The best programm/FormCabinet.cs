using System;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormCabinet : Form
    {
        public FormCabinet()
        {
            InitializeComponent();
        }

        private void FormCabinet_Load(object sender, EventArgs e)
        {
            textBoxSurname.Text = $"{DataUser.family}";
            textBoxName.Text = $"{DataUser.name}";
            textBoxNumber.Text = $"{DataUser.number}";
            textBoxLogin.Text = $"{DataUser.login}";
            textBoxPassword.Text = $"{DataUser.password}";
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formCreateTicket = new FormUser();
            formCreateTicket.Show();
            formCreateTicket.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
    }
}