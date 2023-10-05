using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            string so1 = txtSo1.Text;
            string so2 = txtSo2.Text;
            try
            {
                if( so1.Contains(",") || so1.Contains(".") )
                {
                    decimal so1Dec = Convert.ToDecimal(so1);
                    if (so2.Contains(",") == false && so2.Contains(".") == false)
                    {
                        
                        BigInteger so2Int = BigInteger.Parse(so2);
                        
                        
                        if (radCong.Checked) txtKq.Text = (so1Dec + Convert.ToDecimal(so2Int)).ToString();
                        else if (radTru.Checked) txtKq.Text = (so1Dec - Convert.ToDecimal(so2Int)).ToString();
                        else if (radNhan.Checked) txtKq.Text = (so1Dec * Convert.ToDecimal(so2Int)).ToString();
                        else if (radChia.Checked)
                        {
                            if (so2Int == 0)
                            {
                                DialogResult dr;
                                dr = MessageBox.Show("Số chia phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (dr == DialogResult.OK)
                                    txtSo2.Focus();
                            }
                            else
                            {
                                txtKq.Text = (so1Dec / Convert.ToDecimal(so2Int)).ToString();
                            }
                        }
                           
                    }
                    else if (so2.Contains(",") || so2.Contains(".")) 
                    {
                        decimal so2Dec = decimal.Parse(so2);
                        if(so2Dec == 0)
                        {
                            DialogResult dr;
                            dr = MessageBox.Show("Số chia phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            if (dr == DialogResult.OK)
                                txtSo2.Focus();
                        }
                        
                        if (radCong.Checked) txtKq.Text = (so1Dec + so2Dec).ToString();
                        else if (radTru.Checked) txtKq.Text = (so1Dec - so2Dec).ToString();
                        else if (radNhan.Checked) txtKq.Text = (so1Dec * so2Dec).ToString();
                        else if (radChia.Checked)
                        {
                            if (so2Dec == 0)
                            {
                                DialogResult dr;
                                dr = MessageBox.Show("Số chia phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (dr == DialogResult.OK)
                                    txtSo2.Focus();
                            }
                            else
                            {
                                txtKq.Text = (so1Dec / so2Dec).ToString();
                            }
                        }

                    }
                }
                else if (so1.Contains(",") == false && so1.Contains(".") == false)
                {
                    BigInteger so1Int = BigInteger.Parse(so1);
                    if (so2.Contains(",") == false && so2.Contains(".") == false)
                    {
                       
                        BigInteger so2Int = BigInteger.Parse(so2);
                        if (radCong.Checked) txtKq.Text = (so1Int + so2Int).ToString();
                        else if (radTru.Checked) txtKq.Text = (so1Int - so2Int).ToString();
                        else if (radNhan.Checked) txtKq.Text = (so1Int * so2Int).ToString();
                        else if (radChia.Checked)
                        {
                            if (so2Int == 0)
                            {
                                DialogResult dr;
                                dr = MessageBox.Show("Số chia phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (dr == DialogResult.OK)
                                    txtSo2.Focus();
                            }
                            else
                            {
                                txtKq.Text = (so1Int / so2Int).ToString();
                            }
                        }

                    }
                    else if (so2.Contains(",") || so2.Contains("."))
                    {
                        
                        decimal so2Dec = decimal.Parse(so2);
                        if (radCong.Checked) txtKq.Text = (decimal.Parse(so1) + so2Dec).ToString();
                        else if (radTru.Checked) txtKq.Text = (decimal.Parse(so1) - so2Dec).ToString();
                        else if (radNhan.Checked) txtKq.Text = (decimal.Parse(so1) * so2Dec).ToString();
                        else if (radChia.Checked)
                        {
                            if (so2Dec == 0)
                            {
                                DialogResult dr;
                                dr = MessageBox.Show("Số chia phải khác 0", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (dr == DialogResult.OK)
                                    txtSo2.Focus();
                            }
                            else
                            {
                                txtKq.Text = (Convert.ToDecimal(so1Int) / so2Dec).ToString();
                            }
                        }
                    }
                }
                
            }
            catch(Exception ex) 
            {
                if (so1 == "" || so2 == "")
                {
                    MessageBox.Show("Dữ liệu nhập vào không chứa ký tự và không để trống", "Thông báo", MessageBoxButtons.OK);
                    if(so1 == "")
                    {
                        txtSo1.Focus();
                    }
                    else if(so2 == "")
                    {
                        txtSo2.Focus();
                    }
                    
                }
                else
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }
            //lấy giá trị của 2 ô số
           /* decimal so1, so2, kq = 0;
            so1 = decimal.Parse(txtSo1.Text);
            so2 = decimal.Parse(txtSo2.Text);
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked && so2 != 0) kq = so1 / so2;
            //Hiển thị kết quả lên trên ô kết quả
            txtKq.Text = kq.ToString();*/
        }
    }
}
