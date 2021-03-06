USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateCategory]    Script Date: 26.06.2021 16:38:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CreateCategory](
@Name nvarchar(50)
)
as
begin
	begin tran
		begin try
			declare @Id uniqueidentifier
			set @Id = NEWID()
			insert into obs.Category values(@Id,@Name)
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end