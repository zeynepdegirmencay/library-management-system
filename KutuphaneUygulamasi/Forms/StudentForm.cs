using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using KutuphaneUygulamasi.Helpers;
using KutuphaneUygulamasi.Models;

namespace KutuphaneUygulamasi.Forms
{
    public partial class StudentForm : Form
    {
        private string _username;

        public StudentForm(string username)
        {
            InitializeComponent();
            _username = username;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            // Kitapları ve popüler kitapları yükle
            LoadBooks();
            LoadPopularBooks();
        }

        private void LoadBooks()
        {
            // Kitapları JSON'dan yükle
            var books = FileHelper.LoadData<Book>("Data/books.json");

            if (books == null || books.Count == 0)
            {
                MessageBox.Show("Kitaplar yüklenemedi veya veri boş.");
                return;
            }

            // ComboBox'ı temizle ve kitapları ekle
            cmbBooks.Items.Clear();

            foreach (var book in books)
            {
                // Kitapları kitap adı ve stok bilgisi ile ekle
                cmbBooks.Items.Add($"{book.Title} ({book.StockCount} adet)");
            }

            // ComboBox'da kitap başlığını göster
            cmbBooks.DisplayMember = "Text";  // ComboBox'a yazdırılacak olan metin
            cmbBooks.ValueMember = "ISBN";   // Kitabın ISBN'si değeri olarak kullanılacak
        }

        private void LoadPopularBooks()
        {
            // Popüler kitapları yükle ve ListBox'a ekle
            var books = FileHelper.LoadData<Book>("Data/books.json");
            var popularBooks = books.OrderByDescending(b => b.BorrowCount).Take(5).ToList();

            lstPopularBooks.Items.Clear();

            foreach (var book in popularBooks)
            {
                lstPopularBooks.Items.Add(book.Title);
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            // Kitap ödünç alma işlemi
            if (cmbBooks.SelectedItem == null)
            {
                MessageBox.Show("Lütfen ödünç almak istediğiniz kitabı seçin.");
                return;
            }

            // ComboBox'tan kitabı ve stok bilgisini al
            var selectedBookTitle = cmbBooks.SelectedItem.ToString().Split('(')[0].Trim();
            var books = FileHelper.LoadData<Book>("Data/books.json");

            var bookToBorrow = books.FirstOrDefault(b => b.Title == selectedBookTitle);

            if (bookToBorrow != null && bookToBorrow.StockCount > 0)
            {
                bookToBorrow.StockCount--;  // Stok miktarını bir azaltıyoruz
                bookToBorrow.IsBorrowed = true;  // Kitap ödünç alındı olarak işaretlendi

                // Kitap verilerini güncelle
                FileHelper.SaveData("Data/books.json", books);

                lblStatus.Text = $"{bookToBorrow.Title} kitabı ödünç alındı.";

                // Kitapları yeniden yükle
                LoadBooks();
            }
            else
            {
                lblStatus.Text = "Seçilen kitap stokta yok.";  // Hata mesajı
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            // Kitap iade etme işlemi
            if (cmbBooks.SelectedItem == null)
            {
                MessageBox.Show("Lütfen iade etmek istediğiniz kitabı seçin.");
                return;
            }

            // ComboBox'tan kitabı ve stok bilgisini al
            var selectedBookTitle = cmbBooks.SelectedItem.ToString().Split('(')[0].Trim();
            var books = FileHelper.LoadData<Book>("Data/books.json");

            var bookToReturn = books.FirstOrDefault(b => b.Title == selectedBookTitle);

            if (bookToReturn != null)
            {
                if (bookToReturn.IsBorrowed)
                {
                    bookToReturn.StockCount++;  // Stok sayısını artırıyoruz
                    bookToReturn.IsBorrowed = false;  // Ödünç durumu değiştirilir

                    // Kitap verilerini güncelle
                    FileHelper.SaveData("Data/books.json", books);

                    lblStatus.Text = $"{bookToReturn.Title} kitabı iade edildi.";  // Durum mesajı

                    // Kitapları yeniden yükle
                    LoadBooks();
                }
                else
                {
                    MessageBox.Show("Bu kitap zaten ödünç alınmamış.");  // Hata mesajı
                }
            }
            else
            {
                MessageBox.Show("Bir hata oluştu, kitap bulunamadı.");
            }
        }
    }
}
