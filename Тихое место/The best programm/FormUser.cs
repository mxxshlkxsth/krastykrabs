using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormUser : Form
    {
        private SQLiteConnection DB;
        public FormUser()
        {
            InitializeComponent();
        }

        private async void FormUser_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            TextBoxFN.Text = $"{DataUser.name} {DataUser.family}";
        }

        private void buttonCabinet_Click(object sender, EventArgs e)
        {
            Form formlogin = new FormCabinet();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void buttonOrder_Click(object sender, EventArgs e)
        {
            Form formlogin = new FormCr();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formCreateTicket = new FormLogin();
            formCreateTicket.Show();
            formCreateTicket.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
    }
}