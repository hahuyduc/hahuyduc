using Microsoft.Reporting.WinForms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QUANLYKHACHSAN.PresentationLayers
{
    public partial class frmHoaDonThanhToan : Form
    {
        string MaPDK = "";
        public frmHoaDonThanhToan(Hashtable ThongTinHoaDon)
        {
            InitializeComponent();
            try
            {
                MaPDK = ThongTinHoaDon["MaPDK"].ToString();
                List<ReportParameter> Parameters = new List<ReportParameter>();
                ReportParameter param = default(ReportParameter);
                param = new ReportParameter("MaPTT", ThongTinHoaDon["MaPTT"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("MaPDK", ThongTinHoaDon["MaPDK"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("MaKH", ThongTinHoaDon["MaKH"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("TenKH", ThongTinHoaDon["TenKH"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("TienPhong", ThongTinHoaDon["TienPhong"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("TienDichVu", ThongTinHoaDon["TienDichVu"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("PhatSinh", ThongTinHoaDon["PhatSinh"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("Thue", ThongTinHoaDon["Thue"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("TongTienPhaiTra", ThongTinHoaDon["TongTienPhaiTra"].ToString());
                Parameters.Add(param);
                param = new ReportParameter("NgayLap", ThongTinHoaDon["NgayLap"].ToString());
                Parameters.Add(param);
                reportViewer1.LocalReport.SetParameters(Parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmHoaDonThanhToan_Load(object sender, EventArgs e)
        {
            try
            {
                this.view_HoaDonThanhToanTableAdapter.Fill(this.qLKSDataSet.view_HoaDonThanhToan, MaPDK);
                reportViewer1.LocalReport.DisplayName = "Hóa Đơn Thanh Toán";
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
