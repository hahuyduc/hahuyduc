using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QUANLYKHACHSAN.BUS;
using QUANLYKHACHSAN.Support;

namespace QUANLYKHACHSAN.PresentationLayers
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        public string MaNV { set; get; }
        public string TenNV { set; get; }
        public string ChucVu { set; get; }
        public int Quyen { set; get; }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTenDangNhap.Text != "" && txtMatKhau.Text != "")
                {
                    string matkhau = HamHoTro.MaHoa(txtMatKhau.Text, true);
                    if (NhanVienBUS.DangNhap(cbxTenDangNhap.Text, matkhau) == 1)
                    {
                        sP_NhanVien_ThongTinDangNhapTableAdapter.Fill(qLKSDataSet.SP_NhanVien_ThongTinDangNhap, cbxTenDangNhap.Text, matkhau);
                        MaNV = qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["MaNV"].ToString();
                        TenNV = qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["TenNV"].ToString();
                        ChucVu = qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["TenCV"].ToString();
                        Quyen = Convert.ToInt16(qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["Quyen"]);
                        MessageBox.Show("Đăng nhập thành công");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Sai ID hoặc Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Nhập ID và PASSWORD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MaNV == null)
            {
                Application.Exit();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (cbxTenDangNhap.Text != "" && txtMatKhau.Text != "")
                    {
                        string matkhau = HamHoTro.MaHoa(txtMatKhau.Text, true);
                        if (NhanVienBUS.DangNhap(cbxTenDangNhap.Text, matkhau) == 1)
                        {
                            sP_NhanVien_ThongTinDangNhapTableAdapter.Fill(qLKSDataSet.SP_NhanVien_ThongTinDangNhap, cbxTenDangNhap.Text, matkhau);
                            MaNV = qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["MaNV"].ToString();
                            TenNV = qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["TenNV"].ToString();
                            ChucVu = qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["TenCV"].ToString();
                            Quyen = Convert.ToInt16(qLKSDataSet.SP_NhanVien_ThongTinDangNhap.Rows[0]["Quyen"]);
                            MessageBox.Show("Đăng nhập thành công");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sai ID hoặc Password!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nhập ID và PASSWORD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
