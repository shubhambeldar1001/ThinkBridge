using System.Collections.Generic;

namespace TaskManagementSystem.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public TeamMember TeamMembers { get; set; }
    }
}