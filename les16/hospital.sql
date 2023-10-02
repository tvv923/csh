-- Створення бази Hospital
CREATE DATABASE Hospital;
GO

-- Використання бази Hospital
USE Hospital;

-- Створення таблиці Departments
CREATE TABLE Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Financing MONEY NOT NULL CHECK (Financing >= 0) DEFAULT 0,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- Створення таблиці Diseases
CREATE TABLE Diseases (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    Severity INT NOT NULL CHECK (Severity >= 1) DEFAULT 1
);

-- Створення таблиці Doctors
CREATE TABLE Doctors (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(MAX) NOT NULL,
    Phone CHAR(10) NULL,
    Salary MONEY NOT NULL CHECK (Salary > 0),
    Surname NVARCHAR(MAX) NOT NULL
);

-- Створення таблиці Examinations
CREATE TABLE Examinations (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    DayOfWeek INT NOT NULL CHECK (DayOfWeek BETWEEN 1 AND 7),
    EndTime TIME NOT NULL,
    Name NVARCHAR(100) NOT NULL UNIQUE,
    StartTime TIME NOT NULL CHECK (StartTime >= '08:00' AND StartTime <= '18:00')
);

-- Створення таблиці Wards
CREATE TABLE Wards (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Building INT NOT NULL CHECK (Building BETWEEN 1 AND 5),
    Floor INT NOT NULL CHECK (Floor >= 1),
    Name NVARCHAR(20) NOT NULL UNIQUE
);

-- Вставка даних
INSERT INTO Departments (Building, Financing, [Name])
VALUES
    (1, 25000, 'Cardiology'),
    (2, 30000, 'Pediatrics'),
    (3, 20000, 'Orthopedics'),
    (4, 35000, 'Oncology'),
    (5, 28000, 'Intensive Treatment'),
	(4, 40000, 'Gastroenterology'),
	(5, 27000, 'General Surgery');

-- Вставка даних
INSERT INTO Diseases ([Name], Severity)
VALUES
    ('Heart Disease', 3),
    ('Influenza', 1),
    ('Fracture', 2),
    ('Lung Cancer', 4),
    ('Migraine', 1);

-- Вставка даних
INSERT INTO Doctors ([Name], Phone, Salary, Surname)
VALUES
    ('Thomas', '1234567890', 5000, 'Gerada'),
    ('Anthony', '9876543210', 6000, 'Davis'),
    ('Helen', '5555555555', 5500, 'Williams'),
    ('Sarah', NULL, 5200, 'Norton'),
    ('Joshua', '3333333333', 5800, 'Bell');

-- Вставка даних
INSERT INTO Examinations (DayOfWeek, EndTime, Name, StartTime)
VALUES
    (1, '12:30', 'ECG', '10:00'),
    (2, '14:00', 'Blood Test', '13:00'),
    (3, '15:30', 'X-ray', '14:00'),
    (4, '16:00', 'MRI', '15:00'),
    (5, '14:30', 'Ultrasound', '13:30');

-- Вставка даних
INSERT INTO Wards (Building, Floor, Name)
VALUES
    (1, 1, 'Ward A101'),
    (1, 2, 'Ward A201'),
    (2, 1, 'Ward B101'),
    (3, 2, 'Ward C202'),
    (5, 3, 'Ward E303');

-- 1. Вивести вміст таблиці палат.
SELECT * FROM Wards;

-- 2. Вивести прізвища та телефони усіх лікарів.
SELECT Surname, Phone FROM Doctors;

-- 3. Вивести усі поверхи без повторень, де розміщуються палати.
SELECT DISTINCT Floor FROM Wards;

-- 4. Вивести назви захворювань під назвою «Name of Disease» та ступінь їхньої тяжкості під назвою «Severity of Disease».
SELECT Name AS "Name of Disease", Severity AS "Severity of Disease" FROM Diseases;

-- 5. Застосувати вираз FROM для будь-яких трьох таблиць бази даних, використовуючи псевдоніми.
SELECT D.*, E.*, W.*
FROM Doctors AS D
JOIN Examinations AS E ON D.Id = E.Id
JOIN Wards AS W ON D.Id = W.Id;

-- 6. Вивести назви відділень, які знаходяться у корпусі 5 з фондом фінансування меншим, ніж 30000.
SELECT Name
FROM Departments
WHERE Building = 5 AND Financing < 30000;

-- 7. Вивести назви відділень, які знаходяться у корпусі 3 з фондом фінансування у діапазоні від 12000 до 15000.
SELECT Name
FROM Departments
WHERE Building = 3 AND Financing BETWEEN 12000 AND 15000;

-- 8. Вивести назви палат, які знаходяться у корпусах 4 та 5 на 1-му поверсі.
SELECT Name
FROM Wards
WHERE Building IN (4, 5) AND [Floor] = 1;

-- 9. Вивести назви, корпуси та фонди фінансування відділень, які знаходяться у корпусах 3 або 6 та мають фонд фінансування менший, ніж 11000 або більший за 25000.
SELECT Name, Building, Financing
FROM Departments
WHERE Building IN (3, 6) AND (Financing < 11000 OR Financing > 25000);

-- 10. Вивести прізвища лікарів, зарплата (сума ставки та надбавки) яких перевищує 1500.
SELECT Surname
FROM Doctors
WHERE Salary > 1500;

-- 11. Вивести прізвища лікарів, у яких половина зарплати перевищує триразову надбавку.
SELECT Surname
FROM Doctors
WHERE Salary / 3 < Salary;

-- 12. Вивести назви обстежень без повторень, які проводяться у перші три дні тижня з 12:00 до 15:00.
SELECT DISTINCT Name
FROM Examinations
WHERE DayOfWeek IN (1, 2, 3) AND StartTime >= '12:00' AND EndTime <= '15:00';

-- 13. Вивести назви та номери корпусів відділень, які знаходяться у корпусах 1, 3, 8 або 10.
SELECT D.Name AS "Department Name", D.Building AS "Building Number"
FROM Departments AS D
WHERE D.Building IN (1, 3, 8, 10);

-- 14. Вивести назви захворювань усіх ступенів тяжкості, крім 1-го та 2-го.
SELECT Name
FROM Diseases
WHERE Severity NOT IN (1, 2);

-- 15. Вивести назви відділень, які не знаходяться у 1-му або 3-му корпусі.
SELECT Name
FROM Departments
WHERE Building NOT IN (1, 3);

-- 16. Вивести назви відділень, які знаходяться у 1-му або 3-му корпусі.
SELECT Name
FROM Departments
WHERE Building IN (1, 3);

-- 17. Вивести прізвища лікарів, що починаються з літери «N».
SELECT Surname
FROM Doctors
WHERE Surname LIKE 'N%';