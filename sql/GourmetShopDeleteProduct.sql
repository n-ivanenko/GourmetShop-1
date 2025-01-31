CREATE PROCEDURE GourmetShopDeleteProduct 
(
	@Id int
)
AS
BEGIN
	delete from GourmetShop.dbo.Product where Id = @Id
END
GO
