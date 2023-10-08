CREATE TABLE [dbo].[GameUser] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [GameId]       UNIQUEIDENTIFIER NOT NULL,
    [ExternalUser] BIT              NOT NULL,
    [Score]        INT              NOT NULL,
    CONSTRAINT [PK_GameUser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_GameUser_Game] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Game] ([Id]),
    CONSTRAINT [FK_GameUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

