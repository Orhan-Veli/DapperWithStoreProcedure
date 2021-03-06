USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[DeleteBooks]    Script Date: 26.06.2021 16:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[DeleteBooks](
@BookId uniqueidentifier
)as
begin
	begin tran
		begin try
			delete from CategoryBookRelation where BookId = @BookId
			delete from BookLibraryRelation where BookId = @BookId
			delete from Books where Id = @BookId 
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end	