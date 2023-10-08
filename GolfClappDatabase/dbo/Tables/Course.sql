CREATE TABLE [dbo].[Course] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Name]              VARCHAR (50)     NOT NULL,
    [NineHoles]         BIT              NOT NULL,
    [EighteenHoles]     BIT              NOT NULL,
    [ServiceProviderId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Course_ServiceProvider] FOREIGN KEY ([ServiceProviderId]) REFERENCES [dbo].[ServiceProvider] ([Id])
);

