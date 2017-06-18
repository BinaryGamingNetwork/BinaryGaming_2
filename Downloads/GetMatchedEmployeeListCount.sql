-- =============================================
-- Author:		Owen Brunker
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE GetMatchedEmployeeListCount 
	@SearchString nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	IF (@SearchString = '')
	BEGIN
		SELECT COUNT(*)
		FROM dbo.Employees;
	END
	ELSE
	BEGIN
		SELECT COUNT(*)
		FROM dbo.Employees
		WHERE CHARINDEX(@SearchString, Surname) > 0 OR CHARINDEX(@SearchString, FirstName) > 0;
	END
END