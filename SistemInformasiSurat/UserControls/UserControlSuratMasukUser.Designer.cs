namespace SistemInformasiSurat.UserControls
{
    partial class UserControlSuratMasukUser
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Button btnBaca;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListView lvPesan;
        private System.Windows.Forms.ColumnHeader colId;
        private System.Windows.Forms.ColumnHeader colPengirim;
        private System.Windows.Forms.ColumnHeader colJudul;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colTanggal;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Label lblJumlah;
        private System.Windows.Forms.Label lblNotifikasi;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelHeader = new System.Windows.Forms.Panel();
            this.btnBaca = new System.Windows.Forms.Button();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lvPesan = new System.Windows.Forms.ListView();
            this.colId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPengirim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colJudul = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTanggal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelBottom = new System.Windows.Forms.Panel();
            this.lblNotifikasi = new System.Windows.Forms.Label();
            this.lblJumlah = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.panelHeader.Controls.Add(this.btnBaca);
            this.panelHeader.Controls.Add(this.btnHapus);
            this.panelHeader.Controls.Add(this.btnRefresh);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1548, 67);
            this.panelHeader.TabIndex = 0;
            this.panelHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelHeader_Paint);
            // 
            // btnBaca
            // 
            this.btnBaca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnBaca.FlatAppearance.BorderSize = 0;
            this.btnBaca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaca.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBaca.ForeColor = System.Drawing.Color.White;
            this.btnBaca.Location = new System.Drawing.Point(404, 13);
            this.btnBaca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaca.Name = "btnBaca";
            this.btnBaca.Size = new System.Drawing.Size(103, 40);
            this.btnBaca.TabIndex = 0;
            this.btnBaca.Text = "📖 Baca";
            this.btnBaca.UseVisualStyleBackColor = false;
            this.btnBaca.Click += new System.EventHandler(this.btnBaca_Click);
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnHapus.FlatAppearance.BorderSize = 0;
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHapus.ForeColor = System.Drawing.Color.White;
            this.btnHapus.Location = new System.Drawing.Point(515, 13);
            this.btnHapus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(103, 40);
            this.btnHapus.TabIndex = 1;
            this.btnHapus.Text = "🗑️ Hapus";
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(626, 13);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(84, 40);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "🔄";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lvPesan
            // 
            this.lvPesan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colId,
            this.colPengirim,
            this.colJudul,
            this.colStatus,
            this.colTanggal});
            this.lvPesan.FullRowSelect = true;
            this.lvPesan.GridLines = true;
            this.lvPesan.HideSelection = false;
            this.lvPesan.Location = new System.Drawing.Point(362, 129);
            this.lvPesan.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lvPesan.Name = "lvPesan";
            this.lvPesan.Size = new System.Drawing.Size(1066, 572);
            this.lvPesan.TabIndex = 1;
            this.lvPesan.UseCompatibleStateImageBehavior = false;
            this.lvPesan.View = System.Windows.Forms.View.Details;
            this.lvPesan.DoubleClick += new System.EventHandler(this.lvPesan_DoubleClick);
            // 
            // colId
            // 
            this.colId.Text = "ID";
            this.colId.Width = 40;
            // 
            // colPengirim
            // 
            this.colPengirim.Text = "Pengirim";
            this.colPengirim.Width = 150;
            // 
            // colJudul
            // 
            this.colJudul.Text = "Judul";
            this.colJudul.Width = 300;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 130;
            // 
            // colTanggal
            // 
            this.colTanggal.Text = "Tanggal Diterima";
            this.colTanggal.Width = 150;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.lblNotifikasi);
            this.panelBottom.Controls.Add(this.lblJumlah);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 666);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1548, 67);
            this.panelBottom.TabIndex = 2;
            // 
            // lblNotifikasi
            // 
            this.lblNotifikasi.AutoSize = true;
            this.lblNotifikasi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblNotifikasi.ForeColor = System.Drawing.Color.Red;
            this.lblNotifikasi.Location = new System.Drawing.Point(321, 21);
            this.lblNotifikasi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNotifikasi.Name = "lblNotifikasi";
            this.lblNotifikasi.Size = new System.Drawing.Size(0, 28);
            this.lblNotifikasi.TabIndex = 1;
            this.lblNotifikasi.Visible = false;
            // 
            // lblJumlah
            // 
            this.lblJumlah.AutoSize = true;
            this.lblJumlah.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblJumlah.ForeColor = System.Drawing.Color.Gray;
            this.lblJumlah.Location = new System.Drawing.Point(357, 21);
            this.lblJumlah.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJumlah.Name = "lblJumlah";
            this.lblJumlah.Size = new System.Drawing.Size(311, 28);
            this.lblJumlah.TabIndex = 0;
            this.lblJumlah.Text = "Total Surat: 0 | Belum Dibaca: 0";
            // 
            // UserControlSuratMasukUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lvPesan);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControlSuratMasukUser";
            this.Size = new System.Drawing.Size(1548, 733);
            this.panelHeader.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}