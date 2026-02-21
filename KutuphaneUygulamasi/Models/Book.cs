namespace KutuphaneUygulamasi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public Genre Genre { get; set; }  // Genre nesnesi kullanıyoruz
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        public int Stock { get; set; }
        public int Year { get; set; }
        public int BorrowCount { get; set; }
        public bool IsBorrowed { get; set; }  // Kitap ödünç alındıysa true, alınmadıysa false
        public int StockCount
        {
            get { return Stock; }
            set { Stock = value; }
        }
    }
}
