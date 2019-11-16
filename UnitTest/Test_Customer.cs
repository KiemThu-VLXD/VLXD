using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Customer
    {
        KhachHangBUS khBUS;
        KhachHang kh;

        [TestMethod]
        public void Test_AddKhachHang_Suscess()
        {
            khBUS = new KhachHangBUS();
            kh = new KhachHang();
            kh.HoKH = "XXXXX";
            kh.TenKH = "YYYYYOOOO";
            kh.GioiTinh = "Nu";
            kh.DiaChi = "123";
            kh.DienThoai = "321";
            khBUS.AddKHBUS(kh);
            // Sau khi add thi co them X+1 nguoi
            Assert.AreEqual(29, khBUS.LoadKHBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateKhachHang_Suscess()
        {
            kh = new KhachHang();
            kh.MaKH = 34;
            kh.HoKH = "XXXXX";
            kh.TenKH = "MMMMM";
            kh.GioiTinh = "NU";
            kh.DiaChi = "1234 Nguyễn Văn Linh";
            kh.DienThoai = "038123246";

            khBUS = new KhachHangBUS();
       
            khBUS.UpdateKHBUS(kh);
            // Sau khi update co 1 hang thay doi
            Assert.AreEqual(1, khBUS.SearchTenKHBUS(kh.TenKH).Count);
        }
        [TestMethod]
        public void Test_DeleteKhachHang_Success()
        {
            khBUS = new KhachHangBUS();
            khBUS.DeleteKHBUS(32); // Ma KH
            // Sau khi xoa con lai X -1 nguoi
            Assert.AreEqual(26, khBUS.LoadKHBUS().Count); //So luong KH con lai sau khi xoa
        }

        [TestMethod]
        public void Test_SearchMaKhachHang_Suscess()
        {
            khBUS = new KhachHangBUS();
            // Nhap ma Customer can search
            Assert.AreEqual(1, khBUS.SearchMaKHBUS(38).Count);
        }
        [TestMethod]
        public void Test_SearchMaKhachHang_Fail()
        {
            khBUS = new KhachHangBUS();
            Assert.AreEqual(0, khBUS.SearchMaKHBUS(11).Count);
        }

        [TestMethod]
        public void Test_SearchTenKhachHang_Suscess()
        {
            khBUS = new KhachHangBUS();
            Assert.AreEqual(2, khBUS.SearchTenKHBUS("Hằng").Count);
        }
        [TestMethod]
        public void Test_SearchTenKhachHang_Fail()
        {
            khBUS = new KhachHangBUS();
            Assert.AreEqual(0, khBUS.SearchTenKHBUS("Tinh tinh").Count);
        }
    }
}
