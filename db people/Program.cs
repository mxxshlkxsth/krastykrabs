using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace db_people
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
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
            public static string Name = "Name";
            public static string Foto = "Foto";
        }


    }
}
