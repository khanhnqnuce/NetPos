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

EXEC sp_GetCard 'B8AFF320'