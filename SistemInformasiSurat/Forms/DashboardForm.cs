using System;
using System.Data;
using System.Windows.Forms;
using SistemInformasiSurat.Database;
using SistemInformasiSurat.Helpers;
using SistemInformasiSurat.UserControls;

namespace SistemInformasiSurat.Forms
{
    public partial class DashboardForm : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private Timer timer = new Timer();
        private UserControl currentControl = null;

        public DashboardForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
            LoadDashboard();
            SetupTimer();
        }

        private void SetupTimer()
        {
            timer.Interval = 30000;
            timer.Tick += (s, e) =>
            {
                int unreadCount = GetUnreadCount();
                if (unreadCount > 0)
                {
                    btnSuratMasuk.Text = $"📥 Surat Masuk ({unreadCount} baru)";
                    btnSuratMasuk.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
                }
                else
                {
                    btnSuratMasuk.Text = "📥 Surat Masuk";
                    btnSuratMasuk.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                }
            };
            timer.Start();
        }

        private void LoadDashboard()
        {
            try
            {
                lblWelcome.Text = "Halo, " + SessionManager.CurrentUser.NamaLengkap + "!";
                lblRole.Text = "Role: " + SessionManager.CurrentUser.RoleName;
                lblWaktu.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");

                bool isAdmin = SessionManager.IsAdmin;

                // Menu yang hanya untuk Admin
                btnSuratKeluarAdmin.Visible = isAdmin;
                btnRoleManagement.Visible = isAdmin;
                btnUserManagement.Visible = isAdmin;

                // Menu untuk semua user (termasuk Admin)
                btnKirimSurat.Visible = true;
                btnSuratMasuk.Visible = true;

                // Update notifikasi untuk Surat Masuk
                int unreadCount = GetUnreadCount();
                if (unreadCount > 0)
                {
                    btnSuratMasuk.Text = $"📥 Surat Masuk ({unreadCount} baru)";
                    btnSuratMasuk.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
                }
                else
                {
                    btnSuratMasuk.Text = "📥 Surat Masuk";
                    btnSuratMasuk.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
                }

                // Tampilkan default: Kirim Surat
                ShowControl("Kirim Surat");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetUnreadCount()
        {
            try
            {
                int userId = SessionManager.CurrentUser.Id;
                string query = $"SELECT COUNT(*) FROM pesan WHERE penerima_id = {userId} AND status = 'Belum Dibaca' AND is_archived = 0";
                object result = db.ExecuteScalar(query);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch
            {
                return 0;
            }
        }

        private void ShowControl(string menuText)
        {
            // Hapus control sebelumnya
            if (currentControl != null)
            {
                panelContentContainer.Controls.Remove(currentControl);
                currentControl.Dispose();
                currentControl = null;
            }

            // Buat control baru sesuai menu
            if (menuText.Contains("Kirim Surat"))
            {
                currentControl = new UserControlKirimSurat();
            }
            else if (menuText.Contains("Surat Masuk"))
            {
                currentControl = new UserControlSuratMasukUser();
            }
            else if (menuText.Contains("Surat Keluar"))
            {
                MessageBox.Show("Fitur Surat Keluar akan segera diimplementasikan.", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (menuText.Contains("Manajemen Role"))
            {
                currentControl = new UserControlRoleManagement();
            }
            else if (menuText.Contains("Manajemen User"))
            {
                currentControl = new UserControlUserManagement();
            }
            else
            {
                currentControl = new UserControlKirimSurat();
            }

            if (currentControl != null)
            {
                // Set Dock ke Fill agar mengisi seluruh panel container
                currentControl.Dock = DockStyle.Fill;

                // Tambahkan ke panel container
                panelContentContainer.Controls.Add(currentControl);
                panelContentContainer.Controls.SetChildIndex(currentControl, 0);
            }
        }

        // ========================================
        // SIDEBAR EVENT HANDLERS
        // ========================================

        private void btnKirimSurat_Click(object sender, EventArgs e)
        {
            ShowControl("Kirim Surat");
        }

        private void btnSuratMasuk_Click(object sender, EventArgs e)
        {
            ShowControl("Surat Masuk");
        }

        private void btnSuratKeluarAdmin_Click(object sender, EventArgs e)
        {
            ShowControl("Surat Keluar");
        }

        private void btnRoleManagement_Click(object sender, EventArgs e)
        {
            ShowControl("Manajemen Role");
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            ShowControl("Manajemen User");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Yakin ingin logout?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string logQuery = $@"
                        INSERT INTO log_aktivitas (user_id, aktivitas, detail) 
                        VALUES ({SessionManager.CurrentUser.Id}, 'Logout', 'User logout')";
                    db.ExecuteNonQuery(logQuery);
                }
                catch { }

                timer.Stop();
                SessionManager.Logout();
                this.Hide();
                LoginForm login = new LoginForm();
                login.ShowDialog();
                this.Close();
            }
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
    }
}