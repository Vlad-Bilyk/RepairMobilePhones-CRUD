using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace RepairMobilePhones
{
    // Клас вікна для додавання нових записів
    public partial class AddForm : Form
    {
        private static DataBase dataBase = new DataBase();
        private static string dateFormat = @"^(0[1-9]|[12][0-9]|3[01])\.(0[1-9]|1[0-2])\.\d{4}$";
        private static string contactFormat = @"^\+380-\d{2}-\d{3}-\d{2}-\d{2}$";


        public AddForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        // Метод для очищення полів вводу після збереження даних
        private void ClearFields()
        {
            textBox_date.Text = "";
            textBox_contact.Text = "";
            textBox_phone.Text = "";
            textBox_description.Text = "";
        }

        // Метод для кнопки "Зберегти"
        private void Savebutton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            List<string> values = new List<string>
            {
                textBox_date.Text,
                textBox_contact.Text,
                textBox_phone.Text,
                textBox_description.Text,
            };

            if (inputCheck(values))
            {

                var addQuery = $"INSERT INTO repair_request(filing_date, contact_number, phone_model, problem_description, work_status)" +
                    $" VALUES ('{values[0]}', '{values[1]}', '{values[2]}', '{values[3]}', 'Прийнята')";

                var command = new SQLiteCommand(addQuery, dataBase.getConnection());
                command.ExecuteNonQuery();

                MessageBox.Show("Запис успішно збережено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();

            }

            dataBase.closeConnection();
        }

        public bool inputCheck(List<string> values)
        {
            try
            {
                Regex regex1 = new Regex(dateFormat);
                Regex regex2 = new Regex(contactFormat);

                if (string.IsNullOrEmpty(values[0]) || string.IsNullOrEmpty(values[1]) ||
                    string.IsNullOrEmpty(values[2]) || string.IsNullOrEmpty(values[3]) ||
                    !regex1.IsMatch(values[0]) || !regex2.IsMatch(values[1]))
                { throw new Exception(); }

                return true;
            }
            catch
            {
                MessageBox.Show("Запис не збережено. Один з параметрів не введено або введено неправильно: \nФормат вводу дати: dd.mm.yyyy" +
                    "\nФормат вводу контактного номеру: +380-XX-XXX-XX-XX",
                    "Непрвавильний ввід", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
    }
}