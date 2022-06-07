CREATE TABLE [dbo].[umbracoCreatedPackageSchema] (
    [id]         INT              IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (255)   NOT NULL,
    [value]      NVARCHAR (MAX)   NOT NULL,
    [updateDate] DATETIME         CONSTRAINT [DF_umbracoCreatedPackageSchema_updateDate] DEFAULT (getdate()) NOT NULL,
    [packageId]  UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_umbracoCreatedPackageSchema] PRIMARY KEY CLUSTERED ([id] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_umbracoCreatedPackageSchema_Name]
    ON [dbo].[umbracoCreatedPackageSchema]([name] ASC);

