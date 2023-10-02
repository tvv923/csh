-- ��������� ���� ����� ��� ����������
CREATE DATABASE BarberShopDB;
GO

-- ������������� ���� ����� BarberShopDB
USE BarberShopDB;
GO

-- ��������� ������� ��� ����� �������
CREATE TABLE Barbers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(255) NOT NULL,                                                -- ϲ� �������
    Gender VARCHAR(10) NOT NULL,                                                   -- ����� ������� 
    ContactPhone VARCHAR(15) NOT NULL,                                             -- �������
    Email VARCHAR(255) NOT NULL,                                                   -- ������ �����
    DateOfBirth DATE NOT NULL,                                                     -- ���� ����������
    HireDate DATE NOT NULL,                                                        -- ���� ��������� �� ������ 
    Position VARCHAR(20) NOT NULL CHECK (Position IN ('Chief Barber', 'Senior Barber', 'Junior Barber'))       -- ��� ������� ����� ������
);
GO

-- ��������� ������� ��� ������
CREATE TABLE Services (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name VARCHAR(255) NOT NULL,                                                     -- ����� �������
    Price DECIMAL(10, 2) NOT NULL,                                                  -- ������� ������� 
    Duration TIME NOT NULL CHECK (Duration >= '00:15:00' AND Duration <= '02:00:00') -- ��������� ������� �� 15 ������ �� 2 �����
);
GO

-- ��������� ������� ��� �������� �������
CREATE TABLE BarberSchedule (
    Id INT PRIMARY KEY IDENTITY(1,1),
    BarberId INT NOT NULL,
    StartDate DATE NOT NULL,                                                        -- ���� ������� ������
    EndDate DATE NOT NULL,                                                          -- ���� ���������� ������
    WorkPeriod INT NOT NULL,                                                        -- 1-�� ������, 2-�� ��������, 3-������ ����
    StartTime TIME NOT NULL CHECK (StartTime >= '08:00:00' AND StartTime <= '20:00:00'),  -- ��� ������� ������
    EndTime TIME NOT NULL CHECK (EndTime >= '08:00:00' AND EndTime <= '20:00:00'),    -- ��� ���������� ������
    FOREIGN KEY (BarberId) REFERENCES Barbers(Id) ON DELETE CASCADE
);
GO

-- ��������� ������� ��� ������ �������
CREATE TABLE BarberServices (
    Id INT PRIMARY KEY IDENTITY(1,1),
    BarberId INT NOT NULL,
    ServiceId INT NOT NULL,
    FOREIGN KEY (BarberId) REFERENCES Barbers(Id) ON DELETE CASCADE,
    FOREIGN KEY (ServiceId) REFERENCES Services(Id) ON DELETE CASCADE
);
GO

-- ��������� ������� ��� ����� �볺���
CREATE TABLE Clients (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FullName VARCHAR(255) NOT NULL,                                                  -- ϲ� �볺���
    ContactPhone VARCHAR(15) NOT NULL,                                               -- �������
    Email VARCHAR(255) NOT NULL                                                      -- ������ �����
);
GO

-- ��������� ������� ��� �볺��� �������
CREATE TABLE BarberClients (
    Id INT PRIMARY KEY IDENTITY(1,1),
    BarberId INT NOT NULL,
    ClientId INT NOT NULL,
    ServiceId INT NOT NULL,
    HaircutDate DATE NOT NULL,                                                                                      -- ���� ������� ������� ������� �볺���
    StartTime TIME NOT NULL CHECK (StartTime >= '08:00:00' AND StartTime <= '18:00:00'),                                  -- ��� ������� ������� �������
    BarberRating VARCHAR(20) NOT NULL CHECK (BarberRating IN ('Very Poor', 'Poor', 'Normal', 'Good', 'Excellent')),   -- ������ ������� �� �볺��� 
    Feedback TEXT,                                                                                                  -- ³���� �� �볺���
    FOREIGN KEY (BarberId) REFERENCES Barbers(Id) ON DELETE CASCADE,
    FOREIGN KEY (ClientId) REFERENCES Clients(Id) ON DELETE CASCADE,
    FOREIGN KEY (ServiceId) REFERENCES Services(Id) ON DELETE CASCADE
);
GO

