CREATE PROCEDURE sp_LoginUser
@Email varchar(80),
@Pass varchar(200)
AS
BEGIN

SELECT Id, UserName, LastName, Telephone, Email, Pass, Users.Status 
	FROM Users 
		WHERE Email = @Email AND Pass = @Pass
END


CREATE PROCEDURE sp_CreateUser

@UserName varchar(50),
@LastName varchar(50),
@Telephone varchar(50),
@Email varchar(80),
@Pass varchar(200),
@Status bit,
@CreationDate DATETIME
AS
BEGIN

INSERT INTO dbo.Users (UserName, LastName, Telephone, Email, Pass, [Status], CreationDate) 
VALUES (@UserName, @LastName, @Telephone, @Email, @Pass, @Status, @CreationDate)

END


CREATE PROCEDURE sp_UpdateUser
@Id int,
@UserName varchar(50),
@LastName varchar(50),
@Telephone varchar(50),
@Email varchar(80),
@UpdateCreation DATETIME
AS
BEGIN

UPDATE dbo.Users SET UserName = @UserName, LastName = @LastName, Telephone = @Telephone, Email = @Email, UpdateDate = @UpdateCreation
WHERE Id = @Id

END


select * from Users