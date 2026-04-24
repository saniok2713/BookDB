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
    }
}
