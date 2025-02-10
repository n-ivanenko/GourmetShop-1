CREATE PROCEDURE GourmetShopGetAllCurrentProduct as
BEGIN
	select p.Id as "ProductId",
		   p.ProductName,
		   p.UnitPrice,
		   p.Package,
		   p.SupplierId,
		   s.CompanyName
	from [GourmetShop].dbo.Product as p 
	inner join [GourmetShop].dbo.Supplier as s
	  on p.SupplierId = s.Id
	where IsDiscontinued = 0;
	return;
END
GO
