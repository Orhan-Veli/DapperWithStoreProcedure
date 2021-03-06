USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateWriter]    Script Date: 26.06.2021 17:07:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateWriter](
@Id uniqueidentifier,
@Name nvarchar(50),
@LastName nvarchar(50)
)as
begin
	begin tran
		begin try
			Update Writers
			set [Name] = @Name,
			LastName = @LastName
			where Id = @Id
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end