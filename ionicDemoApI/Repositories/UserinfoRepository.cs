using ionicDemoApI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Repositories
{
    public class UserinfoRepository:IUserinfoRepository
    {
        private readonly MyContext _myContext;
        public UserinfoRepository(MyContext myContext) //依赖注入
        {
            _myContext = myContext;
        }

        public IEnumerable<Role> GetRoles()
        {
            return _myContext.Roles.OrderBy(x=>x.Name).ToList();
        }

        public Role GetRole(int roleId,bool includeUsers)
        {
            if (includeUsers)
            {
                return _myContext.Roles.Include(x => x.Users).FirstOrDefault(x => x.Id == roleId);
            }
            return _myContext.Roles.Find(roleId);
        }

        public IEnumerable<User> GetUsersForRole(int roleId)
        {
            return _myContext.Users.Where(x=>x.RoleId==roleId).ToList();
        }

        public User GetUserForRole(int roleId,int userId)
        {
            return _myContext.Users.FirstOrDefault(x => x.RoleId == roleId && x.Id == userId);
        }
    }
}
