using QUANLYKHACHSAN.BUS;
using QUANLYKHACHSAN.Object;
using QUANLYKHACHSAN.Support;
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
    public partial class frmTimKiemNhanVien : Form
    {
        NhanVien nv = new NhanVien();
        public frmTimKiemNhanVien()
        {
            InitializeComponent();
            LoadData();
            chucvuTableAdapter1.Fill(qlksDataSet2.CHUCVU);
        }
        private void LoadData()
        {
            try
            {
                nhanvienTableAdapter1.Fill(qlksDataSet2.NHANVIEN);
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTimKiem.Text == "Tên Nhân Viên")
                {
                    gridControl1.DataSource = NhanVienBUS.SearchByTenNV(HamHoTro.ChuyenKhongDau(txtThongTin.Text));
                }
                else
                {
                    gridControl1.DataSource = NhanVienBUS.SearchByMaNV(HamHoTro.ChuyenKhongDau(txtThongTin.Text));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (KiemTra())
            {
                try
                {
                    nv.MaNV = (string)gridView1.GetFocusedRowCellValue(colMaNV);
                    nv.TenNV = gridView1.GetFocusedRowCellDisplayText(colTenNV);
                    if ((bool)(gridView1.GetFocusedRowCellValue(colGioiTinh)))
                    {
                        nv.GioiTinh = 1;
                    }
                    else nv.GioiTinh = 0;
                    nv.NgaySinh = Convert.ToDateTime(gridView1.GetFocusedRowCellDisplayText(colNgaySinh));
                    nv.MaCV = gridView1.GetFocusedRowCellDisplayText(colMaCV);
                    nv.Email = gridView1.GetFocusedRowCellDisplayText(colEmail);
                    nv.MatKhau = HamHoTro.MaHoa(gridView1.GetFocusedRowCellDisplayText(colMatKhau), true);
                    nv.DiaChi = gridView1.GetFocusedRowCellDisplayText(colDiaChi);
                    nv.SDT = gridView1.GetFocusedRowCellDisplayText(colSDT);
                    NhanVienBUS.Update(nv);
                    LoadData();
                    MessageBox.Show("Sửa Nhân viên thành công!", "Thông Báo");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private bool KiemTra()
        {
            if(gridView1.GetFocusedRowCellValue(colMaNV) == null
                || gridView1.GetFocusedRowCellDisplayText(colTenNV)==""
                || gridView1.GetFocusedRowCellValue(colGioiTinh)==null
                || gridView1.GetFocusedRowCellDisplayText(colNgaySinh)==""
                || gridView1.GetFocusedRowCellDisplayText(colMaCV)==""
                || gridView1.GetFocusedRowCellDisplayText(colEmail)==""
                || gridView1.GetFocusedRowCellDisplayText(colMatKhau)==""
                || gridView1.GetFocusedRowCellDisplayText(colDiaChi)==""
                || gridView1.GetFocusedRowCellDisplayText(colSDT)=="")
            {
                MessageBox.Show("Không được để trống thông tin");
                return false;
            }

            if (qlksDataSet2.CHUCVU.FindByMaCV(gridView1.GetFocusedRowCellDisplayText(colMaCV)) == null)
            {
                MessageBox.Show("Chức vụ không có!", "Thông báo lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            

            return true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NhanVienBUS.Delete((string)gridView1.GetFocusedRowCellValue(colMaNV));
                    LoadData();
                    MessageBox.Show("Xóa Thành Công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            
            
        }

        private void gridView1_MouseLeave(object sender, EventArgs e)
        {
            
        }

    }
}
