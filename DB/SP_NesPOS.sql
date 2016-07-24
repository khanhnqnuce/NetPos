ALTER PROCEDURE [dbo].[sp_BCTheoKhuVuc]
AS
BEGIN
	select Area.[Desc] as [Area], Record.CountValue from [tblArea] as Area
	join
	 (SELECT AreaCode, sum(Value) as [CountValue] FROM [tblRecord] group by AreaCode ) as Record
	 on Area.Code = Record.AreaCode
END

ALTER PROCEDURE [dbo].[sp_CardProcess]
AS
BEGIN
	select ROW_NUMBER() OVER (Order by Id) AS STT, * from [tblCardProcess]
END

ALTER PROCEDURE [dbo].[sp_EventAlarm]
AS
BEGIN
	select ROW_NUMBER() OVER (Order by Id) AS RowNumber, * from [tblEventAlarm]
END

ALTER PROCEDURE [dbo].[sp_GetCard]	 
	@ch NVARCHAR(20)
AS
BEGIN
	SELECT tc.CardNumber,tc.AccountName,
	CAST(CASE WHEN tct.Name IS NULL THEN '#' ELSE tct.Name END AS NVARCHAR) AS [NameType]
	FROM tblCard AS tc
	LEFT JOIN tblCardType AS tct ON tc.CardTypeCode = tct.Code
	WHERE tc.CardNumber = @ch
END

ALTER PROCEDURE [dbo].[sp_GetListCard]	 
AS
BEGIN
	select ROW_NUMBER() OVER (Order by tb_a.Id DESC) AS RowNumber, tb_a.*,tb_b.Name AS [NameType] from [tblCard] as tb_a
	left join
	tblCardType AS tb_b ON tb_a.CardTypeCode = tb_b.Code
END

ALTER PROCEDURE [dbo].[sp_GiaoDichGanNhat]
 @CardNumber nvarchar(20)

AS
BEGIN
	SELECT TOP 5 Record.*,
	Card.AccountName as [AccountName],
	CardType.Name as [CardType],
	Buiding.Name as [Buiding],
	Area.[Desc] as [Area],
	U.FullName as [UserName],
	Obj.Name as [Object]
	FROM [tblRecord] as Record
	LEFT JOIN 
	  [tblCard] as Card ON Record.CardNumber = Card.CardNumber
	LEFT JOIN 
	  [tblCardType] as CardType ON Record.CardTypeCode = CardType.Code
	LEFT JOIN
	  [tblBuiding] as Buiding ON Record.BuidingCode = Buiding.Code
	LEFT JOIN 
	  [tblArea] as Area ON Record.AreaCode = Area.Code
	LEFT JOIN
	  [tblUser] AS U ON Record.UserCode = u.Code 
    LEFT JOIN
	  [tblObject] AS Obj ON Record.ObjectCode = Obj.Code 
    WHERE Record.CardNumber =  @CardNumber
    ORDER BY Record.Date DESC
END

ALTER PROCEDURE [dbo].[sp_Log]
AS
BEGIN
	select ROW_NUMBER() OVER (Order by Id) AS STT, * from [tblLog]
END


ALTER PROCEDURE [dbo].[sp_Record]
@StartDate DateTime, 
@EndDate DateTime, 
@Buiding nvarchar(20), 
@Area nvarchar(20), 
@PC nvarchar(20),
@Object nvarchar(20), 
@Function nvarchar(20), 
@EventCode nvarchar(20), 
@TypeCard nvarchar(20), 
@CardNumber nvarchar(20), 
@User nvarchar(20)

AS
BEGIN
	SELECT Record.CardNumber, Record.Date, (Record.Value - Record.Bonus) as [Value],
	Record.Balance, Record.Action, Record.EventID, Record.ProductCode,
	Card.AccountName as [AccountName],
	CardType.Name as [CardType],
	Buiding.Name as [Buiding],
	Area.[Desc] as [Area],
	U.FullName as [UserName]
	FROM [tblRecord] as Record
	LEFT JOIN 
	  [tblCard] as Card ON Record.CardNumber = Card.CardNumber
	LEFT JOIN 
	  [tblCardType] as CardType ON Record.CardTypeCode = CardType.Code
	LEFT JOIN
	  [tblBuiding] as Buiding ON Record.BuidingCode = Buiding.Code
	LEFT JOIN 
	  [tblArea] as Area ON Record.AreaCode = Area.Code
	LEFT JOIN
	  [tblUser] AS U ON Record.UserCode = u.Code 

	WHERE
	 Record.BuidingCode LIKE '%' + @Buiding + '%' and
	 Record.AreaCode LIKE '%' + @Area + '%' and
	 Record.PCCode LIKE '%' + @PC + '%' and
	 Record.ObjectCode LIKE '%' + @Object + '%' and
	 Record.FID LIKE '%' + @Function + '%' and
	 Record.EventCode LIKE '%' + @EventCode + '%' and
	 Record.CardTypeCode LIKE '%' + @TypeCard + '%' and
	 Record.CardNumber LIKE '%' + @CardNumber + '%' and
	 Record.UserCode LIKE '%' + @User and
	 Record.Date >= @StartDate and Record.Date <= @EndDate
END

ALTER PROCEDURE [dbo].[sp_TheTrungNhau]
	 
AS
BEGIN
	select ROW_NUMBER() OVER (Order by a.Id) AS RowNumber, a.* from [tblCard] as a
	join
	 (SELECT CardNumber, COUNT(CardNumber) as [Count] FROM [NetPOS].[dbo].[tblCard] group by CardNumber having COUNT(CardNumber) > 1) as b
	 on a.CardNumber = b.CardNumber
END


ALTER PROCEDURE [dbo].[sp_ThongKeThe]
AS
BEGIN
	SELECT tb.NameType, SUM(tb.TotalCard) as [TotalCard],
	SUM(tb.[TotalUsed]) as [TotalUsed],
	(SUM(tb.TotalCard) -  SUM(tb.[TotalUsed])) as [TotalNotUsed],
	SUM(tb.TotalBalance) AS [TotalBalance]
	FROM (
	SELECT tb_a.CardTypeCode,
		CAST(CASE WHEN tb_b.Name IS NULL THEN '#' ELSE tb_b.Name END AS NVARCHAR) AS [NameType],
		COUNT(*) AS [TotalCard],
		count(case tb_a.IsRelease when 1 then 1 else null end) AS [TotalUsed],
			SUM(tb_a.Balance) AS [TotalBalance]
	FROM tblCard as tb_a
	left JOIN tblCardType AS tb_b ON tb_a.CardTypeCode = tb_b.Code
	GROUP BY tb_a.CardTypeCode,tb_b.Name) AS tb
	GROUP BY tb.NameType
END

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

create PROCEDURE [dbo].[sp_findCard]
@Code nvarchar(20),
@CardNumber nvarchar(20),
@Name nvarchar(20),
@CardType nvarchar(20)

AS
BEGIN
	SELECT tb_a.*,tb_b.Name AS [NameType] from [tblCard] as tb_a
	LeFT JOIN
	  tblCardType AS tb_b ON tb_a.CardTypeCode = tb_b.Code
    WHERE
	tb_a.Code LIKE '%' + @Code + '%' and
	tb_a.CardNumber LIKE '%' + @CardNumber + '%' and
	tb_a.AccountName LIKE '%' + @Name + '%' and
	tb_a.CardTypeCode LIKE '%' + @CardType + '%'
END