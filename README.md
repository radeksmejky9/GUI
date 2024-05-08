# KI/GUI
## Lekce: ASP.NET + Razor Pages

[Prezentace](https://tinyurl.com/KI-GUI-PRE)

## Příprava
- **Instalace [Visual Studio 2022](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&channel=Release&version=VS2022&source=VSLandingPage&cid=2030&passive=false)**
  - S .NET 8.0 a ASP.NET and web development.
- **Tvorba projektu**
  - Typ projektu: ASP.NET Core Web App (Razor Pages)
- **NuGet balíčky**
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.InMemory`

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
- **Testování spuštění projektu**
  - Ověření funkčnosti základní konfigurace.
## Tvorba základu aplikace
Použijte následující šablony:

<details>
<summary>Základní HTML formulář</summary>

Formulář využívá Bootstrap třídy pro stylování a layout, což zahrnuje třídy pro formulářové prvky, tlačítka a kontejnery. Bootstrap komponenty zlepšují vizuální prezentaci a usnadňují responsivní design.

  
```html
<!-- Příklad HTML kódu s Bootstrapem -->
```
</details>

<details>

<details>
<summary>Tvorba modelu v rámci EntityFramework `TodoList\Models\Task.cs`</summary>
  
Model obsahuje definice vlastností odpovídajících sloupcům v databázi a může zahrnovat metody pro manipulaci s daty.


```csharp
//TodoList\Models\Task.cs
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Task")]
        [Required]
        public string TaskText { get; set; }
        [Required]
        [DefaultValueAttribute(1)]
        public double TaskPriority { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
        [Required]
        [DefaultValueAttribute(false)]
        public bool Finished { get; set; }
    }
}

```
</details>

<summary>Tvorba modelu v rámci EntityFramework `TodoList\Models\MemoryDbContext.cs`</summary>
  
Zakomponování InMemory databáze


```csharp
//TodoList\Models\MemoryDbContext.cs
using Microsoft.EntityFrameworkCore;

namespace TodoList.Models
{
    public class MemoryDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MemoryDb");
        }
    }
}
```
</details>

