using MySql.Data.MySqlClient;
using System.Windows;

namespace BookDB {
    internal class MySQLBookRepository : IBookRepository {

        Database db = new Database();
        string query = "";

        public void Add(Book book) {
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "INSERT INTO book (titolo,autore,pagine,data_pubblicazione) VALUES (@titolo,@autore,@pagine,@data_pubblicazione)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@titolo", book.Titolo);
                cmd.Parameters.AddWithValue("@autore", book.Autore);
                cmd.Parameters.AddWithValue("@pagine", book.Pagine);
                cmd.Parameters.AddWithValue("@data_pubblicazione", book.Data);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id) {
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "DELETE FROM book WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }


        public void Update(Book book, int id) {
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "UPDATE book SET titolo = @titolo, autore = @autore, data_pubblicazione = @anno, pagine = @pagine WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@titolo", book.Titolo);
                cmd.Parameters.AddWithValue("@autore", book.Autore);
                cmd.Parameters.AddWithValue("@anno", book.Data);
                cmd.Parameters.AddWithValue("@pagine", book.Pagine);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

        }
        public List<Book> GetAll() {
            List<Book> books = new List<Book>();
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "SELECT * FROM book";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Book book = new Book();
                    book.ID = Convert.ToInt32(reader["id"]);
                    book.Titolo = reader["titolo"].ToString();
                    book.Autore = reader["autore"].ToString();
                    book.Pagine = reader["pagine"].ToString();
                    book.Data = reader["data_pubblicazione"].ToString();
                    books.Add(book);
                }
            }
            return books;
        }

        public List<Book> FindBook(string nomeLibro) {
            List<Book> books = new List<Book>();
            using (MySqlConnection connection = db.GetConnection()) {
                connection.Open();
                query = "SELECT * FROM book WHERE titolo LIKE @name";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@name", nomeLibro + "%");
                using MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    Book book = new Book();
                    book.ID = Convert.ToInt32(reader["id"]);
                    book.Titolo = reader["titolo"].ToString();
                    book.Autore = reader["autore"].ToString();
                    book.Pagine = reader["pagine"].ToString();
                    book.Data = reader["data_pubblicazione"].ToString();
                    books.Add(book);
                }
            }
            return books;
        }
    }
}
