namespace BookDB {
    internal interface IBookRepository {
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);
        List<Book> GetAll(); 

    }
}
