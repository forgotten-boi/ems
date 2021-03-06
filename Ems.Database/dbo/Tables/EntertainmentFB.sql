﻿CREATE TABLE [dbo].[EntertainmentFB] (
    [ID]           INT            IDENTITY (1, 1) NOT NULL,
    [CreatedBy]    NVARCHAR (MAX) NULL,
    [CreatedDate]  DATETIME2 (7)  NOT NULL,
    [ModifiedDate] DATETIME2 (7)  NULL,
    [ModifiedBy]   NVARCHAR (MAX) NULL,
    [Comment]      NVARCHAR (MAX) NULL,
    [Price]        FLOAT (53)     NOT NULL,
    [Date]         DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_EntertainmentFB] PRIMARY KEY CLUSTERED ([ID] ASC)
);

