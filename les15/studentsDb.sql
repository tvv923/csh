CREATE DATABASE StudentsDB;
GO

-- Вибір бази даних
USE StudentsDB;

-- Створення таблиці для зберігання оцінок студентів
CREATE TABLE StudentGrades (
    StudentName NVARCHAR(255),     -- Full Name of the student
    City NVARCHAR(255),            -- City
    Country NVARCHAR(255),         -- Country
    DateOfBirth DATE,              -- Date of Birth
    Email NVARCHAR(255),           -- Email
    PhoneNumber NVARCHAR(20),      -- Phone Number
    GroupName NVARCHAR(255),       -- Group Name
    AverageGrade FLOAT,            -- Average grade for the year across all subjects
    MinSubject NVARCHAR(255),      -- Subject with the minimum average grade
    MaxSubject NVARCHAR(255)       -- Subject with the maximum average grade
);

-- Вставка даних
INSERT INTO StudentGrades (StudentName, City, Country, DateOfBirth, Email, PhoneNumber, GroupName, AverageGrade, MinSubject, MaxSubject)
VALUES 
    ('Іванов Іван', 'Київ', 'Україна', '1995-05-15', 'ivanov@example.com', '+380 11-111-22-33', 'Група А', 88.5, 'Математика', 'Англійська'),
    ('Петров Петро', 'Київ', 'Україна', '1996-03-20', 'petrov@example.com', '+380 44-555-66-77', 'Група Б', 76.2, 'Історія', 'Фізика'),
    ('Васечкин Василь', 'Житомир', 'Україна', '1996-01-01', 'vasechkin@example.com', '+380 88-999-00-11', 'Група Б', 77.2, 'Історія', 'Англійська'),
    ('Степаненко Степан', 'Житомир', 'Україна', '1995-01-11', 'stepanenko@example.com', '+380 22-333-44-55', 'Група А', 80.3, 'Математика', 'Фізика'),
    ('Тарасов Тарас', 'Київ', 'Україна', '1995-08-01', 'tarasov@example.com', '+380 66-777-88-99', 'Група А', 81.4, 'Англійська', 'Фізика')
;

-- Відображення всієї інформації з таблиці зі студентами та оцінками
SELECT * FROM StudentGrades;

-- Відображення ПІБ усіх студентів
SELECT StudentName FROM StudentGrades;

-- Відображення усіх середніх оцінок
SELECT StudentName, AverageGrade FROM StudentGrades;

-- Показати ПІБ усіх студентів з мінімальною оцінкою більше, ніж зазначена
SELECT StudentName
FROM StudentGrades
WHERE AverageGrade > 80; -- Наприклад 80 мінімальна оцінка

-- Показати країни студентів. Назви країн мають бути унікальними.
SELECT DISTINCT Country FROM StudentGrades;

-- Показати міста студентів. Назви міст мають бути унікальними.
SELECT DISTINCT City FROM StudentGrades;

-- Показати назви груп. Назви груп мають бути унікальними. 
SELECT DISTINCT GroupName FROM StudentGrades;

-- 1 -- Показати назви предметів. Назви предметів мають бути унікальними. 
SELECT DISTINCT MinSubject FROM StudentGrades;

-- 2 -- Показати назви предметів. Назви предметів мають бути унікальними. 
SELECT DISTINCT MaxSubject FROM StudentGrades;

-- 4 -- Показати назви груп і назви предметів. Назви груп і предметів мають бути унікальними. 
SELECT DISTINCT GroupName, MinSubject, MaxSubject FROM StudentGrades;

-- 5 -- Показати назви груп і назви предметів. Назви груп і предметів мають бути унікальними. 
SELECT DISTINCT GroupName, MinSubject FROM StudentGrades;

-- 6 -- Показати назви груп і назви предметів. Назви груп і предметів мають бути унікальними. 
SELECT DISTINCT GroupName, MaxSubject FROM StudentGrades;