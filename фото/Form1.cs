using Microsoft.VisualBasic.ApplicationServices;

namespace фото
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form users = new Form2();
            users.Show();
            users.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form users = new Form3();
            users.Show();
            users.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form users = new Form4();
            users.Show();
            users.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
    }
}