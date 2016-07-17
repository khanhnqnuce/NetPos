CREATE PROCEDURE sp_GiaoDichGanNhat @CardNumber int

AS
BEGIN
	SELECT TOP 20 * 
	FROM [tblRecord] 
	WHERE CardNumber =  @CardNumber
	ORDER BY Date DESC

END
GO