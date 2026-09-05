using System;
using System.Data;
using System.Windows.Forms;
using SistemInformasiSurat.Database;
using SistemInformasiSurat.Helpers;

namespace SistemInformasiSurat.UserControls
{
    public partial class UserControlSuratMasukUser : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();

        public UserControlSuratMasukUser()
        {
            InitializeComponent();
            this.Padding = new Padding(20);
            LoadPesan();
        }

        private void LoadPesan()
        {
            try
            {
                int userId = SessionManager.CurrentUser.Id;

                string query = $@"
                    SELECT p.id, 
                           pengirim.username as pengirim_username,
                           pengirim.nama_lengkap as pengirim_nama,
                           p.judul, 
                           p.isi,
                           p.status,
                           DATE_FORMAT(p.created_at, '%d/%m/%Y %H:%i') as tanggal
                    FROM pesan p
                    LEFT JOIN users pengirim ON p.pengirim_id = pengirim.id
                    WHERE p.penerima_id = {userId}
                    AND p.is_archived = 0
                    ORDER BY p.created_at DESC";

                DataTable dt = db.ExecuteQuery(query);
                lvPesan.Items.Clear();

                int unreadCount = 0;
                foreach (DataRow row in dt.Rows)
                {
                    string status = row["status"].ToString();
                    if (status == "Belum Dibaca")
                        unreadCount++;

                    ListViewItem item = new ListViewItem(row["id"].ToString());
                    item.SubItems.Add(row["pengirim_nama"].ToString());
                    item.SubItems.Add(row["judul"].ToString());
                    item.SubItems.Add(status == "Belum Dibaca" ? "📩 Belum Dibaca" : "📖 Sudah Dibaca");
                    item.SubItems.Add(row["tanggal"].ToString());
                    item.Tag = row["isi"].ToString();

                    if (status == "Belum Dibaca")
                    {
                        item.BackColor = System.Drawing.Color.FromArgb(255, 255, 240);
                        item.Font = new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);
                    }

                    lvPesan.Items.Add(item);
                }

                lblJumlah.Text = $"Total Surat: {dt.Rows.Count} | Belum Dibaca: {unreadCount}";

                if (unreadCount > 0)
                {
                    lblNotifikasi.Text = $"📬 Anda memiliki {unreadCount} surat belum dibaca!";
                    lblNotifikasi.ForeColor = System.Drawing.Color.Red;
                    lblNotifikasi.Visible = true;
                }
                else
                {
                    lblNotifikasi.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaca_Click(object sender, EventArgs e)
        {
            if (lvPesan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih surat yang akan dibaca!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem selectedItem = lvPesan.SelectedItems[0];
            int pesanId = Convert.ToInt32(selectedItem.Text);
            string pengirim = selectedItem.SubItems[1].Text;
            string judul = selectedItem.SubItems[2].Text;
            string status = selectedItem.SubItems[3].Text;
            string isi = selectedItem.Tag?.ToString() ?? "";

            if (status.Contains("Belum Dibaca"))
            {
                string updateQuery = $"UPDATE pesan SET status = 'Sudah Dibaca' WHERE id = {pesanId}";
                db.ExecuteNonQuery(updateQuery);
            }

            MessageBox.Show(
                $"📨 Surat dari: {pengirim}\n\n" +
                $"📝 Judul: {judul}\n\n" +
                $"📄 Isi:\n{isi}",
                "Baca Surat",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            LoadPesan();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            if (lvPesan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Pilih surat yang akan dihapus!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Yakin ingin menghapus surat ini?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ListViewItem selectedItem = lvPesan.SelectedItems[0];
                int pesanId = Convert.ToInt32(selectedItem.Text);

                try
                {
                    string query = $"UPDATE pesan SET is_archived = 1 WHERE id = {pesanId}";
                    db.ExecuteNonQuery(query);
                    LoadPesan();
                    MessageBox.Show("Surat berhasil dihapus!", "Sukses",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPesan();
        }

        private void lvPesan_DoubleClick(object sender, EventArgs e)
        {
            if (lvPesan.SelectedItems.Count > 0)
            {
                btnBaca.PerformClick();
            }
        }

        private void UserControlSuratMasukUser_Load(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}