CREATE TABLE [dbo].[Employee] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [ModifiedBy]   NVARCHAR (MAX) NULL,
    [FirstName]    NVARCHAR (MAX) NOT NULL,
    [LastName]     NVARCHAR (MAX) NULL,
    [Email]        NVARCHAR (MAX) NOT NULL,
    [IBAN]         NVARCHAR (MAX) NULL,
    [BankName]     NVARCHAR (MAX) NULL,
    [Department]   NVARCHAR (MAX) NULL,
    [Currency]     NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED ([ID] ASC)
);

