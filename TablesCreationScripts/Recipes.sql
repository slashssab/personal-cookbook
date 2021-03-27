CREATE TABLE [dbo].[Recipes]  
(  
 [Id] int IDENTITY(1,1),  
 [DescriptionId] int,
 [Name] varchar(50),
 constraint [FK_Descriptions] foreign key ([DescriptionId]) References [dbo].[Descriptions](Id)
);  