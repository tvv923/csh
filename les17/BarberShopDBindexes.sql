USE BarberShopDB;
GO

-- Для Barbers вже є кластеризований індекс на стовпчику Id, оскільки Id є ключем таблиці, і за замовчуванням кластеризований індекс створюється для первинного ключа.
-- Для BarberClients вже є кластеризований індекс на стовпчику Id.
-- Для BarberSchedule вже є кластеризований індекс на стовпчику Id.
-- Для BarberServices вже є кластеризований індекс на стовпчику Id.
-- Для Clients вже є кластеризований індекс на стовпчику Id.
-- Для Services вже є кластеризований індекс на стовпчику Id.

-- Для Barbers некластеризований індекс на стовпчику FullName для пошуку за ім'ям барбера
CREATE NONCLUSTERED INDEX IX_Barbers_FullName ON Barbers(FullName);

-- Для Services некластеризований індекс на стовпчику Name для пошуку за назвою послуги
CREATE NONCLUSTERED INDEX IX_Services_Name ON Services(Name);

-- Для BarberSchedule некластеризований індекс на стовпчиках BarberId, StartDate і EndDate для пошуку графіку роботи барбера за датами
CREATE NONCLUSTERED INDEX IX_BarberSchedule_BarberId_StartDate_EndDate ON BarberSchedule(BarberId, StartDate, EndDate);

-- Для BarberServices некластеризований індекс на стовпчиках BarberId і ServiceId для пошуку пошук послуг, які надає конкретний барбер
CREATE NONCLUSTERED INDEX IX_BarberServices_BarberId_ServiceId ON BarberServices(BarberId, ServiceId);

-- Для BarberClients некластеризований індекс на стовпчиках BarberId і ClientId для пошуку клієнтів, які обслуговуються конкретним барбером
CREATE NONCLUSTERED INDEX IX_BarberClients_BarberId_ClientId ON BarberClients(BarberId, ClientId);


-- Композитний індекс для Clients для пошуку клієнта та його телефона
CREATE INDEX IX_Composite_Clients ON Clients (FullName, ContactPhone);

-- Композитний індекс для Services для пошуку послуги та ціни
CREATE INDEX IX_Composite_Services ON Services (Name, Price);


-- Індекс з увімкненими стовпчиками для Barbers, що включає Email та посилаєця на FullName, ContactPhone
CREATE INDEX IX_IncludedColumns_Barbers ON Barbers (Email) INCLUDE (FullName, ContactPhone);

-- Індекс з увімкненими стовпчиками для Services
CREATE INDEX IX_IncludedColumns_Services ON Services (Duration) INCLUDE (Price, Name);


-- Відфільтрований індекс для Barbers, який містить тільки рядки з Position 'Senior Barber'
CREATE INDEX IX_Filtered_Barbers_Senior ON Barbers (Gender) WHERE Position = 'Senior Barber';

-- Відфільтрований індекс для BarberClients, який містить тільки рядки з StartTime >= '10:00:00'
CREATE INDEX IX_Filtered_BarberClients_StartTime ON BarberClients (StartTime) WHERE StartTime >= '10:00:00';

-- Відфільтрований індекс для таблиці BarberSchedule, який містить тільки рядки з WorkPeriod = 1
CREATE INDEX IX_Filtered_BarberSchedule_WorkPeriod1 ON BarberSchedule (WorkPeriod) WHERE WorkPeriod = 1;

-- Відфільтрований індекс для таблиці Services, який містить тільки рядки з Price > 50:
CREATE INDEX idx_Filtered_Services_Price ON Services (Price) WHERE Price > 50;
