CREATE TABLE [dbo].[Game] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [Date]     DATETIME         NOT NULL,
    CONSTRAINT [PK_Game] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Course_FK] FOREIGN KEY ([CourseId]) REFERENCES [dbo].[Course] ([Id])
);

