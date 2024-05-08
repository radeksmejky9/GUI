using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoList.Models;

namespace TodoList.Pages
{
    public class _TaskPartialModel : PageModel
    {
        public TaskItem Task { get; private set; }
        public bool IsEditing { get; set; } = false;
        public _TaskPartialModel(TaskItem task)
        {
            Task = task;
        }
        public int GetRemainingDays(DateTime deadline)
        {
            return (Task.Deadline - deadline).Days;
        }
        public void OnPostSetEditing()
        {
            if (TempData.TryGetValue("IsEditing", out object? value))
            {
                IsEditing = value != null && (bool)value;
            }

            IsEditing = !IsEditing;
            TempData["IsEditing"] = IsEditing;

        }
    }
}
