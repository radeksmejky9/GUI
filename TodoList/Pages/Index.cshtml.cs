using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoList.Models;

namespace TodoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public int RemainingDays { get; private set; }
        public string TextColor { get; private set; }
        public bool DisplayAddTask { get; private set; }


        public List<ToDoElement> toDoElements = new List<ToDoElement>();
        [BindProperty]
        public ToDoElement NewToDoElement { get; set; }

        private readonly ToDoContext _toDoContext;

        public IndexModel(ILogger<IndexModel> logger, ToDoContext todoContext)
        {
            _logger = logger;
            TextColor = "black";
            _toDoContext = todoContext;
        }

        public void OnGet()
        {
            toDoElements = _toDoContext.ToDoElements.ToList();
        }

        public IActionResult OnPostAddElement()
        {
            _toDoContext.ToDoElements.Add(NewToDoElement);
            _toDoContext.SaveChanges();
            return RedirectToPage();
        }

        public int GetRemainingDays(int i)
        {
            DateTime deadlineDate = DateTime.Now.AddDays(i);
            return (deadlineDate - DateTime.Now).Days;
        }
        public void OnPostAddTask()
        {
            if (DisplayAddTask)
            {
                DisplayAddTask = false;
            }
            else
            {
                DisplayAddTask = true;
            }
        }
    }
}
