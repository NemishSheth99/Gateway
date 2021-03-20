using HAA.DAL.Database;
using System;
using System.Linq;

namespace HAA.DAL.Repository
{
    public static class UserRepository 
    {
        private static WebApiAssEntities _context = new WebApiAssEntities();

        public static bool UserLogin(string name, string password)
        {
            return _context.tblUsers.Any(u => u.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && u.Password == password);
        }
    }
}
