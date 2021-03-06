USE [NetPOS2015]
GO
/****** Object:  StoredProcedure [dbo].[sp_BCTheoDoiTuong]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[sp_BCTheoDoiTuong]
AS
BEGIN
	select Obj.[Code] as [Code], Obj.[Desc] as [Object], Record.CountValue from [tblObject] as Obj
	FULL OUTER JOIN 
	 (SELECT ObjectCode, sum(Value) as [CountValue] FROM [tblRecord] group by ObjectCode ) as Record
	 on Obj.Code = Record.ObjectCode
END
GO
/****** Object:  StoredProcedure [dbo].[sp_BCTheoKhuVuc]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BCTheoKhuVuc]
AS
BEGIN
	select Area.[Desc] as [Area], Record.CountValue from [tblArea] as Area
	FULL OUTER JOIN 
	 (SELECT AreaCode, sum(Value) as [CountValue] FROM [tblRecord] group by AreaCode ) as Record
	 on Area.Code = Record.AreaCode
END
GO
/****** Object:  StoredProcedure [dbo].[sp_CardProcess]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CardProcess]
AS
BEGIN
	select ROW_NUMBER() OVER (Order by Id) AS STT, * from [tblCardProcess]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DTBanHang]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DTBanHang]
@StartDate DateTime, 
@EndDate DateTime, 
@Buiding nvarchar(20), 
@Area nvarchar(20),
@Object nvarchar(20)

AS
BEGIN
	SELECT TOP 100 Record.CardNumber, Record.Date, (Record.Value) as [Value],
	Record.Balance, Record.Action,
	Card.AccountName as [AccountName],
	CardType.Name as [CardType],
	Buiding.Name as [Buiding],
	Area.[Desc] as [Area],
	U.FullName as [UserName]
	FROM [tblEvent] as Record
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
	 EventCode = 03 and
	 Record.BuidingCode LIKE '%' + @Buiding + '%' and
	 Record.AreaCode LIKE '%' + @Area + '%' and
	 Record.ObjectCode LIKE '%' + @Object + '%' and
	 Record.Date >= @StartDate and Record.Date <= @EndDate
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DTBanHangTongHop]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DTBanHangTongHop]
@StartDate DateTime, 
@EndDate DateTime, 
@Buiding nvarchar(20), 
@Area nvarchar(20),
@Object nvarchar(20)

AS
BEGIN
	SELECT N'Tổng doanh thu đã bán hàng' as [Name], sum(Value) as [Value] FROM [tblEvent] 
		where 
		EventCode = 03 and 
		Date >= @StartDate and Date <= @EndDate and
		BuidingCode LIKE '%' + @Buiding + '%' and
		AreaCode LIKE '%' + @Area + '%' and
		ObjectCode LIKE '%' + @Object + '%'
	union all
	SELECT N'Tổng số giao dịch đã thực hiện trên đầu đọc' as [Name] , count(*) as [Value] FROM [tblEvent] 
		where 
		EventCode = 03 and
		Date >= @StartDate and Date <= @EndDate and
		BuidingCode LIKE '%' + @Buiding + '%' and
		AreaCode LIKE '%' + @Area + '%' and
		ObjectCode LIKE '%' + @Object + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DTBanThe]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DTBanThe]
@StartDate DateTime, 
@EndDate DateTime, 
@Buiding nvarchar(20), 
@Area nvarchar(20),
@Object nvarchar(20)

AS
BEGIN
	SELECT Record.CardNumber, Record.Date, (Record.Value) as [Value],
	Record.Balance, Record.Action,
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
	(EventCode = 00 or EventCode = 01) and
	 Record.BuidingCode LIKE '%' + @Buiding + '%' and
	 Record.AreaCode LIKE '%' + @Area + '%' and
	 Record.ObjectCode LIKE '%' + @Object + '%' and
	 Record.Date >= @StartDate and Record.Date <= @EndDate
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DTBanTheTọngHop]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DTBanTheTọngHop]
@StartDate DateTime, 
@EndDate DateTime, 
@Buiding nvarchar(20), 
@Area nvarchar(20),
@Object nvarchar(20)

AS
BEGIN
	SELECT N'Tổng số thẻ đã phát hành'as [Name] ,count(*) as [Value] FROM [tblRecord] 
		where 
		EventCode = 00 and 
		Date >= @StartDate and Date <= @EndDate and
		BuidingCode LIKE '%' + @Buiding + '%' and
		AreaCode LIKE '%' + @Area + '%' and
		ObjectCode LIKE '%' + @Object + '%'
	union all
	SELECT N'Tổng số tiền đã nạp' as [Name] , sum(Value) as [Value] FROM [tblRecord] 
		where 
		(EventCode = 00 or EventCode = 01) and
		Date >= @StartDate and Date <= @EndDate and
		BuidingCode LIKE '%' + @Buiding + '%' and
		AreaCode LIKE '%' + @Area + '%' and
		ObjectCode LIKE '%' + @Object + '%'
	union all
	SELECT N'Tổng số tiền đã rút'as [Name] , sum(Value) as [Value] FROM [tblRecord] 
		where 
		EventCode = 02 and
		Date >= @StartDate and Date <= @EndDate and
		BuidingCode LIKE '%' + @Buiding + '%' and
		AreaCode LIKE '%' + @Area + '%' and
		ObjectCode LIKE '%' + @Object + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[sp_EventAlarm]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EventAlarm]
AS
BEGIN
	select ROW_NUMBER() OVER (Order by Id) AS RowNumber, * from [tblEventAlarm]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_findCard]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[sp_GetCard]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetCard]	 
	@ch NVARCHAR(20)
AS
BEGIN
	SELECT tc.CardNumber,tc.AccountName,
	CAST(CASE WHEN tct.Name IS NULL THEN '#' ELSE tct.Name END AS NVARCHAR) AS [NameType]
	FROM tblCard AS tc
	LEFT JOIN tblCardType AS tct ON tc.CardTypeCode = tct.Code
	WHERE tc.CardNumber = @ch
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetListCard]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetListCard]	 
AS
BEGIN
	select ROW_NUMBER() OVER (Order by tb_a.Id DESC) AS RowNumber, tb_a.*,tb_b.Name AS [NameType] from [tblCard] as tb_a
	left join
	tblCardType AS tb_b ON tb_a.CardTypeCode = tb_b.Code
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GiaoDichGanNhat]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GiaoDichGanNhat]
 @CardNumber nvarchar(20)

AS
BEGIN
	SELECT TOP 50 Event.*,
	Card.AccountName as [AccountName],
	CardType.Name as [CardType],
	Buiding.Name as [Buiding],
	Area.[Desc] as [Area],
	U.FullName as [UserName],
	Obj.Name as [Object]
	FROM [tblEvent] as Event
	LEFT JOIN 
	  [tblCard] as Card ON Event.CardNumber = Card.CardNumber
	LEFT JOIN 
	  [tblCardType] as CardType ON Event.CardTypeCode = CardType.Code
	LEFT JOIN
	  [tblBuiding] as Buiding ON Event.BuidingCode = Buiding.Code
	LEFT JOIN 
	  [tblArea] as Area ON Event.AreaCode = Area.Code
	LEFT JOIN
	  [tblUser] AS U ON Event.UserCode = u.Code 
    LEFT JOIN
	  [tblObject] AS Obj ON Event.ObjectCode = Obj.Code 
    WHERE Event.CardNumber =  @CardNumber
    ORDER BY Event.Date DESC
END
GO
/****** Object:  StoredProcedure [dbo].[sp_LocCard]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LocCard]
@buiding varchar(20),
@area varchar(20),
@object varchar(20),
@typeCard varchar(20),
@cardNumber varchar(20),
@code varchar(20),
@name varchar(20),
@phatHanh bit,
@chuaPhatHanh bit,
@isLockCard bit

AS
BEGIN
	SELECT a.Id, a.Code, a.CardNumber, a.AccountName, a.Balance, 
	a.CardTypeCode, a.IsRelease, a.IsLockCard, a.IsEdit, a.DateModified,
	b.EventCode, b.BuidingCode, b.AreaCode, b.PCCode, b.LineCode, b.ObjectCode, b.UserCode,
	c.[Name] as [TypeCard]
	 from [tblCard] as a
		Left JOIN
		  (SELECT * FROM [tblRecord] where EventCode = 00) as b
		On a.CardNumber = b.CardNumber
		LEFT JOIN tblCardType AS c ON a.CardTypeCode = c.Code
	where 
	(b.BuidingCode LIKE '%' + @buiding + '%' or (b.BuidingCode is null and @buiding ='' )) and 
	(b.AreaCode LIKE '%' + @area + '%' or (b.AreaCode is null and @area ='' )) and
	(b.ObjectCode LIKE '%' + @object + '%' or (b.ObjectCode is null and @object ='' ) ) and
	(b.CardTypeCode LIKE '%' + @typeCard + '%' or (b.CardTypeCode is null and @typeCard ='' ) ) and
	(a.Code LIKE '%' + @code + '%' or (a.Code is null and @code ='' ) )and
	(a.CardNumber LIKE '%' + @cardNumber + '%' or (a.CardNumber is null and @cardNumber ='' ) ) and
	(a.AccountName LIKE '%' + @name + '%' or (a.AccountName is null and @name ='' ) ) and
	a.IsLockCard = @isLockCard and
	(a.IsRelease = @phatHanh or a.IsRelease != @chuaPhatHanh )

END
GO
/****** Object:  StoredProcedure [dbo].[sp_Log]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Log]
AS
BEGIN
	select ROW_NUMBER() OVER (Order by Id) AS STT, * from [tblLog]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Login]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Login]
@User VARCHAR(50),
@Pass VARCHAR(50)
AS
BEGIN
 SELECT tu.Id,tu.Code, tu.UserName, tu.[Password], tu.FullName,tu.Right1,r.AreaCode,r.BuidingCode, area.[Desc] as [AreaName]
   FROM tblUser AS tu
   LEFT JOIN Roles AS r ON tu.Code = r.UserCode 
   LEFT JOIN tblArea AS area ON r.AreaCode = area.Code
 WHERE tu.UserName = @User AND tu.[Password] = @Pass AND tu.IsLockUser = 0 
 
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Record]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_Record]
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
GO
/****** Object:  StoredProcedure [dbo].[sp_TheTrungNhau]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_TheTrungNhau]
	 
AS
BEGIN
	select ROW_NUMBER() OVER (Order by a.Id) AS RowNumber, a.* from [tblCard] as a
	join
	 (SELECT CardNumber, COUNT(CardNumber) as [Count] FROM [NetPOS].[dbo].[tblCard] group by CardNumber having COUNT(CardNumber) > 1) as b
	 on a.CardNumber = b.CardNumber
END

GO
/****** Object:  StoredProcedure [dbo].[sp_ThongKeThe]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ThongKeThe]
@buiding varchar(20),
@area varchar(20),
@object varchar(20)
AS
BEGIN
	SELECT tb.NameType, 
	SUM(tb.TotalCard) as [TotalCard],
	SUM(tb.[TotalUsed]) as [TotalUsed],
	(SUM(tb.TotalCard) -  SUM(tb.[TotalUsed])) as [TotalNotUsed],
	sum(tb.TotalBlock) as [TotalBlock],
	SUM(tb.TotalBalance) AS [TotalBalance]
	FROM (
	SELECT tb_a.CardTypeCode,
		CAST(CASE WHEN tb_b.Name IS NULL THEN '#' ELSE tb_b.Name END AS NVARCHAR) AS [NameType],
		COUNT(*) AS [TotalCard],
		count(case tb_a.IsRelease when 1 then 1 else null end) AS [TotalUsed],
		count(case tb_a.IsLockCard when 1 then 1 else null end) AS [TotalBlock],
		SUM(tb_a.Balance) AS [TotalBalance]
	FROM tblCard as tb_a
	Left JOIN
		  (SELECT * FROM [tblRecord] where EventCode = 00) as tb_c
		On tb_a.CardNumber = tb_c.CardNumber
	left JOIN tblCardType AS tb_b ON tb_a.CardTypeCode = tb_b.Code
	where
	(tb_c.BuidingCode LIKE '%' + @buiding + '%' or (tb_c.BuidingCode is null and @buiding ='' )) and 
	(tb_c.AreaCode LIKE '%' + @area + '%' or (tb_c.AreaCode is null and @area ='' )) and
	(tb_c.ObjectCode LIKE '%' + @object + '%' or (tb_c.ObjectCode is null and @object ='' ) )

	GROUP BY tb_a.CardTypeCode,tb_b.Name) AS tb
	GROUP BY tb.NameType
END
GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateCard]    Script Date: 7/30/2016 9:32:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_UpdateCard]	 
	@ch NVARCHAR(20),
	@Card NVARCHAR(20)
AS
BEGIN
	Update tblRecord SET CardNumber = @ch WHERE CardNumber = @Card
	Update tblBlackList SET CardNumber = @ch WHERE CardNumber = @Card
	Update tblCardProcess SET CardNumber = @ch WHERE CardNumber = @Card
	Update tblCard SET CardNumber = @ch WHERE CardNumber = @Card
END

GO
