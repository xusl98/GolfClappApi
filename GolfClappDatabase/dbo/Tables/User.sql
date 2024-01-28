CREATE TABLE [dbo].[User] (
    [Id]                   UNIQUEIDENTIFIER   NOT NULL,
    [Name]                 NVARCHAR (MAX)     NOT NULL,
    [Surname]              NVARCHAR (MAX)     NOT NULL,
    [Country]              NVARCHAR (MAX)     NOT NULL,
    [License]              NVARCHAR (MAX)     NULL,
    [UserName]             NVARCHAR (256)     NULL,
    [NormalizedUserName]   NVARCHAR (256)     NULL,
    [Email]                NVARCHAR (256)     NULL,
    [NormalizedEmail]      NVARCHAR (256)     NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [PasswordHash]         NVARCHAR (MAX)     NULL,
    [SecurityStamp]        NVARCHAR (MAX)     NULL,
    [ConcurrencyStamp]     NVARCHAR (MAX)     NULL,
    [PhoneNumber]          NVARCHAR (MAX)     NULL,
    [PhoneNumberConfirmed] BIT                NOT NULL,
    [TwoFactorEnabled]     BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    [LockoutEnabled]       BIT                NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [UserApiKey]           VARCHAR (MAX)      NULL,
    [GoogleSignIn]         BIT                NULL,
    [PaymentMethod]        VARCHAR (MAX)      NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [unique_userName] UNIQUE NONCLUSTERED ([UserName] ASC)
);












GO



GO


