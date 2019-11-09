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
        NhanVienBUS nvBUS = new NhanVienBUS();
        HoaDonBUS hdBUS = new HoaDonBUS();
        ChiTietHDBUS cthdBUS = new ChiTietHDBUS();
        KhachHangBUS khBUS = new KhachHangBUS();

        private void fDatHang_Load(object sender, EventArgs e)
        {
            LoadKH();
            LoadHD();

            dgvSP.AutoGenerateColumns = false;
            dgvSP.DataSource = spBUS.LoadSPBUS();

            cbMaKHang.DataSource = khBUS.LoadKHBUS();
            cbMaKHang.DisplayMember = "MaKH";

            cbMaNVien.DataSource = nvBUS.LoadNVBUS();
            cbMaNVien.DisplayMember = "MaNV";

            cbMaSPham.DataSource = spBUS.LoadSPBUS();
            cbMaSPham.DisplayMember = "MaSP";
        }