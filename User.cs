using AutoMapper.Configuration.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskManagementSystem.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }  // Engineer, Manager, Admin

        //public ICollection<TeamMember> TeamMembers { get; set; }
        
        //public ICollection<TaskOffice> Tasks { get; set; }
    }
}
