CREATE TABLE [dbo].[Log] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Message]  VARCHAR (MAX)    NOT NULL,
    [ErrorLog] BIT              NOT NULL
);

