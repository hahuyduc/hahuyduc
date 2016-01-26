using QUANLYKHACHSAN.BUS;
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
    public partial class frmDoiMatKhau : Form
    {
        string MaNV = "";
        public frmDoiMatKhau(string MaNV)
        {
            InitializeComponent();
            this.MaNV = MaNV;
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            if(txtMatKhauMoi.Text == txtNhapLai.Text)
            {
                if(NhanVienBUS.DoiMatKhau(MaNV,HamHoTro.MaHoa(txtMatKhauCu.Text,true),HamHoTro.MaHoa(txtMatKhauMoi.Text,true))==1)
                {
                    MessageBox.Show("Đổi mật khẩu thành công","Thông báo",MessageBoxButtons.OK);
                }
                else 
                {
                    MessageBox.Show("Mật khẩu cũ không đúng. Xin nhập lại");
                    txtMatKhauCu.Focus();
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu mới không trùng khớp","Thông báo");
                txtNhapLai.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmDoiMatKhau_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }
    }
}
