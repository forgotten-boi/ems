CREATE TABLE [dbo].[MiscExpenses] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [ModifiedBy]   NVARCHAR (MAX) NULL,
    [Comment]      NVARCHAR (MAX) NULL,
    [Price]        FLOAT (53)     NOT NULL,
    [Date]         DATETIME2 (7)  NOT NULL,
    [TraveExpID]   INT            DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_MiscExpenses] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_MiscExpenses_TravelExpenses_TraveExpID] FOREIGN KEY ([TraveExpID]) REFERENCES [dbo].[TravelExpenses] ([ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_MiscExpenses_TraveExpID]
    ON [dbo].[MiscExpenses]([TraveExpID] ASC);

