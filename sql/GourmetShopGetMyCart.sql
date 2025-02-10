CREATE PROCEDURE GourmetShopGetMyCart (@id int) as
BEGIN
	select c.Id,
		   p.ProductName,
		   s.CompanyName,
		   p.Package,
	       c.UnitPrice,
		   c.Quantity		   
	from [GourmetShop].dbo.Cart as c 
	inner join [GourmetShop].dbo.Product as p
	  on p.id = c.ProductId
	inner join [GourmetShop].dbo.Supplier as s
	  on s.id = p.SupplierId
	where c.CustomerId = @id;
	return;
END
GO
