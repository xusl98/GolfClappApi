CREATE TABLE [dbo].[Game] (
    [Id]               UNIQUEIDENTIFIER NOT NULL,
    [Date]             DATETIME         NOT NULL,
    [CourseId]         UNIQUEIDENTIFIER NULL,
    [CourseName]       VARCHAR (MAX)    NOT NULL,
    [Location]         VARCHAR (MAX)    NOT NULL,
    [Price]            FLOAT (53)       NOT NULL,
    [ProviderCourseId] INT              NOT NULL,
    [Holes]            INT              NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Game_Course] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id])
);













