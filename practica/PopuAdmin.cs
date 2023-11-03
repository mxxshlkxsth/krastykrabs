using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica
{
    public partial class PopuAdmin : Form
    {
        private SQLiteConnection DB;
        public PopuAdmin()
        {
            InitializeComponent();
        }

        private async void PopuAdmin_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            LoadingDB();
        }
        private async void LoadingDB()
        {
            dataGridView1.Rows.Clear();
            SQLiteDataReader sqlReader = null;
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{Popu_table.main}]", DB);
            List<string[]> data = new List<string[]>();
            try
            {
                sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[3]); // вывод данных по столбцам

                    data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{Popu_table.ID}"]}");
                    data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{Popu_table.Name}"]}");
                    data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{Popu_table.Quanity}"]}");
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
            Form formlogin = new FormAdmin();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }
    }
}
