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
    public partial class frmTimKiemPhong : Form
    {
        LoaiPhong lp = new LoaiPhong();
        Phong ph = new Phong();
        public frmTimKiemPhong()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            gridControl1.DataSource = PhongBUS.DanhSach();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                switch (cbxTimKiem.Text)
                {
                    case "Hiện Trạng Phòng":
                        gridControl1.DataSource = PhongBUS.SearchBy(HamHoTro.ChuyenKhongDau(txtThongTin.Text), "HienTrang");
                        break;
                    case "Mã Phòng":
                        gridControl1.DataSource = PhongBUS.SearchBy(HamHoTro.ChuyenKhongDau(txtThongTin.Text), "MaPH");
                        break;
                    case "Số Lượng Người":
                        gridControl1.DataSource = PhongBUS.SearchBy(txtThongTin.Text, "SoLuongMax");
                        break;
                    case "Loại Phòng":
                        gridControl1.DataSource = PhongBUS.SearchBy(HamHoTro.ChuyenKhongDau(txtThongTin.Text), "TenLP");
                        break;
                    default:
                        MessageBox.Show("Xin chọn loại tìm kiếm");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void txtThongTin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbxTimKiem.Text == "Số Lượng Người")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            else
            {
                e.Handled = false;
            }
        }
        private bool KiemTra()
        {
            return true;
        }
        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if(KiemTra())
                {
                    lp.MaLP = gridView1.GetFocusedRowCellDisplayText(colMaLP);
                    lp.SoNguoiMax = (int)gridView1.GetFocusedRowCellValue(colSoNguoiMax);
                    lp.Gia = float.Parse(gridView1.GetFocusedRowCellDisplayText(colGia));
                    lp.MoTa = gridView1.GetFocusedRowCellDisplayText(colMoTa);
                    lp.TenLP = gridView1.GetFocusedRowCellDisplayText(colTenLP);
                    LoaiPhongBUS.Update(lp);
                    ph.MaLP = lp.MaLP;
                    ph.MaPhong = gridView1.GetFocusedRowCellDisplayText(colMaPhong);
                    ph.SDTPhong = gridView1.GetFocusedRowCellDisplayText(colSDT);
                    ph.HienTrang = gridView1.GetFocusedRowCellDisplayText(colHienTrang);
                    PhongBUS.Update(ph);
                    LoadData();
                    MessageBox.Show("Chỉnh sửa thành công", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PhongBUS.Delete(gridView1.GetFocusedRowCellDisplayText(colMaPhong));
                    LoadData();
                    MessageBox.Show("Xóa Thành Công!", "Thông Báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnInDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (saveFileDialog1.FilterIndex == 1)
                    gridView1.ExportToPdf(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 2)
                    gridControl1.ExportToXls(saveFileDialog1.FileName);
                if (saveFileDialog1.FilterIndex == 3)
                    gridControl1.ExportToRtf(saveFileDialog1.FileName);
            }
        }

       
    }
}
