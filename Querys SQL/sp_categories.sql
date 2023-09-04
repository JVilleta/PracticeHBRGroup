
CREATE PROCEDURE sp_GetCategories
AS
BEGIN

SELECT id, CategoryCode, CategoryName, Descriptions, Author, CreationDate, UpdateDate
FROM Categories

END

CREATE PROCEDURE sp_GetCategoriesByID
@Id int
AS
BEGIN

SELECT id, CategoryCode, CategoryName, Descriptions, Author, CreationDate, UpdateDate
FROM Categories
WHERE Id = @Id

END



CREATE PROCEDURE sp_AddCategory
@CategoryCode varchar(50),
@CategoryName varchar(50),
@Descriptions varchar(100),
@Status bit,
@Author varchar(100),
@CreationDate datetime
AS
BEGIN

INSERT INTO dbo.Categories(CategoryCode, CategoryName, Descriptions, [Status], Author, CreationDate) 
VALUES (@CategoryCode,@CategoryName, @Descriptions, @Status,@Author, @CreationDate)  

END



ALTER PROCEDURE sp_UpdateCategory
@Id int,
@CategoryCode varchar(50),
@CategoryName varchar(50),
@Descriptions varchar(100),
@Status bit,
@Author varchar(100),
@UpdateDate datetime
AS
BEGIN

UPDATE  dbo.Categories SET CategoryCode = @CategoryCode, CategoryName = @CategoryName, Descriptions= @Descriptions ,[Status] = @Status, Author = @Author, UpdateDate
= @UpdateDate
WHERE Id = @id

END


ALTER PROCEDURE sp_DeleteCategory
@Id int,
@productexists bit output
AS
BEGIN
	IF EXISTS (SELECT 1 FROM  dbo.Products WHERE IdCategory = @Id) 

	BEGIN 
		SET  @productexists = 0
	END
	ELSE 
	BEGIN
		SET @productexists = 1
		DELETE Categories WHERE Id = @Id
	END 

END