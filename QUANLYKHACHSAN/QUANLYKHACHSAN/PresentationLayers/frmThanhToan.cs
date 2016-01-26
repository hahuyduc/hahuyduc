﻿using DevExpress.XtraEditors.Controls;
using QUANLYKHACHSAN.BUS;
using QUANLYKHACHSAN.Object;
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
    public partial class frmThanhToan : Form
    {
        DataTable DanhSachChuaTT = PhieuThanhToanBUS.DanhSachChuaTT();
        private string MaNV;
        public frmThanhToan()
        {
            InitializeComponent();
            thamsoTableAdapter1.Fill(qlksDataSet1.ThamSo);
            // This line of code is generated by Data Source Configuration Wizard
            
        }

        public frmThanhToan(string MaNV)
        {
            // TODO: Complete member initialization
            this.MaNV = MaNV;
            InitializeComponent();
            thamsoTableAdapter1.Fill(qlksDataSet1.ThamSo);
        }

        void LoadGridView()
        {
            try
            {
                phieuthanhtoanTableAdapter1.Fill(qlksDataSet2.PHIEUTHANHTOAN);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            LoadMaPDK();
            LoadGridView();
            cbxMaPDK.ItemIndex = 0;
        }

        private void LoadMaPDK()
        {
            try
            {
                DanhSachChuaTT = PhieuThanhToanBUS.DanhSachChuaTT();
                cbxMaPDK.Properties.DataSource = DanhSachChuaTT;
                cbxMaPDK.Properties.DisplayMember = "MaPDK";
                cbxMaPDK.Properties.ValueMember = "MaPDK";
                //cbxMaPDK.Properties.PopulateColumns();
                cbxMaPDK.Properties.Columns.Add(new LookUpColumnInfo("MaPDK"));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        
        private void cbxMaPDK_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtTienPhatSinh.Text = "0";
                txtTraTruoc.Text = "0";
                txtMaKH.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["MaKH"].ToString();
                txtTenKH.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["TenKH"].ToString();
                txtMaPTT.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["MaPTT"].ToString();
                dateNgayDangKy.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["NgayDangKy"].ToString();
                dateNgayNhanPhong.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["NgayNhanPhong"].ToString();
                dateNgayTraPhong.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["NgayTraPhong"].ToString();
                TinhToan();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void TinhToan()
        {
            try
            {
                if (PhieuThanhToanBUS.TongTienDichVu(cbxMaPDK.Text)==null)
                {
                    txtTienDichVu.Text = "0";
                }
                else
                {
                    txtTienDichVu.Text = PhieuThanhToanBUS.TongTienDichVu(cbxMaPDK.Text).ToString();
                }
                txtTienPhong.Text = DanhSachChuaTT.Rows[cbxMaPDK.ItemIndex]["TongTien"].ToString();
                if (txtTienPhong.Text == "") txtTienPhong.Text = "0";
                double tongtien = Convert.ToDouble(txtTienPhong.Text) + Convert.ToDouble(txtTienDichVu.Text) + Convert.ToDouble(txtTienPhatSinh.Text);
                txtTongTien.Text = tongtien.ToString();
                txtThue.Text = qlksDataSet1.ThamSo.Rows[0]["ThueVAT"].ToString();
                //Thanh Toan = Tong Tien + TongTien/Thue - Tra Truoc
                double tienthue = tongtien / (Convert.ToDouble(txtThue.Text));
                txtTienThanhToan.Text = (tongtien + tienthue - Convert.ToDouble(txtTraTruoc.Text)).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                
                if(txtMaPTT.Text =="")
                {
                    PhieuThanhToan ptt = new PhieuThanhToan();
                    //TinhToan();
                    ptt.MaPTT = PhieuThanhToanBUS.XuLyMa();
                    ptt.MaPDK = cbxMaPDK.Text;
                    ptt.MaNV = this.MaNV;
                    ptt.NgayLap = DateTime.Now;
                    ptt.Thue = Convert.ToDouble(txtThue.Text);
                    ptt.PhatSinh = Convert.ToDouble(txtTienPhatSinh.Text);
                    ptt.TienPhaiTra = Convert.ToDouble(txtTienThanhToan.Text);
                    PhieuThanhToanBUS.Insert(ptt);
                    txtMaPTT.Text = ptt.MaPTT;
                    LoadGridView();
                    MessageBox.Show("Thanh toán thành công", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Phiếu này đã thanh toán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTienPhatSinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTraTruoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private Form KiemTraTonTai(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }

            return null;
        }
        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                Form frm = KiemTraTonTai(typeof(PresentationLayers.frmHoaDonThanhToan));
                if (frm != null)
                {
                    frm.Activate();
                }
                else
                {
                    Hashtable ThongTinHoaDon = new Hashtable();
                    ThongTinHoaDon.Add("MaPTT", txtMaPTT.Text);
                    ThongTinHoaDon.Add("MaPDK", cbxMaPDK.Text);
                    ThongTinHoaDon.Add("MaKH", txtMaKH.Text);
                    ThongTinHoaDon.Add("TenKH", txtTenKH.Text);
                    ThongTinHoaDon.Add("TienPhong", txtTienPhong.Text);
                    ThongTinHoaDon.Add("TienDichVu", txtTienDichVu.Text);
                    ThongTinHoaDon.Add("PhatSinh", txtTienPhatSinh.Text);
                    ThongTinHoaDon.Add("Thue", txtThue.Text);
                    ThongTinHoaDon.Add("TongTienPhaiTra", txtTienThanhToan.Text);
                    ThongTinHoaDon.Add("NgayLap", DateTime.Now.ToShortDateString());
                    PresentationLayers.frmHoaDonThanhToan f = new PresentationLayers.frmHoaDonThanhToan(ThongTinHoaDon);
                    f.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        bool KiemTra()
        {
            
            return true;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if(KiemTra())
                {
                    PhieuThanhToan ptt = new PhieuThanhToan();
                    TinhToan();
                    ptt.MaPTT = gridView1.GetFocusedRowCellDisplayText(colMaPTT);
                    ptt.PhatSinh = Convert.ToDouble(txtTienPhatSinh.Text);
                    ptt.TienPhaiTra = Convert.ToDouble(txtTienThanhToan.Text);
                    PhieuThanhToanBUS.Update(ptt);
                    LoadGridView();
                    MessageBox.Show("Sửa phiếu thành công.", "Thông Báo");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu thanh toán này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(rs == DialogResult.Yes)
                {
                    PhieuThanhToanBUS.Delete(gridView1.GetFocusedRowCellDisplayText(colMaPTT));
                    LoadGridView();
                    LoadMaPDK();
                    MessageBox.Show("Xóa thành công", "Thông báo");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            cbxMaPDK.Text = gridView1.GetFocusedRowCellDisplayText(colMaPDK);
            txtTienPhatSinh.Text = gridView1.GetFocusedRowCellDisplayText(colPhatSinh);
        }
    }
}