

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
