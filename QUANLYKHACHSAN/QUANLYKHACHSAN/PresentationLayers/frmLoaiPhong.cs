﻿using System;
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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            txtMaLP.Text = LoaiPhongBUS.XuLyMa();
            txtTenLP.Select();
            // This line of code is generated by Data Source Configuration Wizard
            loaiphongTableAdapter1.Fill(qlksDataSet1.LOAIPHONG);
        }

        private Boolean KiemTra()
        {
            if (txtTenLP.Text == "" || txtSoNguoiMax4.Text == "" || txtGiaTinh.Text == "")
            {
                MessageBox.Show("Xin nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Boolean KiemTraMa()
        {
            string tam = DichVuBUS.XuLyMa();
            if (Convert.ToInt32(txtMaLP.Text.Substring(2)) >= Convert.ToInt32(tam.Substring(2)))
            {
                MessageBox.Show("Phiếu này chưa đăng ký!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
             if (KiemTra())
            {
                try
                {
                    LoaiPhong lp = new LoaiPhong();
                    lp.MaLP = txtMaLP.Text;
                    lp.TenLP = txtTenLP.Text;
                    lp.MoTa = txtMoTa.Text;
                    lp.SoNguoiMax = int.Parse(txtSoNguoiMax.Text.ToString());
                    lp.Gia = float.Parse(txtGiaTinh.Text.ToString());
                    LoaiPhongBUS.Insert(lp);
                    LoadData();
                    MessageBox.Show("Thêm thành công.", "Thông báo");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            if (KiemTraMa() && KiemTra())
            {
                try
                {
                    LoaiPhong lp = new LoaiPhong();
                    lp.MaLP = txtMaLP.Text;
                    lp.TenLP = txtTenLP.Text;
                    lp.MoTa = txtMoTa.Text;
                    lp.SoNguoiMax = int.Parse(txtSoNguoiMax.Text.ToString());
                    lp.Gia = float.Parse(txtGiaTinh.Text.ToString());
                    LoaiPhongBUS.Update(lp);
                    LoadData();
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
            txtMaLP.EditValue = LoaiPhongBUS.XuLyMa();
            txtTenLP.ResetText();
            txtMoTa.ResetText();
            txtSoNguoiMax.ResetText();
            txtGiaTinh.ResetText();
            txtTenLP.Select();
        }

        private void btnInDanhSach_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "File PDF|*.pdf|Excel|*.xls|Text rtf|*.rtf";
            saveFileDialog1.Title = "Xuất danh sách loại phòng";
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

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LoaiPhongBUS.Delete(gridView1.GetFocusedRowCellValue(colMaLP).ToString());
                    LoadData();
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
            try
            {
                LoaiPhong lp = new LoaiPhong();
                lp.MaLP = gridView1.GetFocusedRowCellValue(colMaLP).ToString();
                lp.TenLP = gridView1.GetFocusedRowCellValue(colTenLP).ToString();
                lp.MoTa = gridView1.GetFocusedRowCellValue(colMoTa).ToString();
                lp.SoNguoiMax = int.Parse(gridView1.GetFocusedRowCellValue(colSoNguoiMax).ToString());
                lp.Gia = float.Parse(gridView1.GetFocusedRowCellValue(colGia).ToString());
                LoaiPhongBUS.Update(lp);
                LoadData();
                MessageBox.Show("Chỉnh sửa thành công.", "Thông báo");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            txtMaLP.Text = gridView1.GetFocusedRowCellDisplayText(colMaLP);
            txtTenLP.Text = gridView1.GetFocusedRowCellDisplayText(colTenLP);
            txtMoTa.Text = gridView1.GetFocusedRowCellDisplayText(colMoTa);
            txtSoNguoiMax.Text = gridView1.GetFocusedRowCellDisplayText(colSoNguoiMax);
            txtGiaTinh.Text = gridView1.GetFocusedRowCellDisplayText(colGia); 
        }
    }
}
