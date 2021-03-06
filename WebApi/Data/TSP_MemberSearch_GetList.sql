USE [TestAA]
GO
/****** Object:  StoredProcedure [dbo].[TSP_MemberSearch_GetList]    Script Date: 2022/5/10 下午 11:51:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Alize>
-- Create date: <2022/04/08>
-- Description:	會員搜尋
-- =============================================
ALTER PROCEDURE [dbo].[TSP_MemberSearch_GetList]
	@MemberAccount			VARCHAR(30)		--會員帳號(不使用空白)	
	,@MemberStatus			int				--狀態(-1不限制)(0:停用 1:啟用)	
	,@startDate				varchar(30)		--起始日期(不使用空白)
	,@endDate				varchar(30)		--結束日期(不使用空白)
	,@trace_op				VARCHAR(2)		--篩選運算子 大於等於('>=')，小於等於('<=')
	,@trace_value			INT				--篩選值
	,@fuzzyQuery			bit				--興趣搜尋方式(0:精準搜尋 1:模糊查詢)
	,@MemberInterests		varchar(200)	--興趣(-1不限制)(興趣ID以;分隔)
	,@sort_column			INT				--排序欄位(預設:1   1.CreateDateTime,2.MemberLevel,3.MemberAccount,4.MemberName,5.CreateUser )	
	,@asc_order				bit				--排序方式(預設:DESC True:ASC False:DESC)
	,@row_start				int				--起始頁
	,@row_number			int				--當頁呈現筆數

AS

BEGIN
	-- 宣告變數
	SET NOCOUNT ON;
		
	DECLARE @strSQL			NVarchar(MAX);	--搜尋字串
	DECLARE @strSQL_ALL		NVarchar(MAX);
	DECLARE @strSortColumn	Varchar(50);	--排序欄位
	DECLARE	@strAscOrder	Varchar(50);	--排序方式
	DECLARE @start_num		Int;			--起始數
	DECLARE @end_num		Int;			--結束數
	Declare @Result_Count	int;			--查詢結果數目	
	
	SET @start_num = ((@row_start-1)*@row_number);
	SET @end_num = @start_num + @row_number-1;

	
	--排序欄位
	SELECT @strSortColumn=
	CASE @sort_column
	WHEN 2 THEN 'MemberLevel' 
	WHEN 3 THEN 'MemberAccount'
	WHEN 4 THEN 'MemberName'
	WHEN 5 THEN 'CreateUser'
	ELSE 'CreateDateTime'
	END
	
	--排序方式
	SELECT @strAscOrder=
	CASE @asc_order
	WHEN 1 THEN 'ASC'
	ELSE 'DESC'
	END
	
	SET @strSQL = 'SELECT * FROM Member  WHERE MemberID > 0 '; 


	--查詢會員帳號(空白不限制)
	IF  @MemberAccount<>''
	BEGIN
		SET @strSQL = @strSQL + ' AND MemberAccount  =   '''+ @MemberAccount + ''' ' ;
	END	

	--狀態(-1不限制)(1:待解鎖 2:成功 3:失敗)
	IF @MemberStatus<>-1
	BEGIN
		SET @strSQL = @strSQL + ' AND MemberStatus  =  '''+CAST(@MemberStatus  AS VARCHAR(2))+''' '
	END
	
	--創立日期
	IF  @startDate<>'' AND @endDate<>''
	BEGIN
	
		SET @strSQL = @strSQL + ' AND CreateDateTime BETWEEN '''+@startDate+''' AND '''+@endDate+''' '
	END
	
	--薪資查詢
	IF @trace_value>0 AND @trace_op <>''
	BEGIN
		SET @strSQL = @strSQL + ' AND MemberSalaly '  + @trace_op + CAST(@trace_value as varchar)
	END		
	ELSE
	BEGIN
		SET @strSQL = @strSQL
	END		

	--精確查詢興趣(空白不限制)
	IF @fuzzyQuery=0 AND @MemberInterests<>''
	BEGIN	
		SET @strSQL = @strSQL + ' AND MemberInterests  =  '''+@MemberInterests+''' ' ;
	END	
	--模糊查詢興趣(空白不限制)
	IF @fuzzyQuery=1 AND @MemberInterests<>''
	BEGIN	
		SET @strSQL = @strSQL + ' AND EXISTS (select * from db_owner.FN_Split(MemberInterests, '';'')  intersect (select * from db_owner.FN_Split('''+@MemberInterests+''','';''))) ';
	END	
	
	
	--分頁及排序前先記錄取得需要欄位的計算總數語句
	SET @strSQL_ALL= ' SELECT COUNT(*) AS ''RecordCount'',
	ISNULL(SUM(MemberSalaly),0) AS ''SalaryTotal''  FROM (' + @strSQL + ') Main';

	--排序
	SET @strSQL = @strSQL + ' ORDER BY '
	SET @strSQL = @strSQL + ''+@strSortColumn+' '+@strAscOrder
	
	
	--取分頁
	SET @strSQL = @strSQL + ' OFFSET '+CAST(@start_num as varchar(20))  +' ROWS' ;
    SET @strSQL = @strSQL + ' FETCH NEXT '+ CAST(@row_number as varchar(20)) +' ROWS ONLY' ;

	--取出查詢資料列表
	EXEC (@strSQL);

	--取出查詢總數
	EXEC (@strSQL_ALL);

	--print @strSQL
	--print @strSQL_ALL
	
END





