USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[DeleteLibrary]    Script Date: 26.06.2021 16:55:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[DeleteLibrary](
@LibraryId uniqueidentifier
)as
begin
	begin tran
		begin try
		delete from CustomerLibraryRelation where LibraryId = @LibraryId
		delete from BookLibraryRelation where LibraryId = @LibraryId
		delete from Libraries where Id = @LibraryId
		commit tran
		end try
		begin catch
			rollback tran
		end catch
end