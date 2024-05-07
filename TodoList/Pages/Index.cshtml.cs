using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TodoList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public int RemainingDays { get; private set; }
        public string TextColor { get; private set; }
        public bool DisplayAddTask { get; private set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            TextColor = "black";
        }

        public void OnGet()
        {
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
            } else
            {
                DisplayAddTask = true;
            }
        }
    }
}
