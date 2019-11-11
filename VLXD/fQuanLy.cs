using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DAO;
using DTO.Entity;
using DTO;

namespace VLXD
{
    public partial class fQuanLy : Form
    {
        public fQuanLy()
        {
            InitializeComponent();
        }

        private void fQuanLy_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất.", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.Cancel:
                    break;
                case DialogResult.OK:
                    fDangNhap f = new fDangNhap();
                    f.Show();
                    this.Hide();
                    break;
                default:
                    break;
            }
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            fDatHang f = new fDatHang();
            f.Show();
            this.Hide();
        }
    }
}