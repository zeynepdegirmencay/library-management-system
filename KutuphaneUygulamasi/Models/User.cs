using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneUygulamasi.Models
{
    public class User
    {
        public string Username { get; set; }   // Kullanıcı adı
        public string Password { get; set; }   // Şifre
        public bool IsAdmin { get; set; }      // Admin mi?
    }
}
