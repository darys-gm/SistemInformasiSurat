namespace SistemInformasiSurat.Forms
{
    partial class DashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        // Deklarasi semua kontrol
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblWaktu;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelContentContainer; // Panel Container untuk konten
        private System.Windows.Forms.Panel panelSidebarHeader;
        private System.Windows.Forms.Label lblSidebarTitle;

        // Menu Admin (hanya untuk Admin)
        private System.Windows.Forms.Button btnSuratKeluarAdmin;
        private System.Windows.Forms.Button btnRoleManagement;
        private System.Windows.Forms.Button btnUserManagement;

        // Menu untuk Semua User (Admin + User biasa)
        private System.Windows.Forms.Button btnKirimSurat;
        private System.Windows.Forms.Button btnSuratMasuk;

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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblWaktu = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelSidebarHeader = new System.Windows.Forms.Panel();
            this.lblSidebarTitle = new System.Windows.Forms.Label();
            this.btnKirimSurat = new System.Windows.Forms.Button();
            this.btnSuratMasuk = new System.Windows.Forms.Button();
            this.btnSuratKeluarAdmin = new System.Windows.Forms.Button();
            this.btnRoleManagement = new System.Windows.Forms.Button();
            this.btnUserManagement = new System.Windows.Forms.Button();
            this.panelContentContainer = new System.Windows.Forms.Panel(); // Panel Container

            this.panelHeader.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelSidebar.SuspendLayout();
            this.panelSidebarHeader.SuspendLayout();
            this.SuspendLayout();

            // ========================================
            // PANEL HEADER
            // ========================================
            this.panelHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelHeader.Controls.Add(this.lblTitle);
            this.panelHeader.Controls.Add(this.lblWelcome);
            this.panelHeader.Controls.Add(this.lblRole);
            this.panelHeader.Controls.Add(this.lblWaktu);
            this.panelHeader.Controls.Add(this.btnLogout);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.panelHeader.Size = new System.Drawing.Size(1200, 75);
            this.panelHeader.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(309, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📊 Sistem Informasi Surat";

            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.ForeColor = System.Drawing.Color.FromArgb(200, 200, 200);
            this.lblWelcome.Location = new System.Drawing.Point(15, 44);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(105, 20);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Halo, Admin!";

            // lblRole
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblRole.Location = new System.Drawing.Point(126, 45);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(68, 19);
            this.lblRole.TabIndex = 2;
            this.lblRole.Text = "Role: Admin";

            // lblWaktu
            this.lblWaktu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWaktu.AutoSize = true;
            this.lblWaktu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblWaktu.ForeColor = System.Drawing.Color.FromArgb(180, 180, 180);
            this.lblWaktu.Location = new System.Drawing.Point(900, 12);
            this.lblWaktu.Name = "lblWaktu";
            this.lblWaktu.Size = new System.Drawing.Size(154, 15);
            this.lblWaktu.TabIndex = 3;
            this.lblWaktu.Text = "Senin, 01 Januari 2026 00:00";

            // btnLogout
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Location = new System.Drawing.Point(1100, 18);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(85, 35);
            this.btnLogout.TabIndex = 4;
            this.btnLogout.Text = "🚪 Logout";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // ========================================
            // PANEL MAIN (Container untuk Sidebar + Content)
            // ========================================
            this.panelMain.Controls.Add(this.panelSidebar);
            this.panelMain.Controls.Add(this.panelContentContainer);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 75);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1200, 605);
            this.panelMain.TabIndex = 5;

            // ========================================
            // PANEL SIDEBAR
            // ========================================
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(44, 62, 80);
            this.panelSidebar.Controls.Add(this.panelSidebarHeader);
            this.panelSidebar.Controls.Add(this.btnKirimSurat);
            this.panelSidebar.Controls.Add(this.btnSuratMasuk);
            this.panelSidebar.Controls.Add(this.btnSuratKeluarAdmin);
            this.panelSidebar.Controls.Add(this.btnRoleManagement);
            this.panelSidebar.Controls.Add(this.btnUserManagement);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(220, 605);
            this.panelSidebar.TabIndex = 0;

            // ========================================
            // PANEL SIDEBAR HEADER
            // ========================================
            this.panelSidebarHeader.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelSidebarHeader.Controls.Add(this.lblSidebarTitle);
            this.panelSidebarHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSidebarHeader.Location = new System.Drawing.Point(0, 0);
            this.panelSidebarHeader.Name = "panelSidebarHeader";
            this.panelSidebarHeader.Size = new System.Drawing.Size(220, 50);
            this.panelSidebarHeader.TabIndex = 0;

            // lblSidebarTitle
            this.lblSidebarTitle.AutoSize = true;
            this.lblSidebarTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Location = new System.Drawing.Point(30, 14);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(158, 21);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "📋 Menu Aplikasi";

            // ========================================
            // MENU BUTTONS
            // ========================================

            // btnKirimSurat
            this.btnKirimSurat.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnKirimSurat.FlatAppearance.BorderSize = 0;
            this.btnKirimSurat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKirimSurat.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnKirimSurat.ForeColor = System.Drawing.Color.White;
            this.btnKirimSurat.Location = new System.Drawing.Point(10, 60);
            this.btnKirimSurat.Name = "btnKirimSurat";
            this.btnKirimSurat.Size = new System.Drawing.Size(200, 40);
            this.btnKirimSurat.TabIndex = 1;
            this.btnKirimSurat.Text = "📨 Kirim Surat";
            this.btnKirimSurat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKirimSurat.UseVisualStyleBackColor = false;
            this.btnKirimSurat.Click += new System.EventHandler(this.btnKirimSurat_Click);

            // btnSuratMasuk
            this.btnSuratMasuk.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnSuratMasuk.FlatAppearance.BorderSize = 0;
            this.btnSuratMasuk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuratMasuk.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuratMasuk.ForeColor = System.Drawing.Color.White;
            this.btnSuratMasuk.Location = new System.Drawing.Point(10, 110);
            this.btnSuratMasuk.Name = "btnSuratMasuk";
            this.btnSuratMasuk.Size = new System.Drawing.Size(200, 40);
            this.btnSuratMasuk.TabIndex = 2;
            this.btnSuratMasuk.Text = "📥 Surat Masuk";
            this.btnSuratMasuk.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuratMasuk.UseVisualStyleBackColor = false;
            this.btnSuratMasuk.Click += new System.EventHandler(this.btnSuratMasuk_Click);

            // btnSuratKeluarAdmin
            this.btnSuratKeluarAdmin.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnSuratKeluarAdmin.FlatAppearance.BorderSize = 0;
            this.btnSuratKeluarAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuratKeluarAdmin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSuratKeluarAdmin.ForeColor = System.Drawing.Color.White;
            this.btnSuratKeluarAdmin.Location = new System.Drawing.Point(10, 160);
            this.btnSuratKeluarAdmin.Name = "btnSuratKeluarAdmin";
            this.btnSuratKeluarAdmin.Size = new System.Drawing.Size(200, 40);
            this.btnSuratKeluarAdmin.TabIndex = 3;
            this.btnSuratKeluarAdmin.Text = "📤 Surat Keluar";
            this.btnSuratKeluarAdmin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuratKeluarAdmin.UseVisualStyleBackColor = false;
            this.btnSuratKeluarAdmin.Visible = false;
            this.btnSuratKeluarAdmin.Click += new System.EventHandler(this.btnSuratKeluarAdmin_Click);

            // btnRoleManagement
            this.btnRoleManagement.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnRoleManagement.FlatAppearance.BorderSize = 0;
            this.btnRoleManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoleManagement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRoleManagement.ForeColor = System.Drawing.Color.White;
            this.btnRoleManagement.Location = new System.Drawing.Point(10, 210);
            this.btnRoleManagement.Name = "btnRoleManagement";
            this.btnRoleManagement.Size = new System.Drawing.Size(200, 40);
            this.btnRoleManagement.TabIndex = 4;
            this.btnRoleManagement.Text = "⚙️ Manajemen Role";
            this.btnRoleManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoleManagement.UseVisualStyleBackColor = false;
            this.btnRoleManagement.Visible = false;
            this.btnRoleManagement.Click += new System.EventHandler(this.btnRoleManagement_Click);

            // btnUserManagement
            this.btnUserManagement.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnUserManagement.FlatAppearance.BorderSize = 0;
            this.btnUserManagement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserManagement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUserManagement.ForeColor = System.Drawing.Color.White;
            this.btnUserManagement.Location = new System.Drawing.Point(10, 260);
            this.btnUserManagement.Name = "btnUserManagement";
            this.btnUserManagement.Size = new System.Drawing.Size(200, 40);
            this.btnUserManagement.TabIndex = 5;
            this.btnUserManagement.Text = "👤 Manajemen User";
            this.btnUserManagement.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUserManagement.UseVisualStyleBackColor = false;
            this.btnUserManagement.Visible = false;
            this.btnUserManagement.Click += new System.EventHandler(this.btnUserManagement_Click);

            // ========================================
            // PANEL CONTENT CONTAINER
            // ========================================
            this.panelContentContainer.BackColor = System.Drawing.Color.White;
            this.panelContentContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContentContainer.Location = new System.Drawing.Point(220, 0);
            this.panelContentContainer.Name = "panelContentContainer";
            this.panelContentContainer.Padding = new System.Windows.Forms.Padding(20);
            this.panelContentContainer.Size = new System.Drawing.Size(980, 605);
            this.panelContentContainer.TabIndex = 1;

            // ========================================
            // DASHBOARD FORM
            // ========================================
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 680);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelHeader);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard - Sistem Informasi Surat";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardForm_FormClosing);
            this.panelHeader.ResumeLayout(false);
            this.panelHeader.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.panelSidebarHeader.ResumeLayout(false);
            this.panelSidebarHeader.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}