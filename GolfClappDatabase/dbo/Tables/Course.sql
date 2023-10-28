CREATE TABLE [dbo].[Course] (
    [Id]              UNIQUEIDENTIFIER NOT NULL,
    [LocationString]  VARCHAR (50)     NULL,
    [ImageUrl]        VARCHAR (50)     NULL,
    [IMasterCourseId] INT              NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([Id] ASC)
);





