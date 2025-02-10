create procedure [dbo].[GourmetShopAddProductToCart] 
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
GO


