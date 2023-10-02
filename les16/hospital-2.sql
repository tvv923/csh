-- ������������ ���� Hospital
USE Hospital;
GO

-- ��������� �� ������� ������ ���������
ALTER TABLE Doctors
ADD Specialization NVARCHAR(100);
GO

-- ��������� �� ������� ������ ���������
ALTER TABLE Doctors
ADD Premium MONEY NOT NULL DEFAULT 0;
go

-- ��������� �� ������� ������ ���������
ALTER TABLE Wards
ADD DepartmentId INT NOT NULL DEFAULT 0;
GO

-- ��������� ����� � ��������
UPDATE Wards SET DepartmentId=Id;
GO

-- ��������� ���������� �����
ALTER TABLE Wards
ADD FOREIGN KEY (DepartmentId) REFERENCES Departments(Id);

-- ��������� �������
CREATE TABLE Specializations (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- ��������� �������
CREATE TABLE Sponsors (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL UNIQUE
);

-- ��������� �������
CREATE TABLE Vacations (
    Id INT IDENTITY PRIMARY KEY,
    EndDate DATE NOT NULL,
    StartDate DATE NOT NULL,
    DoctorId INT NOT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id)
);
GO

-- ��������� �������
CREATE TABLE DoctorsSpecializations (
    Id INT IDENTITY PRIMARY KEY,
    DoctorId INT NOT NULL,
    SpecializationId INT NOT NULL,
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (SpecializationId) REFERENCES Specializations(Id)
);

-- ��������� ������� "���� ���� ������ ��� ����������" ��������� �������
CREATE TABLE DoctorsExaminations ( 
    Id INT IDENTITY PRIMARY KEY,
    DoctorId INT NOT NULL,
    ExaminationId INT NOT NULL,
	WardId INT NOT NULL,
	ExaminationtDate DATE NOT NULL,                     -- ���� ����������
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (ExaminationId) REFERENCES Examinations(Id),
	FOREIGN KEY (WardId) REFERENCES Wards(Id)
);

-- ��������� ������� "� ����� ������� ������ ���� ����" ��������� �������
CREATE TABLE DoctorsDepartments (
    Id INT IDENTITY PRIMARY KEY,
    DoctorId INT NOT NULL,
    DepartmentId INT NOT NULL,	
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id)
);

-- ��������� ������� "�� ������� ��� ���� ����"  ��������� �������
CREATE TABLE DoctorsDiseases (
    Id INT IDENTITY PRIMARY KEY,
    DoctorId INT NOT NULL,
    DiseaseId INT NOT NULL,	
    FOREIGN KEY (DoctorId) REFERENCES Doctors(Id),
    FOREIGN KEY (DiseaseId) REFERENCES Diseases(Id)
);

-- ��������� �������
CREATE TABLE Donations (
    Id INT IDENTITY PRIMARY KEY,
    Amount MONEY NOT NULL CHECK (Amount > 0),
    Date DATE NOT NULL DEFAULT GETDATE(),
    DepartmentId INT NOT NULL,
    SponsorId INT NOT NULL,
    FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
    FOREIGN KEY (SponsorId) REFERENCES Sponsors(Id)
);

-- ������� �����
INSERT INTO Specializations (Name)
VALUES ('Cardiology'), ('Pediatrics'), ('Orthopedics'), ('Oncology'), ('Intensive Treatment');
GO

-- ������� �����
INSERT INTO Sponsors (Name)
VALUES ('Umbrella Corporation'), ('Wayne Enterprises'), ('Stark Industries');
GO

-- ������� �����
INSERT INTO DoctorsExaminations (ExaminationId, DoctorId, WardId, ExaminationtDate)
VALUES
    (1, 1, 1, '2023-09-10'),
    (2, 2, 2, '2023-09-15'),
    (3, 3, 3, '2023-09-20'),
    (4, 4, 4, '2023-09-25'),
    (5, 5, 5, '2023-09-30');
GO

