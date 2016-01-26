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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using QUANLYKHACHSAN.PresentationLayers;

namespace QUANLYKHACHSAN.PresentationLayers
{
    public partial class frmDangKyPhong : Form
    {
        private string MaNV;

        public frmDangKyPhong()
        {
            InitializeComponent();
            LoadData();          
        }

        public frmDangKyPhong(string MaNV)
        {
            
            this.MaNV = MaNV;
            InitializeComponent();
            LoadData();  
        }

        private void frmDangKyPhong_Load(object sender, EventArgs e)
        {
            cbbMaPDK.Text = PhieuDangKyPhongBUS.XuLyMa();
            Load_MaPDK();
            luMaKH.ItemIndex = 0;
            luMaKH.Select();
            luCMND.EditValue = luMaKH.Text;
            txtHoTen.Text = KhachHangBUS.SearchTenKHBYMaKH(luMaKH.Text);
            cbbSLP.SelectedItem = 1;
            deNgayDangKy.EditValue = DateTime.Now;
            deNgayDen.EditValue = DateTime.Now;

            luMaPhong.ItemIndex = 0;
            cbbPhuongThuc.SelectedIndex = 0;
            Load_SoNguoiMax();
        }
        private void LoadData()
        {
            gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
            kHACHHANGTableAdapter.Fill(qLKSDataSet.KHACHHANG);
            pHONGTableAdapter.Fill(qLKSDataSet.PHONG);
            Load_SoPhongMax();
            Load_SoPhongMax1();
            Load_MaPhong();
        }

        private void Load_MaPDK()
        {
            cbbMaPDK.Properties.Items.Clear();
            foreach(string PDK in PhieuDangKyPhongBUS.ListPDK())
            {
                cbbMaPDK.Properties.Items.Add(PDK);
            }
            //cbbMaPDK.SelectedItem = 1;
        }

        private void Load_MaPhong()
        {
            luMaPhong.Properties.DataSource = PhongBUS.GetPhongTrong();
        }

        private void Load_SoPhongMax1()
        {
            col_cbbSoLuongPhong.Items.Clear();
            for (int i = 1; i <= ThamSoBUS.ThamSo_SoPhongMax(); i++)
            {
                col_cbbSoLuongPhong.Items.Add(i);
            }
        }

        private void luMaKH_Properties_EditValueChanged(object sender, EventArgs e)
        {
            if(luMaKH.ContainsFocus)
            {
                luCMND.EditValue = luMaKH.Text;
                txtHoTen.Text = KhachHangBUS.SearchTenKHBYMaKH(luMaKH.Text);
            }
            
        }

        private void Load_SoPhongMax()
        {
            cbbSLP.Properties.Items.Clear();
            for(int i = 1; i<= ThamSoBUS.ThamSo_SoPhongMax(); i++)
            {
                cbbSLP.Properties.Items.Add(i);
            }
        }

        private void Load_SoNguoiMax()
        {
            cbbSoLuongNguoi.Properties.Items.Clear();
            for (int i = 1; i <= LoaiPhongBUS.SoNguoiMax(luMaPhong.Text); i++)
            {
                cbbSoLuongNguoi.Properties.Items.Add(i);
            }
            cbbSoLuongNguoi.SelectedItem = LoaiPhongBUS.SoNguoiMax(luMaPhong.Text);
        }
        private void luCMND_EditValueChanged(object sender, EventArgs e)
        {
            if (luCMND.ContainsFocus)
            {
                luMaKH.EditValue = luCMND.Text;
                txtHoTen.Text = KhachHangBUS.SearchTenKHByCMND(luCMND.Text);
            }
        }

