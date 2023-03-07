CREATE TABLE [dbo].[ServiceProvider] (
    [Id]   UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR (50)     NOT NULL,
    CONSTRAINT [PK_ServiceProvider] PRIMARY KEY CLUSTERED ([Id] ASC)
);

