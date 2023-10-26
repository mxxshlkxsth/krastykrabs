using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormAdmin : Form
    {
        private SQLiteConnection DB;
        public FormAdmin()
        {
            InitializeComponent();
        }
        private async void FormAdmin_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            LoadingDB();
        }
        private async void LoadingDB()
        {
            dataGridViewAdmin.Rows.Clear();
            SQLiteDataReader sqlReader = null;
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_Menu.main}]", DB);
            List<string[]> data = new List<string[]>();
            try
            {
                sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[3]); // вывод данных по столбцам

                    data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{table_Menu.ID}"]}");
                    data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{table_Menu.Name}"]}");
                    data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{table_Menu.Price}"]}");
                }

                foreach (string[] s in data)
                {
                    _ = dataGridViewAdmin.Rows.Add(s);
                }
                dataGridViewAdmin.ClearSelection();

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show($"{ex.Message}", $"{ex.Source}");
            }
            finally
            {
                sqlReader?.Close();
            }
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand($"DELETE FROM [{table_Menu.main}] " +
                    $"WHERE ID = @ID", DB); // удаляем данные из БД
                _ = command.Parameters.Add(new SQLiteParameter("@ID", dataGridViewAdmin.CurrentRow.Cells["ID"].Value));
                _ = command.ExecuteNonQuery();
                _ = MessageBox.Show("Удаление заявки прошло успешно", "Удаление", MessageBoxButtons.OK);

            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Ошибка при удалении записи из базы данных: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteCommand query = new SQLiteCommand($"UPDATE [{table_Menu.main}] SET ColumnPrice = @Column WHERE ColumnPrice", DB);
                _ = query.Parameters.AddWithValue("@ColumnPrice", dataGridViewAdmin.CurrentRow.Cells["ColumnPrice"].Value); ;
                _ = query.ExecuteNonQuery();

                _ = MessageBox.Show("Данные успешно изменены");
            }
            catch (Exception ex)
            {
                _ = MessageBox.Show("Ошибка при изменении данных: " + ex.Message);
            }
        }

        private void dataGridViewAdmin_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form formCreateTicket = new FormLogin();
            formCreateTicket.Show();
            formCreateTicket.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadingDB();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}