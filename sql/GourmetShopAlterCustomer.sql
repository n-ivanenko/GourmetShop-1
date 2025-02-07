alter table dbo.[Customer] 
add LoginName nvarchar(40) null,
PasswordHash binary(64) null,
Salt uniqueidentifier null;