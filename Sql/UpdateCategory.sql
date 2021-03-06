USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[updatecategory]    Script Date: 26.06.2021 17:03:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[updatecategory](
@CategoryId uniqueidentifier,
@Name nvarchar(50)
)as
begin
	begin tran
		begin try
			update Category
			set [Name] = @Name
			where Id = @CategoryId
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end