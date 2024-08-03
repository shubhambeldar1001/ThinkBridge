using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class TaskNote
    {
        [Key]
        public int NoteId { get; set; }

        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public string NoteContent { get; set; }
        public DateTime CreatedAt { get; set; }

       
       // public TaskOffice Task { get; set; }
        //public User User { get; set; }
    }
}
