CREATE TABLE [dbo].[MstExpenses] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [ModifiedBy]   NVARCHAR (MAX) NULL,
    [Comment]      NVARCHAR (MAX) NULL,
    [Order]        INT            NOT NULL,
    CONSTRAINT [PK_MstExpenses] PRIMARY KEY CLUSTERED ([ID] ASC)
);

