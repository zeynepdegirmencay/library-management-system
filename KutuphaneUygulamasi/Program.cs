using System;
using System.Windows.Forms;
using KutuphaneUygulamasi.Forms;

namespace KutuphaneUygulamasi
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana giriş noktasıdır.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Giriş ekranını başlat
            Application.Run(new LoginForm());
        }
    }
}



