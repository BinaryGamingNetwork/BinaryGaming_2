-- =============================================
-- Author:		Owen Brunker
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE GetMatchedEmployeeList 
	@RequestedPage int = 0, 
	@RowsPerPage int = 0,
	@SearchString nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	
	IF @RequestedPage = 0
		SET @RequestedPage = 1;
	
	IF @RowsPerPage = 0
		SET @RowsPerPage = 10;

	IF (@SearchString = '')
	BEGIN
		SELECT *
		FROM
		(
			SELECT ROW_NUMBER() OVER (ORDER BY Surname ASC, FirstName ASC) AS RowNumber, *
			FROM dbo.Employees
		) AS ConstrainedRow
		WHERE RowNumber >= ((@RequestedPage * @RowsPerPage) -  @RowsPerPage) +1 AND RowNumber <= (@RequestedPage * @RowsPerPage)
		ORDER BY Surname ASC, FirstName ASC;
	END
	ELSE
	BEGIN
		SELECT *
		FROM
		(
			SELECT ROW_NUMBER() OVER (ORDER BY Surname ASC, FirstName ASC) AS RowNumber, *
			FROM dbo.Employees
			WHERE CHARINDEX(@searchString, Surname) > 0 OR CHARINDEX(@searchString, FirstName) > 0
		) AS ConstrainedRow
		WHERE RowNumber >= ((@RequestedPage * @RowsPerPage) -  @RowsPerPage) +1 AND RowNumber <= (@RequestedPage * @RowsPerPage)
		ORDER BY Surname ASC, FirstName ASC;
	END

END