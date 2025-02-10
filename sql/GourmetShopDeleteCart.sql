CREATE PROCEDURE GourmetShopDeleteCart
(
	@Id int
)
AS
BEGIN
	delete from GourmetShop.dbo.Cart where Id = @Id
END
GO
