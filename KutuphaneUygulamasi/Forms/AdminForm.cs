using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KutuphaneUygulamasi.Helpers;
using KutuphaneUygulamasi.Models;

namespace KutuphaneUygulamasi.Forms
{
    public partial class AdminForm : Form
    {
        private string _username;

        // Yapıcı metot
        public AdminForm(string username)
        {
            InitializeComponent(); // Form bileşenlerini doğru şekilde yükleyin
            _username = username;
            lblWelcome.Text = "Hoş geldiniz, " + _username;
            LoadBooks();
            LoadGenres();  // Türleri yükleyelim
        }

        // Kitapları yükleme
        private void LoadBooks()
        {
            var books = FileHelper.LoadData<Book>("Data/books.json");

            if (books == null || books.Count == 0)
            {
                MessageBox.Show("Kitaplar yüklenemedi veya veri boş.");
                return;
            }

            listBoxBooks.Items.Clear();

            foreach (var book in books)
            {
                listBoxBooks.Items.Add($"{book.Title} - {book.Author}");
            }
        }

        // Türleri yükleme
        private void LoadGenres()
        {
            var genres = new List<Genre>
            {
                new Genre { Id = 1, Name = "Fiction" },
                new Genre { Id = 2, Name = "Non-Fiction" },
                new Genre { Id = 3, Name = "Science" },
                new Genre { Id = 4, Name = "Fantasy" },
                new Genre { Id = 5, Name = "History" }
            };

            // ComboBox'ı yükleyelim
            cmbGenre.DataSource = genres;
            cmbGenre.DisplayMember = "Name";  // Gösterilecek ad
            cmbGenre.ValueMember = "Id";  // Değer olarak ID'yi kullan
        }

        // Kitap ekleme
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            // Seçilen türü almak
            var selectedGenre = (Genre)cmbGenre.SelectedItem;  // Genre nesnesine dönüştürme

            var newBook = new Book
            {
                Title = txtTitle.Text,
                Author = txtAuthor.Text,
                Genre = selectedGenre,  // Genre nesnesini kullanıyoruz
                Publisher = txtPublisher.Text,
                ISBN = txtISBN.Text,
                StockCount = (int)nudStock.Value, // Bu satırda stok sayısını ekliyorsunuz
                Year = (int)nudYear.Value
            };

            var books = FileHelper.LoadData<Book>("Data/books.json");
            books.Add(newBook);
            FileHelper.SaveData("Data/books.json", books);

            // Kitapları yeniden yükleyelim
            LoadBooks();
        }

        // Kitap silme
        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (listBoxBooks.SelectedItem == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz kitabı seçin.");
                return;
            }

            var selectedBook = listBoxBooks.SelectedItem.ToString();
            var books = FileHelper.LoadData<Book>("Data/books.json");

            // Kitapları listeye eklerken gösterdiğimiz formatı kullanarak kitabı bulma
            var bookToDelete = books.FirstOrDefault(b => $"{b.Title} - {b.Author}" == selectedBook);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                FileHelper.SaveData("Data/books.json", books);
                LoadBooks(); // Kitapları tekrar yükle
            }
        }
    }
}
