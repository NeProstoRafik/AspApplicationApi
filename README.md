<h3>Cервис API </h3>
<hr>
Данный сервис предоставляет прототип сервиса для сбора заявок на выступление для IT конференции. Имеет точки доступа для управления сущностями в базе данных PostgreSQL.

 <strong>Начало работы </strong>
<hr>
<p>
Клонируйте данный репозиторий.
Установите(если нет) <a href="https://visualstudio.microsoft.com/ru/vs/community/">Visual Studio</a>  (dot net 8).  
Установите  <a href="https://www.enterprisedb.com/downloads/postgres-postgresql-downloads">PostgreSQ</a> 
В проекте поменяйте сроку подлкючения в файле appsettings.json на свои данные из БД (PostgreSQL)
Запустите проект.
Используйте эндпойнты для работы.
</p>
 <strong>Точки доступа API</strong>
<hr>
  <ul>
  <li>Получение всех активностей: GET /activities</li>
  <li>Создание заявки: POST /create</li>
  <li>Обновление заявки: PUT /update/{id}</li>
    <li>Удаление заявки: DELETE /delete/{id}</li>
      <li>Получение заявки по идентификатору: GET /{id}</li>
      <li>Отправка заявки на рассмотрение: POST /submid/{id}</li>
      <li>Получение списка заявок до определнной даты и после определенной даты включая не отправленных на рассмотрение: GET /GetAfterDateOrUnsubmittedOlder</li>
       <li>Получение текущей не поданной заявки для указанного пользователя </li>
</ul>








