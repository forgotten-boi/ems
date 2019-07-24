CREATE TABLE [dbo].[TravelExpenses] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [ModifiedBy]   NVARCHAR (MAX) NULL,
    [TravelID]     INT            NOT NULL,
    [Details]      NVARCHAR (MAX) NULL,
    [Date]         DATETIME2 (7)  NOT NULL,
    [Expenses]     FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_TravelExpenses] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TravelExpenses_TravelInfo_TravelID] FOREIGN KEY ([TravelID]) REFERENCES [dbo].[TravelInfo] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_TravelExpenses_TravelID]
    ON [dbo].[TravelExpenses]([TravelID] ASC);

