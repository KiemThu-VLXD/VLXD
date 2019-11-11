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
            LoadNV();
           

            cbMaNV.DataSource = nvBUS.LoadNVBUS();
            cbMaNV.DisplayMember = "MaNV";

           

            cbMaNVien.DataSource = nvBUS.LoadNVBUS();
            cbMaNVien.DisplayMember = "MaNV";

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

        #region NhanVien
        NhanVienBUS nvBUS = new NhanVienBUS();

        private void LoadNV()
        {
            dgvNV.AutoGenerateColumns = false;
            dgvNV.DataSource = nvBUS.LoadNVBUS();
        }

        private void tabNV_Click(object sender, EventArgs e)
        {
            LoadNV();
            txtMaNV.Text = "";
            txtHoNV.Text = "";
            txtTenNV.Text = "";
            txtDiaChiNV.Text = "";
            txtSdtNV.Text = "";
            txtTimNV.Text = "";
            dtpNgaySinhNV.Value = new DateTime(1998, 1, 1);
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaNV.Text = dgvNV.Rows[row].Cells[0].Value.ToString();
                txtHoNV.Text = dgvNV.Rows[row].Cells[1].Value.ToString();
                txtTenNV.Text = dgvNV.Rows[row].Cells[2].Value.ToString();

                if (dgvNV.Rows[row].Cells[3].Value.ToString() == "Nam")
                {
                    rdbNamNV.Checked = true;
                }
                else
                {
                    rdbNuNV.Checked = true;
                }

                dtpNgaySinhNV.Value = DateTime.Parse(dgvNV.Rows[row].Cells[4].Value.ToString());
                txtDiaChiNV.Text = dgvNV.Rows[row].Cells[5].Value.ToString();
                txtSdtNV.Text = dgvNV.Rows[row].Cells[6].Value.ToString();
            }
        }

       

        #endregion
    }
}