-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
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
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
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
