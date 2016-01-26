using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QUANLYKHACHSAN.PresentationLayers
{
    public partial class frmThayDoiQuyDinh : Form
    {
        SqlDataProvider provider = new SqlDataProvider();
        DataTable dt = new DataTable();
        public frmThayDoiQuyDinh()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                using (var cmd = new SqlCommand("Select * from ThamSo", provider.GetConnection()))
                {
                    cmd.CommandType = CommandType.Text;
                    var da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    txtTienGio.Text = dt.Rows[0]["TienGio"].ToString();
                    txtTienNgay.Text = dt.Rows[0]["TienNgay"].ToString();
                    txtSoPhongMax.Text = dt.Rows[0]["SoPhongMax"].ToString();
                    txtThue.Text = dt.Rows[0]["ThueVAT"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

       
        bool KiemTra()
        {
            if(txtTienGio.Text=="" || txtSoPhongMax.Text =="" || txtTienNgay.Text == "" || txtThue.Text =="")
            {
                if(MessageBox.Show("Chưa nhập giá trị đầy đủ. Tiếp tục sử dụng giá trị ban đầu?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    if (txtTienGio.Text == "") txtTienGio.Text = dt.Rows[0]["TienGio"].ToString();
                    if (txtTienNgay.Text == "") txtTienNgay.Text = dt.Rows[0]["TienNgay"].ToString();
                    if (txtSoPhongMax.Text == "") txtSoPhongMax.Text = dt.Rows[0]["SoPhongMax"].ToString();
                    if (txtThue.Text == "") txtThue.Text = dt.Rows[0]["ThueVAT"].ToString();
                    return true;
                }
                return false;
                
            }
            return true;
        }
        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                if(KiemTra())
                {
                    using (var cmd = new SqlCommand("SP_ThamSo_ThayDoiQuyDinh", provider.GetConnection()))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@TienGio", Convert.ToDouble(txtTienGio.Text)));
                        cmd.Parameters.Add(new SqlParameter("@TienNgay", Convert.ToDouble(txtTienNgay.Text)));
                        cmd.Parameters.Add(new SqlParameter("@SoPhongMax", Convert.ToInt16(txtSoPhongMax.Text)));
                        cmd.Parameters.Add(new SqlParameter("@ThueVAT", Convert.ToDouble(txtThue.Text)));
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Thay đổi thành công", "Thông báo");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtTienGio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTienNgay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSoPhongMax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
