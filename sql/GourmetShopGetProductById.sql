CREATE PROCEDURE GourmetShopGetProductById (@id int) as
BEGIN
	select * from [GourmetShop].dbo.Product where Product.id = @id;
	return;
END
GO