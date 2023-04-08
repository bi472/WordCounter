# Тестовое задание
## Задание 1

1. Сотрудник с максимальной заработной платой:
```SQL
SELECT *
FROM EMPLOYEE
WHERE SALARY = (
    SELECT MAX(SALARY)
    FROM EMPLOYEE
)
```
2.  Максимальная длина цепочки руководителей по таблице сотрудников:
```SQL
WITH RECURSIVE emp_chain AS (
    SELECT ID, CHIEF_ID, 1 AS depth
    FROM EMPLOYEE
    WHERE CHIEF_ID IS NULL
    UNION ALL
    SELECT e.ID, e.CHIEF_ID, ec.depth + 1 AS depth
    FROM EMPLOYEE e
    JOIN emp_chain ec ON e.CHIEF_ID = ec.ID
)
SELECT MAX(depth)
FROM emp_chain
```
3. Отдел с максимальной суммарной зарплатой сотрудников:
```SQL
SELECT d.NAME, SUM(e.SALARY) AS total_salary
FROM DEPARTMENT d
JOIN EMPLOYEE e ON d.ID = e.DEPARTMENT_ID
GROUP BY d.ID, d.NAME
ORDER BY total_salary DESC
FETCH FIRST 1 ROW ONLY
```
4.  Сотрудника, чье имя начинается на «Р» и заканчивается на «н»:
```SQL
SELECT *
FROM EMPLOYEE
WHERE NAME LIKE 'Р%н'
```

## Задание 2
Использование:
```bash
WordCount <input_file>
```
### Выходные данные записываются в файл output.txt в корневом каталоге проекта.
### Могут возникнуть проблемы с кодировкой и в output.txt запишуться некорректные данные. Для этого просто вставьте текст в готовый файл формата .txt и всё заработает)
