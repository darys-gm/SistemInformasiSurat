using System;
using System.Data;
using System.Windows.Forms;
using SistemInformasiSurat.Database;
using SistemInformasiSurat.Helpers;

namespace SistemInformasiSurat.UserControls
{
    public partial class UserControlUserManagement : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private DataTable dtUsers;
        private int selectedId = 0;
        private bool isEdit = false;

        public UserControlUserManagement()
        {
            InitializeComponent();
            this.Padding = new Padding(20);
            LoadUsers();
            LoadRoles();
        }

        private void LoadUsers()
        {
            try
            {
                string query = @"
                    SELECT u.id, u.username, u.nama_lengkap, u.email, 
                           u.role_id, r.nama_role, u.is_active, u.created_at
                    FROM users u 
                    LEFT JOIN roles r ON u.role_id = r.id 
                    ORDER BY u.id";

                dtUsers = db.ExecuteQuery(query);
                lvUsers.Items.Clear();

                foreach (DataRow row in dtUsers.Rows)
                {
                    ListViewItem item = new ListViewItem(row["id"].ToString());
                    item.SubItems.Add(row["username"].ToString());
                    item.SubItems.Add(row["nama_lengkap"].ToString());
                    item.SubItems.Add(row["email"]?.ToString() ?? "-");
                    item.SubItems.Add(row["nama_role"]?.ToString() ?? "-");
                    item.SubItems.Add(Convert.ToBoolean(row["is_active"]) ? "✅ Aktif" : "❌ Nonaktif");
                    item.SubItems.Add(Convert.ToDateTime(row["created_at"]).ToString("dd/MM/yyyy"));
                    item.Tag = row["id"];
                    lvUsers.Items.Add(item);
                }

                lblJumlah.Text = $"Total User: {dtUsers.Rows.Count}";
                ClearFields();
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

                cmbRole.DataSource = dt;
                cmbRole.DisplayMember = "nama_role";
                cmbRole.ValueMember = "id";
                cmbRole.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading roles: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            ClearFields();
            isEdit = false;
            selectedId = 0;
            btnSimpan.Text = "Simpan";
            txtPassword.Enabled = true;
            txtPassword.Text = "";
            lblPassword.Text = "Password:";
            gbForm.Enabled = true;
            gbForm.Visible = true;
            txtUsername.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ListViewItem selectedItem = lvUsers.SelectedItems[0];
                selectedId = Convert.ToInt32(selectedItem.Tag);
                isEdit = true;

                txtUsername.Text = selectedItem.SubItems[1].Text;
                txtNamaLengkap.Text = selectedItem.SubItems[2].Text;
                txtEmail.Text = selectedItem.SubItems[3].Text;

                string roleName = selectedItem.SubItems[4].Text;
                foreach (DataRowView item in cmbRole.Items)
                {
                    if (item["nama_role"].ToString() == roleName)
                    {
                        cmbRole.SelectedItem = item;
                        break;
                    }
                }

                chkActive.Checked = selectedItem.SubItems[5].Text.Contains("Aktif");

                txtPassword.Text = "";
                txtPassword.Enabled = false;
                lblPassword.Text = "Password (kosongkan jika tidak diubah)";

                btnSimpan.Text = "Update";
                gbForm.Enabled = true;
                gbForm.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = lvUsers.SelectedItems[0];
            string username = selectedItem.SubItems[1].Text;
            int userId = Convert.ToInt32(selectedItem.Tag);

            if (userId == SessionManager.CurrentUser.Id)
            {
                MessageBox.Show("Tidak bisa menghapus akun sendiri!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Yakin ingin menghapus user '{username}'?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM users WHERE id = {userId}";
                    db.ExecuteNonQuery(query);

                    LogAktivitas("Hapus User", $"Menghapus user: {username}");
                    LoadUsers();
                    LoadRoles();
                    MessageBox.Show("User berhasil dihapus!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (lvUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih user yang akan direset passwordnya!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = lvUsers.SelectedItems[0];
            string username = selectedItem.SubItems[1].Text;
            int userId = Convert.ToInt32(selectedItem.Tag);

            DialogResult result = MessageBox.Show($"Reset password user '{username}' menjadi '123456'?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = $"UPDATE users SET password = MD5('123456') WHERE id = {userId}";
                    db.ExecuteNonQuery(query);

                    LogAktivitas("Reset Password", $"Reset password user: {username}");
                    MessageBox.Show("Password berhasil direset!\nPassword baru: 123456", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (!ValidateFields())
                return;

            try
            {
                string query;
                if (isEdit)
                {
                    string passwordPart = "";
                    if (!string.IsNullOrEmpty(txtPassword.Text.Trim()))
                    {
                        passwordPart = $", password = MD5('{txtPassword.Text.Trim()}')";
                    }

                    query = $@"
                        UPDATE users SET 
                            username = '{txtUsername.Text.Trim()}',
                            nama_lengkap = '{txtNamaLengkap.Text.Trim()}',
                            email = '{txtEmail.Text.Trim()}',
                            role_id = {cmbRole.SelectedValue},
                            is_active = {(chkActive.Checked ? 1 : 0)}
                            {passwordPart}
                        WHERE id = {selectedId}";
                }
                else
                {
                    query = $@"
                        INSERT INTO users (username, password, nama_lengkap, email, role_id, is_active) 
                        VALUES (
                            '{txtUsername.Text.Trim()}', 
                            MD5('{txtPassword.Text.Trim()}'), 
                            '{txtNamaLengkap.Text.Trim()}', 
                            '{txtEmail.Text.Trim()}', 
                            {cmbRole.SelectedValue}, 
                            {(chkActive.Checked ? 1 : 0)}
                        )";
                }

                db.ExecuteNonQuery(query);

                LogAktivitas(isEdit ? "Edit User" : "Tambah User",
                    (isEdit ? "Mengedit" : "Menambah") + $" user: {txtUsername.Text}");

                LoadUsers();
                LoadRoles();
                MessageBox.Show("Data user berhasil disimpan!", "Sukses",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateFields()
        {
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                MessageBox.Show("Username harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtNamaLengkap.Text.Trim()))
            {
                MessageBox.Show("Nama lengkap harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaLengkap.Focus();
                return false;
            }

            string checkQuery = $@"
                SELECT COUNT(*) FROM users 
                WHERE username = '{txtUsername.Text.Trim()}' 
                AND id != {selectedId}";

            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery));
            if (count > 0)
            {
                MessageBox.Show("Username sudah digunakan!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                txtUsername.SelectAll();
                return false;
            }

            if (!isEdit && string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                MessageBox.Show("Password harus diisi untuk user baru!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return false;
            }

            if (cmbRole.SelectedIndex == -1 || cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Pilih role untuk user!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRole.Focus();
                return false;
            }

            return true;
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtUsername.Clear();
            txtNamaLengkap.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            txtPassword.Enabled = true;
            lblPassword.Text = "Password:";
            cmbRole.SelectedIndex = -1;
            chkActive.Checked = true;
            gbForm.Enabled = false;
            gbForm.Visible = false;
            btnSimpan.Text = "Simpan";
            selectedId = 0;
            isEdit = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUsers();
            LoadRoles();
        }

        private void LogAktivitas(string aktivitas, string detail)
        {
            try
            {
                int userId = SessionManager.CurrentUser?.Id ?? 0;
                string query = $@"
                    INSERT INTO log_aktivitas (user_id, aktivitas, detail) 
                    VALUES ({userId}, '{aktivitas}', '{detail}')";
                db.ExecuteNonQuery(query);
            }
            catch { }
        }

        private void gbForm_Enter(object sender, EventArgs e)
        {

        }
    }
}