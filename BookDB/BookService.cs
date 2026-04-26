namespace BookDB {
    internal class BookService {
        private MySQLBookRepository bookRepository = new MySQLBookRepository();

        public void AddBook(string titolo, string autore, string pagine, string data) {
            Book book = new Book();
            book.Titolo = titolo;
            book.Autore = autore;
            book.Pagine = pagine;
            book.Data = data;

            bookRepository.Add(book);
        }

        public List<Book> GetAllBooks() {
            return bookRepository.GetAll();
        }

        public void DeleteBook(int id) {
            bookRepository.Delete(id);
        }

        public void UpdateBook(string titolo, string autore, string anno, string pagine, int id) {
            Book book = new Book { Titolo = titolo, Autore = autore, Data = anno, Pagine = pagine };
            bookRepository.Update(book, id);
        }
    }
}
