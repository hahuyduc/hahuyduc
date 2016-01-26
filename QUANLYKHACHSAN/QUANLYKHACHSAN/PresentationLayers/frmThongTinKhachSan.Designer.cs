namespace QUANLYKHACHSAN.PresentationLayers
{
    partial class frmThongTinKhachSan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThongTinKhachSan));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtChuThich = new DevExpress.XtraEditors.TextEdit();
            this.btnSuaThongTin = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtTenKhachSan = new DevExpress.XtraEditors.TextEdit();
            this.txtWebSite = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.khachsanTableAdapter1 = new QUANLYKHACHSAN.QLKSDataSetTableAdapters.KHACHSANTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.TxtChuThich.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhachSan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebSite.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(634, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "THÔNG TIN KHÁCH SẠN";
            // 
            // TxtChuThich
            // 
            this.TxtChuThich.EditValue = "";
            this.TxtChuThich.Enabled = false;
            this.TxtChuThich.Location = new System.Drawing.Point(50, 314);
            this.TxtChuThich.Name = "TxtChuThich";
            this.TxtChuThich.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtChuThich.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.TxtChuThich.Properties.Appearance.Options.UseFont = true;
            this.TxtChuThich.Properties.Appearance.Options.UseForeColor = true;
            this.TxtChuThich.Properties.Appearance.Options.UseTextOptions = true;
            this.TxtChuThich.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.TxtChuThich.Properties.AutoHeight = false;
            this.TxtChuThich.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtChuThich.Size = new System.Drawing.Size(494, 76);
            this.TxtChuThich.TabIndex = 5;
            // 
            // btnSuaThongTin
            // 
            this.btnSuaThongTin.Image = ((System.Drawing.Image)(resources.GetObject("btnSuaThongTin.Image")));
            this.btnSuaThongTin.Location = new System.Drawing.Point(50, 412);
            this.btnSuaThongTin.Name = "btnSuaThongTin";
            this.btnSuaThongTin.Size = new System.Drawing.Size(145, 35);
            this.btnSuaThongTin.TabIndex = 6;
            this.btnSuaThongTin.Text = "Sữa thông tin";
            this.btnSuaThongTin.Click += new System.EventHandler(this.btnSuaThongTin_Click);
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(445, 412);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(99, 35);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl4.Location = new System.Drawing.Point(48, 210);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 19);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Website: \r\n";
            // 
            // labelControl3
            // 
            this.labelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl3.Location = new System.Drawing.Point(50, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(186, 25);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "TÊN KHÁCH SẠN: \r\n";
            // 
            // labelControl5
            // 
            this.labelControl5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl5.Location = new System.Drawing.Point(54, 164);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(56, 19);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Email: ";
            // 
            // labelControl6
            // 
            this.labelControl6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl6.Location = new System.Drawing.Point(54, 90);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(66, 19);
            this.labelControl6.TabIndex = 10;
            this.labelControl6.Text = "Địa chỉ: ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.EditValue = "";
            this.txtDiaChi.Enabled = false;
            this.txtDiaChi.Location = new System.Drawing.Point(128, 87);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiaChi.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Properties.Appearance.Options.UseForeColor = true;
            this.txtDiaChi.Size = new System.Drawing.Size(402, 26);
            this.txtDiaChi.TabIndex = 1;
            // 
            // txtSDT
            // 
            this.txtSDT.EditValue = "";
            this.txtSDT.Enabled = false;
            this.txtSDT.Location = new System.Drawing.Point(128, 119);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Properties.Appearance.Options.UseForeColor = true;
            this.txtSDT.Size = new System.Drawing.Size(346, 26);
            this.txtSDT.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.EditValue = "";
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(128, 160);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.Appearance.Options.UseForeColor = true;
            this.txtEmail.Size = new System.Drawing.Size(402, 26);
            this.txtEmail.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl2.Location = new System.Drawing.Point(50, 289);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(110, 19);
            this.labelControl2.TabIndex = 15;
            this.labelControl2.Text = "Tự giới thiệu:";
            // 
            // txtTenKhachSan
            // 
            this.txtTenKhachSan.Enabled = false;
            this.txtTenKhachSan.Location = new System.Drawing.Point(242, 43);
            this.txtTenKhachSan.Name = "txtTenKhachSan";
            this.txtTenKhachSan.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKhachSan.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtTenKhachSan.Properties.Appearance.Options.UseFont = true;
            this.txtTenKhachSan.Properties.Appearance.Options.UseForeColor = true;
            this.txtTenKhachSan.Size = new System.Drawing.Size(288, 32);
            this.txtTenKhachSan.TabIndex = 0;
            // 
            // txtWebSite
            // 
            this.txtWebSite.EditValue = "";
            this.txtWebSite.Enabled = false;
            this.txtWebSite.Location = new System.Drawing.Point(128, 207);
            this.txtWebSite.Name = "txtWebSite";
            this.txtWebSite.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWebSite.Properties.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.txtWebSite.Properties.Appearance.Options.UseFont = true;
            this.txtWebSite.Properties.Appearance.Options.UseForeColor = true;
            this.txtWebSite.Size = new System.Drawing.Size(402, 26);
            this.txtWebSite.TabIndex = 4;
            // 
            // labelControl8
            // 
            this.labelControl8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.DodgerBlue;
            this.labelControl8.Location = new System.Drawing.Point(54, 126);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(39, 19);
            this.labelControl8.TabIndex = 18;
            this.labelControl8.Text = "SĐT:";
            // 
            // khachsanTableAdapter1
            // 
            this.khachsanTableAdapter1.ClearBeforeFill = true;
            // 
            // frmThongTinKhachSan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 463);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.txtWebSite);
            this.Controls.Add(this.txtTenKhachSan);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSuaThongTin);
            this.Controls.Add(this.TxtChuThich);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.Name = "frmThongTinKhachSan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin khách sạn";
            this.Load += new System.EventHandler(this.frmThongTinKhachSan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TxtChuThich.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenKhachSan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebSite.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit TxtChuThich;
        private DevExpress.XtraEditors.SimpleButton btnSuaThongTin;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtTenKhachSan;
        private DevExpress.XtraEditors.TextEdit txtWebSite;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private QLKSDataSetTableAdapters.KHACHSANTableAdapter khachsanTableAdapter1;
    }
}