CREATE TABLE [dbo].[Game] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Date]     DATETIME         NOT NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Game_Course] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id])
);

