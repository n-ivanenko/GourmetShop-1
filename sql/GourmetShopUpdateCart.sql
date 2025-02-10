USE [GourmetShop]
GO

/****** Object:  StoredProcedure [dbo].[GourmetShopUpdateProduct]    Script Date: 2/9/2025 8:46:10 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GourmetShopUpdateCart] 
(
	@Id int,
	@Quantity int
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	update GourmetShop.dbo.Cart
	set Quantity = @Quantity
	where Id = @Id
END
GO


