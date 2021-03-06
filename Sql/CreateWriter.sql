USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateWriters]    Script Date: 26.06.2021 16:44:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CreateWriters](
@Name nvarchar(50),
@LastName nvarchar(50),
@AddressId uniqueidentifier
) as 
begin
	begin tran
		begin try
		declare @Id uniqueidentifier;
		set @Id = NEWID();
		insert into Writers values(@Id,@Name,@LastName,@AddressId);
		commit tran
		end try
		begin catch 
			rollback tran
		end catch
end
