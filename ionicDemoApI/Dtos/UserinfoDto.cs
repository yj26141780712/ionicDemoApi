using ionicDemoApI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Dtos
{
    public class RoleDto
    {
        public RoleDto()
        {
            Users = new List<User>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public ICollection<User> Users { get; set; }
        public int UserCount => Users.Count;
    }
    public class RoleWithoutUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
    }
    public class UserDto
    {
        
    }
}
