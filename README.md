# XML Tree Editor

Windows Forms aplikace pro prohlížení, editaci a ukládání XML dokumentů s grafickou vizualizací stromové struktury.

Technologie: .NET 10.0, C# 12, Windows Forms

## Funkce

- Načítání XML souborů s validací a error handlingem
- TreeView vizualizace stromové struktury s ikonami
- Statistiky dokumentu: maximální hloubka, počet potomků, atributy
- Detail elementu: hloubka, pořadí, atributy, textový obsah
- Editace názvů elementů přímo v TreeView
- Ukládání změn do nového XML souboru
- Robustní error handling pro vadné XML soubory

## Instalace a spuštění

Požadavky:

- Windows 10/11
- .NET 8.0 SDK nebo novější
- Visual Studio 2022 / 2026 (doporučeno) nebo VS Code

Postup:

```bash
# Klonování repozitáře
git clone https://github.com/dusankovarik/xml-tree-editor.git
cd xml-tree-editor

# Otevření v Visual Studio
start XmlTreeEditor.sln

# Nebo build z příkazové řádky
dotnet build
dotnet run
```

## Použití

### 1. Načtení XML souboru

- Klikněte na tlačítko **"Otevřít"**
- Vyberte XML soubor
- Aplikace zobrazí stromovou strukturu a vypočítá statistiky

### 2. Prohlížení elementů

- Klikněte na libovolný uzel ve stromu
- Zobrazí se detailní informace o elementu:
  - Hloubka zanoření
  - Pořadí mezi sourozenci
  - Seznam atributů a jejich hodnot
  - Textový obsah (pro koncové elementy)

### 3. Editace názvů

- Dvojklikněte na uzel
- Upravte název elementu
- Stiskněte Enter pro potvrzení

### 4. Uložení změn

- Klikněte na tlačítko **"Uložit"**
- Zvolte umístění a název souboru
- Aplikace uloží XML se změněnými názvy elementů
- Poznámka: Atributy a textový obsah zůstanou nezměněny

### 5. Zavření dokumentu

- Klikněte na tlačítko **"Zavřít"**
- Aplikace se vyprázdní a je připravena na načtení nového souboru

## Architektura

```
XmlTreeEditor/
├── MainForm.cs              # UI logika a koordinace
├── XmlDocumentInfo.cs       # Výpočet statistik dokumentu
├── XmlElementInfo.cs        # Informace o jednotlivém elementu
└── Program.cs               # Entry point
```

### Klíčové komponenty

**MainForm**

- Správa UI (TreeView, Labels, ToolStrip)
- Event handlery pro uživatelské akce
- Koordinace načítání, zobrazení a ukládání

**XmlDocumentInfo**

- Výpočet maximální hloubky stromu (rekurzivně)
- Zjištění min/max počtu atributů
- Zjištění maximálního počtu potomků

**XmlElementInfo**

- Výpočet hloubky zanoření elementu
- Určení pořadí mezi sourozenci
- Extrakce atributů a textového obsahu

## Technické detaily

Použité technologie:

- **LINQ to XML** (`XDocument`, `XElement`) - moderní API pro práci s XML
- **Windows Forms** - UI framework
- **Rekurzivní algoritmy** - procházení stromové struktury
- **GDI+** - generování ikon

### Klíčové algoritmy

**Výpočet maximální hloubky** (O(n)):

```csharp
int CalculateMaxDepth(XElement element)
{
    if (!element.Elements().Any())
        return 1;

    return 1 + element.Elements()
        .Max(child => CalculateMaxDepth(child));
}
```

**Rekurzivní vytvoření stromu**:

```csharp
TreeNode CreateTreeNode(XElement element)
{
    TreeNode node = new TreeNode(element.Name.LocalName);
    node.Tag = element;

    foreach (XElement child in element.Elements())
    {
        node.Nodes.Add(CreateTreeNode(child));
    }

    return node;
}
```

## Testovací data

Repozitář obsahuje 3 testovací XML soubory:

- **test_knihovna.xml** - komplexní struktura s knihovnou (hloubka 6)
- **test_simple.xml** - jednoduchý obchod s produkty
- **test_invalid.xml** - vadný XML pro testování error handlingu

## Statistiky projektu

- **Řádků kódu**: ~600
- **Třídy**: 3 hlavní
- **Metody**: 20+
- **Rekurzivní algoritmy**: 4
- **Event handlery**: 5

## Možná rozšíření

- Editace atributů a textového obsahu
- Validace proti XSD schématu
- XPath vyhledávání
- Přidávání/odebírání elementů
- Drag & Drop pro přesouvání elementů
- Undo/Redo funkcionalita
- Export do jiných formátů (JSON, CSV)

## Přispívání

Příspěvky jsou vítány! Pro větší změny prosím nejdřív otevřete issue.

## Licence

Tento projekt je licencován pod MIT licencí.

## Autor

Dušan Kovářík - XML Tree Editor

## Poděkování

- Vytvořeno jako úkol k přijímacímu pohovoru
- Děkuji za zpětnou vazbu a code review
