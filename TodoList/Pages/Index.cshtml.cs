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

        private readonly TaskContext _taskContext;

        public IndexModel(TaskContext taskContext)
        {
            _taskContext = taskContext;
            taskItems = _taskContext.TaskItems.ToList();
        }

        public IActionResult OnPostAddElement()
        {
            _taskContext.TaskItems.Add(NewToDoElement);
            _taskContext.SaveChanges();
            return RedirectToPage();
        }

        public IActionResult OnPostAddTask()
        {
            if (TempData.TryGetValue("DisplayAddTask", out object? value))
            {
                DisplayAddTask = value != null && (bool)value;
            }

            DisplayAddTask = !DisplayAddTask;
            TempData["DisplayAddTask"] = DisplayAddTask;
            return RedirectToPage();
        }
        public IActionResult OnPostMarkAsFinished(int taskId)
        {
            var taskItem = _taskContext.TaskItems.Find(taskId);
            if (taskItem == null)
            {
                return NotFound();
            }
            taskItem.Finished = 1;
            _taskContext.SaveChanges();

            return RedirectToPage();
        }

    }
}
