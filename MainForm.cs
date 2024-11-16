using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace RepairMobilePhones
{
    // Клас головного вікна програми
    public partial class MainForm : Form
    {
        private static AddForm add = new AddForm();
        private static DataBase dataBase = new DataBase();
        private static BindingSource bindingSrs;

        private static SQLiteConnection connection = dataBase.getConnection();
        private static SQLiteCommand command = new SQLiteCommand("", connection);

        private static string sql;
        private static List<string> values;

        // Конструктор форми
        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.textBox_id.Enabled = false;
        }

        // Метод завантаження форми
        private void MainForm_Load(object sender, EventArgs e)
        {
            dataBase.openConnection();
            updateDataBinding();
            dataBase.closeConnection();
        }

        // Відображення позиції в таблиці
        private void displayPosition()
        {
            positionLabel.Text = "Position: " + Convert.ToString(bindingSrs.Position + 1) +
                "/" + bindingSrs.Count.ToString(); 
        }

        // Метод для зв'язування даних в базі даних і таблицею для їх виведення в програмі
        private void updateDataBinding(SQLiteCommand cmd = null)
        {
            try
            {
                TextBox tb;
                foreach (Control c in groupBox1.Controls)
                {
                    if (c.GetType() == typeof(TextBox))
                    {
                        tb = (TextBox)c;
                        tb.DataBindings.Clear();
                        tb.Text = "";
                    }
                    if (c.GetType() == typeof(ComboBox))
                    {
                        ComboBox comboBox = (ComboBox)c;
                        comboBox.DataBindings.Clear();
                        comboBox.Text = "";
                    }
                }

                sql = "SELECT * FROM repair_request ORDER BY ID ASC";

                if (cmd == null)
                    command.CommandText = sql;
                else
                    command = cmd;

                SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                DataSet dataSt = new DataSet();
                adapter.Fill(dataSt, "repair_request");

                bindingSrs = new BindingSource();
                bindingSrs.DataSource = dataSt.Tables["repair_request"];

                // Зв'язування даних і налаштування таблиці
                textBox_id.DataBindings.Add("Text", bindingSrs, "ID");
                textBox_date.DataBindings.Add("Text", bindingSrs, "Filing_date");
                textBox_contact.DataBindings.Add("Text", bindingSrs, "Contact_number");
                textBox_phone.DataBindings.Add("Text", bindingSrs, "Phone_model");
                textBox_description.DataBindings.Add("Text", bindingSrs, "Problem_description");
                comboBox_WorkStat.DataBindings.Add("Text", bindingSrs, "Work_status");

                dataGridView1.Enabled = true;
                dataGridView1.DataSource = bindingSrs;

                dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.ColumnHeader);
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                
                renameColumns();
                displayPosition();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка зв'язування даних: " + ex.Message.ToString(),
                    "Повідомлення про помилку", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Переіменування стовпців таблиці
        private void renameColumns()
        {
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Дата подачі";
            dataGridView1.Columns[2].HeaderText = "Контактний номер";
            dataGridView1.Columns[3].HeaderText = "Модель телефону";
            dataGridView1.Columns[4].HeaderText = "Опис проблеми";
            dataGridView1.Columns[5].HeaderText = "Статус роботи";
        }

        // Відкриття форми для додавання записів
        private void addButton_Click(object sender, EventArgs e)
        {
            add.ShowDialog();
            updateDataBinding();
        }

        // Відображення даних з таблиці в полях для вводу
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            displayPosition();
        }

        // Оновлення даних в таблиці
        private void updateButton_Click(object sender, EventArgs e)
        {
            updateDataBinding();
        }

        // Метод для кнопки "Змінити", змінює дані в строкі
        private void changeButton_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            try
            {
                if (MessageBox.Show("ID: " + textBox_id.Text.Trim() + " -- Ви дійсно хочете змінити цей запис?", "Зміна даних",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    return;

                values = new List<string>()
                {
                    textBox_date.Text,
                    textBox_contact.Text,
                    textBox_phone.Text,
                    textBox_description.Text,
                };

                if(add.inputCheck(values))
                {
                    sql = "UPDATE repair_request SET filing_date = @filing_date, contact_number = @contact_number," +
                    "phone_model = @phone_model, problem_description = @problem_description, work_status = @work_status WHERE ID = @ID";

                    command.Parameters.Clear();
                    command.CommandText = sql;

                    command.Parameters.AddWithValue("ID", textBox_id.Text.Trim());
                    command.Parameters.AddWithValue("filing_date", textBox_date.Text.Trim());
                    command.Parameters.AddWithValue("contact_number", textBox_contact.Text.Trim());
                    command.Parameters.AddWithValue("phone_model", textBox_phone.Text.Trim());
                    command.Parameters.AddWithValue("problem_description", textBox_description.Text.Trim());
                    command.Parameters.AddWithValue("work_status", comboBox_WorkStat.Text.Trim());

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message.ToString(), "Збереження даних",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                updateDataBinding();
                dataBase.closeConnection();
            }
        }

        // Метод для кнопки "Видалити", видаляє строку з таблиці
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (textBox_id.Text.Trim() == "" ||
                string.IsNullOrEmpty(textBox_id.Text.Trim()))
            {
                MessageBox.Show("Оберіть запис в таблиці", "Видалення даних",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dataBase.openConnection();

            try
            {
                if (MessageBox.Show("ID: " + textBox_id.Text.Trim() +
                    " -- Ви дійсно хочете видалити цей запис?", "Видалення даних",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                sql = "DELETE FROM repair_request WHERE ID = @ID";

                command.Parameters.Clear();
                command.CommandText = sql;
                command.Parameters.AddWithValue("ID", textBox_id.Text.Trim());

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message.ToString(), "Повідомлення про помилку",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                updateDataBinding();
                dataBase.closeConnection();
            }
        }

        // Метод для пошуку в таблиці
        private void search()
        {
            dataBase.openConnection();

            try
            {
                if (string.IsNullOrEmpty(textBox_search.Text.Trim()))
                {
                    updateDataBinding();
                    return;
                }

                sql = "SELECT * FROM repair_request" +
                    " WHERE filing_date LIKE @Keyword1" +
                    " OR contact_number LIKE @Keyword1" +
                    " OR phone_model LIKE @Keyword1" +
                    " OR problem_description LIKE @Keyword1" +
                    " ORDER BY ID ASC";

                command.CommandType = CommandType.Text;
                command.CommandText = sql;
                command.Parameters.Clear();

                string keyword = string.Format("%{0}%", textBox_search.Text);
                command.Parameters.AddWithValue("Keyword1", keyword);

                updateDataBinding(command);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку: " + ex.Message.ToString(), "Повідомлення про помилку",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dataBase.closeConnection();
                textBox_search.Focus();
            }
        }

        // Пошук в таблиці при зміні поля вводу
        private void textBox_search_TextChanged(object sender, EventArgs e)
        {
            search();
        }


        // Вихід із програми
        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Видалення всіх даних таблиці
        private void clearTableMenuItem_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();
            try
            {
                if (MessageBox.Show("Ви справді хочете видалити всі записи з таблиці? Їх повернення не можливе", "Видалення даних",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                sql = "DELETE FROM repair_request";
                command.CommandText = sql;
                command.ExecuteNonQuery();

                sql = "UPDATE sqlite_sequence SET seq=0 WHERE name='repair_request'";
                command.CommandText = sql;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при видаленні даних: " + ex.Message.ToString(),
                    "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                updateDataBinding();
                dataBase.closeConnection();
            }
        }

        // Метод для зміни показу підказок
        private void offOnToolTipsMenuitem_Click(object sender, EventArgs e)
        {
            if (offOnToolTipsMenuitem.Text == "Вимкнути спливаючі підказки")
            {
                toolTip.Active = false;
                offOnToolTipsMenuitem.Text = "Ввімкнути спливаючі підказки";
            }
            else if (offOnToolTipsMenuitem.Text == "Ввімкнути спливаючі підказки")
            {
                toolTip.Active = true;
                offOnToolTipsMenuitem.Text = "Вимкнути спливаючі підказки";
            }
        }

        // Метод для кнопки "Про програму"
        private void aboutProgramMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Даний програмний продукт створений: \nБіликом Владиславом студентом 3 курсу групи 6.04.122.010.21.01"
                + "\n\nЙого головноюю метою є оптимізація роботи сервісного центру з ремонту" +
                " мобільних телефонів, шляхом автоматизації роботи з заявками на ремонт",
                "Про програму", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}