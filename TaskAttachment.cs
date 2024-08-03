using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagementSystem.Models
{
    public class TaskAttachment
    {
        [Key]
        //public int TaskAttachmentId { get; set; } // Primary Key

        [ForeignKey("TaskId")]
        public int TaskId { get; set; }
        public string FilePath { get; set; }
        public string UploadedBy { get; set; }
        public DateTime UploadedAt { get; set; }

        
       // public TaskOffice Task { get; set; }
       // public User UploadedUser { get; set; }
    }
}
