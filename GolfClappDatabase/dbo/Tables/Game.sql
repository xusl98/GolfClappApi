CREATE TABLE [dbo].[Game] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [Date]                    DATETIME         NOT NULL,
    [CourseName]              VARCHAR (MAX)    NOT NULL,
    [Location]                VARCHAR (MAX)    NOT NULL,
    [Price]                   FLOAT (53)       NOT NULL,
    [ProviderCourseId]        INT              NOT NULL,
    [Holes]                   INT              NOT NULL,
    [PackageCombination]      VARCHAR (MAX)    NOT NULL,
    [NumberOfPlayers]         INT              NOT NULL,
    [CreatorUserClientSecret] VARCHAR (MAX)    NOT NULL,
    [Creator]                 UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Game_User] FOREIGN KEY ([Creator]) REFERENCES [dbo].[User] ([Id])
);

























