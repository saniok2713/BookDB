namespace BookDB {
    internal interface IBookRepository {
        void Add(Book book);
        void Delete(int id);
        void Update(Book book, int id);
        List<Book> GetAll();
        List<Book> FindBook(string nomeLibro);
    }
}