        private Boolean KiemTraPhieuDK()
        {
            string tam = PhieuDangKyPhongBUS.XuLyMa();
            if (cbbSLP.Text == "" || deNgayDangKy.Text == "" || deNgayDen.Text == "" || deNgayDi.Text == "")
            {
                MessageBox.Show("Xin nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (deNgayDangKy.DateTime > deNgayDen.DateTime || deNgayDangKy.DateTime > deNgayDi.DateTime || deNgayDen.DateTime > deNgayDi.DateTime)
            {
                MessageBox.Show("Xin xem lại ngày tháng!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if(Convert.ToInt32(cbbMaPDK.Text.Substring(3)) < Convert.ToInt32(tam.Substring(3)))
            {
                MessageBox.Show("Phiếu này đã tồn tại!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (deNgayDangKy.DateTime.Date < DateTime.Now.Date || deNgayDangKy.DateTime.Date < DateTime.Now.Date || deNgayDen.DateTime < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày tháng không được bé hơn ngày hiện tại!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Boolean DKDangKyPhong()
        {
            List<DateTime> ngayden = PhieuDangKyPhongBUS.ListNgayNhanPhong(luMaPhong.Text);
            List<DateTime> ngaydi = PhieuDangKyPhongBUS.ListNgayTraPhong(luMaPhong.Text);
            for(int i = 0; i < ngayden.Count; i++)
            {
                if ((deNgayDen.DateTime >= ngayden[i] && deNgayDen.DateTime <= ngaydi[i]) || (deNgayDi.DateTime >= ngayden[i] && deNgayDi.DateTime <= ngaydi[i]))
                {
                    MessageBox.Show("Trùng thời gian! Xin chọn thời gian khác.", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return false;
                }

            }

            return true;
        }

        private Boolean DkDangKyPhong1()
        {
            List<DateTime> ngayden = PhieuDangKyPhongBUS.ListNgayNhanPhong(gridView1.GetFocusedRowCellValue(colMaPhong).ToString());
            List<DateTime> ngaydi = PhieuDangKyPhongBUS.ListNgayTraPhong(gridView1.GetFocusedRowCellValue(colMaPhong).ToString());
            for (int i = 0; i < ngayden.Count; i++)
            {
                if (((DateTime)gridView1.GetFocusedRowCellValue(colNgayDen) >= ngayden[i] && (DateTime)gridView1.GetFocusedRowCellValue(colNgayDen) <= ngaydi[i])
                    || ((DateTime)gridView1.GetFocusedRowCellValue(colNgayDi) >= ngayden[i] && (DateTime)gridView1.GetFocusedRowCellValue(colNgayDi) <= ngaydi[i]))
                {
                    MessageBox.Show("Trùng thời gian! Xin chọn thời gian khác.", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    return false;
                }

            }

            return true;
        }
        private Boolean KiemTraCS()
        {
            if (cbbSLP.Text == "" || deNgayDangKy.Text == "" || deNgayDen.Text == "" || deNgayDi.Text == "")
            {
                MessageBox.Show("Xin nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if (deNgayDangKy.DateTime > deNgayDen.DateTime || deNgayDangKy.DateTime > deNgayDi.DateTime || deNgayDen.DateTime > deNgayDi.DateTime)
            {
                MessageBox.Show("Xin xem lại ngày tháng!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            if (cbbMaPDK.Text == PhieuDangKyPhongBUS.XuLyMa())
            {
                MessageBox.Show("Phiếu này chưa đăng ký!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private Boolean KiemTra()
        {
            if (cbbMaPDK.Text == PhieuDangKyPhongBUS.XuLyMa())
            {
                MessageBox.Show("Phiếu này chưa đăng ký!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if(luMaPhong.Text == "" || cbbPhuongThuc.Text == "" || cbbSoLuongNguoi.Text == "")
            {
                MessageBox.Show("Phiếu này chưa đăng ký!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if(PhieuDangKyPhongBUS.SoLuongPhong(cbbMaPDK.Text) == PhieuDangKyPhongBUS.CountPhongDK(cbbMaPDK.Text))
            {
                MessageBox.Show("Phiếu này đã đủ phòng!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private Boolean KiemTraLuu()
        {
            if (gridView1.GetFocusedRowCellValue(colMaKH).ToString() == "" || gridView1.GetFocusedRowCellValue(colMaPhong).ToString() == "")
            {
                MessageBox.Show("Phiếu này chưa điền đầy đủ thông tin!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if((DateTime)gridView1.GetFocusedRowCellValue(colNgayDangKy) > (DateTime)gridView1.GetFocusedRowCellValue(colNgayDen) ||
                (DateTime)gridView1.GetFocusedRowCellValue(colNgayDangKy) > (DateTime)gridView1.GetFocusedRowCellValue(colNgayDi) ||
                (DateTime)gridView1.GetFocusedRowCellValue(colNgayDen) > (DateTime)gridView1.GetFocusedRowCellValue(colNgayDi))
            {
                MessageBox.Show("Xin xem lại ngày tháng!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if(int.Parse(gridView1.GetFocusedRowCellValue(colSoLuongNguoi).ToString()) > LoaiPhongBUS.SoNguoiMax(gridView1.GetFocusedRowCellDisplayText(colMaPhong)))
            {
                MessageBox.Show("Số người lớn hơn số người tối đa cho phép!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            else if(int.Parse(gridView1.GetFocusedRowCellValue(colSoLuongPhong).ToString()) < PhieuDangKyPhongBUS.CountPhongDK(gridView1.GetFocusedRowCellDisplayText(colMaPDK)))
            {
                MessageBox.Show("Số phòng không thể ít hơn số phòng đã đăng ký!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnDangKyPhieu_Click(object sender, EventArgs e)
        {
            if(KiemTraPhieuDK())
            {
                try
                {
                    PhieuDangKyPhong PDK = new PhieuDangKyPhong();
                    PDK.MaPDK = cbbMaPDK.Text;
                    PDK.MaKH = luMaKH.Text;
                    PDK.SoLuongphong = int.Parse(cbbSLP.Text);
                    PDK.NgayDangKy = deNgayDangKy.DateTime;
                    PDK.NgayNhanPhong = deNgayDen.DateTime;
                    PDK.NgayTraPhong = deNgayDi.DateTime;
                    PDK.MaNV = this.MaNV;
                    PhieuDangKyPhongBUS.DangKyPhong_Insert(PDK);

                    gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
                    MessageBox.Show("Thêm thành công.", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void luMaPhong_EditValueChanged(object sender, EventArgs e)
        {
            if(luMaPhong.ContainsFocus)
            {
                Load_SoNguoiMax();
            }
        }

        private void cbbMaPDK_EditValueChanged(object sender, EventArgs e)
        {
            if(cbbMaPDK.ContainsFocus)
            {
                List<string> tam = PhieuDangKyPhongBUS.GetByMaPDK(cbbMaPDK.Text);
                luMaKH.EditValue = tam[0];
                txtHoTen.Text = tam[1];
                luCMND.EditValue = tam[2];
                cbbSLP.Text = tam[3];
                deNgayDangKy.Text = tam[4];
                deNgayDen.Text = tam[5];
                deNgayDi.Text = tam[6];
            }
        }

        private void btnDangKyPhong_Click(object sender, EventArgs e)
        {
            if (KiemTra() && DKDangKyPhong())
            {
                try
                {
                    DangKyPhongCT CTPDK = new DangKyPhongCT();
                    PhieuDangKyPhong PDK = new PhieuDangKyPhong();
                    CTPDK.MaCTPDK = DangKyPhongCTBUS.XuLyMa();
                    CTPDK.MaPDK = cbbMaPDK.Text;
                    CTPDK.MaPhong = luMaPhong.Text;
                    CTPDK.SoLuongNguoi = cbbSoLuongNguoi.Text;
                    PDK.MaPDK = cbbMaPDK.Text;
                    PDK.PhuongThucTinhTien = cbbPhuongThuc.Text;
                    DangKyPhongCTBUS.DangKyPhongCT_Insert(CTPDK);
                    PhieuDangKyPhongBUS.UpdatePhuongThuc(PDK);

                    gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
                    MessageBox.Show("Đăng ký phòng thành công.", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (KiemTraCS())
            {   
                try
                {
                    PhieuDangKyPhong PDK = new PhieuDangKyPhong();
                    PDK.MaPDK = cbbMaPDK.Text;
                    PDK.MaKH = luMaKH.Text;
                    PDK.SoLuongphong = int.Parse(cbbSLP.Text);
                    PDK.NgayDangKy = deNgayDangKy.DateTime;
                    PDK.NgayNhanPhong = deNgayDen.DateTime;
                    PDK.NgayTraPhong = deNgayDi.DateTime;
                    PDK.MaNV = this.MaNV;
                    PhieuDangKyPhongBUS.DangKyPhong_Update(PDK);

                    gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
                    MessageBox.Show("Chỉnh sửa thành công.", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnNhapLai_Click(object sender, EventArgs e)
        {
            frmDangKyPhong_Load(sender, e);
            deNgayDi.Text = "";
            gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            frmKhachHang f = new frmKhachHang();
            f.ShowDialog();
        }

        private void btnThemDichVu_Click(object sender, EventArgs e)
        {
            frmDangKyDichVu f = new frmDangKyDichVu();
            f.ShowDialog();
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DangKyPhongCTBUS.Delete(gridView1.GetFocusedRowCellValue(colMaCTPDK).ToString());
                    frmDangKyPhong_Load(sender, e);
                    gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
                    MessageBox.Show("Xóa Thành Công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTraLuu() && DkDangKyPhong1())
            {
                PhieuDangKyPhong PDK = new PhieuDangKyPhong();
                DangKyPhongCT DKP = new DangKyPhongCT();
                PDK.MaPDK = gridView1.GetFocusedRowCellValue(colMaPDK).ToString();
                PDK.MaKH = gridView1.GetFocusedRowCellValue(colMaKH).ToString();
                PDK.MaNV = gridView1.GetFocusedRowCellValue(colMaNV).ToString();
                PDK.SoLuongphong = int.Parse(gridView1.GetFocusedRowCellValue(colSoLuongPhong).ToString());
                PDK.NgayDangKy = (DateTime)gridView1.GetFocusedRowCellValue(colNgayDangKy);
                PDK.NgayNhanPhong = (DateTime)gridView1.GetFocusedRowCellValue(colNgayDen);
                PDK.NgayTraPhong = (DateTime)gridView1.GetFocusedRowCellValue(colNgayDi);
                PDK.PhuongThucTinhTien = gridView1.GetFocusedRowCellValue(colPhuongThucTinhTien).ToString();
                DKP.MaCTPDK = gridView1.GetFocusedRowCellValue(colMaCTPDK).ToString();
                DKP.MaPDK = gridView1.GetFocusedRowCellValue(colMaPDK).ToString();
                DKP.MaPhong = gridView1.GetFocusedRowCellValue(colMaPhong).ToString();
                DKP.SoLuongNguoi = gridView1.GetFocusedRowCellValue(colSoLuongNguoi).ToString();

                PhieuDangKyPhongBUS.DangKyPhong_Update(PDK);
                PhieuDangKyPhongBUS.UpdatePhuongThuc(PDK);
                DangKyPhongCTBUS.DangKyPhongCT_Update(DKP);

                gridControl1.DataSource = PhieuDangKyPhongBUS.GetAll();
                MessageBox.Show("Lưu thành công.", "Thông báo");
            }     
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            col_cbbSoLuongNguoi.Items.Clear();
            for (int i = 1; i <= LoaiPhongBUS.SoNguoiMax(gridView1.GetFocusedRowCellDisplayText(colMaPhong)); i++)
            {
                col_cbbSoLuongNguoi.Items.Add(i);
            }
        }

    }
}
