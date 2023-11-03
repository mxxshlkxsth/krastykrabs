using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace practica
{
    public partial class countryForm : Form
    {
        private SQLiteConnection DB;
        public countryForm()
        {
            InitializeComponent();
        }

        private async void countryForm_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            LoadingDB();
        }
        private async void LoadingDB()
        {
            dataGridView1.Rows.Clear();
            SQLiteDataReader sqlReader = null;
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{Country_table.main}]", DB);
            List<string[]> data = new List<string[]>();
            try
            {
                sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[8]); // вывод данных по столбцам

                    data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{Country_table.ID}"]}");
                    data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{Country_table.Population}"]}");
                    data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{Country_table.Nation}"]}");
                    data[data.Count - 1][3] = Convert.ToString($"{sqlReader[$"{Country_table.Name}"]}");
                    data[data.Count - 1][4] = Convert.ToString($"{sqlReader[$"{Country_table.Capital}"]}");
                    data[data.Count - 1][5] = Convert.ToString($"{sqlReader[$"{Country_table.Region}"]}");
                    data[data.Count - 1][6] = Convert.ToString($"{sqlReader[$"{Country_table.Square}"]}");
                    data[data.Count - 1][7] = Convert.ToString($"{sqlReader[$"{Country_table.Economy}"]}");
                }

                foreach (string[] s in data)
                {
                    _ = dataGridView1.Rows.Add(s);
                }
                dataGridView1.ClearSelection();

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

        private void countryButton_Click(object sender, EventArgs e)
        {
            Form formlogin = new Form1();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создание SQL-запроса
            string sql = $"SELECT [{Country_table.Nation}] FROM [{Country_table.main}]" +
                $"WHERE [{Country_table.Region}] = @parameter";

            // Создание команды на основе SQL-запроса и подключения
            using (SQLiteCommand command = new SQLiteCommand(sql, DB))
            {
                command.Parameters.AddWithValue("@parameter", textBox1.Text);
                // Выполнение команды и получение результата
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Получение значения из результата и вставка в Label
                        string value = reader.GetString(0);
                        label3.Text = value;
                    }
                    else
                    {
                        label3.Text = "Нет данных";
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создание SQL-запроса
            string sql = $"SELECT [{Country_table.Capital}] FROM [{Country_table.main}]" +
                $"WHERE [{Country_table.Nation}] = @parameter";

            // Создание команды на основе SQL-запроса и подключения
            using (SQLiteCommand command = new SQLiteCommand(sql, DB))
            {
                command.Parameters.AddWithValue("@parameter", textBox1.Text);
                // Выполнение команды и получение результата
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Получение значения из результата и вставка в Label
                        string value = reader.GetString(0);
                        label3.Text = value;
                    }
                    else
                    {
                        label3.Text = "Нет данных";
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Создание SQL-запроса на суммирование данных
            string sqlQuery = $"SELECT SUM([{Country_table.Population}]) FROM [{Country_table.main}]";

            // Создание команды для выполнения запроса
            using (SQLiteCommand command = new SQLiteCommand(sqlQuery, DB))
            {
                // Выполнение запроса и получение результата
                object result = command.ExecuteScalar();

                // Проверка результата на null и преобразование в нужный тип данных
                if (result != null && result != DBNull.Value)
                {
                    double sum = Convert.ToDouble(result);

                    // Вставка результата в label
                    label3.Text = $" {sum.ToString()}  млрд.";
                }
                else
                {
                    // Если результат равен null или DBNull, вставляем значение по умолчанию
                    label3.Text = "Нет данных";
                }
            }
        }
    }
}
