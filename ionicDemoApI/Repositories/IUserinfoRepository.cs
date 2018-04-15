using ionicDemoApI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Repositories
{
    public interface IUserinfoRepository
    {
        IEnumerable<Role> GetRoles();
        Role GetRole(int roleId, bool includeUsers);
        IEnumerable<User> GetUsersForRole(int roleId);
        User GetUserForRole(int roleId, int userId);
    }
}
