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
Použijte následující šablony.

<details>
<summary>Základní HTML formulář</summary>
  Formulář využívá Bootstrap třídy pro stylování a layout, což zahrnuje třídy pro formulářové prvky, tlačítka a kontejnery. Bootstrap komponenty zlepšují vizuální prezentaci a usnadňují responsivní design.
```html
<!-- Příklad HTML kódu s Bootstrapem -->
```
</details>

<details>
<summary>Propojení HTML a C# pomocí Razor dekorátoru</summary>
Razor dekorátory umožňují vkládat C# kód přímo do HTML šablon, což je užitečné pro dynamické generování obsahu na webu z backendu.
  
```razor
<!-- Příklad Razor syntaxe v HTML kódu -->
```
</details>

<details>
<summary>Tvorba modelu v rámci EntityFramework `Projekt\Models\Task.cs`</summary>
Model obsahuje definice vlastností odpovídajících sloupcům v databázi a může zahrnovat metody pro manipulaci s daty.

```csharp
// Příklad C# kódu pro model Task
```
</details>

