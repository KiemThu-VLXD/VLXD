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