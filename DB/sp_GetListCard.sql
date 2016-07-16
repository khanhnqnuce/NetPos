CREATE PROCEDURE [dbo].[sp_GetListCard]	 
AS
BEGIN
	select ROW_NUMBER() OVER (Order by tb_a.Id DESC) AS RowNumber, tb_a.*,tb_b.Name AS [NameType] from [tblCard] as tb_a
	left join
	tblCardType AS tb_b ON tb_a.CardTypeCode = tb_b.Code
END

SELECT * FROM tblCardType AS tct
SELECT * FROM [tblCard] AS tct

SELECT * FROM [tblCard] WHERE CardTypeCode NOT IN('01','02','03','04')