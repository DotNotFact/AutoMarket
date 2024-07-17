# Auto Market API

## Описание

Этот проект представляет собой кроссплатформенный сервис, предоставляющий REST API для управления производителями автомобилей и марками машин. В проекте используется база данных PostgreSQL и ORM EntityFramework Core для работы с данными.

## Требования

- .NET 8.0
- PostgreSQL

## Установка

1. Клонируйте репозиторий:
  ```sh
  git clone https://github.com/yourusername/AutoMarket.git
  cd AutoMarket
  ```

2. Установите необходимые зависимости:
  ```sh
  dotnet restore
  ```

3. Настройте подключение к базе данных PostgreSQL в файле `appsettings.json`:
  ```json
  {
    "ConnectionStrings": {
      "ApplicationDbContext": "Host=localhost;Database=AutoMarketDb;Username=yourusername;Password=yourpassword"
    }
  }
  ```

4. Примените миграции к базе данных:
  ```sh
  dotnet ef database update
  ```

## Запуск

1. Запустите приложение:
  ```sh
  dotnet run
  ```

## API Методы

### Получить всех производителей

**GET** `/api/Car/get-all-makers`

**Пример запроса:**
  ```sh
  curl -X GET "http://localhost:5000/api/Car/get-all-makers"
  ```

### Получить все марки машин заданного производителя

**GET** `/api/Car/get-model?id={id}`

**Пример запроса:**
  ```sh
  curl -X GET "http://localhost:5000/api/Car/get-model?id=af274da4-f6ba-4725-af4c-96a6f1789913"
  ```

### Добавить нового производителя автомобилей

**POST** `/api/Car/add-maker`

**Пример запроса:**
  ```sh
  curl -X POST "http://localhost:5000/api/Car/add-maker?name=Kia&country=South Korea&foundedYear=1944"
  ```

### Удалить производителя автомобилей

**DELETE** `/api/Car/delete-maker?id={id}`

**Пример запроса:**
  ```sh
  curl -X DELETE "http://localhost:5000/api/Car/delete-maker?id=af274da4-f6ba-4725-af4c-96a6f1789913"
  ```

### Добавить новую марку машины

**POST** `/api/Car/add-model`

**Пример запроса:**
  ```sh
  curl -X POST "http://localhost:5000/api/Car/add-model?name=Rio&releaseYear=2000&makerId=af274da4-f6ba-4725-af4c-96a6f1789913"
  ```

### Удалить марку машины

**DELETE** `/api/Car/delete-model?id={id}`

**Пример запроса:**
  ```sh
  curl -X DELETE "http://localhost:5000/api/Car/delete-model?id=c5e71e98-09c0-4bd0-a67d-9d46bbbbb1b3"
  ```

## Структура БД

### Таблица производителей автомобилей (Makers)

- `Id` (UUID, PK)
- `Name` (string)
- `Country` (string)
- `FoundedYear` (int)

### Таблица марок машин (Models)

- `Id` (UUID, PK)
- `Name` (string)
- `ReleaseYear` (int)
- `MakerId` (UUID, FK)

## Контрибьютинг

1. Форкните проект.
2. Создайте свою ветку (`git checkout -b feature-branch`).
3. Сделайте коммит ваших изменений (`git commit -am 'Add new feature'`).
4. Запушьте изменения в ветку (`git push origin feature-branch`).
5. Создайте новый Pull Request.

## Лицензия
  
  Этот проект лицензирован под лицензией MIT. См. файл [LICENSE](LICENSE) для подробностей.
  ```
  Этот файл README.md предоставляет полное описание проекта, установки, запуска, API методов и структуры базы данных. Вы можете адаптировать и расширить его по мере необходимости.
  ```
