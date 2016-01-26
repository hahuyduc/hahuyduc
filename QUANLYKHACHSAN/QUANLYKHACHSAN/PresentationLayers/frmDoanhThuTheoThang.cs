using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QUANLYKHACHSAN.PresentationLayers
{
    public partial class frmDoanhThuTheoThang : Form
    {
        public frmDoanhThuTheoThang()
        {
            InitializeComponent();
        }

        private void frmDoanhThuTheoThang_Load(object sender, EventArgs e)
        {

            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            int thang = Convert.ToInt32(cbbThang.Text);
            int nam = Convert.ToInt32(txtNam.Text);
            int month = Convert.ToInt32(DateTime.Now.Month);
            int year = Convert.ToInt32(DateTime.Now.Year);
            if(nam > year)
            {
                MessageBox.Show("Thời gian không hợp lý! (Năm báo cáo không thể lớn hơn nam hiện tại))", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else if(thang > month)
            {
                MessageBox.Show("Thời gian không hợp lý! (Tháng báo cáo không thể lớn hơn tháng hiện tại)", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                this.doanhThuTheoNgayTableAdapter.FillBy(this.qLKSDataSet.DoanhThuTheoNgay, thang, nam);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
