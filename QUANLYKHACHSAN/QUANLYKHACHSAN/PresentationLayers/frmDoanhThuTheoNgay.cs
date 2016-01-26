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
    public partial class frmDoanhThuTheoNgay : Form
    {
        public frmDoanhThuTheoNgay()
        {
            InitializeComponent();
        }

        private void frmDoanhThuTheoNgay_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLKSDataSet.DoanhThuTheoNgay' table. You can move, or remove it, as needed.
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DateTime date = deNgayBaoCao.DateTime;
            string formatted = date.ToString("MM/d/yyyy");
            if(deNgayBaoCao.DateTime > DateTime.Now)
            {
                MessageBox.Show("Thời gian không hợp lý (Ngày báo cáo lớn hơn ngày hiện tại)", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    this.doanhThuTheoNgayTableAdapter.Fill(this.qLKSDataSet.DoanhThuTheoNgay, formatted);

                    this.reportViewer1.RefreshReport();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
