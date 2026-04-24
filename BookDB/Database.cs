using MySql.Data.MySqlClient;

namespace BookDB {
    internal class Database {
        string connectionString = "server=localhost;user=root;password=5623;database=bookDB;";

        public MySqlConnection GetConnection() {
            return new MySqlConnection(connectionString);
        }
    }
}
