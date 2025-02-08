create procedure GourmetShopMakeOrder
(
@CustId int,
@OrderNumber int
) as
begin
	begin transaction;
	/* can only output into a table, not a var *shakes fist* */
	declare @i table (id int);
	declare @OrderId int;

	insert into GourmetShop.dbo.[Order]  ( 
	OrderNumber, CustomerId, TotalAmount
	) output INSERTED.id into @i
	select top 1 @OrderNumber, CustomerId, 
	sum(UnitPrice * Quantity) over()
	from GourmetShop.dbo.Cart where CustomerId = @CustId;
	
	set @OrderId = (select id from @i);

	insert into Gourmetshop.dbo.[OrderItem] (
	  OrderId, ProductId, UnitPrice, Quantity
	) select @OrderId, ProductId, UnitPrice, Quantity from GourmetShop.dbo.Cart
	  where CustomerId = @CustId;
	  
	delete from GourmetShop.dbo.Cart where CustomerId = @CustId;
	commit;
end
go
