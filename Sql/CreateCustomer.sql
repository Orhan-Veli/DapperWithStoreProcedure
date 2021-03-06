USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateCustomer]    Script Date: 26.06.2021 16:29:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CreateCustomer](
@Name nvarchar(50),
@LastName nvarchar(50),
@AddressId uniqueidentifier,
@LibrariessId id_list readonly
)as
begin
begin tran
 begin try
	declare @customerId uniqueidentifier
	set @customerId = NEWID()
	insert into Customers values(@customerId,@Name,@LastName,@AddressId)
	declare @tempId uniqueidentifier
	declare customerCursor cursor for select id from @LibrariessId
	open customerCursor
	fetch next from customerCursor into @tempId
	while @@FETCH_STATUS = 0
	begin 
	declare @CustomerLibraryRelation uniqueidentifier
	set @CustomerLibraryRelation = NEWID()
	insert into CustomerLibraryRelation values(@CustomerLibraryRelation,@customerId,@tempId)
	fetch next from customerCursor into @tempId
	end
	close customerCursor
	deallocate customerCursor
	commit tran
 end try
begin catch 
	rollback tran
end catch
end