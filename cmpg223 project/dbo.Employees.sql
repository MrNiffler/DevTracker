CREATE TABLE [dbo].[Employees] (
    [EmployeeID]          INT          NOT NULL,
    [employeeFirstName]   VARCHAR (30) NULL,
    [employeeLastname]    VARCHAR (30) NULL,
    [EmployeePhoneNumber] VARCHAR (10) NULL,
    [employeeEmail] VARCHAR(100) NULL, 
    PRIMARY KEY CLUSTERED ([EmployeeID] ASC)
);

