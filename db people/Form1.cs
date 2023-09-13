using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace db_people
{
    public partial class Form1 : Form
    {
        public SQLiteConnection DB;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(Database.connectionString);
            await DB.OpenAsync();


        }

        static class Database //строка подключения БД
        {
            public static string connectionString = @"Data Source=people.db;Integrated Security=False; MultipleActiveResultSets=True";
        }

        static class People_table
        {
            public static string main = "People";
            public static string ID = "ID";
            public static string Name = "Name";
            public static string Foto = "Foto";
        }

        static class foto_table
        {
            public static string main = "People";
            public static string ID = "ID";
            public static string Foto = "Foto";
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM foto", DB);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataAdapter.Fill(ds, "Info");
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter("SELECT * FROM People", DB);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            dataAdapter.Fill(ds, "Info");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
