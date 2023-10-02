-- Використання бази Hospital
USE Hospital;
GO

-- Додавання до таблиці нового стовпчика
ALTER TABLE Wards
ADD Places INT NOT NULL CHECK (Places >= 1)  DEFAULT 10;
GO

-- Оновлення даних в таблиці
UPDATE Wards Set Places=Places*Id;
GO

-- 1. Виведіть назви відділень, які знаходяться у тому ж корпусі, що й відділення «Cardiology».
SELECT D1.Name AS 'Department Name'
FROM Departments AS D1
JOIN Departments AS D2 ON D1.Building = D2.Building
WHERE D2.Name = 'Cardiology' AND D1.Name <> 'Cardiology';

-- 2. Виведіть назви відділень, які знаходяться у тому ж корпусі, що й відділення «Gastroenterology» та «General Surgery».
SELECT D1.Name AS 'Department Name'
FROM Departments AS D1
JOIN Departments AS D2 ON D1.Building = D2.Building
WHERE D2.Name IN ('Gastroenterology', 'General Surgery') AND D1.Name NOT IN ('Gastroenterology', 'General Surgery');

-- 3. Виведіть назву відділення, яке отримало найменше пожертвувань.
SELECT TOP 1 Departments.Name AS 'Department Name'
FROM Departments
JOIN Donations ON Departments.Id = Donations.DepartmentId
GROUP BY Departments.Name
ORDER BY SUM(Donations.Amount);

-- 4. Виведіть прізвища лікарів, ставка яких більша, ніж у лікаря «Thomas Gerada».
SELECT Surname AS 'Doctor Surname'
FROM Doctors
WHERE (Salary + Premium) > (SELECT Salary + Premium FROM Doctors WHERE Name = 'Thomas Gerada');

-- 5. Виведіть назви палат, місткість яких більша, ніж середня місткість палат відділення «Microbiology».
SELECT Wards.Name AS 'Ward Name'
FROM Wards
JOIN Departments ON Wards.DepartmentId = Departments.Id
WHERE Wards.Places > (SELECT AVG(Wards.Places) FROM Wards WHERE DepartmentId = (SELECT Id FROM Departments WHERE Name = 'Microbiology'));

-- 6. Виведіть повні імена лікарів, зарплати яких (сума ставки та надбавки) перевищують, більше, ніж на 100, зарплату лікаря «Anthony Davis».
SELECT CONCAT(Name, ' ', Surname) AS 'Doctor Name'
FROM Doctors
WHERE (Salary + Premium) > ((SELECT Salary + Premium FROM Doctors WHERE Name = 'Anthony Davis') + 100);

-- 7. Виведіть назви відділень, в яких проводить обстеження лікар «Joshua Bell».
SELECT DISTINCT Dep.Name AS 'Department Name'
FROM DoctorsDepartments AS DD
JOIN Doctors AS Doc ON DD.DoctorId = Doc.Id 
JOIN Departments AS Dep ON DD.DepartmentId = Dep.Id 
JOIN DoctorsExaminations AS DE ON DE.DoctorId = Doc.Id
WHERE Doc.Name = 'Joshua Bell';

-- 8. Виведіть назви спонсорів, які не робили пожертвування відділенням «Neurology» та «Oncology».
SELECT Sponsors.Name AS 'Sponsor Name'
FROM Sponsors
WHERE Sponsors.Id NOT IN (SELECT SponsorId FROM Donations WHERE DepartmentId IN (SELECT Id FROM Departments WHERE Name IN ('Neurology', 'Oncology')));

-- 9. Виведіть прізвища лікарів, які проводять обстеження у період з 12:00 до 15:00.
SELECT DISTINCT Doc.Surname AS 'Doctor Surname'
FROM DoctorsExaminations AS DE
JOIN Examinations AS E ON E.Id = DE.ExaminationId
JOIN Doctors AS Doc ON Doc.Id = DE.DoctorId
WHERE E.StartTime >= '12:00:00' AND E.EndTime <= '15:00:00';

-- 10. Виведіть кількість палат, місткість яких більша за 10.
SELECT COUNT(*) AS 'Wards Count'
FROM Wards
WHERE Places > 10;

-- 11. Виведіть назви корпусів і кількість палат у кожному з них.
SELECT Departments.Building AS 'Building Name', COUNT(*) AS 'Wards Count'
FROM Departments
JOIN Wards ON Departments.Id = Wards.DepartmentId
GROUP BY Departments.Building;

-- 12. Виведіть назви відділень і кількість палат у кожному з них.
SELECT Departments.Name AS 'Department Name', COUNT(*) AS 'Wards Count'
FROM Departments
JOIN Wards ON Departments.Id = Wards.DepartmentId
GROUP BY Departments.Name;

-- 13. Виведіть назви відділень і сумарну надбавку лікарів у кожному з них.
SELECT Dep.Name AS 'Department Name', SUM(Doc.Premium) AS 'Total Premium'
FROM DoctorsDepartments AS DD
JOIN Doctors AS Doc ON Doc.Id = DD.DoctorId
JOIN Departments AS Dep ON Dep.Id = DD.DepartmentId
GROUP BY Dep.Name;

-- 14. Виведіть назви відділень, в яких проводять обстеження 5 та більше лікарів.
SELECT Dep.Name AS 'Department Name'
FROM DoctorsDepartments AS DD
JOIN Doctors AS Doc ON Doc.Id = DD.DoctorId
JOIN Departments AS Dep ON Dep.Id = DD.DepartmentId
JOIN DoctorsExaminations AS DE ON Doc.Id = DE.DoctorId
GROUP BY Dep.Name
HAVING COUNT(DISTINCT Doc.Id) >= 5;

-- 15. Виведіть кількість лікарів та їх сумарну зарплату (сума ставки та надбавки).
SELECT COUNT(*) AS 'Doctors Count', SUM(Salary + Premium) AS 'Total Salary'
FROM Doctors;

-- 16. Виведіть середню зарплату (сума ставки та надбавки) лікарів.
SELECT AVG(Salary + Premium) AS 'Avarage Salary'
FROM Doctors;

-- 17. Виведіть назви палат з мінімальною місткістю.
SELECT Name AS 'Ward Name'
FROM Wards
WHERE Places = (SELECT MIN(Places) FROM Wards);

-- 18. Виведіть, в яких із корпусів 1, 6, 7 та 8 сумарна кількість місць у палатах перевищує 100. При цьому враховуватиме лише палати з кількістю місць більше 10.
SELECT Departments.Building AS 'Building Name', SUM(Wards.Places) AS 'Total Places'
FROM Departments
JOIN Wards ON Departments.Id = Wards.DepartmentId
WHERE Departments.Building IN (1, 6, 7, 8) AND Wards.Places > 10
GROUP BY Departments.Building
HAVING SUM(Wards.Places) > 100;

