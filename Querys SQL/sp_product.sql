

CREATE PROCEDURE sp_GetProducts 
AS
BEGIN
SELECT p.Id, ProductCode, ProductName, p.Stock ,p.[Status],p.Author,p.CreationDate,p.UpdateDate, c.Id AS CategoryId, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.IdCategory = c.Id
END

select * from Products


CREATE PROCEDURE sp_AddProduct
@ProductCode varchar(50),
@ProductName varchar(50),
@Stock int,
@Status bit,
@Autor varchar(100),
@CreationDate datetime,
@IdCategory int
AS
BEGIN

INSERT INTO dbo.Products (ProductCode, ProductName, Stock, [Status], Author, CreationDate, IdCategory) 
VALUES (@ProductCode,@ProductName, @Stock, @Status,@Autor, @CreationDate, @IdCategory)  

END



CREATE PROCEDURE sp_UpdateProduct
@Id int,
@ProductCode varchar(50),
@ProductName varchar(50),
@Stock int,
@Status bit,
@Autor varchar(100),
@UpdateDate datetime,
@IdCategory int
AS
BEGIN

UPDATE  dbo.Products SET ProductCode = @ProductCode, ProductName = @ProductName, Stock = @Stock, [Status] = @Status, Author = @Autor, UpdateDate
= @UpdateDate, IdCategory = @IdCategory
WHERE Id = @id

END



CREATE PROCEDURE sp_DeleteProduct
@Id int
AS
BEGIN

Delete dbo.Products where Id = @Id

END


CREATE PROCEDURE sp_GetProductsByName
@ProductName varchar(50)
AS
BEGIN 
SELECT p.Id, ProductCode, ProductName, p.Stock ,p.[Status],p.Author,p.CreationDate,p.UpdateDate, c.Id AS CategoryId, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.IdCategory = c.Id
	WHERE  ProductName LIKE '%'+ @ProductName +'%'
END



CREATE PROCEDURE sp_GetProductsByCategoryID
@IdCategory int
as
BEGIN 
SELECT p.Id, ProductCode, ProductName, p.Stock ,p.[Status],p.Author,p.CreationDate,p.UpdateDate, c.Id AS CategoryId, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.IdCategory = c.Id
	WHERE  IdCategory =  @IdCategory
END


CREATE PROCEDURE sp_GetProductsByID
@Id int
as
BEGIN 
SELECT p.Id, ProductCode, ProductName, p.Stock ,p.[Status],p.Author,p.CreationDate,p.UpdateDate, c.Id AS CategoryId, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.IdCategory = c.Id
	WHERE  p.Id =  @Id
END