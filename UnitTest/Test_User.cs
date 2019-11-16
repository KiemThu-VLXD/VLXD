using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BUS;
using DAO;
using DTO.Entity;

namespace UnitTest
{
    [TestClass]
    public class Test_User
    {
        TaiKhoanBUS userBUS;
        TaiKhoan user;
        [TestMethod]
        public void Test_AddUser_Suscess()
        {
            userBUS = new TaiKhoanBUS();
            
            user = new TaiKhoan();
            user.TenTaiKhoan = "Hoa";
            user.MatKhau = "123";
            user.ChucVu = "Nhân viên";
            user.MaNV = 13;
            userBUS.AddUserBUS(user);

            Assert.AreEqual(8, userBUS.LoadUserBUS().Count);
        }

        [TestMethod]
        public void Test_UpdateUser_Suscess()
        {
            user = new TaiKhoan();
            user.MaTaiKhoan = 10;
            user.TenTaiKhoan = "Hoa123";
            user.MatKhau = "123";
            user.ChucVu = "Nhân viên";
            user.MaNV = 4;

            userBUS = new TaiKhoanBUS();
            
            userBUS.UpdateUserBUS(user);

            Assert.AreEqual(1, userBUS.SearchTenTaiKhoan(user.TenTaiKhoan).Count);
        }
        [TestMethod]
        public void Test_DeleteUser_Success()
        {
            userBUS = new TaiKhoanBUS();
            userBUS.DeleteUserBUS(30);
            Assert.AreEqual(7, userBUS.LoadUserBUS().Count);
        }

        [TestMethod]
        public void Test_SearchMaUser_Suscess()
        {
            userBUS = new TaiKhoanBUS();

            Assert.AreEqual(1, userBUS.SearchMaTaiKhoan(1).Count);
        }
        [TestMethod]
        public void Test_SearchMaUser_Fail()
        {
            userBUS = new TaiKhoanBUS();

            Assert.AreEqual(0, userBUS.SearchMaTaiKhoan(4).Count);
        }
        [TestMethod]
        public void Test_SearchTenUser_Suscess()
        {
            userBUS = new TaiKhoanBUS();

            Assert.AreEqual(1, userBUS.SearchTenTaiKhoan("Long").Count);
        }

        [TestMethod]
        public void Test_SearchTenUser_Fail()
        {
            userBUS = new TaiKhoanBUS();

            Assert.AreEqual(0, userBUS.SearchTenTaiKhoan("Tinh tinh").Count);
        }
    }
}
