USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateLibrary]    Script Date: 26.06.2021 17:05:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateLibrary](
@Id uniqueidentifier,
@Name nvarchar(50)
)as
begin
	begin tran
		begin try
			update Libraries
			set [Name] = @Name
			where Id = @Id
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end