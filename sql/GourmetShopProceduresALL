USE [GourmetShop]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- GET ALL PRODUCTS
CREATE PROCEDURE GourmetShopGetAllProduct as
BEGIN
	select * from [GourmetShop].dbo.Product;
	return;
END
GO

-- GET ALL SUPPLIERS
CREATE PROCEDURE GourmetShopGetAllSupplier as
BEGIN
	select * from [GourmetShop].dbo.Supplier;
	return;
END
GO

-- GET PRODUCTS BY ID
CREATE PROCEDURE GourmetShopGetProductById (@id int) as
BEGIN
	select * from [GourmetShop].dbo.Product where Product.id = @id;
	return;
END
GO

-- GET SUPPLIERS BY ID
CREATE PROCEDURE GourmetShopGetSupplierById (@id int) as
BEGIN
	select * from [GourmetShop].dbo.Supplier where Supplier.id = @id;
	return;
END
GO

-- INSERT PRODUCT
CREATE PROCEDURE GourmetShopInsertProduct 
(
	@ProductName nvarchar(50),
	@SupplierId int,
	@UnitPrice decimal(12,2),
	@Package nvarchar(30),
	@IsDiscontinued bit
)
AS
BEGIN
	SET NOCOUNT ON;
	insert into GourmetShop.dbo.Product
	(ProductName, SupplierId, UnitPrice, Package, IsDiscontinued)
	values (@ProductName, @SupplierId, @UnitPrice, @Package, @IsDiscontinued)
END
GO

-- INSERT SUPPLIER
CREATE PROCEDURE GourmetShopInsertSupplier
(
	@CompanyName nvarchar(40),
	@ContactName nvarchar(50),
	@ContactTitle nvarchar(40),
	@City nvarchar(40),
	@Country nvarchar(40),
	@Phone nvarchar(30),
	@Fax nvarchar(30)
)
AS
BEGIN
	SET NOCOUNT ON;
	insert into GourmetShop.dbo.Supplier
	(CompanyName, ContactName, ContactTitle, City, Country, Phone, Fax)
	values (@CompanyName, @ContactName, @ContactTitle, @City, @Country, @Phone, @Fax)
END
GO

-- UPDATE PRODUCT
CREATE PROCEDURE GourmetShopUpdateProduct 
(
	@Id int,
	@ProductName nvarchar(50),
	@SupplierId int,
	@UnitPrice decimal(12,2),
	@Package nvarchar(30),
	@IsDiscontinued bit
)
AS
BEGIN
	SET NOCOUNT ON;
	update GourmetShop.dbo.Product
	set ProductName = @ProductName,
	SupplierId = @SupplierId,
	UnitPrice = @UnitPrice,
	Package = @Package,
	IsDiscontinued = @IsDiscontinued
	where Id = @Id
END
GO

-- UPDATE SUPPLIER
CREATE PROCEDURE GourmetShopUpdateSupplier
(
    @Id int,
	@CompanyName nvarchar(40),
	@ContactName nvarchar(50),
	@ContactTitle nvarchar(40),
	@City nvarchar(40),
	@Country nvarchar(40),
	@Phone nvarchar(30),
	@Fax nvarchar(30)
)
AS
BEGIN
	SET NOCOUNT ON;
	update GourmetShop.dbo.Supplier
	set CompanyName = @CompanyName, 
	    ContactName = @ContactName, 
		ContactTitle = @ContactTitle,
		City = @City, 
		Country = @Country, 
		Phone = @Phone,
		Fax = @Fax
	where Id = @Id
END
GO

-- REPLACE FK

ALTER TABLE [dbo].[OrderItem] DROP CONSTRAINT [FK_ORDERITE_REFERENCE_PRODUCT]
GO

ALTER TABLE [dbo].[OrderItem]  WITH CHECK ADD  CONSTRAINT [FK_ORDERITE_REFERENCE_PRODUCT] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([Id]) on delete cascade
GO

ALTER TABLE [dbo].[OrderItem] CHECK CONSTRAINT [FK_ORDERITE_REFERENCE_PRODUCT]
GO

-- DELETE PRODUCT
CREATE PROCEDURE GourmetShopDeleteProduct 
(
	@Id int
)
AS
BEGIN
	delete from GourmetShop.dbo.Product where Id = @Id
END
GO

-- DELETE SUPPLIER
CREATE PROCEDURE GourmetShopDeleteSupplier
(
	@Id int
)
AS
BEGIN
	delete from GourmetShop.dbo.Supplier where Id = @Id
END
GO

-- INSERT CUSTOMER
CREATE PROCEDURE dbo.GourmetShopInsertCustomer 
@pLogin nvarchar(40),
@pPassword nvarchar(40),
@pFirst nvarchar(40),
@pLast nvarchar(40),
@pCity nvarchar(40),
@pCountry nvarchar(40),
@pPhone nvarchar(20)
as
begin
  declare @salt uniqueidentifier=newid()
  insert into dbo.[Customer] (FirstName, LastName, City, Country, Phone, LoginName, PasswordHash, Salt)
	values (@pFirst, @pLast, @pCity, @pCountry, @pPhone, @pLogin, HASHBYTES('SHA2_512', @pPassword+CAST(@salt AS NVARCHAR(36))), @salt)
end
GO

-- GET CUSTOMERS BY ID
CREATE PROCEDURE GourmetShopGetCustomerById (@id int) as
BEGIN
	select * from [GourmetShop].dbo.Customer where Customer.Id = @id;
END
GO

-- LOGIN CUSTOMER
create procedure dbo.GourmetShopLoginCustomer
@pLogin nvarchar(40),
@pPassword nvarchar(40)
as
begin
    set nocount on
	declare @userid int
	set @userid = (select Id from Customer where LoginName = @pLogin and PasswordHash=hashbytes('SHA2_512', @pPassword+CAST(Salt AS nvarchar(36))))
	if (@userid is null)
		return 0;
    else
		return @userid;
end
GO

-- ALTER CUSTOMER
alter table dbo.[Customer] 
add LoginName nvarchar(40) null,
PasswordHash binary(64) null,
Salt uniqueidentifier null;
GO

-- CREATE CART
create table GourmetShop.dbo.[Cart] (
Id int identity(1,1) not null,
CustomerId int not null,
ProductId int not null,
UnitPrice decimal(12,2) not null,
Quantity int not null,
constraint PK_Cart primary key (Id),
constraint FK_Cart_Customer foreign key (CustomerId) references GourmetShop.dbo.[Customer](Id),
constraint FK_Cart_Product foreign key (ProductId) references GourmetShop.dbo.[Product](Id)
)
GO
-- GET CUSTOMER CART
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
GO

-- MAKE ORDER
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
GO

-- GET CUSTOMER CART
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
GO

-- DELETE PRODUCT FROM CART
create procedure GourmetShopDeleteProductFromCart
(
 @Id int
) as
begin
delete from GourmetShop.dbo.Cart where Id = @Id
end
GO

-- GET ALL CUSTOMERS
CREATE PROCEDURE GourmetShopGetAllCustomers
AS
BEGIN
   SELECT * FROM [GourmetShop].dbo.Customer;
END
GO

-- GET ALL ORDERS
CREATE PROCEDURE GourmetShopGetAllOrders
AS
BEGIN
    SELECT 
        Id,
        OrderDate,
        OrderNumber,
        CustomerId,
        TotalAmount
    FROM 
        [GourmetShop].dbo.[Order]
END
GO
