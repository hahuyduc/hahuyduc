using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QUANLYKHACHSAN.BUS;
using QUANLYKHACHSAN.Object;


namespace QUANLYKHACHSAN.PresentationLayers
{
    public partial class frmNhanPhong : Form
    {
        public frmNhanPhong()
        {
            InitializeComponent();
        }


        private void frmNhanPhong_Load(object sender, EventArgs e)
        {
            Load_MaPDK();
            cbbMaPDK.SelectedIndex = 0;
            List<string> tam = PhieuDangKyPhongBUS.GetNhanPhong(cbbMaPDK.Text);
            if (tam.Count != 0)
            {
                txtMaKH.Text = tam[0];
                txtHoTen.Text = tam[1];
                txtCMND.Text = tam[2];
                txtSoLuongPhong.Text = tam[3];
                txtSoLuongNguoi.Text = tam[4];
                deNgayDangKy.Text = tam[5];
                deNgayDen.Text = tam[6];
                deNgayDi.Text = tam[7];
            }
            gridControl1.DataSource = PhieuDangKyPhongBUS.ThongTinNhanPhong();
        }

        private void Load_MaPDK()
        {
            cbbMaPDK.Properties.Items.Clear();
            foreach (string PDK in PhieuDangKyPhongBUS.GetMaPDK())
            {
                cbbMaPDK.Properties.Items.Add(PDK);
            }
        }
        private void cbbMaPDK_EditValueChanged(object sender, EventArgs e)
        {
            if (cbbMaPDK.ContainsFocus)
            {
                List<string> tam = PhieuDangKyPhongBUS.GetNhanPhong(cbbMaPDK.Text);
                if(tam.Count != 0)
                {
                    txtMaKH.Text = tam[0];
                    txtHoTen.Text = tam[1];
                    txtCMND.Text = tam[2];
                    txtSoLuongPhong.Text = tam[3];
                    txtSoLuongNguoi.Text = tam[4];
                    deNgayDangKy.Text = tam[5];
                    deNgayDen.Text = tam[6];
                    deNgayDi.Text = tam[7];
                }
                
            }
        }

        private void btnDKPhong_Click(object sender, EventArgs e)
        {
            frmDangKyPhong f = new frmDangKyPhong();
            f.ShowDialog();
        }

        private void btnDKDichVu_Click(object sender, EventArgs e)
        {
            frmDangKyDichVu f = new frmDangKyDichVu();
            f.ShowDialog();
        }


        private void btnNhanPhong_Click(object sender, EventArgs e)
        {
            PhieuDangKyPhongBUS.UpdateTongTien(TinhTienPhong(cbbMaPDK.Text));
            UpdateHienTrang(cbbMaPDK.Text,"Có");

            frmNhanPhong_Load(sender, e);
            MessageBox.Show("Nhận phòng thành công.", "Thông báo");
        }

        private void btnLoadLai_Click(object sender, EventArgs e)
        {
            frmNhanPhong_Load(sender, e);
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuDangKyPhongBUS.UpdateTongTienNull(gridView1.GetFocusedRowCellDisplayText(colMaPDK));
            UpdateHienTrangTrong(gridView1.GetFocusedRowCellDisplayText(colMaPDK));
            frmNhanPhong_Load(sender, e);
        }
        private PhieuDangKyPhong TinhTienPhong(string MaPDK)
        {
            double s = 0;
            List<string> DanhSachPhong = DangKyPhongCTBUS.NhanPhong(MaPDK);
            double hour = ChuyenThanhGio(MaPDK);
            double day = ChuyenThanhNgay(MaPDK);
            PhieuDangKyPhong Ph = new PhieuDangKyPhong();
            Ph.MaPDK = MaPDK;
            if (PhieuDangKyPhongBUS.GetPhuongThuc(MaPDK).Equals("Giờ"))
            {
                foreach(string phong in DanhSachPhong)
                {
                    s += LoaiPhongBUS.GetGia(phong);
                }
                Ph.TongTien = s + TienGiamTheoGio((int)hour) * DanhSachPhong.Count;
                return Ph;
            }
            else
            {
                foreach (string phong in DanhSachPhong)
                {
                    s += LoaiPhongBUS.GetGia(phong)  ;
                }
                Ph.TongTien = s + day * DanhSachPhong.Count * ThamSoBUS.TienNgay();
                return Ph;
            }

        }

        private double TienGiamTheoGio(int gio)
        {
            double tam = ThamSoBUS.TienGio();
            double result = 0;
            for (int i = 0; i < gio; i++)
            {
                if (tam > 10000)
                {
                    result += tam;
                    tam *= 90 / 100;
                }
            }
            return result;
        }
        private void UpdateHienTrang(string MaPDK,string HienTrang)
        {
            Phong ph = new Phong();
            foreach(string MaPhong in DangKyPhongCTBUS.NhanPhong(MaPDK))
            {
                ph.MaPhong = MaPhong;
                ph.HienTrang = HienTrang;
                PhongBUS.UpdateHienTrang(ph);
            }
        }

        private void UpdateHienTrangTrong(string MaPDK)
        {
            Phong ph = new Phong();
            foreach (string MaPhong in DangKyPhongCTBUS.NhanPhong(MaPDK))
            {
                if(PhieuDangKyPhongBUS.KiemTraPhongTrong(MaPhong) == 1)
                {
                    ph.MaPhong = MaPhong;
                    ph.HienTrang = "Trống";
                    PhongBUS.UpdateHienTrang(ph);
                }   
            }
        }

        private double ChuyenThanhGio(string MaPDK)
        {
            DateTime NgayNhanPhong = PhieuDangKyPhongBUS.NgayNhanPhong(MaPDK);
            DateTime NgayTraPhong = PhieuDangKyPhongBUS.NgayTraPhong(MaPDK);
            TimeSpan difference = NgayTraPhong - NgayNhanPhong;
            return difference.TotalHours;
        }

        private double ChuyenThanhNgay(string MaPDK)
        {
            DateTime NgayNhanPhong = PhieuDangKyPhongBUS.NgayNhanPhong(MaPDK);
            DateTime NgayTraPhong = PhieuDangKyPhongBUS.NgayTraPhong(MaPDK);
            TimeSpan difference = NgayTraPhong - NgayNhanPhong;
            return difference.Days;
        }

    }
}
