# KI/GUI
## Lekce: ASP.NET + Razor Pages

[Prezentace](https://tinyurl.com/KI-GUI-PRE)

[README_EN](https://github.com/radeksmejky9/GUI/edit/main/README_EN.md)

## Požadavky
- **Instalace [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)**
  - `.NET 8.0` a `ASP.NET and web development`
- **Tvorba projektu**
  - Typ projektu: `ASP.NET Core Web App (Razor Pages)`
- **NuGet balíčky**
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Sqlite`
  - `Microsoft.EntityFrameworkCore.Tools`

## Úvod do řešení
### TodoList\Program.cs
- Sestavovací skript pro spuštění webové aplikace
- Řešení dependency injection
- Přidání NuGet balíčků

### TodoList\Pages\
- Složka obsahující všechny Razor Pages

### TodoList\Pages\Shared\
- Obsahuje `_Layout.cshtml`

### TodoList\Models\
- Složka pro definice databázových modelů (vytváříme sami)

### TodoList\wwwroot\
- Pro statické soubory jako jsou CSS, JS a obrázky
  
## Příprava před tvorbou
- **Tvorba složky `Models`**
- **Správa NuGet balíčků**
  - Project > Manage NuGet Packages
    - Přidání `Microsoft.EntityFrameworkCore`
    - Přidání `Microsoft.EntityFrameworkCore.Sqlite`
    - Přidání `Microsoft.EntityFrameworkCore.Tools`
- **Testování spuštění projektu**
  - Ověření funkčnosti základní konfigurace

Pokud vám vše funguje, můžete se vrhnout na Úkol 1

## Úkol 1
- `TodoList\Index.cshtml`
- Smažte všechen html obsah
- Vytvořte si jednoduchý html form s údaji v databázi (Text - text, Deadline - date)
- Lze využívat bootstrap prvky v základu

## Tvorba základu aplikace
Využijte následující bloky kódu:

<details>
<summary>Tvorba modelu v rámci EntityFramework</summary>
  

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

<summary>Tvorba Sqlite databáze</summary>


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

<summary>Dependency injection databáze</summary>


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

## Úkol 2
- Propojení HTML formu a 