-- ������� �����
INSERT INTO DoctorsDepartments (DoctorId, DepartmentId)
VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5);
GO

-- ������� �����
INSERT INTO DoctorsDiseases (DoctorId, DiseaseId)
VALUES (1, 1), (2, 2), (3, 3), (4, 4), (5, 5);
GO

-- ��������� �������
UPDATE Doctors SET Premium=500, Specialization='Cardiology' WHERE Id=1;
UPDATE Doctors SET Premium=550, Specialization='Pediatrics' WHERE Id=2;
UPDATE Doctors SET Premium=600, Specialization='Orthopedics' WHERE Id=3;
UPDATE Doctors SET Premium=650, Specialization='Oncology' WHERE Id=4;
UPDATE Doctors SET Premium=0, Specialization='Intensive Treatment' WHERE Id=5;
GO

-- ������� �����
INSERT INTO DoctorsSpecializations (DoctorId, SpecializationId)
VALUES (1, 1), (1, 2), (2, 2), (2, 3), (3, 3), (3, 4), (4, 4);
GO

-- ������� �����
INSERT INTO Donations (Amount, Date, DepartmentId, SponsorId)
VALUES
    (100000.00, '2023-01-01', 1, 1),
    (50000.00, '2023-02-02', 2, 2),
    (150000.00, '2023-09-20', 3, 3),
    (800000.00, '2023-09-25', 5, 2),
    (120000.00, '2023-09-30', 4, 1);

-- ������� �����
INSERT INTO Vacations (EndDate, StartDate, DoctorId)
VALUES ('2023-10-10', '2023-10-01', 1), ('2023-09-20', '2023-09-10', 3);
GO

-- 1. ������� ���� ����� ����� �� �� ������������.
SELECT CONCAT(Doctors.Name, ' ', Doctors.Surname) AS 'Full Name', Specializations.Name AS 'Specialization'
FROM Doctors
JOIN DoctorsSpecializations ON Doctors.Id = DoctorsSpecializations.DoctorId
JOIN Specializations ON DoctorsSpecializations.SpecializationId = Specializations.Id;

-- 2. ������� ������� �� �������� (���� ������ �� ��������) �����, �� �� ����������� � ��������.
SELECT Surname, (Salary + Premium) AS 'Total Salary'
FROM Doctors
WHERE Id NOT IN (SELECT DISTINCT DoctorId FROM Vacations);

-- 3. ������� ����� �����, �� ����������� � ������� �Intensive Treatment�.
SELECT Wards.Name AS 'Ward Name'
FROM Wards
JOIN Departments ON Wards.DepartmentId = Departments.Id
WHERE Departments.Name = 'Intensive Treatment';

-- 4. ������� ����� ������� ��� ���������, �� ������������� ������� �Umbrella Corporation�.
SELECT DISTINCT Departments.Name AS 'Department Name'
FROM Departments
JOIN Donations ON Departments.Id = Donations.DepartmentId
JOIN Sponsors ON Donations.SponsorId = Sponsors.Id
WHERE Sponsors.Name = 'Umbrella Corporation';

-- 5. ������� �� ������������� �� ������� ����� � ������: ��������, �������, ���� �������������, ���� �������������.
SELECT Departments.Name AS 'Department Name', Sponsors.Name AS 'Sponsor Name', Amount AS 'Donation Amount', Date AS 'Donation Date'
FROM Donations
JOIN Departments ON Donations.DepartmentId = Departments.Id
JOIN Sponsors ON Donations.SponsorId = Sponsors.Id
WHERE Donations.Date >= DATEADD(MONTH, -1, GETDATE());

