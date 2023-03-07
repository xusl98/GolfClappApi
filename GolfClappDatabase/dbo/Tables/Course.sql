CREATE TABLE [dbo].[Course] (
    [Id]                UNIQUEIDENTIFIER NOT NULL,
    [Name]              VARCHAR (50)     NOT NULL,
    [Holes]             INT              NOT NULL,
    [ServiceProviderId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [ServiceProvider_FK] FOREIGN KEY ([ServiceProviderId]) REFERENCES [dbo].[ServiceProvider] ([Id])
);

