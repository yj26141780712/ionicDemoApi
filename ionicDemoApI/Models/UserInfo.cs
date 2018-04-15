using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Des { get; set; }
        public ICollection<User> Users { get; set; }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class RoleCreation
    {

        [Display(Name = "角色名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0}的长度应该不小于{2}, 不大于{1}")]
        public string Name { get; set; }
        public string Des { get; set; }
    }

    public class RoleModification
    {
        public int Id { get; set; }
        [Display(Name = "角色名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "{0}的长度应该不小于{2}, 不大于{1}")]
        public string Name { get; set; }
        public string Des { get; set; }
       // public int MyProperty { get; set; }
    }

    public class UserCreation
    {

    }

    public class Function
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public string ModuleName { get; set; }
        public string page { get; set; }
        public int? index { get; set; } 
        public string icon { get; set; }
        public ICollection<Function> ChildFunc { get; set;}
    }

    //public class ChildFunction
    //{
    //    public int Id { get; set; }
    //    public int ParentId { get; set; }
    //    public string ModuleName { get; set; }
    //    public string path { get; set; }
    //}
}
