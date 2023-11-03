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
    public partial class nationForm : Form
    {
        private SQLiteConnection DB;
        public nationForm()
        {
            InitializeComponent();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void nationForm_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            LoadingDB();
        }
        private async void LoadingDB()
        {
            dataGridView1.Rows.Clear();
            SQLiteDataReader sqlReader = null;
            SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{Nation_table.main}]", DB);
            List<string[]> data = new List<string[]>();
            try
            {
                sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    data.Add(new string[4]); // вывод данных по столбцам

                    data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{Nation_table.ID}"]}");
                    data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{Nation_table.Name}"]}");
                    data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{Nation_table.Language}"]}");
                    data[data.Count - 1][3] = Convert.ToString($"{sqlReader[$"{Nation_table.Quanity}"]}");
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


    }
}
