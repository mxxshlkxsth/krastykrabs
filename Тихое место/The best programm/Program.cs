using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_best_programm
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
            Application.Run(new FormLogin());
        }
    }
    static class DataBase // строка подключения к БД
    {
        public static string connectionString = @"Data Source=db.db; Integrated Security=False; MultipleActiveResultSets=True";
    }
    static class table_Menu // описание таблиц из БД
    {
        public static string main = "Menu";
        public static string ID = "ID";
        public static string Name = "Name";
        public static string Price = "Price";
    }
    static class table_Order
    {
        public static string main = "Order";
        public static string ID = "ID";
        public static string Dishes = "Dishes";
        public static string Price = "Price";
        public static string Number = "Number";
        public static string User = "User";
        public static string Waiter = "Waiter";
    }
    static class table_Users
    {
        public static string main = "Users";
        public static string ID = "ID";
        public static string Name = "Name";
        public static string Surname = "Surname";
        public static string Number = "Number";
        public static string Login = "Login";
        public static string Password = "Password";
        public static string Role = "Role";
    }
    static class DataUser
    {
        public static string family { get; set; }
        public static string name { get; set; }
        public static string number { get; set; }
        public static string login { get; set; }
        public static string password { get; set; }
    }
}
