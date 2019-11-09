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

namespace VLXD
{
    public partial class fDatHang : Form
    {
        public fDatHang()
        {
            InitializeComponent();
        }

        SanPhamBUS spBUS = new SanPhamBUS();
       
        KhachHangBUS khBUS = new KhachHangBUS();

        private void fDatHang_Load(object sender, EventArgs e)
        {
            LoadKH();
            
            cbMaKHang.DataSource = khBUS.LoadKHBUS();
            cbMaKHang.DisplayMember = "MaKH";

            
        }
        #region Khách hàng
        //Hiển thị KH
        private void LoadKH()
        {
            dgvKH.AutoGenerateColumns = false;
            dgvKH.DataSource = khBUS.LoadKHBUS();
        }

        private void tabKH_Click(object sender, EventArgs e)
        {
            LoadKH();
            txtMaKH.Text = "";
            txtHoKH.Text = "";
            txtTenKH.Text = "";
            txtDiaChiKH.Text = "";
            txtSdtKH.Text = "";
            txtTimKH.Text = "";
        }

        private void dgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {
                txtMaKH.Text = dgvKH.Rows[row].Cells[0].Value.ToString();
                txtHoKH.Text = dgvKH.Rows[row].Cells[1].Value.ToString();
                txtTenKH.Text = dgvKH.Rows[row].Cells[2].Value.ToString();

                if (dgvKH.Rows[row].Cells[3].Value.ToString() == "Nam")
                {
                    rdbNamKH.Checked = true;
                }
                else
                {
                    rdbNuKH.Checked = true;
                }

                txtDiaChiKH.Text = dgvKH.Rows[row].Cells[4].Value.ToString();
                txtSdtKH.Text = dgvKH.Rows[row].Cells[5].Value.ToString();
            }
        }

        //Thêm KH
        private void AddKH()
        {
            KhachHang khToAdd = new KhachHang();
            khToAdd.HoKH = txtHoKH.Text;
            khToAdd.TenKH = txtTenKH.Text;
            if (rdbNamKH.Checked == true)
            {
                khToAdd.GioiTinh = "Nam";
            }
            else
            {
                khToAdd.GioiTinh = "Nữ";
            }
            khToAdd.DiaChi = txtDiaChiKH.Text;
            khToAdd.DienThoai = txtSdtKH.Text;

            khBUS.AddKHBUS(khToAdd);
        }

        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (txtHoKH.Text != "" || txtTenKH.Text != "" || txtDiaChiKH.Text != "" || txtSdtKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Thêm một khách hàng mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddKH();
                        LoadKH();
                        MessageBox.Show("Đã thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Đúng và Đầy Đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Sửa KH
        private void UpdateKH()
        {
            KhachHang khToUpdate = new KhachHang();
            khToUpdate.MaKH = int.Parse(txtMaKH.Text);
            khToUpdate.HoKH = txtHoKH.Text;
            khToUpdate.TenKH = txtTenKH.Text;
            if (rdbNamKH.Checked == true)
            {
                khToUpdate.GioiTinh = "Nam";
            }
            else
            {
                khToUpdate.GioiTinh = "Nữ";
            }
            khToUpdate.DiaChi = txtDiaChiKH.Text;
            khToUpdate.DienThoai = txtSdtKH.Text;

            khBUS.UpdateKHBUS(khToUpdate);
        }

        private void btnSuaKH_Click(object sender, EventArgs e)
        {
            if (txtMaKH.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa khách hàng. " + txtMaKH.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateKH();
                        LoadKH();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn khách hàng muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Tìm KH
        private void txtTimKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKH_Click(sender, e);
            }
        }

        private void txtTimKH_Click(object sender, EventArgs e)
        {
            txtTimKH.Text = "";
            txtTimKH.ForeColor = Color.Black;
        }

        private void SearchKH()
        {
            if (rdbTimMaKH.Checked == true)
            {
                int key = int.Parse(txtTimKH.Text);
                dgvKH.DataSource = khBUS.SearchMaKHBUS(key);
            }
            else
            {
                string key = txtTimKH.Text;
                dgvKH.DataSource = khBUS.SearchTenKHBUS(key);
            }

        }

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            if (txtTimKH.Text != "" && txtTimKH.Text != "Nhập từ khóa............")
            {
                SearchKH();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #region Button

        private void btnQLy_Click(object sender, EventArgs e)
        {
            fDangNhapQuanLy f = new fDangNhapQuanLy();
            f.Show();
            this.Hide();
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            switch (result)
            {
                case DialogResult.No:
                    break;
                case DialogResult.Yes:
                    fDangNhap f = new fDangNhap();
                    f.Show();
                    this.Hide();
                    break;
                default:
                    break;
            }
        }

        private void btnTaiKhoan_Click(object sender, EventArgs e)
        {
            fTaiKhoan f = new fTaiKhoan();
            f.Show();
            this.Hide();
        }

        #endregion
        #region Sản phẩm

        private void txtTimSP_Click(object sender, EventArgs e)
        {
            txtTimSP.Text = "";
            txtTimSP.ForeColor = Color.Black;
        }

        private void txtTimSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimSP_Click(sender, e);
            }
        }

        private void SearchSP()
        {

            if (rdbTimMaSP.Checked)
            {
                int key = int.Parse(txtTimSP.Text);
                dgvSP.DataSource = spBUS.SearchMaSPBUS(key);
            }
            else
            {
                string key = txtTimSP.Text;
                dgvSP.DataSource = spBUS.SearchTenSPBUS(key);
            }
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            if (txtTimSP.Text != "" && txtTimSP.Text != "Nhập từ khóa............")
            {
                SearchSP();
            }
            else
            {
                MessageBox.Show("Hãy nhập từ khóa để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
