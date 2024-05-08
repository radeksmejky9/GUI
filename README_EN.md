# KI/GUI
## Lesson: ASP.NET + Razor Pages
- The support primarily does not serve for in-person teaching; we will not necessarily stick to it, but rather it introduces the technology and shows the basics.

[Presentation](https://tinyurl.com/KI-GUI-PRE)

## Requirements
- **Installation of [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)**
  - `.NET 8.0` and `ASP.NET and web development`
- **Project Creation**
  - Project type: `ASP.NET Core Web App (Razor Pages)`
  - Project name ideally TodoList
- **NuGet packages**
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Sqlite`
  - `Microsoft.EntityFrameworkCore.Tools`

## Introduction to the solution
### TodoList\Program.cs
- Builds the script for launching the web application
- Dependency injection solution

### TodoList\Pages\
- Folder containing all Razor Pages

### TodoList\Pages\Shared\
- Contains `_Layout.cshtml`

### TodoList\Models\
- Folder for defining database models (created by us)

### TodoList\wwwroot\
- For static files such as CSS, JS, and images
  
## Preparation before development
- **Creation of `Models` folder**
- **Management of NuGet packages**
  - Project > Manage NuGet Packages
    - Add `Microsoft.EntityFrameworkCore`
    - Add `Microsoft.EntityFrameworkCore.Sqlite`
    - Add `Microsoft.EntityFrameworkCore.Tools`
- **Testing project launch**
  - Verify the functionality of the basic configuration

If everything works for you, you can move on to Task 1

## Task 1
- `TodoList\Index.cshtml`
- Delete all HTML content
- Create a simple HTML form with inputs for inserting into the database (Text - text, Deadline - date)
- **ATTENTION** Within the input field, the value of the attribute `name=""` must match the database, so Text and Deadline
- Basic bootstrap elements can be used

## Building the foundation of the application
Use the following code blocks:

<details>
<summary>Model creation within EntityFramework</summary>
  
```csharp
//TodoList\Models\TaskItemModel.cs
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class TaskItemModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Task Text")]
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Deadline { get; set; } = DateTime.Now;
        [Required]
        [DefaultValue(0)]
        public byte Finished { get; set; }
    }
}

```
</details>
<details>

<summary>Creation of SQLite database</summary>

```csharp
//TodoList\Models\TaskContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Models;

public class TaskContext : DbContext
{
    public DbSet<TaskItemModel> TaskItems { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite(@"Data Source=..\Demo.db");

}
```

</details>

<details>

<summary>Database dependency injection</summary>

```csharp
//TodoList\Program.cs
builder.Services.AddDbContext<TaskContext>();
```

</details>

Tools > NuGet Package Manager > Package Manager Console
```
Add-migration DB
Update-database
```

## Task 2
- Create a simple table, use `<table class="table">` (Deadline, Text, Buttons for editing and completing)

<details>
  
<summary>Connecting to the database</summary>
  
```csharp
//TodoList\Models\IndexModel.cshtml.cs
public bool DisplayAddTask { get; private set; } = false;
public List<_TaskPartialModel> taskItems = new List<_TaskPartialModel>();
[BindProperty]
public TaskItemModel NewTaskItem { get; set; }
private readonly TaskContext _taskContext;

public IActionResult OnPostAddElement()
 {
     _taskContext.TaskItems.Add(NewTaskItem);
     _taskContext.SaveChanges();
     return RedirectToPage();
 }

 public IndexModel(TaskContext taskContext)
 {
     _taskContext = taskContext;
     var items = _taskContext.TaskItems.ToList();
     taskItems.AddRange(items);
 }
```
</details>

## Task 3
- Color the text `Deadline` according to the number of remaining days.
