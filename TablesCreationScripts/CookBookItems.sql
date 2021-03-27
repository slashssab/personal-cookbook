IF (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'CookbookItems'))
BEGIN
    DROP TABLE [dbo].[CookbookItems]  
END

CREATE TABLE [dbo].[CookbookItems]  
(  
 [Id] int IDENTITY(1,1),  
 [IngredientId] int not null,  
 [RecipeId] int not null,
 [Quantity] float(2) not null,
 [Unit] int not null,
 constraint [FK_Recipes] foreign key ([RecipeId]) References [dbo].Recipes(Id),
 constraint [FK_Ingredients] foreign key ([IngredientId]) References [dbo].Ingredients(Id),
);