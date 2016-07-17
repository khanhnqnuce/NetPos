CREATE PROCEDURE sp_Record
AS
BEGIN
	SELECT ROW_NUMBER() OVER (Order by Record.Id) AS RowNumber, 
	CardType.Name AS CardType, 
	Card.AccountName, 
	Buiding.Name AS  Buiding,
	Area.[Desc] AS Area,
	U.FullName as NameUser,
	Record.* 
	from [NetPOS].[dbo].[tblRecord] as Record
		LEFT JOIN [NetPOS].[dbo].[tblCardType] as CardType ON Record.CardTypeCode = CardType.Code
		LEFT JOIN [NetPOS].[dbo].[tblCard] as Card ON Record.CardNumber = Card.CardNumber
		LEFT JOIN [NetPOS].[dbo].[tblBuiding] as Buiding ON Record.BuidingCode = Buiding.Code
		LEFT JOIN [NetPOS].[dbo].[tblArea] as Area ON Record.AreaCode = Area.Code
		LEFT JOIN [NetPOS].[dbo].[tblUser] as U ON Record.UserCode = U.Code
END
GO


