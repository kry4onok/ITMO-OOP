# Лабораторная 5: банковский API

Лаба реализует небольшой банковский backend со счетами, сессиями, операциями над
балансом и историей операций. Приложение доступно как ASP.NET Core API.

## Идея

В системе есть два типа сессий:

- admin-сессия позволяет создавать банковские счета;
- user-сессия позволяет смотреть баланс, пополнять счет, снимать деньги и
  смотреть историю операций.

Счет хранит номер, хэш PIN-кода, текущий баланс, валюту и историю операций.
Бизнес-правила живут в domain/application-слоях, а infrastructure предоставляет
in-memory репозитории и реализации сервисов.

## Архитектура

```text
src/Lab5/
  DomainModel/       Entities, value objects, and operation results
  Application/       Use cases, requests, handlers, DTOs, ports, sessions
  Infrastructure/    In-memory repositories, PIN hashing, admin validation
  Presentation/      ASP.NET Core controllers and API models
```

## Что использовалось

- Слоистая архитектура: Domain, Application, Infrastructure, Presentation.
- Ports and adapters через интерфейсы application-слоя.
- Mediator request handlers для use case-ов.
- Dependency Injection для сборки зависимостей.
- Value objects для номеров счетов, сессий, денег, валют и PIN hash.
- Repository pattern с in-memory реализациями.
- SHA-256 для хэширования PIN.
- ASP.NET Core controllers и Swagger.
- xUnit и NSubstitute для тестов application-поведения.

## API

Сессии:

- `POST /api/session/admin` - создать admin-сессию.
- `POST /api/session/user` - создать user-сессию по номеру счета и PIN.

Счета:

- `POST /api/account` - создать счет, используется header `adminSessionId`.
- `GET /api/account/balance` - посмотреть баланс, используется header `sessionId`.
- `POST /api/account/deposit` - пополнить счет, используется header `sessionId`.
- `POST /api/account/withdraw` - снять деньги, используется header `sessionId`.
- `GET /api/account/history` - посмотреть историю, используется header `sessionId`.

## Основные файлы

- `DomainModel/Entities/Account.cs` - агрегат счета и операции баланса.
- `DomainModel/ValueObjects/` - типизированные доменные значения.
- `Application/Handlers/` - бизнес-сценарии.
- `Application/Ports/` - интерфейсы, которые реализует infrastructure.
- `Infrastructure/Services/Repository/` - in-memory хранилища счетов и сессий.
- `Infrastructure/Services/Sha256PinHasher.cs` - хэширование PIN.
- `Infrastructure/Authentication/AdminPasswordValidator.cs` - проверка admin-пароля.
- `Presentation/Controllers/` - HTTP endpoints.

## Запуск

```bash
dotnet run --project src/Lab5/Presentation/Presentation.csproj
```

Swagger включен по умолчанию после старта. Состояние хранится в памяти и
сбрасывается при остановке приложения.

Демонстрационный admin-пароль читается из
`src/Lab5/Presentation/appsettings.json`. Для реального запуска его лучше
перенести в user secrets или переменные окружения.

## Тесты

Тесты лежат в `tests/Lab5.Tests`.

Проверяются:

- успешные и неуспешные пополнения;
- успешные и неуспешные снятия;
- валидация user-сессий;
- изменения баланса и обновление истории операций.

Запуск только тестов Lab 5:

```bash
dotnet test tests/Lab5.Tests/Lab5.Tests.csproj
```
