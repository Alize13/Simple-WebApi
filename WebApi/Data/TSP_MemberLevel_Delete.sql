USE [TestAA]
GO
/****** Object:  StoredProcedure [dbo].[TSP_MemberLevel_Delete]    Script Date: 2022/5/10 下午 10:29:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO
-- =============================================
-- Author:		Alize
-- Create date: <2022/04/08>
-- Description:	刪除一筆會員等級設定
-- Execute sample:
-- EXEC [TSP_MemberLevel_Delete]  
-- =============================================
ALTER PROCEDURE [dbo].[TSP_MemberLevel_Delete]
	@Key			int			--流水Key

AS


BEGIN
	SET NOCOUNT ON;
	IF EXISTS( SELECT * FROM MemberLevels WHERE LevelID=@Key )
	BEGIN

		DECLARE @MemberLevel				tinyint			--會員等級代碼
		DECLARE @MaxCode					tinyint			--會員等級代碼當前最大值
				
		select @MemberLevel = MemberLevel from MemberLevels WHERE LevelID=@Key
		select @MaxCode = Max(MemberLevel) from MemberLevels 
		
		IF ( @MemberLevel <> @MaxCode)
		Begin
			SELECT '97' --'Only the maximum level can be deleted'	
		End
		ELSE IF EXISTS( SELECT * FROM Member WHERE MemberLevel=@MemberLevel )
		Begin				   
			SELECT '98' --'There are already members in this VIP level'	
		End
		Else
		Begin
			DELETE MemberLevels WHERE  LevelID=@Key 	
		End
	END
	ELSE
	Begin
	SELECT '99' --'This VIP level does not exist'	
	End	
END

