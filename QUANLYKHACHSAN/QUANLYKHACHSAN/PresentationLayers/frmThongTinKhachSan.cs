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
    public partial class frmThongTinKhachSan : Form
    {
        public frmThongTinKhachSan()
        {
            InitializeComponent();
        }

        private void frmThongTinKhachSan_Load(object sender, EventArgs e)
        {
            List<string> ThongTinKhacSan = KhachSanBUS.GetAll();
            txtTenKhachSan.Text = ThongTinKhacSan[0];
            txtDiaChi.Text = ThongTinKhacSan[1];
            txtSDT.Text = ThongTinKhacSan[2];
            txtEmail.Text = ThongTinKhacSan[3];
            txtWebSite.Text = ThongTinKhacSan[4];
            TxtChuThich.Text = ThongTinKhacSan[5];

        }

        private Boolean KiemTra()
        {
            if (txtTenKhachSan.Text == "" || txtDiaChi.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtWebSite.Text == "" || TxtChuThich.Text == "")
            {
                MessageBox.Show("Xin nhập đầy đủ thông tin!", "thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        bool edit;
        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {
           /* try
            {*/
                if (edit)
                {
                    edit = false;
                    btnSuaThongTin.Text = "Sữa thông tin.";
                    KhachSan ks = new KhachSan();
                    ks.TenKhachSan = txtTenKhachSan.Text;
                    ks.DiaChi = txtDiaChi.Text;
                    ks.Email = txtEmail.Text;
                    ks.SDT = txtSDT.Text;
                    ks.Website = txtWebSite.Text;
                    ks.ChuThich = TxtChuThich.Text;
                    KhachSanBUS.Update(ks);
                    txtTenKhachSan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtWebSite.Enabled = TxtChuThich.Enabled = txtEmail.Enabled = false;

                }

                else
                {
                    edit = true;
                    btnSuaThongTin.Text = "Hoàn Thành";
                    txtTenKhachSan.Enabled = txtDiaChi.Enabled = txtSDT.Enabled = txtWebSite.Enabled = TxtChuThich.Enabled = txtEmail.Enabled = true;
                }
            /*}
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        
    }
}
