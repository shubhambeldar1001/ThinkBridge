using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class TaskOffice
    {
        [Key]
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       // public int AssignedTo { get; set; }
        //public int CreatedBy { get; set; }
        public DateTime DueDate { get; set; }

        [DefaultValue("Pending")]
        public string Status { get; set; }  // Pending, In Progress, Completed

        public User AssignedUser { get; set; }
        public User CreatedUser { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string NoteContent { get; set; }

        [ForeignKey("AssignedUserId")]
        public int AssignedUserId { get; set; }
    }
}
