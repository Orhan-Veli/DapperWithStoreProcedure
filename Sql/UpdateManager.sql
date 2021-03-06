USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateManager]    Script Date: 26.06.2021 17:06:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateManager](
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50),
@LibraryId uniqueidentifier
)as
begin
	begin tran
		begin try
			update Managers
			set [Name] = @Name,
			LastName = @LastName,
			LibraryId = @LibraryId
			where Id = @Id
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end