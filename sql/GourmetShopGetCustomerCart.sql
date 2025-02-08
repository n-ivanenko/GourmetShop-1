CREATE PROCEDURE GourmetShopGetCustomerCart 
(
	@CustomerId int
) as
BEGIN
	select * from GourmetShop.dbo.Cart where CustomerId = @CustomerId;
	return;
END
GO

create procedure GourmetShopAddProductToCart 
(
	@CustomerId int,
	@ProductId int,
	@UnitPrice decimal(12,2),
	@Quantity int
) as
begin
  insert into GourmetShop.dbo.Cart (CustomerId, ProductId, UnitPrice, Quantity)
   values ( @CustomerId, @ProductId, @UnitPrice, @Quantity )
end
go

create procedure GourmetShopDeleteProductFromCart
(
 @Id int
) as
begin
delete from GourmetShop.dbo.Cart where Id = @Id
end
go
