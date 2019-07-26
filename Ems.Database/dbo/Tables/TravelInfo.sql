CREATE TABLE [dbo].[TravelInfo] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [CreatedDate]   DATETIME2 (7)  NOT NULL,
    [ModifiedDate]  DATETIME2 (7)  NULL,
    [ModifiedBy]    NVARCHAR (MAX) NULL,
    [Destination]   NVARCHAR (MAX) NULL,
    [Purpose]       NVARCHAR (MAX) NULL,
    [Date]          DATETIME2 (7)  NOT NULL,
    [StartDate]     DATETIME2 (7)  NOT NULL,
    [EndDate]       DATETIME2 (7)  NOT NULL,
    [StartTime]     DATETIME2 (7)  NOT NULL,
    [EndTime]       DATETIME2 (7)  NOT NULL,
    [IsApproved]    BIT            NULL,
    [RecieptDoc]    NVARCHAR (MAX) NULL,
    [BankName]      NVARCHAR (MAX) NULL,
    [Currency]      NVARCHAR (MAX) NULL,
    [Department]    NVARCHAR (MAX) NULL,
    [EmployeeFName] NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    [EmployeeLName] NVARCHAR (MAX) NULL,
    [IBAN]          NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_TravelInfo] PRIMARY KEY CLUSTERED ([ID] ASC)
);








GO


