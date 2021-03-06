USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateManagers]    Script Date: 26.06.2021 16:40:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CreateManagers](
@Name nvarchar(50),
@LastName nvarchar(50),
@LibraryId uniqueidentifier,
@AddressId uniqueidentifier
)as
begin
	begin tran
		begin try
			Declare @Id uniqueidentifier
			set @Id = NEWID()
			insert into Managers values(@Id,@Name,@LastName,@LibraryId,@AddressId)
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end