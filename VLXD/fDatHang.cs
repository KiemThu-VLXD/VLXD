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

       
       
        #endregion


    }
}
