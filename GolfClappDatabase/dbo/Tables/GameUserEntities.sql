CREATE TABLE [dbo].[GameUserEntities] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [GameId]       UNIQUEIDENTIFIER NOT NULL,
    [Name]         NVARCHAR (MAX)   NULL,
    [ExternalUser] BIT              NOT NULL,
    [Score]        INT              NOT NULL,
    [Price]        FLOAT (53)       NOT NULL,
    [HasPayed]     BIT              NOT NULL,
    CONSTRAINT [PK_dbo.GameUserEntities] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.GameUserEntities_dbo.GameEntities_GameId] FOREIGN KEY ([GameId]) REFERENCES [dbo].[GameEntities] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_GameId]
    ON [dbo].[GameUserEntities]([GameId] ASC);

