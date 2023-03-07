CREATE TABLE [dbo].[GameUser] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [UserId]       UNIQUEIDENTIFIER NOT NULL,
    [GameId]       UNIQUEIDENTIFIER NOT NULL,
    [ExternalUser] BIT              NOT NULL,
    [Score]        INT              CONSTRAINT [DF_GameUser_Score] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_GameUser] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [Game_FK] FOREIGN KEY ([GameId]) REFERENCES [dbo].[Game] ([Id]),
    CONSTRAINT [User_FK] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])
);

