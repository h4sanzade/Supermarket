using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_1.Models;

namespace Project_1.Services
{
    public class AdminService
    {
        private List<Admin> admins = new List<Admin>();

        // Bu Register methodu admin yaratsın deyə var. kod çalışdığından sonra 1 dəfə çağırılır.
        public void Register(Admin admin)
        {
            admins.Add(admin);
        }

        public Admin Login(string username, string password)
        {
            return admins.FirstOrDefault(a => a.UserName == username && a.Password == password);
        }
    }
}
