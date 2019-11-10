using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO.Entity;

namespace DAO
{
    public class NhanVienDAO
    {
        VLXD db = new VLXD();

        public List<NhanVien> LoadNVDAO()
        {
            return db.NhanVien.ToList();
        }
        public void AddNVDAO(NhanVien nv)
        {
            db.NhanVien.Add(nv);
            db.SaveChanges();
        }

       
    }
}
