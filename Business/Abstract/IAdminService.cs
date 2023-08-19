using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAdminList();
        void AddAdmin(Admin admin);
        Admin GetById(int id);
        void DeleteAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
    }
}
