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