-- 6. ������� ������� ����� �� ����������� �������, � ���� ���� ��������� ����������. ���������� ����������, �� ����������� ���� � ���� ��.
SELECT CONCAT(Doc.Name, ' ', Doc.Surname) AS 'Doctor Name', Dep.Name AS 'Examination Name', E.DayOfWeek AS 'Examination Day'
FROM Doctors AS Doc
JOIN DoctorsExaminations AS DE ON Doc.Id=DE.DoctorId
JOIN Examinations AS E ON DE.ExaminationId = E.Id
JOIN DoctorsDepartments AS DD ON DD.DoctorId = Doc.Id
JOIN Departments AS Dep ON Dep.Id = DD.DepartmentId
WHERE E.DayOfWeek BETWEEN 1 AND 5;

-- 7. ������� ����� ����� � ������� �������, � ���� ��������� ���������� ���� �Helen Williams�.
SELECT W.Name AS 'Ward Name', DE.Name AS 'Department Name'
FROM Wards AS W
JOIN Departments AS DE ON W.DepartmentId = DE.Id
JOIN DoctorsDepartments AS DD ON DD.DoctorId = DE.Id
JOIN Doctors AS Doc ON Doc.Id = DD.DoctorId
WHERE CONCAT(Doc.Name, ' ', Doc.Surname) = 'Helen Williams';

-- 8. ������� ����� �������, �� ���������� ������������� � ����� ����� 100000, �� ����������� �� �����.
SELECT DISTINCT Dep.Name AS 'Department Name', CONCAT(Doc.Name, ' ', Doc.Surname) AS 'Doctor Name'
FROM Departments AS Dep
JOIN Donations AS Don ON Dep.Id = Don.DepartmentId
JOIN Doctors AS Doc ON Dep.Id = Doc.Id
WHERE Don.Amount > 100000;

-- 9. ������� ����� �������, � ���� ���� �� ��������� ��������.
SELECT DISTINCT Dep.Name AS 'Department Name'
FROM Departments AS Dep
JOIN DoctorsDepartments AS DD ON Dep.Id = DD.DepartmentId
JOIN Doctors AS Doc ON Doc.Id = DD.DoctorId
WHERE Doc.Premium = 0;

-- 10. ������� ����� ������������, �� ������ ������ � ������� ����������� �� �������� ������� ���� 3.
SELECT DISTINCT S.Name AS 'Specialization Name'
FROM Specializations AS S
JOIN DoctorsSpecializations AS DS ON S.Id = DS.SpecializationId
JOIN Doctors AS Doc ON Doc.Id = DS.DoctorId
JOIN DoctorsDiseases AS DD ON DD.DoctorId = Doc.Id
JOIN Diseases AS Dis ON Dis.Id = DD.DiseaseId
WHERE Dis.Severity > 3;

-- 11. ������� ����� ������� � ����� �����������, ���������� � ���� ���� ��������� �� ������ ������.
SELECT DISTINCT Dep.Name AS 'Department Name', DS.Name AS 'Disease Name'
FROM Departments AS Dep
JOIN DoctorsDepartments AS DD ON DD.DepartmentId = Dep.Id
JOIN DoctorsExaminations AS DE ON DE.DoctorId = DD.DoctorId
JOIN DoctorsDiseases AS Dis ON Dis.DoctorId = DD.DoctorId
JOIN Diseases AS DS ON DS.Id = Dis.DiseaseId
JOIN Examinations AS E ON E.Id = DE.ExaminationId
WHERE DE.ExaminationtDate >= DATEADD(MONTH, -6, GETDATE());

-- 12. ������� ����� ������� � ����� �����, � ���� ����������� ���������� �� �������� �����������.
SELECT DISTINCT Dep.Name AS 'Department Name', W.Name AS 'Ward Name'
FROM Departments AS Dep
JOIN Wards AS W ON Dep.Id = W.DepartmentId
JOIN DoctorsDepartments AS DD ON DD.DepartmentId = Dep.Id
JOIN DoctorsExaminations AS DE ON DE.DoctorId = DD.DoctorId
JOIN DoctorsDiseases AS Dis ON Dis.DoctorId = DD.DoctorId
JOIN Diseases AS DS ON (DS.Id = Dis.DiseaseId And DS.Name = 'Influenza');