-- ������, �� ��������� ��������� ���������� ��� ���-�������, ���� �� ������ ������ ���-������
CREATE TRIGGER PreventDeleteChiefBarber
ON Barbers
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @barberId INT, @barberPosition VARCHAR(20);
	SELECT @barberId = Id, @barberPosition = Position FROM DELETED;
    IF NOT (@barberPosition = 'Chief Barber' AND (SELECT COUNT(*) FROM Barbers WHERE Position = 'Chief Barber') = 1)
		DELETE FROM Barbers WHERE Id = @barberId;
END;
GO

-- ������, ���� ��������� �������� ������� ������� 21 ����
CREATE TRIGGER PreventUnderageBarber
ON Barbers
INSTEAD OF INSERT 
AS
BEGIN
	DECLARE @NewDateOfBirth DATE;
	SELECT @NewDateOfBirth = DateOfBirth FROM INSERTED;	
    IF DATEDIFF(YEAR, @NewDateOfBirth, GETDATE()) >= 21    
		INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
	    SELECT FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position FROM INSERTED;
END;
GO

-- ��������� ��������� ��� ��������� ϲ� ��� ������� ������. 
CREATE PROCEDURE GetAllBarbersNames AS
BEGIN
    SELECT FullName
    FROM Barbers;
END;
GO

-- ��������� ��������� ��� ��������� ���������� ��� ��� �������-�������. 
CREATE PROCEDURE GetSeniorBarbers AS
BEGIN
    SELECT *
    FROM Barbers
    WHERE Position = 'Senior Barber';
END; 
GO

-- ��������� ��������� ��� ��������� ���������� ��� ��� �������, �� ������ ������ ������� ������������ ������ ������. 
CREATE PROCEDURE GetBarbersForTraditionalShave AS
BEGIN
    SELECT B.*
    FROM Barbers B
    INNER JOIN BarberServices BS ON B.Id = BS.BarberId
    INNER JOIN Services S ON BS.ServiceId = S.Id
    WHERE S.Name='Shave';
END;
GO

-- ��������� ��������� ��� ��������� ���������� ��� ��� �������, �� ������ ������ ��������� �������. ���������� ��� ������� ������� �������� �� ��������.
CREATE PROCEDURE GetBarbersForService(@serviceName VARCHAR(255)) AS
BEGIN
    SELECT B.*
    FROM Barbers B
    INNER JOIN BarberServices BS ON B.Id = BS.BarberId
    INNER JOIN Services S ON BS.ServiceId = S.Id
    WHERE S.Name = @serviceName;
END;
GO

-- ��������� ��������� ��� ��������� ���������� ��� ��� �������, �� �������� ����� ��������� ������� ����. ʳ������ ���� ���������� �� ��������. 
CREATE PROCEDURE GetExperiencedBarbers(@yearsOfExperience INT) AS
BEGIN
    SELECT *
    FROM Barbers
    WHERE DATEDIFF(YEAR, HireDate, GETDATE()) > @yearsOfExperience;
END;
GO

-- ��������� ��������� ��� ��������� ������� �������-������� �� ������� ������-�������. 
CREATE PROCEDURE GetSeniorAndJuniorBarberCounts AS
BEGIN
    SELECT
        (SELECT COUNT(*) FROM Barbers WHERE Position = 'Senior Barber') AS SeniorBarberCount,
        (SELECT COUNT(*) FROM Barbers WHERE Position = 'Junior Barber') AS JuniorBarberCount;
END;
GO

-- ��������� ��������� ��� ��������� ���������� ��� �������� �볺���. ������� ��������� �볺���: ��� � ����� ������ ������� ����. ʳ������ ���������� �� ��������. 
CREATE PROCEDURE GetRegularClients(@visitCount INT) AS
BEGIN
    SELECT C.Id, C.FullName
    FROM Clients C
    INNER JOIN BarberClients BC ON C.Id = BC.ClientId
    GROUP BY C.Id, C.FullName
    HAVING COUNT(BC.BarberId) >= @visitCount;
