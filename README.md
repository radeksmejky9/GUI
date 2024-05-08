# KI/GUI
## Lekce: ASP.NET + Razor Pages

[Prezentace](https://tinyurl.com/KI-GUI-PRE)

[README_EN](https://github.com/radeksmejky9/GUI/edit/main/README_EN.md)

## Příprava
- **Instalace [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)**
  - S .NET 8.0 a ASP.NET and web development.
- **Tvorba projektu**
  - Typ projektu: ASP.NET Core Web App (Razor Pages)
- **NuGet balíčky**
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Sqlite`
  - `Microsoft.EntityFrameworkCore.Tools`

## Popis řešení
### TodoList\Program.cs
- Sestavovací skript pro spuštění webové aplikace.
- Řešení dependency injection.
- Přidání NuGet balíčků.

### TodoList\Pages\
- Složka obsahující všechny Razor Pages.

#### TodoList\Pages\Shared\
- Obsahuje `_Layout.cshtml` pro výpis jednotlivých stránek.

### TodoList\Models\
- Složka pro definice databázových modelů (vytváříme sami).

### TodoList\wwwroot\
- Pro statické soubory jako CSS, JS a obrázky.

## Začátek vývoje ve Visual Studio 2022
- **Tvorba složky `Models`**
- **Správa NuGet balíčků**
  - Project > Manage NuGet Packages
    - Přidání `Microsoft.EntityFrameworkCore`
    - Přidání `Microsoft.EntityFrameworkCore.InMemory`
- **Zavedení 
- **Testování spuštění projektu**
  - Ověření funkčnosti základní konfigurace.

## Tvorba základu aplikace
Použijte následující šablony:

<details>
<summary>Základní HTML formulář</summary>


  
```html
<!-- Příklad HTML kódu s Bootstrapem -->
```
</details>

<details>
<summary>Tvorba modelu v rámci EntityFramework</summary>
  


```csharp
//TodoList\Models\ToDoElement.cs
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class ToDoElement
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Task Text")]
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Finished { get; set; }
    }
}
```
</details>
<details>

<summary>Vytvoření Sqlite databáze</summary>



```csharp
//TodoList\Models\TodoContext.cs
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TodoList.Models;

public class TodoContext : DbContext
{
    public DbSet<ToDoElement> TodoElements { set; get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite(@"Data Source=..\Demo.db");
}
```

</details>

<details>

<summary>Dependency injection - databáze</summary>


```csharp
//TodoList\Program.cs
builder.Services.AddDbContext<TodoContext>(options => options.UseSqlite(@"Data Source=..\Demo.db"));
```

</details>

