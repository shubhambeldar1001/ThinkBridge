using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class TeamMember
    {
       public int TeamMemberId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        //public int UserId { get; set; }

        //public Team Team { get; set; }
        public ICollection<User> User { get; set; }
    }
}
