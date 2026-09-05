using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SistemInformasiSurat
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // TEST: Coba koneksi langsung tanpa DatabaseHelper
            try
            {
                string connStr = "Server=localhost;Database=db_surat;Uid=root;Pwd=;SslMode=none;AllowPublicKeyRetrieval=True;CharSet=utf8mb4;";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    conn.Open();

                    // Test query sederhana
                    using (MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM users", conn))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        MessageBox.Show($"✅ Koneksi Berhasil!\nJumlah User: {count}",
                            "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Jika berhasil, jalankan LoginForm
                Application.Run(new Forms.LoginForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error: {ex.Message}\n\n{ex.StackTrace}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}