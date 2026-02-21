using System;
using System.Linq;
using System.Windows.Forms;
using KutuphaneUygulamasi.Helpers;
using KutuphaneUygulamasi.Models;

namespace KutuphaneUygulamasi.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kullanıcıları yükle
            var users = FileHelper.LoadData<User>("Data/users.json");

            // Kullanıcı adı ve şifreyi kontrol et
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Admin olarak giriş yapılırsa
                if (username == "admin")
                {
                    // Admin formuna yönlendir
                    AdminForm adminForm = new AdminForm(username);  // Burada username parametresini geçiriyoruz
                    adminForm.Show();
                    this.Hide();
                }
                else
                {
                    // Öğrenci formuna yönlendir
                    StudentForm studentForm = new StudentForm(username);
                    studentForm.Show();
                    this.Hide();
                }
            }
            else
            {
                lblStatus.Text = "Kullanıcı adı veya şifre hatalı.";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Kayıt işlemi için fonksiyon (isteğe bağlı)
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            bool isAdmin = chkIsAdmin.Checked;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblStatus.Text = "Kullanıcı adı ve şifre boş olamaz.";
                return;
            }

            var users = FileHelper.LoadData<User>("Data/users.json");

            if (users.Any(u => u.Username == username))
            {
                lblStatus.Text = "Bu kullanıcı adı zaten kayıtlı.";
                return;
            }

            users.Add(new User
            {
                Username = username,
                Password = password,
                IsAdmin = isAdmin
            });

            FileHelper.SaveData("Data/users.json", users);
            lblStatus.Text = "Kayıt başarılı. Şimdi giriş yapabilirsiniz.";
        }
    }
}
