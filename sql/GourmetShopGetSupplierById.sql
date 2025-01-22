CREATE PROCEDURE GourmetShopGetSupplierById (@id int) as
BEGIN
	select * from [GourmetShop].dbo.Supplier where Supplier.id = @id;
	return;
END
GO