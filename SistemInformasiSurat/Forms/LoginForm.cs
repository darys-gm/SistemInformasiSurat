using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using SistemInformasiSurat.Database;
using SistemInformasiSurat.Models;
using SistemInformasiSurat.Helpers;

namespace SistemInformasiSurat.Forms
{
    public partial class LoginForm : Form
    {
        private DatabaseHelper db;
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            db = new DatabaseHelper();

            this.Load += LoginForm_Load;
            this.FormClosing += LoginForm_FormClosing;
            this.btnLogin.Click += btnLogin_Click;
            this.btnClose.Click += btnClose_Click;
            this.btnMinimize.Click += btnMinimize_Click;
            this.btnTogglePassword.Click += btnTogglePassword_Click;
            this.txtPassword.KeyPress += txtPassword_KeyPress;
            this.llblForgotPassword.LinkClicked += llblForgotPassword_LinkClicked;
            this.llblRegister.LinkClicked += llblRegister_LinkClicked;
            this.panelHeader.MouseDown += panelHeader_MouseDown;
            this.panelHeader.MouseMove += panelHeader_MouseMove;
            this.panelHeader.MouseUp += panelHeader_MouseUp;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (!db.TestConnection())
            {
                MessageBox.Show(
                    "Tidak dapat terhubung ke database!\n\n" +
                    "Pastikan:\n" +
                    "1. MySQL/Laragon sudah berjalan\n" +
                    "2. Database 'db_surat' sudah dibuat\n" +
                    "3. Cek connection string di App.config",
                    "Error Koneksi Database",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            SetPlaceholder(txtUsername, "Masukkan Username");
            SetPlaceholder(txtPassword, "Masukkan Password");
            txtUsername.Focus();
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;

            textBox.Enter += (sender, e) =>
            {
                if (textBox.Text == placeholder)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                    if (textBox == txtPassword)
                    {
                        txtPassword.UseSystemPasswordChar = true;
                    }
                }
            };

            textBox.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholder;
                    textBox.ForeColor = Color.Gray;
                    if (textBox == txtPassword)
                    {
                        txtPassword.UseSystemPasswordChar = false;
                    }
                }
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginUser();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoginUser();
            }
        }

        private void LoginUser()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (username == "Masukkan Username" || string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Username harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return;
            }

            if (password == "Masukkan Password" || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Password harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                txtPassword.SelectAll();
                return;
            }

            btnLogin.Enabled = false;
            btnLogin.Text = "Memproses...";
            lblStatus.Text = "Sedang memproses login...";
            lblStatus.ForeColor = Color.Blue;

            try
            {
                string query = $@"
                    SELECT u.*, r.nama_role 
                    FROM users u 
                    LEFT JOIN roles r ON u.role_id = r.id 
                    WHERE u.username = '{username}' 
                    AND u.password = MD5('{password}') 
                    AND u.is_active = 1";

                DataTable dt = db.ExecuteQuery(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    SessionManager.CurrentUser = new User
                    {
                        Id = Convert.ToInt32(row["id"]),
                        Username = row["username"].ToString(),
                        NamaLengkap = row["nama_lengkap"].ToString(),
                        Email = row["email"]?.ToString() ?? "",
                        RoleId = Convert.ToInt32(row["role_id"]),
                        RoleName = row["nama_role"].ToString(),
                        IsActive = Convert.ToBoolean(row["is_active"]),
                        CreatedAt = Convert.ToDateTime(row["created_at"]),
                        UpdatedAt = Convert.ToDateTime(row["updated_at"])
                    };

                    LogAktivitas("Login", $"User {username} berhasil login");

                    lblStatus.Text = "Login berhasil! Mengalihkan...";
                    lblStatus.ForeColor = Color.Green;

                    Timer timer = new Timer();
                    timer.Interval = 100;
                    timer.Tick += (s, ev) =>
                    {
                        if (this.Opacity > 0)
                        {
                            this.Opacity -= 0.1;
                        }
                        else
                        {
                            timer.Stop();
                            this.Hide();
                            DashboardForm dashboard = new DashboardForm();
                            dashboard.ShowDialog();
                            this.Close();
                        }
                    };
                    timer.Start();
                }
                else
                {
                    string checkUserQuery = $"SELECT * FROM users WHERE username = '{username}'";
                    DataTable checkDt = db.ExecuteQuery(checkUserQuery);

                    if (checkDt.Rows.Count == 0)
                    {
                        lblStatus.Text = "Username tidak ditemukan!";
                        lblStatus.ForeColor = Color.Red;
                        txtUsername.Focus();
                        txtUsername.SelectAll();
                    }
                    else
                    {
                        lblStatus.Text = "Password salah!";
                        lblStatus.ForeColor = Color.Red;
                        txtPassword.Focus();
                        txtPassword.SelectAll();
                        txtPassword.Text = "";
                    }

                    LogAktivitas("Login Gagal", $"Percobaan login gagal untuk username: {username}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saat login: {ex.Message}",
                    "Error Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                lblStatus.Text = "Terjadi kesalahan sistem!";
                lblStatus.ForeColor = Color.Red;
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Login";
            }
        }

        private void LogAktivitas(string aktivitas, string detail)
        {
            try
            {
                int userId = SessionManager.CurrentUser?.Id ?? 0;
                string query = $@"
                    INSERT INTO log_aktivitas (user_id, aktivitas, detail, ip_address) 
                    VALUES ({userId}, '{aktivitas}', '{detail}', 'localhost')";
                db.ExecuteNonQuery(query);
            }
            catch { }
        }

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void panelHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void panelHeader_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Yakin ingin keluar dari aplikasi?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.UseSystemPasswordChar)
            {
                txtPassword.UseSystemPasswordChar = false;
                btnTogglePassword.Text = "👁️";
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
                btnTogglePassword.Text = "👁️‍🗨️";
            }
        }

        private void llblForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Hubungi administrator untuk mereset password Anda.\n\n" +
                "Email: admin@email.com",
                "Lupa Password",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void llblRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(
                "Pendaftaran akun baru hanya dapat dilakukan oleh administrator.\n\n" +
                "Hubungi bagian administrasi untuk membuat akun baru.",
                "Registrasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Yakin ingin keluar dari aplikasi?", "Konfirmasi",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}