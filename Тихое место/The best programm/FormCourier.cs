using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormCourier : Form
    {
        private SQLiteConnection DB;
        public FormCourier()
        {
            InitializeComponent();
        }

        private async void FormCourier_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            LoadingDB();
        }
        private async void LoadingDB()
        {
            dataGridViewCourier.Rows.Clear();
            SQLiteDataReader sqlReader = null;
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_Order.main}]", DB);
            List<string[]> data = new List<string[]>();
            try
            {
                sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[6]); // вывод данных по столбцам

                    data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{table_Order.ID}"]}");
                    data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{table_Order.Price}"]}");
                    data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{table_Order.Number}"]}");
                    data[data.Count - 1][3] = Convert.ToString($"{sqlReader[$"{table_Order.User}"]}");
                    data[data.Count - 1][4] = Convert.ToString($"{sqlReader[$"{table_Order.Waiter}"]}");
                    data[data.Count - 1][5] = Convert.ToString($"{sqlReader[$"{table_Order.Dishes}"]}");
                }

                foreach (string[] s in data)
                {
                    _ = dataGridViewCourier.Rows.Add(s);
                }
                dataGridViewCourier.ClearSelection();

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

        private void button3_Click(object sender, EventArgs e)
        {
            Form formCreateTicket = new FormLogin();
            formCreateTicket.Show();
            formCreateTicket.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell cell in dataGridViewCourier.SelectedCells)
            {
                cell.Style.BackColor = Color.Green;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand($"DELETE FROM [{table_Order.main}] " +
                        $"WHERE ID = @ID", DB); // удаляем данные из БД
                    _ = command.Parameters.Add(new SQLiteParameter("@ID", dataGridViewCourier.CurrentRow.Cells["ID"].Value));
                    _ = command.ExecuteNonQuery();
                    _ = MessageBox.Show("Удаление заявки прошло успешно", "Удаление", MessageBoxButtons.OK);

                }
                catch (Exception ex)
                {
                    _ = MessageBox.Show("Ошибка при удалении записи из базы данных: " + ex.Message);
                }
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LoadingDB();
        }
    }
}