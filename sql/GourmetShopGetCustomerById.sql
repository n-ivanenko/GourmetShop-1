CREATE PROCEDURE GourmetShopGetCustomerById (@id int) as
BEGIN
	select * from [GourmetShop].dbo.Customer where Customer.Id = @id;
END
GO