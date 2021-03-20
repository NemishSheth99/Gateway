using HAA.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.BAL
{
    public static class UserManager
    {

        public static bool UserLogin(string name, string password)
        {
            return UserRepository.UserLogin(name, password);
        }
    }
}
