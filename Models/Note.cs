using NotelyRestApi.Models;

namespace NotelyRestApi.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string subject { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastModified { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
