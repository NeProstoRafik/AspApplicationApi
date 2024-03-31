<strong>Cервис API </strong>
Данный сервис предоставляет прототип сервиса для сбора заявок на выступление для IT конференции. Имеет точки доступа для управления сущностями в базе данных PostgreSQL.

Начало работы
Клонируйте данный репозиторий.
Установите(если нет) < a href="https://visualstudio.microsoft.com/ru/vs/community/">Visual Studio</ a> (dot net 8).  
Установите < a href="https://www.enterprisedb.com/downloads/postgres-postgresql-downloads">PostgreSQL</ a>
В проекте поменяйте сроку подлкючения в файле appsettings.json на свои данные из БД (PostgreSQL)
Запустите проект.
Используйте эндпойнты для работы.

Точки доступа API

Получение всех активностей: GET /activities
Создание заявки: POST /create
Обновление заявки: PUT /update/{id}
Удаление заявки: DELETE /delete/{id}
Получение заявки по идентификатору: GET /{id}
Отправка заявки на рассмотрение: POST /submid/{id}
Получение списка заявок до определнной даты и после определенной даты включая не отправленных на рассмотрение: GET /GetAfterDateOrUnsubmittedOlder
Получение текущей не поданной заявки для указанного пользователя
