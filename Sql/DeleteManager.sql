USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[DeleteManager]    Script Date: 26.06.2021 16:57:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[DeleteManager](
@ManagerId uniqueidentifier
)as
begin
	begin tran
		begin try
			delete from Managers where Id = @ManagerId 
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end