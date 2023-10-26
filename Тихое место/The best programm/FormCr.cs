using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Windows.Forms;

namespace The_best_programm
{
    public partial class FormCr : Form
    {
        private SQLiteConnection DB;
        public FormCr()
        {
            InitializeComponent();
        }
        private async void FormCr_Load(object sender, EventArgs e)
        {
            DB = new SQLiteConnection(DataBase.connectionString);
            await DB.OpenAsync();
            Text = $"{DataUser.name}";
            Text = $"{DataUser.number}";
            Text = $"{table_Menu.Price}";
        }
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private async void ButtonSend_Click_1(object sender, EventArgs e)
        {
            List<string> selectedDishes = new List<string>();
            List<string> prices = new List<string>();

            double total_price = 0;

            foreach (object selectedDish in checkedListBox2.CheckedItems)
            {
                string Dishes = selectedDish.ToString();

                if (Dishes != "")
                {
                    double price = 0;

                    using (SQLiteCommand commandGetPrice = new SQLiteCommand($"SELECT * FROM [{table_Menu.main}] WHERE [{table_Menu.Name}]=@Name", DB))
                    {
                        _ = commandGetPrice.Parameters.AddWithValue("@Name", Dishes);
                        using (DbDataReader sqlReaderPrice = await commandGetPrice.ExecuteReaderAsync())
                        {
                            if (await sqlReaderPrice.ReadAsync())
                            {
                                _ = double.TryParse(sqlReaderPrice[table_Menu.Price].ToString(), out price);
                            }
                            else
                            {
                                Console.WriteLine("Блюдо не найдено");
                            }
                        }
                    }

                    selectedDishes.Add(Dishes);
                    total_price += price;
                }
            }

            string dishesLine = string.Join(",", selectedDishes);
            

            using (SQLiteCommand commandInsert = new SQLiteCommand($"INSERT INTO [{table_Order.main}] ([{table_Order.Dishes}], [Price], [Number], [User], [Waiter]) " +
                $"VALUES (@Dishes, @Price, @Number, @User, @Waiter)", DB))
            {
                _ = commandInsert.Parameters.AddWithValue("Dishes", dishesLine);
                _ = commandInsert.Parameters.AddWithValue("Price", total_price);
                _ = commandInsert.Parameters.AddWithValue("Number", $"{DataUser.number}");
                _ = commandInsert.Parameters.AddWithValue("User", $"{DataUser.name}");
                _ = commandInsert.Parameters.AddWithValue("Waiter", "Мария");
                _ = await commandInsert.ExecuteNonQueryAsync();
            }

            _ = MessageBox.Show($"Заявка успешно зарегистрирована!", "Создание новой заяки прошла успешно ", MessageBoxButtons.OK);

            Form formlogin = new FormUser();
            formlogin.Show();
            formlogin.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form formCreateTicket = new FormUser();
            formCreateTicket.Show();
            formCreateTicket.FormClosed += new FormClosedEventHandler(Form_FormClosed);
            Hide();
        }
    }
}