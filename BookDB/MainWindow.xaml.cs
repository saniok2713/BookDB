using System.Collections.ObjectModel;
using System.Windows;


namespace BookDB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        BookService bookService = new BookService();
        ObservableCollection<Book> books;

        public MainWindow() {
            InitializeComponent();
            LoadBooks();
        }

        private void AddBook(object sender, RoutedEventArgs e) {
            bookService.AddBook(titolo.Text, autore.Text, pagine.Text, anno.Text);
            titolo.Clear();
            autore.Clear();
            pagine.Clear();
            anno.Clear();
            LoadBooks();
        }

        private void DeleteBook(object sender, RoutedEventArgs e) {

        }

        private void UpdateBook(object sender, RoutedEventArgs e) {

        }

        private void LoadBooks() {
            books = new ObservableCollection<Book>(bookService.GetAllBooks());
            dataGrid.ItemsSource = books;
        }

        private void RefreshList(object sender, RoutedEventArgs e) {
            LoadBooks();
        }
    }
}