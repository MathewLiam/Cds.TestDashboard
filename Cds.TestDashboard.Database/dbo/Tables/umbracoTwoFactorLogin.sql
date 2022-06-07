CREATE TABLE [dbo].[umbracoTwoFactorLogin] (
    [id]              INT              IDENTITY (1, 1) NOT NULL,
    [userOrMemberKey] UNIQUEIDENTIFIER NOT NULL,
    [providerName]    NVARCHAR (400)   NOT NULL,
    [secret]          NVARCHAR (400)   NOT NULL,
    CONSTRAINT [PK_umbracoTwoFactorLogin] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_umbracoTwoFactorLogin_ProviderName]
    ON [dbo].[umbracoTwoFactorLogin]([providerName] ASC, [userOrMemberKey] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_umbracoTwoFactorLogin_userOrMemberKey]
    ON [dbo].[umbracoTwoFactorLogin]([userOrMemberKey] ASC);