END;
GO

-- ������� ����������� ��� ��������� ������
CREATE FUNCTION GreetUser(@Name VARCHAR(255)) 
RETURNS VARCHAR(255)
AS
BEGIN
    RETURN CONCAT('Hello, ', @Name, '!');
END;
GO

-- ������� ����������� ��� ��������� ������� ������� ������
CREATE FUNCTION GetCurrentMinutes()
RETURNS INT
AS
BEGIN
    RETURN (SELECT FORMAT(GETDATE(),'mm'));
END;
GO

-- ������� ����������� ��� ��������� ��������� ����
CREATE FUNCTION GetCurrentYear()
RETURNS INT
AS
BEGIN
    RETURN YEAR(GETDATE());
END;
GO

-- ������� ����������� ��� ���������� ������� ��� ��������� ����
CREATE FUNCTION IsYearEvenOrOdd(@Year INT)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @yearType VARCHAR(10);
    IF @Year % 2 = 0 
        SET @yearType = 'Even';
    ELSE
        SET @yearType = 'Odd';    
	RETURN @yearType;
END;
GO

-- ������� ����������� ��� ����������, �� � ����� �������
CREATE FUNCTION IsPrime(@Number INT)
RETURNS VARCHAR(3)
AS
BEGIN
    DECLARE @i INT;
    DECLARE @isPrime VARCHAR(3);
    SET @i = 2;
    SET @isPrime = 'yes';
    WHILE @i <= @Number / 2 
	    BEGIN 
			IF @Number % @i = 0 
				BEGIN
					SET @isPrime = 'no';
					BREAK;
				END;
		    SET @i = @i + 1;
		END;
    RETURN @isPrime;
END;
GO

-- ������� ����������� ��� ��������� ���� ���������� �� ������������� ��������
CREATE FUNCTION GetSumOfMinMax(@Num1 INT, @Num2 INT, @Num3 INT, @Num4 INT, @Num5 INT)
RETURNS INT
BEGIN
    DECLARE @MinValue INT;
    DECLARE @MaxValue INT;
    SET @MinValue = LEAST(@Num1, LEAST(@Num2, LEAST(@Num3, LEAST(@Num4, @Num5))));
    SET @MaxValue = GREATEST(@Num1, GREATEST(@Num2, GREATEST(@Num3, GREATEST(@Num4, @Num5))));
    RETURN @MinValue + @MaxValue;
END;
GO

-- ������� ����������� ��� ������ ��� ������ ��� �������� ����� � �������
CREATE FUNCTION GetEvenOrOddNumbers(@Start INT, @End INT, @EvenOrOdd VARCHAR(5))
RETURNS VARCHAR(255)
AS
BEGIN
    DECLARE @result VARCHAR(255);
    DECLARE @i INT;
    SET @result = '';
    SET @i = @Start;
    WHILE @i <= @End 
		BEGIN
			IF @EvenOrOdd = 'even' AND @i % 2 = 0 
	            SET @result = CONCAT(@result, @i, ' ');
			ELSE
				IF @EvenOrOdd = 'odd' AND @i % 2 <> 0 
					SET @result = CONCAT(@result, @i, ' ');				
			SET @i = @i + 1;
		END;
    RETURN TRIM(@result);
END;
GO

-- ��������� ��������� ��� ��������� "Hello, world!"
CREATE PROCEDURE SayHelloWorld AS
BEGIN
    SELECT 'Hello, world!';
END;
GO

-- ��������� ��������� ��� ��������� ��������� ����
CREATE PROCEDURE GetCurrentTime AS
BEGIN
    SELECT FORMAT(GETDATE(),'HH:mm:ss'); 
END;
GO

-- ��������� ��������� ��� ��������� ������� ����
CREATE PROCEDURE GetCurrentDate AS
BEGIN
    SELECT CONVERT(DATE, GETDATE());
END;
GO

