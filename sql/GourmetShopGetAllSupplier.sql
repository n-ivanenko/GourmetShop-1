CREATE PROCEDURE GourmetShopGetAllSupplier as
BEGIN
	select * from [GourmetShop].dbo.Supplier;
	return;
END
GO
