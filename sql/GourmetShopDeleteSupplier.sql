CREATE PROCEDURE GourmetShopDeleteSupplier
(
	@Id int
)
AS
BEGIN
	delete from GourmetShop.dbo.Supplier where Id = @Id
END
GO
