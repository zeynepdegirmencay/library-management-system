using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Models
{
    public class Loan
    {
        public string Username { get; set; }     // Hangi kullanıcı aldı
        public string BookTitle { get; set; }    // Hangi kitap
        public DateTime LoanDate { get; set; }   // Alış tarihi
        public DateTime DueDate { get; set; }    // İade edilmesi gereken tarih
    }
}