-- ��������� ��������� ��� ���������� ���� ����� �����
CREATE PROCEDURE GetSumOfThreeNumbers(@Num1 INT, @Num2 INT, @Num3 INT) AS
BEGIN
    SELECT @Num1 + @Num2 + 	@Num3;
END;
GO

-- ��������� ��������� ��� ���������� ��������������������� ����� �����
CREATE PROCEDURE GetAverageOfThreeNumbers(@Num1 INT, @Num2 INT, @Num3 INT) AS
BEGIN
    SELECT (@Num1 + @Num2 + @Num3) / 3;
END;
GO

-- ��������� ��������� ��� ��������� ������������� �������� � ����� �����
CREATE PROCEDURE GetMaxOfThreeNumbers(@Num1 INT, @Num2 INT, @Num3 INT) AS
BEGIN
    SELECT GREATEST(@Num1, GREATEST(@Num2, @Num3));
END;
GO

-- ��������� ��������� ��� ��������� ���������� �������� � ����� �����
CREATE PROCEDURE GetMinOfThreeNumbers(@Num1 INT, @Num2 INT, @Num3 INT) AS
BEGIN
    SELECT LEAST(@Num1, LEAST(@Num2, @Num3));
END;
GO

-- ��������� ��������� ��� �������� �� � ������� ��������
CREATE PROCEDURE PrintLineWithSymbol(@Length INT, @Symbol CHAR(1)) AS
BEGIN
    DECLARE @i INT;
    DECLARE @Line VARCHAR(255);
    SET @Line = '';
    SET @i = 1;
    WHILE @i <= @Length 
		BEGIN
	        SET @Line = CONCAT(@Line, @Symbol);
		    SET @i = @i + 1;
		END;
    SELECT @Line;
END;
GO

-- ��������� ��������� ��� ���������� ��������� �����
CREATE PROCEDURE CalculateFactorial(@Number INT) AS
BEGIN
    DECLARE @Result INT;
    DECLARE @i INT;
    SET @Result = 1;
    SET @i = 1;
    WHILE @i <= @Number
		BEGIN
			SET @Result = @Result * @i;
			SET @i = @i + 1;
		END;
    SELECT @Result;
END;
GO

-- ��������� ��������� ��� ��������� ����� �� �������
CREATE PROCEDURE CalculatePower(@Base INT, @Exponent INT) AS
BEGIN
    DECLARE @Result INT;
    SET @Result = POWER(@Base, @Exponent);
    SELECT @Result;
END;
GO

-- ���������� ������� ������
INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES ('John Doe', 'Male', '123-456-7890', 'john@example.com', '1990-05-15', '2021-03-10', 'Chief Barber');
INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES ('Jane Smith', 'Female', '987-654-3210', 'jane@example.com', '1985-11-20', '2021-04-05', 'Senior Barber');
INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES ('Michael Johnson', 'Male', '555-111-2222', 'michael@example.com', '1988-09-30', '2021-02-15', 'Junior Barber');
INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES ('Emily Davis', 'Female', '555-333-4444', 'emily@example.com', '1992-07-12', '2022-01-20', 'Senior Barber');
INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES ('David Wilson', 'Male', '555-555-6666', 'david@example.com', '1995-03-25', '2023-05-10', 'Junior Barber');
INSERT INTO Barbers (FullName, Gender, ContactPhone, Email, DateOfBirth, HireDate, Position)
VALUES ('Olivia Johnson', 'Female', '555-777-8888', 'olivia@example.com', '1991-12-08', '2022-11-15', 'Junior Barber');
GO

INSERT INTO Services (Name, Price, Duration) VALUES ('Haircut', 30.00, '00:45:00');
INSERT INTO Services (Name, Price, Duration) VALUES ('Beard Trim', 15.00, '00:25:00');
INSERT INTO Services (Name, Price, Duration) VALUES ('Shave', 20.00, '00:30:00');
INSERT INTO Services (Name, Price, Duration) VALUES ('Moustache Trim', 10.00, '00:20:00');
INSERT INTO Services (Name, Price, Duration) VALUES ('Hair Color', 50.00, '01:15:00');
INSERT INTO Services (Name, Price, Duration) VALUES ('Manicure', 25.00, '00:30:00');
GO

