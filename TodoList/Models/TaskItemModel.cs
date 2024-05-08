using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TaskItemModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Task Text")]
        [StringLength(30, MinimumLength = 3)]
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Deadline { get; set; } = DateTime.Now;
        [Required]
        [DefaultValue(0)]
        public byte Finished { get; set; }
    }
}
