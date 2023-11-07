CREATE TABLE [dbo].[FriendRequest] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [SenderId]   UNIQUEIDENTIFIER NULL,
    [ReceiverId] UNIQUEIDENTIFIER NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ReceiverId]) REFERENCES [dbo].[User] ([Id]),
    FOREIGN KEY ([SenderId]) REFERENCES [dbo].[User] ([Id])
);

