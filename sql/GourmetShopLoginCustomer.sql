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
		return 1;
end