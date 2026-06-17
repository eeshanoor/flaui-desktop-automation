# FlaUI Desktop Automation
> **Eesha Noor** | SDET | C# + FlaUI + NUnit

## Tech Stack
- C# (.NET 6)
- FlaUI (UIA3)
- NUnit
- Page Object Model
- Windows UI Automation

## Test Coverage
- Windows Calculator: basic arithmetic, keyboard input, chained operations
- Notepad: open, type, save, verify content

## Prerequisites
- Windows OS
- .NET 6 SDK
- Visual Studio 2022 or Rider

## Run Tests
```bash
dotnet restore
dotnet test
dotnet test --filter "Category=Calculator"
dotnet test --logger "trx;LogFileName=results.trx"
```

## Project Structure
```
Base/        BaseTest.cs
Pages/       CalculatorPage.cs, NotepadPage.cs
Tests/       CalculatorTests.cs, NotepadTests.cs
Utils/       WaitHelper.cs
```