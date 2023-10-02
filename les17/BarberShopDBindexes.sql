USE BarberShopDB;
GO

-- ��� Barbers ��� � ��������������� ������ �� ��������� Id, ������� Id � ������ �������, � �� ������������� ��������������� ������ ����������� ��� ���������� �����.
-- ��� BarberClients ��� � ��������������� ������ �� ��������� Id.
-- ��� BarberSchedule ��� � ��������������� ������ �� ��������� Id.
-- ��� BarberServices ��� � ��������������� ������ �� ��������� Id.
-- ��� Clients ��� � ��������������� ������ �� ��������� Id.
-- ��� Services ��� � ��������������� ������ �� ��������� Id.

-- ��� Barbers ����������������� ������ �� ��������� FullName ��� ������ �� ��'�� �������
CREATE NONCLUSTERED INDEX IX_Barbers_FullName ON Barbers(FullName);

-- ��� Services ����������������� ������ �� ��������� Name ��� ������ �� ������ �������
CREATE NONCLUSTERED INDEX IX_Services_Name ON Services(Name);

-- ��� BarberSchedule ����������������� ������ �� ���������� BarberId, StartDate � EndDate ��� ������ ������� ������ ������� �� ������
CREATE NONCLUSTERED INDEX IX_BarberSchedule_BarberId_StartDate_EndDate ON BarberSchedule(BarberId, StartDate, EndDate);

-- ��� BarberServices ����������������� ������ �� ���������� BarberId � ServiceId ��� ������ ����� ������, �� ���� ���������� ������
CREATE NONCLUSTERED INDEX IX_BarberServices_BarberId_ServiceId ON BarberServices(BarberId, ServiceId);

-- ��� BarberClients ����������������� ������ �� ���������� BarberId � ClientId ��� ������ �볺���, �� �������������� ���������� ��������
CREATE NONCLUSTERED INDEX IX_BarberClients_BarberId_ClientId ON BarberClients(BarberId, ClientId);


-- ����������� ������ ��� Clients ��� ������ �볺��� �� ���� ��������
CREATE INDEX IX_Composite_Clients ON Clients (FullName, ContactPhone);

-- ����������� ������ ��� Services ��� ������ ������� �� ����
CREATE INDEX IX_Composite_Services ON Services (Name, Price);


-- ������ � ���������� ����������� ��� Barbers, �� ������ Email �� �������� �� FullName, ContactPhone
CREATE INDEX IX_IncludedColumns_Barbers ON Barbers (Email) INCLUDE (FullName, ContactPhone);

-- ������ � ���������� ����������� ��� Services
CREATE INDEX IX_IncludedColumns_Services ON Services (Duration) INCLUDE (Price, Name);


-- ³������������� ������ ��� Barbers, ���� ������ ����� ����� � Position 'Senior Barber'
CREATE INDEX IX_Filtered_Barbers_Senior ON Barbers (Gender) WHERE Position = 'Senior Barber';

-- ³������������� ������ ��� BarberClients, ���� ������ ����� ����� � StartTime >= '10:00:00'
CREATE INDEX IX_Filtered_BarberClients_StartTime ON BarberClients (StartTime) WHERE StartTime >= '10:00:00';

-- ³������������� ������ ��� ������� BarberSchedule, ���� ������ ����� ����� � WorkPeriod = 1
CREATE INDEX IX_Filtered_BarberSchedule_WorkPeriod1 ON BarberSchedule (WorkPeriod) WHERE WorkPeriod = 1;

-- ³������������� ������ ��� ������� Services, ���� ������ ����� ����� � Price > 50:
CREATE INDEX idx_Filtered_Services_Price ON Services (Price) WHERE Price > 50;
