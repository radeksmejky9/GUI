using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoList.Models;

namespace TodoList.Pages
{
    public class _TaskPartialModel : PageModel
    {
        public TaskItemModel Task { get; private set; }
        public bool IsEditing { get; set; } = false;
        public _TaskPartialModel(TaskItemModel task)
        {
            Task = task;
        }
        public int GetRemainingDays(DateTime deadline)
        {
            return (Task.Deadline - deadline).Days;
        }
    }
}
