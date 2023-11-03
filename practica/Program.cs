using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace practica
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
    }
    static class DataBase // строка подключения к БД
    {
        public static string connectionString = @"Data Source=db.db; Integrated Security=False; MultipleActiveResultSets=True";
    }

    static class Country_table // описание таблиц из БД
    {
        public static string main = "Country";
        public static string ID = "ID";
        public static string Population = "Population";
        public static string Nation = "Nation";
        public static string Name = "Name";
        public static string Capital = "Capital";
        public static string Region = "Region";
        public static string Square = "Square";
        public static string Economy = "Economy";
    }

    static class Nation_table // описание таблиц из БД
    {
        public static string main = "Nation";
        public static string ID = "ID";
        public static string Name = "Name";
        public static string Language = "Language";
        public static string Quanity = "Quanity";
    }
    static class Popu_table // описание таблиц из БД
    {
        public static string main = "Population";
        public static string ID = "ID";
        public static string Name = "Name";
        public static string Quanity = "Quanity";
    }
}
