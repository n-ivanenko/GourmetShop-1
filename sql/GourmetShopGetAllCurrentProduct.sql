CREATE PROCEDURE GourmetShopGetAllCurrentProduct as
BEGIN
	select * from [GourmetShop].dbo.Product where IsDiscontinued = 0;
	return;
END
GO
