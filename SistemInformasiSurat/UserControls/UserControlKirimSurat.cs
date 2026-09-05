using System;
using System.Data;
using System.Windows.Forms;
using SistemInformasiSurat.Database;
using SistemInformasiSurat.Helpers;

namespace SistemInformasiSurat.UserControls
{
    public partial class UserControlKirimSurat : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private DataTable dtUsers;
        private bool isAdmin = SessionManager.IsAdmin;

        public UserControlKirimSurat()
        {
            InitializeComponent();
            this.Padding = new Padding(20);
            LoadUsers();
            LoadRoles();
            SetAdminControls();
        }

        private void SetAdminControls()
        {
            if (isAdmin)
            {
                panelAdmin.Visible = true;
                lblAdminInfo.Visible = true;
                lblTargetInfo.Visible = true;
                cmbTargetType.Visible = true;
                lblTargetType.Visible = true;
            }
            else
            {
                panelAdmin.Visible = false;
                lblAdminInfo.Visible = false;
                lblTargetInfo.Visible = false;
                cmbTargetType.Visible = false;
                lblTargetType.Visible = false;
            }
        }

        private void LoadUsers()
        {
            try
            {
                string query = $@"
                    SELECT id, username, nama_lengkap, role_id, 
                           (SELECT nama_role FROM roles WHERE id = users.role_id) as nama_role
                    FROM users 
                    WHERE id != {SessionManager.CurrentUser.Id} 
                    AND is_active = 1
                    ORDER BY nama_lengkap";

                dtUsers = db.ExecuteQuery(query);
                cmbPenerima.DataSource = dtUsers;
                cmbPenerima.DisplayMember = "nama_lengkap";
                cmbPenerima.ValueMember = "id";
                cmbPenerima.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoles()
        {
            try
            {
                string query = "SELECT * FROM roles WHERE is_active = 1 ORDER BY nama_role";
                DataTable dt = db.ExecuteQuery(query);

                cmbTargetRole.DataSource = dt;
                cmbTargetRole.DisplayMember = "nama_role";
                cmbTargetRole.ValueMember = "id";
                cmbTargetRole.SelectedIndex = -1;

                DataRow row = dt.NewRow();
                row["id"] = -1;
                row["nama_role"] = "📢 Semua User";
                dt.Rows.InsertAt(row, 0);
                cmbTargetRole.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbTargetType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTargetType.SelectedItem == null) return;

            string selected = cmbTargetType.SelectedItem.ToString();

            if (selected == "Pilih User Spesifik")
            {
                cmbPenerima.Enabled = true;
                cmbPenerima.Visible = true;
                lblPenerima.Visible = true;
                lblUserInfo.Visible = true;
                cmbTargetRole.Enabled = false;
                cmbTargetRole.Visible = false;
                lblTargetRole.Visible = false;
            }
            else if (selected == "Kirim ke Role")
            {
                cmbPenerima.Enabled = false;
                cmbPenerima.Visible = false;
                lblPenerima.Visible = false;
                lblUserInfo.Visible = false;
                cmbTargetRole.Enabled = true;
                cmbTargetRole.Visible = true;
                lblTargetRole.Visible = true;
            }
            else if (selected == "Kirim ke Semua User")
            {
                cmbPenerima.Enabled = false;
                cmbPenerima.Visible = false;
                lblPenerima.Visible = false;
                lblUserInfo.Visible = false;
                cmbTargetRole.Enabled = false;
                cmbTargetRole.Visible = false;
                lblTargetRole.Visible = false;
            }
        }

        private void cmbPenerima_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPenerima.SelectedIndex != -1)
            {
                DataRowView row = (DataRowView)cmbPenerima.SelectedItem;
                lblUserInfo.Text = $"📧 {row["nama_lengkap"]} ({row["username"]}) - {row["nama_role"]}";
            }
            else
            {
                lblUserInfo.Text = "";
            }
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                if (isAdmin)
                {
                    KirimAdmin();
                }
                else
                {
                    KirimUser();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void KirimUser()
        {
            int penerimaId = Convert.ToInt32(cmbPenerima.SelectedValue);
            string judul = txtJudul.Text.Trim();
            string isi = txtIsi.Text.Trim();

            string query = $@"
                INSERT INTO pesan (pengirim_id, penerima_id, judul, isi, status) 
                VALUES ({SessionManager.CurrentUser.Id}, {penerimaId}, '{judul}', '{isi}', 'Belum Dibaca')";

            db.ExecuteNonQuery(query);

            MessageBox.Show("✅ Surat berhasil dikirim!", "Sukses",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            ResetForm();
        }

        private void KirimAdmin()
        {
            string selectedType = cmbTargetType.SelectedItem?.ToString();
            string judul = txtJudul.Text.Trim();
            string isi = txtIsi.Text.Trim();
            int adminId = SessionManager.CurrentUser.Id;

            if (selectedType == "Pilih User Spesifik")
            {
                int penerimaId = Convert.ToInt32(cmbPenerima.SelectedValue);
                string query = $@"
                    INSERT INTO pesan (pengirim_id, penerima_id, judul, isi, status, is_pengumuman) 
                    VALUES ({adminId}, {penerimaId}, '{judul}', '{isi}', 'Belum Dibaca', 1)";
                db.ExecuteNonQuery(query);
                MessageBox.Show($"✅ Surat berhasil dikirim!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedType == "Kirim ke Role")
            {
                int roleId = Convert.ToInt32(cmbTargetRole.SelectedValue);
                string getUsersQuery = $"SELECT id FROM users WHERE role_id = {roleId} AND is_active = 1";
                DataTable dtUsers = db.ExecuteQuery(getUsersQuery);

                if (dtUsers.Rows.Count == 0)
                {
                    MessageBox.Show($"Tidak ada user dengan role ini!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int sentCount = 0;
                foreach (DataRow row in dtUsers.Rows)
                {
                    int penerimaId = Convert.ToInt32(row["id"]);
                    string query = $@"
                        INSERT INTO pesan (pengirim_id, penerima_id, judul, isi, status, is_pengumuman) 
                        VALUES ({adminId}, {penerimaId}, '{judul}', '{isi}', 'Belum Dibaca', 1)";
                    db.ExecuteNonQuery(query);
                    sentCount++;
                }

                MessageBox.Show($"✅ Surat berhasil dikirim ke {sentCount} user!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (selectedType == "Kirim ke Semua User")
            {
                string getUsersQuery = $"SELECT id FROM users WHERE id != {adminId} AND is_active = 1";
                DataTable dtUsers = db.ExecuteQuery(getUsersQuery);

                if (dtUsers.Rows.Count == 0)
                {
                    MessageBox.Show("Tidak ada user lain yang aktif!", "Info",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int sentCount = 0;
                foreach (DataRow row in dtUsers.Rows)
                {
                    int penerimaId = Convert.ToInt32(row["id"]);
                    string query = $@"
                        INSERT INTO pesan (pengirim_id, penerima_id, judul, isi, status, is_pengumuman) 
                        VALUES ({adminId}, {penerimaId}, '{judul}', '{isi}', 'Belum Dibaca', 1)";
                    db.ExecuteNonQuery(query);
                    sentCount++;
                }

                MessageBox.Show($"✅ Surat berhasil dikirim ke {sentCount} user!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ResetForm();
        }

        private bool ValidateFields()
        {
            if (isAdmin)
            {
                string selectedType = cmbTargetType.SelectedItem?.ToString();

                if (selectedType == "Pilih User Spesifik" && cmbPenerima.SelectedIndex == -1)
                {
                    MessageBox.Show("Pilih penerima surat!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPenerima.Focus();
                    return false;
                }

                if (selectedType == "Kirim ke Role" && cmbTargetRole.SelectedIndex == -1)
                {
                    MessageBox.Show("Pilih role yang akan dikirimi!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbTargetRole.Focus();
                    return false;
                }
            }
            else
            {
                if (cmbPenerima.SelectedIndex == -1)
                {
                    MessageBox.Show("Pilih penerima surat!", "Peringatan",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbPenerima.Focus();
                    return false;
                }
            }

            if (string.IsNullOrEmpty(txtJudul.Text.Trim()))
            {
                MessageBox.Show("Judul surat harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtJudul.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtIsi.Text.Trim()))
            {
                MessageBox.Show("Isi surat harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIsi.Focus();
                return false;
            }

            return true;
        }

        private void ResetForm()
        {
            cmbPenerima.SelectedIndex = -1;
            txtJudul.Clear();
            txtIsi.Clear();
            lblUserInfo.Text = "";

            if (isAdmin)
            {
                cmbTargetType.SelectedIndex = 0;
                cmbTargetRole.SelectedIndex = 0;
            }

            cmbPenerima.Focus();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void txtIsi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnKirim.PerformClick();
            }
        }

        private void UserControlKirimSurat_Load(object sender, EventArgs e)
        {

        }
    }
}