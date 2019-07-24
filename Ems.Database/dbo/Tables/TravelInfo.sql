CREATE TABLE [dbo].[TravelInfo] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [ModifiedBy]   NVARCHAR (MAX) NULL,
    [EmployeeID]   INT            NOT NULL,
    [Destination]  NVARCHAR (MAX) NULL,
    [Purpose]      NVARCHAR (MAX) NULL,
    [Date]         DATETIME2 (7)  NOT NULL,
    [StartDate]    DATETIME2 (7)  NOT NULL,
    [EndDate]      DATETIME2 (7)  NOT NULL,
    [StartTime]    DATETIME2 (7)  NOT NULL,
    [EndTime]      DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_TravelInfo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TravelInfo_Employee_EmployeeID] FOREIGN KEY ([EmployeeID]) REFERENCES [dbo].[Employee] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_TravelInfo_EmployeeID]
    ON [dbo].[TravelInfo]([EmployeeID] ASC);

