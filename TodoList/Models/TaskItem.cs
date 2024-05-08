using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TaskItem
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Task Text")]
        [Required]
        public string Text { get; set; } = "";
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        [DefaultValue(0)]
        public byte Finished { get; set; }
    }
}
