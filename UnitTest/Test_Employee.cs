using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Employee
    {
        NhanVienBUS nvBUS;
        NhanVien nv;

        [TestMethod]
        public void Test_AddNhanVien_Suscess()
        {
            nvBUS = new NhanVienBUS();
            int expected = 7;

            nv = new NhanVien();
            nv.HoNV = "Long";
            nv.TenNV = "Linh";
            nv.GioiTinh = "xxx";
            DateTime birthday = new DateTime(1996, 6, 6);
            nv.NgaySinh = birthday;
            nv.DiaChi = "123";
            nv.DienThoai = "321";
            nvBUS.AddNVBUS(nv);

            Assert.AreEqual(8, nvBUS.LoadNVBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateNhanVien_Suscess()
        {
            nvBUS = new NhanVienBUS();
            nv = new NhanVien();
            nv.MaNV = 6;
            nv.HoNV = "BDSH";
            nv.TenNV = "Pass Test";
            nv.GioiTinh = "Nam";
            DateTime birthday = new DateTime(1996, 6, 6);
            nv.NgaySinh = birthday;
            nv.DiaChi = "1234 Nguyễn Văn Linh";
            nv.DienThoai = "038123246";


            Assert.AreEqual(0, nvBUS.SearchTenNVBUS(nv.TenNV).Count);

            nvBUS.UpdateNVBUS(nv);

            Assert.AreEqual(1, nvBUS.SearchTenNVBUS(nv.TenNV).Count);
        }

        [TestMethod]
        public void Test_DeleteNhanVien_Success()
        {
            nvBUS = new NhanVienBUS();
            nvBUS.DeleteNVBUS(12);

            Assert.AreEqual(8, nvBUS.LoadNVBUS().Count);

        }

        [TestMethod]
        public void Test_DeleteNhanVien_Fail()
        {
            //????????????????????
        }


        [TestMethod]
        public void Test_SearchMaNhanVien_Suscess()
        {
            nvBUS = new NhanVienBUS();
            Assert.AreEqual(1, nvBUS.SearchMaNVBUS(6).Count);
        }

        [TestMethod]
        public void Test_SearchMaNhanVien_Fail()
        {
            nvBUS = new NhanVienBUS();
            Assert.AreEqual(0, nvBUS.SearchMaNVBUS(7).Count);
        }

        [TestMethod]
        public void Test_SearchTenNhanVien_Suscess()
        {
            nvBUS = new NhanVienBUS();
            Assert.AreEqual(1, nvBUS.SearchTenNVBUS("An").Count);
        }

        [TestMethod]
        public void Test_SearchTenNhanVien_Fail()
        {
            nvBUS = new NhanVienBUS();
            Assert.AreEqual(0, nvBUS.SearchTenNVBUS("Tinh tinh").Count);
        }

    }
}
