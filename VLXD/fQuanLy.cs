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

        //Them Nhan Vien
        private void AddNV()
        {
            NhanVien nv = new NhanVien();
            nv.HoNV = txtHoNV.Text;
            nv.TenNV = txtTenNV.Text;
            if (rdbNamNV.Checked)
            {
                nv.GioiTinh = "Nam";
            }
            else
            {
                nv.GioiTinh = "Nữ";
            }
            nv.NgaySinh = dtpNgaySinhNV.Value;
            nv.DiaChi = txtDiaChiNV.Text;
            nv.DienThoai = txtSdtNV.Text;

            nvBUS.AddNVBUS(nv);
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (txtHoNV.Text != "" && txtTenNV.Text != "" && txtDiaChiNV.Text != "" && txtSdtNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn muốn thêm một nhân viên mới?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        AddNV();
                        LoadNV();
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
        //Xoa Nhan Vien
        private void DeleteNV()
        {
            int id = int.Parse(txtMaNV.Text);
            nvBUS.DeleteNVBUS(id);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        DeleteNV();
                        LoadNV();
                        MessageBox.Show("Đã xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhân viên muốn xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Sua Nhan Vien
        private void UpdateNV()
        {
            NhanVien nvToUpdate = new NhanVien();
            nvToUpdate.MaNV = int.Parse(txtMaNV.Text);
            nvToUpdate.HoNV = txtHoNV.Text;
            nvToUpdate.TenNV = txtTenNV.Text;
            if (rdbNamNV.Checked == true)
            {
                nvToUpdate.GioiTinh = "Nam";
            }
            else
            {
                nvToUpdate.GioiTinh = "Nữ";
            }
            nvToUpdate.NgaySinh = dtpNgaySinhNV.Value;
            nvToUpdate.DiaChi = txtDiaChiNV.Text;
            nvToUpdate.DienThoai = txtSdtNV.Text;

            nvBUS.UpdateNVBUS(nvToUpdate);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text != "")
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa nhân viên " + txtMaNV.Text, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
                switch (result)
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        UpdateNV();
                        LoadNV();
                        MessageBox.Show("Đã sửa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                MessageBox.Show("Bạn hãy chọn nhân viên muốn sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        #endregion
    }
}