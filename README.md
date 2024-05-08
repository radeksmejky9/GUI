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
### Projekt\Program.cs
- Sestavovací skript pro spuštění webové aplikace.
- Řešení dependency injection.
- Přidání NuGet balíčků.

### Projekt\Pages\
- Složka obsahující všechny Razor Pages.

#### Projekt\Pages\Shared\
- Obsahuje `_Layout.cshtml` pro výpis jednotlivých stránek.

### Projekt\Models\
- Složka pro definice databázových modelů (vytváříme sami).

### Projekt\wwwroot\
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
- **Tvorba formuláře `Projekt\Pages\Index.cshtml`**
  - Základní html formulář s pár bootstrap prvky.
```
<div class="container text-center">
    <div class="d-flex justify-content-center align-items-center my-4">
        <h1 class="display-4 px-2">TodoList</h1>
        <form method="post">
            <button type="submit" class="btn btn-primary rounded-circle p-0" style="width: 25px; height: 25px; font-size: 15px;" asp-page-handler="AddTask">
                @(Model.DisplayAddTask ? "-" : "+")
            </button>
        </form>
    </div>

    @if (Model.DisplayAddTask)
    {
        <form id="todolist" class="col-6 container">
            <div class="row">
                <div class="form-group col">
                    <label for="inputTask">Task</label>
                    <input type="text" class="form-control" id="inputTask">
                </div>
                <div class="form-group col">
                    <label for="inputDeadline">Deadline</label>
                    <input type="date" class="form-control" id="inputDeadline">
                </div>
            </div>
            <div class="container" style="max-width: 400px;">
                <div class="row">
                    <div class="col">
                        <input type="submit" value="Add Task" class="btn btn-primary my-3" />
                    </div>
                </div>
            </div>
        </form>
    }

<form id="content" class="my-5 container border rounded">
        @for (var i = 1; i < 21; i += 2)
        {
            int remainingDays = Model.GetRemainingDays(i);
            string textColor = remainingDays > 10 ? "green" : remainingDays > 5 ? "orange" : "red";

            <div class="row border-bottom mx-3 align-items-center">
                <div id="task" class="col my-3 col">
                    <div class="border-end pe-3">Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Duis sapien nunc, commodo et</div>
                </div>
                <div id="deadline" class="col my-3 mx-3 col-lg-auto" style="color: @textColor">
                    <div>@DateTime.Now.AddDays(i)</div>
                </div>
                <div id="submit" class="col my-3 col-lg-2">
                    <input class="btn btn-outline-primary" type="submit" value="&#x2714;" />
                </div>
            </div>
        }
    </form>
</div>
```
  - Samozřejmě je třeba propojit hmtl a C# pomocí razor dekorátoru
```
@page
@model IndexModel
@{
  ViewData["Title"] = "TodoList";
}
```

- **Tvorba modelu v rámci EntityFramework `Projekt\Models\Task.cs`**
```
TEMPLATE TADY
```
