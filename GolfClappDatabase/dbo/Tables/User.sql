CREATE TABLE [dbo].[User] (
    [Id]       UNIQUEIDENTIFIER NOT NULL,
    [Name]     VARCHAR (50)     NOT NULL,
    [Surname]  VARCHAR (100)    NOT NULL,
    [Password] VARCHAR (MAX)    NOT NULL,
    [Email]    VARCHAR (256)    NOT NULL,
    [Phone]    INT              NOT NULL,
    [Country]  VARCHAR (50)     NOT NULL,
    [License]  VARCHAR (50)     NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
);

