using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoList.Models;

namespace TodoList.Pages
{
    public class IndexModel : PageModel
    {
        public bool DisplayAddTask { get; private set; } = false;
        public List<TaskItem> taskItems = new List<TaskItem>();
        [BindProperty]
        public TaskItem NewToDoElement { get; set; }

        private readonly TaskContext _toDoContext;

        public IndexModel(TaskContext todoContext)
        {
            _toDoContext = todoContext;
            taskItems = _toDoContext.TaskItems.ToList();
        }

        public IActionResult OnPostAddElement()
        {
            _toDoContext.TaskItems.Add(NewToDoElement);
            _toDoContext.SaveChanges();
            return RedirectToPage();
        }

        public void OnPostAddTask()
        {
            if (TempData.TryGetValue("DisplayAddTask", out object? value))
            {
                DisplayAddTask = value != null && (bool)value;
            }

            DisplayAddTask = !DisplayAddTask;
            TempData["DisplayAddTask"] = DisplayAddTask;
        }

    }
}