INSERT INTO BarberSchedule (BarberId, StartDate, EndDate, WorkPeriod, StartTime, EndTime) 
VALUES (1, '2023-09-20', '2023-09-20', 1, '08:00:00', '18:00:00');
INSERT INTO BarberSchedule (BarberId, StartDate, EndDate, WorkPeriod, StartTime, EndTime) 
VALUES (2, '2023-09-21', '2023-09-21', 2, '08:00:00', '18:00:00');
INSERT INTO BarberSchedule (BarberId, StartDate, EndDate, WorkPeriod, StartTime, EndTime)
VALUES (3, '2023-09-22', '2023-09-22', 3, '08:00:00', '18:00:00');
INSERT INTO BarberSchedule (BarberId, StartDate, EndDate, WorkPeriod, StartTime, EndTime)
VALUES (4, '2023-09-23', '2023-09-23', 1, '08:00:00', '18:00:00');
INSERT INTO BarberSchedule (BarberId, StartDate, EndDate, WorkPeriod, StartTime, EndTime)
VALUES (5, '2023-09-24', '2023-09-24', 2, '08:00:00', '18:00:00');
INSERT INTO BarberSchedule (BarberId, StartDate, EndDate, WorkPeriod, StartTime, EndTime)
VALUES (6, '2023-09-25', '2023-09-25', 3, '08:00:00', '18:00:00');
GO

INSERT INTO BarberServices (BarberId, ServiceId) VALUES (1, 1);
INSERT INTO BarberServices (BarberId, ServiceId) VALUES (2, 2);
INSERT INTO BarberServices (BarberId, ServiceId) VALUES (3, 3);
INSERT INTO BarberServices (BarberId, ServiceId) VALUES (4, 4);
INSERT INTO BarberServices (BarberId, ServiceId) VALUES (5, 5);
INSERT INTO BarberServices (BarberId, ServiceId) VALUES (6, 6);
GO

INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES ('Alice Johnson', '555-123-4567', 'alice@example.com');
INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES ('Bob Smith', '555-987-6543', 'bob@example.com');
INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES ('Charlie Brown', '555-555-5555', 'charlie@example.com');
INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES ('David Wilson', '555-444-3333', 'david@example.com');
INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES ('Eva Davis', '555-777-8888', 'eva@example.com');
INSERT INTO Clients (FullName, ContactPhone, Email)
VALUES ('Frankie Johnson', '555-666-9999', 'frankie@example.com');
GO

INSERT INTO BarberClients (BarberId, ClientId, ServiceId, HaircutDate, StartTime, BarberRating, Feedback)
VALUES (1, 1, 1, '2023-09-20', '09:00:00', 'Good', 'Great service!');
INSERT INTO BarberClients (BarberId, ClientId, ServiceId, HaircutDate, StartTime, BarberRating, Feedback)
VALUES (2, 2, 2, '2023-09-21', '10:30:00', 'Excellent', 'Perfect beard trim!');
INSERT INTO BarberClients (BarberId, ClientId, ServiceId, HaircutDate, StartTime, BarberRating, Feedback)
VALUES (3, 3, 3, '2023-09-22', '14:00:00', 'Good', 'Nice shave!');
INSERT INTO BarberClients (BarberId, ClientId, ServiceId, HaircutDate, StartTime, BarberRating, Feedback)
VALUES (4, 4, 4, '2023-09-23', '08:30:00', 'Excellent', 'Awesome moustache trim!');
INSERT INTO BarberClients (BarberId, ClientId, ServiceId, HaircutDate, StartTime, BarberRating, Feedback)
VALUES (5, 5, 5, '2023-09-24', '11:15:00', 'Good', 'Nice hair color!');
INSERT INTO BarberClients (BarberId, ClientId, ServiceId, HaircutDate, StartTime, BarberRating, Feedback)
VALUES (6, 6, 6, '2023-09-25', '16:45:00', 'Excellent', 'Great manicure!');
GO

