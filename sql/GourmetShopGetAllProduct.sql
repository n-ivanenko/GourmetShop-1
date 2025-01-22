CREATE PROCEDURE GourmetShopGetAllProduct as
BEGIN
	select * from [GourmetShop].dbo.Product;
	return;
END
GO
