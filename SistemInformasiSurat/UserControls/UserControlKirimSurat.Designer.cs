namespace SistemInformasiSurat.UserControls
{
    partial class UserControlKirimSurat
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Label lblAdminInfo;
        private System.Windows.Forms.Label lblTargetInfo;
        private System.Windows.Forms.Label lblTargetType;
        private System.Windows.Forms.ComboBox cmbTargetType;
        private System.Windows.Forms.Label lblTargetRole;
        private System.Windows.Forms.ComboBox cmbTargetRole;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Label lblPenerima;
        private System.Windows.Forms.ComboBox cmbPenerima;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.TextBox txtJudul;
        private System.Windows.Forms.Label lblIsi;
        private System.Windows.Forms.TextBox txtIsi;
        private System.Windows.Forms.Button btnKirim;
        private System.Windows.Forms.Button btnBatal;

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
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.lblTargetInfo = new System.Windows.Forms.Label();
            this.lblTargetType = new System.Windows.Forms.Label();
            this.cmbTargetType = new System.Windows.Forms.ComboBox();
            this.lblTargetRole = new System.Windows.Forms.Label();
            this.cmbTargetRole = new System.Windows.Forms.ComboBox();
            this.lblAdminInfo = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.lblPenerima = new System.Windows.Forms.Label();
            this.cmbPenerima = new System.Windows.Forms.ComboBox();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblJudul = new System.Windows.Forms.Label();
            this.txtJudul = new System.Windows.Forms.TextBox();
            this.lblIsi = new System.Windows.Forms.Label();
            this.txtIsi = new System.Windows.Forms.TextBox();
            this.btnKirim = new System.Windows.Forms.Button();
            this.btnBatal = new System.Windows.Forms.Button();
            this.panelAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAdmin
            // 
            this.panelAdmin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelAdmin.Controls.Add(this.lblTargetInfo);
            this.panelAdmin.Controls.Add(this.lblTargetType);
            this.panelAdmin.Controls.Add(this.cmbTargetType);
            this.panelAdmin.Controls.Add(this.lblTargetRole);
            this.panelAdmin.Controls.Add(this.cmbTargetRole);
            this.panelAdmin.Controls.Add(this.lblAdminInfo);
            this.panelAdmin.Location = new System.Drawing.Point(343, 18);
            this.panelAdmin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Size = new System.Drawing.Size(1041, 146);
            this.panelAdmin.TabIndex = 0;
            this.panelAdmin.Visible = false;
            // 
            // lblTargetInfo
            // 
            this.lblTargetInfo.AutoSize = true;
            this.lblTargetInfo.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblTargetInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblTargetInfo.Location = new System.Drawing.Point(13, 47);
            this.lblTargetInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetInfo.Name = "lblTargetInfo";
            this.lblTargetInfo.Size = new System.Drawing.Size(369, 21);
            this.lblTargetInfo.TabIndex = 1;
            this.lblTargetInfo.Text = "💡 Pilih target: User spesifik, Role, atau Semua User";
            // 
            // lblTargetType
            // 
            this.lblTargetType.AutoSize = true;
            this.lblTargetType.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTargetType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTargetType.Location = new System.Drawing.Point(13, 87);
            this.lblTargetType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetType.Name = "lblTargetType";
            this.lblTargetType.Size = new System.Drawing.Size(121, 25);
            this.lblTargetType.TabIndex = 2;
            this.lblTargetType.Text = "Target Kirim:";
            // 
            // cmbTargetType
            // 
            this.cmbTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetType.Items.AddRange(new object[] {
            "Pilih User Spesifik",
            "Kirim ke Role",
            "Kirim ke Semua User"});
            this.cmbTargetType.Location = new System.Drawing.Point(141, 83);
            this.cmbTargetType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTargetType.Name = "cmbTargetType";
            this.cmbTargetType.Size = new System.Drawing.Size(230, 28);
            this.cmbTargetType.TabIndex = 3;
            this.cmbTargetType.SelectedIndexChanged += new System.EventHandler(this.cmbTargetType_SelectedIndexChanged);
            // 
            // lblTargetRole
            // 
            this.lblTargetRole.AutoSize = true;
            this.lblTargetRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTargetRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTargetRole.Location = new System.Drawing.Point(399, 87);
            this.lblTargetRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTargetRole.Name = "lblTargetRole";
            this.lblTargetRole.Size = new System.Drawing.Size(55, 25);
            this.lblTargetRole.TabIndex = 4;
            this.lblTargetRole.Text = "Role:";
            this.lblTargetRole.Visible = false;
            // 
            // cmbTargetRole
            // 
            this.cmbTargetRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTargetRole.Location = new System.Drawing.Point(455, 83);
            this.cmbTargetRole.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbTargetRole.Name = "cmbTargetRole";
            this.cmbTargetRole.Size = new System.Drawing.Size(230, 28);
            this.cmbTargetRole.TabIndex = 5;
            this.cmbTargetRole.Visible = false;
            // 
            // lblAdminInfo
            // 
            this.lblAdminInfo.AutoSize = true;
            this.lblAdminInfo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAdminInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAdminInfo.Location = new System.Drawing.Point(13, 16);
            this.lblAdminInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAdminInfo.Name = "lblAdminInfo";
            this.lblAdminInfo.Size = new System.Drawing.Size(398, 28);
            this.lblAdminInfo.TabIndex = 0;
            this.lblAdminInfo.Text = "👑 Admin: Pilih target pengiriman surat:";
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblInfo.Location = new System.Drawing.Point(343, 185);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(422, 25);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "💡 Pilih penerima, tulis judul dan isi surat, lalu kirim.";
            // 
            // lblPenerima
            // 
            this.lblPenerima.AutoSize = true;
            this.lblPenerima.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPenerima.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblPenerima.Location = new System.Drawing.Point(343, 225);
            this.lblPenerima.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPenerima.Name = "lblPenerima";
            this.lblPenerima.Size = new System.Drawing.Size(139, 28);
            this.lblPenerima.TabIndex = 2;
            this.lblPenerima.Text = "📌 Penerima:";
            // 
            // cmbPenerima
            // 
            this.cmbPenerima.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPenerima.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbPenerima.Location = new System.Drawing.Point(343, 258);
            this.cmbPenerima.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPenerima.Name = "cmbPenerima";
            this.cmbPenerima.Size = new System.Drawing.Size(513, 36);
            this.cmbPenerima.TabIndex = 3;
            this.cmbPenerima.SelectedIndexChanged += new System.EventHandler(this.cmbPenerima_SelectedIndexChanged);
            // 
            // lblUserInfo
            // 
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.Gray;
            this.lblUserInfo.Location = new System.Drawing.Point(26, 307);
            this.lblUserInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(0, 25);
            this.lblUserInfo.TabIndex = 4;
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblJudul.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblJudul.Location = new System.Drawing.Point(343, 351);
            this.lblJudul.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(102, 28);
            this.lblJudul.TabIndex = 5;
            this.lblJudul.Text = "📝 Judul:";
            // 
            // txtJudul
            // 
            this.txtJudul.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtJudul.Location = new System.Drawing.Point(343, 385);
            this.txtJudul.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJudul.Name = "txtJudul";
            this.txtJudul.Size = new System.Drawing.Size(1040, 34);
            this.txtJudul.TabIndex = 6;
            // 
            // lblIsi
            // 
            this.lblIsi.AutoSize = true;
            this.lblIsi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblIsi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblIsi.Location = new System.Drawing.Point(343, 438);
            this.lblIsi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIsi.Name = "lblIsi";
            this.lblIsi.Size = new System.Drawing.Size(128, 28);
            this.lblIsi.TabIndex = 7;
            this.lblIsi.Text = "📄 Isi Surat:";
            // 
            // txtIsi
            // 
            this.txtIsi.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtIsi.Location = new System.Drawing.Point(343, 471);
            this.txtIsi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIsi.Multiline = true;
            this.txtIsi.Name = "txtIsi";
            this.txtIsi.Size = new System.Drawing.Size(1040, 199);
            this.txtIsi.TabIndex = 8;
            this.txtIsi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIsi_KeyDown);
            // 
            // btnKirim
            // 
            this.btnKirim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnKirim.FlatAppearance.BorderSize = 0;
            this.btnKirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKirim.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnKirim.ForeColor = System.Drawing.Color.White;
            this.btnKirim.Location = new System.Drawing.Point(1114, 685);
            this.btnKirim.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnKirim.Name = "btnKirim";
            this.btnKirim.Size = new System.Drawing.Size(129, 47);
            this.btnKirim.TabIndex = 9;
            this.btnKirim.Text = "📤 Kirim";
            this.btnKirim.UseVisualStyleBackColor = false;
            this.btnKirim.Click += new System.EventHandler(this.btnKirim_Click);
            // 
            // btnBatal
            // 
            this.btnBatal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnBatal.FlatAppearance.BorderSize = 0;
            this.btnBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBatal.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnBatal.ForeColor = System.Drawing.Color.White;
            this.btnBatal.Location = new System.Drawing.Point(1256, 685);
            this.btnBatal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBatal.Name = "btnBatal";
            this.btnBatal.Size = new System.Drawing.Size(129, 47);
            this.btnBatal.TabIndex = 10;
            this.btnBatal.Text = "❌ Batal";
            this.btnBatal.UseVisualStyleBackColor = false;
            this.btnBatal.Click += new System.EventHandler(this.btnBatal_Click);
            // 
            // UserControlKirimSurat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnBatal);
            this.Controls.Add(this.btnKirim);
            this.Controls.Add(this.txtIsi);
            this.Controls.Add(this.lblIsi);
            this.Controls.Add(this.txtJudul);
            this.Controls.Add(this.lblJudul);
            this.Controls.Add(this.lblUserInfo);
            this.Controls.Add(this.cmbPenerima);
            this.Controls.Add(this.lblPenerima);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.panelAdmin);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UserControlKirimSurat";
            this.Size = new System.Drawing.Size(1542, 733);
            this.Load += new System.EventHandler(this.UserControlKirimSurat_Load);
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}