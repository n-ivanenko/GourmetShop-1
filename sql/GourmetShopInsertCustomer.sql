create procedure dbo.GourmetShopInsertCustomer 
@pLogin nvarchar(40),
@pPassword nvarchar(40),
@pFirst nvarchar(40),
@pLast nvarchar(40),
@pCity nvarchar(40),
@pCountry nvarchar(40),
@pPhone nvarchar(20)
as
begin
  declare @salt uniqueidentifier=newid()
  insert into dbo.[Customer] (FirstName, LastName, City, Country, Phone, LoginName, PasswordHash, Salt)
	values (@pFirst, @pLast, @pCity, @pCountry, @pPhone, @pLogin, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt)
end