-- ��������� ϲ� ��� ������� ������. 
EXEC GetAllBarbersNames;
-- ��������� ���������� ��� ��� �������-�������. 
EXEC GetSeniorBarbers;
--��������� ���������� ��� ��� �������, �� ������ ������ ������� ������������ ������ ������. 
EXEC GetBarbersForTraditionalShave;
-- ��������� ���������� ��� ��� �������, �� ������ ������ ��������� �������. ���������� ��� ������� ������� �������� �� ��������.
EXEC GetBarbersForService 'Haircut';
-- ��������� ���������� ��� ��� �������, �� �������� ����� ��������� ������� ����. ʳ������ ���� ���������� �� ��������. 
EXEC GetExperiencedBarbers 5;
-- ��������� ������� �������-������� �� ������� ������-�������. 
EXEC GetSeniorAndJuniorBarberCounts;
-- ��������� ���������� ��� �������� �볺���. ������� ��������� �볺���: ��� � ����� ������ ������� ����. ʳ������ ���������� �� ��������. 
EXEC GetRegularClients 3;

-- ������� ����������� ������� ������ � ���� �Hello, ��'�!� �� ��'� ���������� �� ��������. ���������, ���� �������� Nick, �� ���� Hello, Nick! 
SELECT dbo.GreetUser('Nick');
-- ������� ����������� ������� ���������� ��� ������� ������� ������; 
SELECT dbo.GetCurrentMinutes();
-- ������� ����������� ������� ���������� ��� �������� ��; 
SELECT dbo.GetCurrentYear();
-- ������� ����������� ������� ���������� ��� ��: ������ ��� �������� ��; 
SELECT dbo.IsYearEvenOrOdd(2023);
-- ������� ����������� ������ ����� � ������� yes, ���� ����� ������ � no, ���� ����� �� ������; 
SELECT dbo.IsPrime(7);
-- ������� ����������� ������ �� ��������� �'��� �����. ������� ���� ���������� �� ������������� �������� � ��������� �'��� ���������;
SELECT dbo.GetSumOfMinMax(5, 8, 2, 10, 4);
-- ������� ����������� ������ �� ���� ��� ������ ����� � ���������� �������. ������� ������ ��� ���������: ������� ��������, ����� ��������, ����� �� ������� ����������.
SELECT dbo.GetEvenOrOddNumbers(1, 5, 'even');

-- ��������� ��������� �������� �Hello, world!�; 
EXEC SayHelloWorld;
-- ��������� ��������� ������� ���������� ��� �������� ���; 
EXEC GetCurrentTime;
-- ��������� ��������� ������� ���������� ��� ������� ����; 
EXEC GetCurrentDate;
-- ��������� ��������� ������ ��� ����� � ������� ���� ����; 
EXEC GetSumOfThreeNumbers 5, 8, 3;
-- ��������� ��������� ������ ��� ����� � ������� ������������������� ����� �����; 
EXEC GetAverageOfThreeNumbers 10, 15, 20;
-- ��������� ��������� ������ ��� ����� � ������� ����������� ��������; 
EXEC GetMaxOfThreeNumbers 30, 15, 25;
-- ��������� ��������� ������ ��� ����� � ������� �������� ��������; 
EXEC GetMinOfThreeNumbers 30, 15, 25;
-- ��������� ��������� ������ ����� �� ������. 
-- � ��������� ������ ��������� ��������� ������������  ��� ��������, �� ������� �����. ˳�� ���������� �� �������, ��������� � ������� ��������. 
EXEC PrintLineWithSymbol 5, '#';
-- ��������� ��������� ������ �� �������� ����� � ������� ���� ��������.
EXEC CalculateFactorial 4;
-- ��������� ��������� ������ ��� ������ ���������. ������ �������� � �� �����. ������ �������� � �� ������. ��������� ������� �����, ������� �� �������. 
EXEC CalculatePower 2, 3;

















