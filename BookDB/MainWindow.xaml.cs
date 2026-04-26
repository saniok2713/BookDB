using System.Collections.ObjectModel;
using System.Windows;


namespace BookDB {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        BookService bookService = new BookService();
        ObservableCollection<Book> books;
        Book book;
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
            try {
                book = dataGrid.SelectedItem as Book;
                int id = book.ID;
                bookService.DeleteBook(id);
                LoadBooks();
            }
            catch {
                MessageBox.Show("I campi da eliminare sono vuoiti");
            }

        }

        private void UpdateBook(object sender, RoutedEventArgs e) {
            try {
                book = dataGrid.SelectedItem as Book;
                bookService.UpdateBook(titolo.Text, autore.Text, anno.Text, pagine.Text, book.ID);
            }
            catch {

            }
            LoadBooks();
        }

        private void LoadBooks() {
            books = new ObservableCollection<Book>(bookService.GetAllBooks());
            dataGrid.ItemsSource = books;
        }

        private void RefreshList(object sender, RoutedEventArgs e) {
            LoadBooks();
        }

        private void dataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
            if (dataGrid.SelectedItem == null)
                return;
            book = dataGrid.SelectedItem as Book;
            titolo.Text = book.Titolo;
            autore.Text = book.Autore;
            anno.Text = book.Data;
            pagine.Text = book.Pagine;
        }
    }
}