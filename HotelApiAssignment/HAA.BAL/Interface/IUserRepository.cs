using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HAA.BAL.Interface
{
    public interface IUserRepository
    {
        bool Login(string userName, string password);
    }
}
