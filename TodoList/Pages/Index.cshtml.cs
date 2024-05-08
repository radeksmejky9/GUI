using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Query;
using TodoList.Models;

namespace TodoList.Pages
{
    public class IndexModel : PageModel
    {
        public bool DisplayAddTask { get; private set; } = false;
        public List<_TaskPartialModel> taskItems = new List<_TaskPartialModel>();
        [BindProperty]
        public TaskItemModel NewTaskItem { get; set; }

        private readonly TaskContext _taskContext;

        public IndexModel(TaskContext taskContext)
        {
            _taskContext = taskContext;
            var items = _taskContext.TaskItems.ToList();
            items.ForEach(item => taskItems.Add(new _TaskPartialModel(item)));
        }

        public IActionResult OnPostAddElement()
        {
            _taskContext.TaskItems.Add(NewTaskItem);
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
            return Page();
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
        public void OnPostSetEditing(int taskId)
        {
            var task = taskItems.Find(item => item.Task.Id == taskId);
            if (TempData.TryGetValue("IsEditing", out object? value))
            {
                task.IsEditing = value != null && (bool)value;
            }

            task.IsEditing = !task.IsEditing;
            TempData["IsEditing"] = task.IsEditing;

        }
        public IActionResult OnPostTaskEditFinished(int taskId)
        {
            Console.WriteLine(NewTaskItem);
            var task = taskItems.Find(item => item.Task.Id == taskId);
            if (TempData.TryGetValue("IsEditing", out object? value))
            {
                task.IsEditing = value != null && (bool)value;
            }

            task.IsEditing = !task.IsEditing;
            TempData["IsEditing"] = task.IsEditing;

            task.Task.Text = NewTaskItem.Text;
            task.Task.Deadline = NewTaskItem.Deadline;

            _taskContext.SaveChanges();
            return RedirectToPage();

        }

    }
}
