using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormLogin : Form
    {
        private SQLiteConnection DB;
        public FormLogin()
        {
            InitializeComponent();
        }

        private async void FormLogin_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private async void ButtonEnter_Click_1(object sender, EventArgs e)
        {
            string login = TextBoxLogin.Text;
            string Password = TextBoxPassword.Text;

            if (login != "" && Password != "")
            {
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_Users.main}] " +
                    $"WHERE {table_Users.Login}=@Login " +
                    $"AND {table_Users.Password}=@Password", DB); // берет данные для TextBox из таблицы table_Users
                _ = command.Parameters.AddWithValue("Login", TextBoxLogin.Text);
                _ = command.Parameters.AddWithValue("Password", TextBoxPassword.Text);
                SQLiteDataReader sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();

                if (await sqlReader.ReadAsync())
                {   // вывод данных в личный кабинет
                    DataUser.family = sqlReader[$"{table_Users.Surname}"].ToString();
                    DataUser.name = sqlReader[$"{table_Users.Name}"].ToString();
                    DataUser.number = sqlReader[$"{table_Users.Number}"].ToString();
                    DataUser.login = sqlReader[$"{table_Users.Login}"].ToString();
                    DataUser.password = sqlReader[$"{table_Users.Password}"].ToString();

                    if (sqlReader[$"{table_Users.Role}"].ToString() == "admin")
                    {
                        Form formlogin = new FormAdmin();
                        _ = MessageBox.Show("Вход прошел успешно", "Успех", MessageBoxButtons.OK);
                        formlogin.Show();
                        formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                        Hide();

                    }
                    else if (sqlReader[$"{table_Users.Role}"].ToString() == "user")
                    {
                        Form formlogin = new FormUser();
                        _ = MessageBox.Show("Вход прошел успешно", "Успех", MessageBoxButtons.OK);
                        formlogin.Show();
                        formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                        Hide();
                    }
                    else if (sqlReader[$"{table_Users.Role}"].ToString() == "waiter")
                    {
                        Form formlogin = new FormWaiter();
                        _ = MessageBox.Show("Вход прошел успешно", "Успех", MessageBoxButtons.OK);
                        formlogin.Show();
                        formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                        Hide();
                    }
                    else if (sqlReader[$"{table_Users.Role}"].ToString() == "courier")
                    {
                        Form formlogin = new FormCourier();
                        _ = MessageBox.Show("Вход прошел успешно", "Успех", MessageBoxButtons.OK);
                        formlogin.Show();
                        formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                        Hide();
                    }
                    sqlReader.Close();
                }
                else
                {
                    _ = MessageBox.Show("Вход не выполнен, введены неправильно данные", "Ошибка входа", MessageBoxButtons.OK);
                    return;
                }
            }

        }

        private void ButtonRegistration_Click(object sender, EventArgs e)
        {
            Form formlogin = new FormRegistration();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}