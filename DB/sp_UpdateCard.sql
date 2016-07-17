
ALTER PROCEDURE [dbo].[sp_UpdateCard]	 
	@ch NVARCHAR(20),
	@Card NVARCHAR(20)
AS
BEGIN
	Update tblRecord SET CardNumber = @ch WHERE CardNumber = @Card
	Update tblBlackList SET CardNumber = @ch WHERE CardNumber = @Card
	Update tblCardProcess SET CardNumber = @ch WHERE CardNumber = @Card
	Update tblCard SET CardNumber = @ch WHERE CardNumber = @Card
END
