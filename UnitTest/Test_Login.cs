using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_Login
    {
        TaiKhoanBUS uBUS;

        [TestMethod]
        public void Test_LoginByNhanVien()
        {
            uBUS = new TaiKhoanBUS();
            // 2 là Nhân viên
            int expected = 2;
            int actual = uBUS.DangNhapBUS("Huy", "123");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_LoginByQuanLy()
        {
            uBUS = new TaiKhoanBUS();
            // 1 là Quản lý
            int expected = 1;
            int actual = uBUS.DangNhapBUS("Long", "123");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Login_Sai_ID()
        {
            uBUS = new TaiKhoanBUS();

            int expected = -1;
            int actual = uBUS.DangNhapBUS("LongLong", "123");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_Login_Sai_Pass()
        {
            uBUS = new TaiKhoanBUS();

            int expected = -2;
            int actual = uBUS.DangNhapBUS("Long", "321");

            Assert.AreEqual(expected, actual);
        }
    }
}