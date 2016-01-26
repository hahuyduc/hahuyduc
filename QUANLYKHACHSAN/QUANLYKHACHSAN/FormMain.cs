using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Helpers;
using QUANLYKHACHSAN.PresentationLayers;

namespace QUANLYKHACHSAN
{
    public partial class FormMain : RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            InitSkinGallery();
        }
        string MaNV { set; get; }
        string TenNV { set; get; }
        string ChucVu { set; get; }
        int Quyen { set; get; }
        void InitSkinGallery()
        {
            SkinHelper.InitSkinGallery(ribbonGallery, true);
        }
        private Form KiemTraTonTai(Type ftype)
        {
            foreach(Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }

            return null;
        }

        

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            frmDangNhap DangNhap = new frmDangNhap();
            DangNhap.ShowDialog();
            TenNV = DangNhap.TenNV;
            ChucVu = DangNhap.ChucVu;
            MaNV = DangNhap.MaNV;
            Quyen = DangNhap.Quyen;
            DangNhap.Dispose();
            navBarItemTenNhanVien.Caption += TenNV;
            navBarItemChucVu.Caption += ChucVu;
            switch (Quyen)
            {
                case 2: // Quan ly                   
                    ribbonHeThong.Visible = false;
                    ribbonDoanhThu.Visible = false;
                    break;
                case 3: // Nhan vien
                    ribbonQuanLyDichVu.Visible = false;
                    ribbonQuanLyNhanVien.Visible = false;
                    ribbonQuanLyKhachHang.Visible = false;
                    ribbonHeThong.Visible = false;
                    ribbonDoanhThu.Visible = false;
                    break;
                default:
                    break;
            }
        }

        private void btnDangKyPhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThuePhong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnThemDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnThanhToan_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmThanhToan));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmThanhToan f = new PresentationLayers.frmThanhToan(MaNV);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmKhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmKhachHang f = new PresentationLayers.frmKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmNhanVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmNhanVien f = new PresentationLayers.frmNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDanhSachPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmDanhSachPhong));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmDanhSachPhong f = new PresentationLayers.frmDanhSachPhong();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnLoaiPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmLoaiPhong));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmLoaiPhong f = new PresentationLayers.frmLoaiPhong();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThoat1_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnTKPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmTimKiemPhong));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmTimKiemPhong f = new PresentationLayers.frmTimKiemPhong();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmTimKiemDichVu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmTimKiemDichVu f = new PresentationLayers.frmTimKiemDichVu();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKKhachHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmTimKiemKhachHang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmTimKiemKhachHang f = new PresentationLayers.frmTimKiemKhachHang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnTKNhanVien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmTimKiemNhanVien));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmTimKiemNhanVien f = new PresentationLayers.frmTimKiemNhanVien();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThemDV_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmThemDichVu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmThemDichVu f = new PresentationLayers.frmThemDichVu();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnBackUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                Support.BackupAndRestore ht = new Support.BackupAndRestore();
                SaveFileDialog save = new SaveFileDialog();
                if (save.ShowDialog() == DialogResult.OK)
                {
                    ht.backup(save.FileName);
                    MessageBox.Show("Backup thành công.", "Thông báo");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Bạn không nên Backup trên ổ đĩa hệ thông!", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
                Support.BackupAndRestore ht = new Support.BackupAndRestore();
                OpenFileDialog open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    ht.Restore(open.FileName);
                    MessageBox.Show("Backup thành công.", "Thông báo");
                }
        }

        private void btnDTTheoNgay_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmDoanhThuTheoNgay));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmDoanhThuTheoNgay f = new PresentationLayers.frmDoanhThuTheoNgay();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDTTheoThang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmDoanhThuTheoThang));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmDoanhThuTheoThang f = new PresentationLayers.frmDoanhThuTheoThang();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnThongTinNhom_ItemClick(object sender, ItemClickEventArgs e)
        {
                PresentationLayers.frmThongTinNhom f = new PresentationLayers.frmThongTinNhom();
                f.ShowDialog();
        }

        private void btnThongTinKhachSan_ItemClick(object sender, ItemClickEventArgs e)
        {
            PresentationLayers.frmThongTinKhachSan f = new PresentationLayers.frmThongTinKhachSan();
            f.ShowDialog();
        }

        private void btnDangNhap1_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void barThayDoiQuyDinh1_ItemClick(object sender, ItemClickEventArgs e)
        {
            PresentationLayers.frmThayDoiQuyDinh f = new PresentationLayers.frmThayDoiQuyDinh();
            f.ShowDialog();
        }

        private void btnSaoLuu1_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnBackUp_ItemClick(sender, e);
        }

        private void btnKhoiPhuc1_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnRestore_ItemClick(sender, e);
        }

        private void navBarItemDoiMatKhau_LinkPressed(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            PresentationLayers.frmDoiMatKhau f = new PresentationLayers.frmDoiMatKhau(MaNV);
            f.ShowDialog();
        }

        private void btnThayDoiQuyDinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmThayDoiQuyDinh f = new frmThayDoiQuyDinh();
            f.ShowDialog();
        }

        private void btnDangKyPhong_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmDangKyPhong));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmDangKyPhong f = new PresentationLayers.frmDangKyPhong(MaNV);
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnNhanPhong_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmNhanPhong));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmNhanPhong f = new PresentationLayers.frmNhanPhong();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDKDichVu_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.KiemTraTonTai(typeof(PresentationLayers.frmDangKyDichVu));
            if (frm != null)
            {
                frm.Activate();
            }
            else
            {
                PresentationLayers.frmDangKyDichVu f = new PresentationLayers.frmDangKyDichVu(MaNV);
                f.MdiParent = this;
                f.Show();
            }
        }

    }
}
