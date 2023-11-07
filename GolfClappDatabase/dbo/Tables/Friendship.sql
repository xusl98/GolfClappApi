CREATE TABLE [dbo].[Friendship] (
    [Id]      UNIQUEIDENTIFIER NOT NULL,
    [User1Id] UNIQUEIDENTIFIER NULL,
    [User2Id] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([User1Id]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([User2Id]) REFERENCES [dbo].[User] ([Id])
);

