using System;
using System.Data;
using System.Windows.Forms;
using SistemInformasiSurat.Database;
using SistemInformasiSurat.Helpers;

namespace SistemInformasiSurat.UserControls
{
    public partial class UserControlRoleManagement : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private DataTable dtRoles;
        private int selectedId = 0;
        private bool isEdit = false;

        public UserControlRoleManagement()
        {
            InitializeComponent();
            this.Padding = new Padding(20);
            LoadRoles();
        }

        private void LoadRoles()
        {
            try
            {
                string query = "SELECT * FROM roles ORDER BY id";
                dtRoles = db.ExecuteQuery(query);

                // Bersihkan ListView
                lvRoles.Items.Clear();

                // Tambahkan data ke ListView
                foreach (DataRow row in dtRoles.Rows)
                {
                    ListViewItem item = new ListViewItem(row["id"].ToString());
                    item.SubItems.Add(row["nama_role"].ToString());
                    item.SubItems.Add(row["deskripsi"]?.ToString() ?? "-");
                    item.SubItems.Add(Convert.ToBoolean(row["is_active"]) ? "✅ Aktif" : "❌ Nonaktif");
                    item.SubItems.Add(Convert.ToDateTime(row["created_at"]).ToString("dd/MM/yyyy HH:mm"));

                    // Simpan ID di Tag
                    item.Tag = row["id"];

                    lvRoles.Items.Add(item);
                }

                lblJumlah.Text = $"Total Role: {dtRoles.Rows.Count}";
                ClearFields();
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
            gbForm.Enabled = true;
            gbForm.Visible = true;
            txtNamaRole.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan diedit!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ListViewItem selectedItem = lvRoles.SelectedItems[0];
                selectedId = Convert.ToInt32(selectedItem.Tag);
                isEdit = true;

                txtNamaRole.Text = selectedItem.SubItems[1].Text;
                txtDeskripsi.Text = selectedItem.SubItems[2].Text;
                chkActive.Checked = selectedItem.SubItems[3].Text.Contains("Aktif");

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
            if (lvRoles.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih data yang akan dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = lvRoles.SelectedItems[0];
            string roleName = selectedItem.SubItems[1].Text;
            int roleId = Convert.ToInt32(selectedItem.Tag);

            // Cek apakah role sedang digunakan
            string checkQuery = $"SELECT COUNT(*) FROM users WHERE role_id = {roleId}";
            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery));

            if (count > 0)
            {
                MessageBox.Show($"Role '{roleName}' sedang digunakan oleh {count} user!\nTidak bisa dihapus.",
                    "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show($"Yakin ingin menghapus role '{roleName}'?",
                "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    string query = $"DELETE FROM roles WHERE id = {roleId}";
                    db.ExecuteNonQuery(query);

                    LogAktivitas("Hapus Role", $"Menghapus role: {roleName}");
                    LoadRoles();
                    MessageBox.Show("Role berhasil dihapus!", "Sukses",
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
                    query = $@"
                        UPDATE roles SET 
                            nama_role = '{txtNamaRole.Text.Trim()}',
                            deskripsi = '{txtDeskripsi.Text.Trim()}',
                            is_active = {(chkActive.Checked ? 1 : 0)}
                        WHERE id = {selectedId}";
                }
                else
                {
                    query = $@"
                        INSERT INTO roles (nama_role, deskripsi, is_active) 
                        VALUES ('{txtNamaRole.Text.Trim()}', '{txtDeskripsi.Text.Trim()}', {(chkActive.Checked ? 1 : 0)})";
                }

                db.ExecuteNonQuery(query);

                LogAktivitas(isEdit ? "Edit Role" : "Tambah Role",
                    (isEdit ? "Mengedit" : "Menambah") + $" role: {txtNamaRole.Text}");

                LoadRoles();
                MessageBox.Show("Data berhasil disimpan!", "Sukses",
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
            if (string.IsNullOrEmpty(txtNamaRole.Text.Trim()))
            {
                MessageBox.Show("Nama role harus diisi!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaRole.Focus();
                return false;
            }

            // Cek duplikat
            string checkQuery = $@"
                SELECT COUNT(*) FROM roles 
                WHERE nama_role = '{txtNamaRole.Text.Trim()}' 
                AND id != {selectedId}";

            int count = Convert.ToInt32(db.ExecuteScalar(checkQuery));
            if (count > 0)
            {
                MessageBox.Show("Nama role sudah ada!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaRole.Focus();
                txtNamaRole.SelectAll();
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
            txtNamaRole.Clear();
            txtDeskripsi.Clear();
            chkActive.Checked = true;
            gbForm.Enabled = false;
            gbForm.Visible = false;
            btnSimpan.Text = "Simpan";
            selectedId = 0;
            isEdit = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
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

        private void lvRoles_DoubleClick(object sender, EventArgs e)
        {
            if (lvRoles.SelectedItems.Count > 0)
            {
                btnEdit.PerformClick();
            }
        }

        private void UserControlRoleManagement_Load(object sender, EventArgs e)
        {

        }

        private void lblJumlah_Click(object sender, EventArgs e)
        {

        }
    }
}