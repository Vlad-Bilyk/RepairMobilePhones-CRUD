using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace RepairMobilePhones
{
    // Клас бази даних
    public class DataBase
    {
        private static string dbPath = Application.StartupPath + "\\" + "RepairRequestDB.db;";
        private static string conString = "Data Source=" + dbPath + "Version=3;New=false;Compress=True;";

        private static SQLiteConnection connection = new SQLiteConnection(conString);

        // Метод для відкриття підключення до бази даних
        public void openConnection()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        // Метод для закриття підключення до бази даних
        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        // Метод для отримання строки підключення до бази даних
        public SQLiteConnection getConnection() => connection;
    }
}
