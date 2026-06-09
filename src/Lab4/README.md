# Лабораторная 4: консольный файловый менеджер

Лаба реализует консольный файловый менеджер, который парсит текстовые команды и
выполняет операции над локальной файловой системой.

Код разделен на два проекта:

- `src/Lab4.Core` - команды, парсер, состояния и логика файловой системы.
- `src/Lab4.Presentation` - консольный runner и точка входа.

## Идея

Приложение читает команды из стандартного ввода, превращает их в command-объекты
и выполняет через абстракцию `IFileSystem`. У файловой системы есть состояния
connected/disconnected, поэтому команды, которым нужно активное подключение,
завершаются ошибкой до вызова `connect`.

## Поддерживаемые команды

```text
connect <path> -m local
disconnect
tree goto <path>
tree list -d <depth>
file show <path> -m console
file copy <source> <destination>
file move <source> <destination>
file delete <path>
file rename <path> <new-name>
exit
```

## Что использовалось

- Command для исполняемых операций.
- Chain of Responsibility для парсинга команд.
- State для поведения подключенной и отключенной файловой системы.
- Абстракция файловой системы для тестируемости.
- Абстракция writer для вывода.
- xUnit и NSubstitute для тестов парсера, команд и состояний.

## Основные файлы

- `src/Lab4.Core/Command/` - command-объекты.
- `src/Lab4.Core/ParserCommand/` - звенья цепочки парсинга.
- `src/Lab4.Core/FileSystem/IFileSystem.cs` - контракт файловой системы.
- `src/Lab4.Core/FileSystem/LocalFileSystem.cs` - фасад локальной реализации.
- `src/Lab4.Core/FileSystem/State/` - connected/disconnected состояния.
- `src/Lab4.Core/FileSystem/FileSystemOperation/` - конкретные операции.
- `src/Lab4.Presentation/Runner/ApplicationRunner.cs` - консольный цикл.

## Запуск

```bash
dotnet run --project src/Lab4.Presentation/Lab4.Presentation.csproj
```

## Тесты

Тесты лежат в `tests/Lab4.Tests`.

Проверяются:

- парсинг команд;
- валидация некорректных команд;
- вызовы файловой системы из command-объектов;
- переходы состояний;
- ошибки при выполнении команд в disconnected-состоянии.

Запуск только тестов Lab 4:

```bash
dotnet test tests/Lab4.Tests/Lab4.Tests.csproj
```
