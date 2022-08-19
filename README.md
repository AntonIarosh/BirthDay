# BirthDay
For SolarLab
## Программа День Рождения работает режиме Web-API приложения с БД а также в качестве презентации выполнена простейшая демонстрация работы с пользователями

### Web-API создавалась для работы с сущностями Пользователя, Праздника - Дня Рождения, Поздравления, Знакомых.
Представление работает только с сущностью Пользователя, позволяет:
+ Просмотреть списко пользователей у кого ДР сегодня
+ Добавить нового пользователя
+ Просмотреть список всех пользователей
+ Просмотреть список пользователей у кого ДР будет в интервале нескольких дней.
+ Искать пользователя, по ФИО (полностью или частично заполнено), по адресу электронной почты. После того как пользователь будет найден,
информацию о нём можно изменить, а можно удалить пользователя.

### Работа с базой данных.
Схема базы данных:

![БД](https://github.com/AntonIarosh/BirthDay/db.png)