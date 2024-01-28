CREATE TABLE [dbo].[GameEntities] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [Date]                    DATETIME         NOT NULL,
    [CourseName]              NVARCHAR (MAX)   NULL,
    [Location]                NVARCHAR (MAX)   NULL,
    [Price]                   FLOAT (53)       NOT NULL,
    [ProviderCourseId]        INT              NOT NULL,
    [Holes]                   INT              NOT NULL,
    [NumberOfPlayers]         INT              NOT NULL,
    [PackageCombination]      NVARCHAR (MAX)   NULL,
    [CreatorUserClientSecret] NVARCHAR (MAX)   NULL,
    [Creator]                 UNIQUEIDENTIFIER NOT NULL,
    [FullyPaid]               BIT              NOT NULL,
    CONSTRAINT [PK_dbo.GameEntities] PRIMARY KEY CLUSTERED ([Id] ASC)
);

