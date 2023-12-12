CREATE TABLE [dbo].[Payment] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [GameUserId]   UNIQUEIDENTIFIER NOT NULL,
    [ClientSecret] VARCHAR (MAX)    NOT NULL,
    [GameId]       UNIQUEIDENTIFIER NOT NULL,
    [Amount]       FLOAT (53)       NOT NULL,
    CONSTRAINT [FK_Payment_Game] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Game] ([Id]),
    CONSTRAINT [FK_Payment_GameUser] FOREIGN KEY ([GameUserId]) REFERENCES [dbo].[GameUser] ([Id]),
    CONSTRAINT [FK_Payment_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);



