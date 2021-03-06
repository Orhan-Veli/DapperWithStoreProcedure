USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateLibraries]    Script Date: 26.06.2021 16:39:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CreateLibraries](
@Name nvarchar(50),
@AddressId uniqueidentifier
)as
begin
	begin tran
		begin try
			declare @Id uniqueidentifier
			set @Id = NEWID();
			insert into Libraries values(@Id,@Name,@AddressId);
			commit tran
		end try
		begin catch 
			rollback tran
		end catch
end
