namespace QUANLYKHACHSAN.PresentationLayers
{
    partial class frmHoaDonThanhToan
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.qLKSDataSet = new QUANLYKHACHSAN.QLKSDataSet();
            this.viewHoaDonThanhToanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.view_HoaDonThanhToanTableAdapter = new QUANLYKHACHSAN.QLKSDataSetTableAdapters.view_HoaDonThanhToanTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.qLKSDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonThanhToanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "viewHoaDon";
            reportDataSource1.Value = this.viewHoaDonThanhToanBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QUANLYKHACHSAN.PresentationLayers.Report_HoaDonThanhToan.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(686, 340);
            this.reportViewer1.TabIndex = 0;
            // 
            // qLKSDataSet
            // 
            this.qLKSDataSet.DataSetName = "QLKSDataSet";
            this.qLKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // viewHoaDonThanhToanBindingSource
            // 
            this.viewHoaDonThanhToanBindingSource.DataMember = "view_HoaDonThanhToan";
            this.viewHoaDonThanhToanBindingSource.DataSource = this.qLKSDataSet;
            // 
            // view_HoaDonThanhToanTableAdapter
            // 
            this.view_HoaDonThanhToanTableAdapter.ClearBeforeFill = true;
            // 
            // frmHoaDonThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(686, 340);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmHoaDonThanhToan";
            this.Text = "frmHoaDonThanhToan";
            this.Load += new System.EventHandler(this.frmHoaDonThanhToan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qLKSDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.viewHoaDonThanhToanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource viewHoaDonThanhToanBindingSource;
        private QLKSDataSet qLKSDataSet;
        private QLKSDataSetTableAdapters.view_HoaDonThanhToanTableAdapter view_HoaDonThanhToanTableAdapter;
    }
}