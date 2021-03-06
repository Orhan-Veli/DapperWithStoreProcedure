USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateBook]    Script Date: 26.06.2021 17:01:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateBook](
@BookId uniqueidentifier,
@BookName nvarchar(50),
@WriterId uniqueidentifier
)as
begin
	begin tran
		begin try
			Update Books
			set Books.[Name] = @BookName
			where Id = @BookId
			Update Books
			set WriterId = @WriterId
			where Id = @BookId
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end
