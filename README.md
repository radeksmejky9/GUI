# KI/GUI
## Lekce: ASP.NET + Razor Pages

- [Prezentace](https://tinyurl.com/KI-GUI-PRE)
- [README_EN on GitHub](https://github.com/radeksmejky9/GUI/edit/main/README_EN.md)

## Požadavky
- **Instalace [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)**
  - Vyžadováno: `.NET 8.0` a `ASP.NET and web development`
- **Tvorba projektu**
  - Typ projektu: `ASP.NET Core Web App (Razor Pages)`
  - Název projektu: `TodoList`
- **NuGet balíčky**
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Sqlite`
  - `Microsoft.EntityFrameworkCore.Tools`

## Úvod do řešení
### Struktura projektu
- **TodoList\Program.cs**
  - Sestavovací skript pro spuštění webové aplikace
  - Řešení dependency injection
- **TodoList\Pages\**
  - Obsahuje všechny Razor Pages
- **TodoList\Pages\Shared\**
  - Obsahuje `_Layout.cshtml`
- **TodoList\Models\**
  - Složka pro definice databázových modelů
- **TodoList\wwwroot\**
  - Složka pro statické soubory (CSS, JS, obrázky)

## Příprava před tvorbou
1. **Tvorba složky `Models`**
2. **Správa NuGet balíčků**
   - Project > Manage NuGet Packages
   - Přidat `Microsoft.EntityFrameworkCore`
   - Přidat `Microsoft.EntityFrameworkCore.Sqlite`
   - Přidat `Microsoft.EntityFrameworkCore.Tools`
3. **Testování spuštění projektu**
   - Ověřit funkčnost základní konfigurace

**Připraveni na Úkol 1**

## Úkol 1
- Upravte `TodoList\Index.cshtml`
- Odstraňte veškerý HTML obsah
- Vytvořte HTML formulář s inputy:
  - Text: `text`
  - Deadline: `date`
- **POZOR:** Hodnota atributu `name` musí odpovídat názvům v databázi (např. `Text` a `Deadline`)

## Tvorba základu aplikace
- **Model v rámci EntityFramework**
  ```csharp
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
- **Tvorba Sqlite databáze**
  ```csharp
  public class TaskContext : DbContext
  {
      public DbSet<TaskItemModel> TaskItems { set; get; }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          => optionsBuilder.UseSqlite(@"Data Source=..\Demo.db");
  }
  ```
- **Dependency injection databáze**
  ```csharp
  builder.Services.AddDbContext<TaskContext>();
  ```

## Úkol 2
- Vytvořte tabulku s `<table class="table">`
  - Zobrazujte `Deadline`, `Text`, případně i tlačítka pro úpravu a dokončení úkolů.
 
## Napojení na databázi
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

## Úkol 3
- Obarvěte text `Deadline` podle počtu zbývajících dní.
