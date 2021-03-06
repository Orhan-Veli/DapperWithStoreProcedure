USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[DeleteWriter]    Script Date: 26.06.2021 16:58:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[DeleteWriter](
@WriterId uniqueidentifier
)as
begin 
	begin tran
		begin try
			delete from Books where WriterId = @WriterId
			delete from Writers where Id = @WriterId
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end