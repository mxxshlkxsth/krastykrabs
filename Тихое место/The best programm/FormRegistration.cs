using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormRegistration : Form
    {
        private SQLiteConnection DB;
        public FormRegistration()
        {
            InitializeComponent();
        }

        private async void FormRegistration_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
        }

        private async void ButtonRegistration_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;
            string surname = TextBoxSurname.Text;
            string name = textBoxName.Text;
            string number = textBoxNumber.Text;
            string role = "user"; //устанавливаем значение роли по умолчанию
            string query = $"INSERT INTO [{table_Users.main}] (Name, Login, Password, Surname,Number , Role) " +
                    $"VALUES (@Name, @Login, @Password, @Surname, @Number, @Role)";

            if (login != "" && password != "" && name != "" && surname != "" && number != "" && role != "")
            {
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_Users.main}] " +
                    $"WHERE {table_Users.Login}=@Login " +
                    $"AND {table_Users.Password}=@Password " +
                    $"AND {table_Users.Surname}=@Surname " +
                    $"AND {table_Users.Number}=@Number " +
                    $"AND {table_Users.Name}=@Name", DB); // берет полученные данные из TextBox в БД(table_Users)
                _ = command.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                _ = command.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                _ = command.Parameters.AddWithValue("@Name", textBoxName.Text);
                _ = command.Parameters.AddWithValue("@Surname", TextBoxSurname.Text);
                _ = command.Parameters.AddWithValue("@Number", textBoxNumber.Text);
                SQLiteDataReader sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                if (await sqlReader.ReadAsync())
                {
                    _ = MessageBox.Show("Такой пользователь уже есть", "Ошибка регистрации", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    using (SQLiteCommand commandInsert = new SQLiteCommand(query, DB))
                    {
                        _ = commandInsert.Parameters.AddWithValue("@Name", textBoxName.Text);
                        _ = commandInsert.Parameters.AddWithValue("@Login", textBoxLogin.Text);
                        _ = commandInsert.Parameters.AddWithValue("@Password", textBoxPassword.Text);
                        _ = commandInsert.Parameters.AddWithValue("@Surname", TextBoxSurname.Text);
                        _ = commandInsert.Parameters.AddWithValue("@Number", textBoxNumber.Text);
                        _ = commandInsert.Parameters.AddWithValue("@Role", role); //устанавливаем значение роли по умолчанию
                        _ = await commandInsert.ExecuteNonQueryAsync();
                    }
                    Form formCreateTicket = new FormLogin();
                    _ = MessageBox.Show($"Пользователь успешно зарегистрирован!\nЛогин: {textBoxLogin.Text} Пароль: {textBoxPassword.Text}", "Регистрация нового пользователя прошла успешно ", MessageBoxButtons.OK);
                    formCreateTicket.Show();
                    formCreateTicket.FormClosed += new FormClosedEventHandler(Form_FormClosed);
                    Hide();
                }


            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void textBoxNumber_KeyPress(object sender, KeyPressEventArgs e)
        {

            e.Handled = !System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[0,1,2,3,4,5,6,7,8,9,\b,',','-']");

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