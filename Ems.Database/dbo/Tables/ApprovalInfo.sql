CREATE TABLE [dbo].[ApprovalInfo] (
    [ID]            INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]     NVARCHAR (MAX) NULL,
    [CreatedDate]   DATETIME2 (7)  NOT NULL,
    [ModifiedDate]  DATETIME2 (7)  NULL,
    [ModifiedBy]    NVARCHAR (MAX) NULL,
    [TravelID]      INT            NOT NULL,
    [IsApproved]    BIT            NOT NULL,
    [ApprovedBy]    NVARCHAR (MAX) NULL,
    [Comment]       NVARCHAR (MAX) NULL,
    [ApprovedDate]  DATETIME2 (7)  NOT NULL,
    [TotalExpenses] FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_ApprovalInfo] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_ApprovalInfo_TravelInfo_TravelID] FOREIGN KEY ([TravelID]) REFERENCES [dbo].[TravelInfo] ([ID])
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_ApprovalInfo_TravelID]
    ON [dbo].[ApprovalInfo]([TravelID] ASC);

