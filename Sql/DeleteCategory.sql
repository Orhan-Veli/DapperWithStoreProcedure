USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[DeleteCustomer]    Script Date: 26.06.2021 16:53:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[DeleteCustomer](
@CustomerId uniqueidentifier
)as
begin 
 begin tran
	begin try
		delete from CustomerLibraryRelation where CustomerId = @CustomerId
		delete from Customers where Id = @CustomerId 
		commit tran
	end try
	begin catch
		rollback tran
	end catch
end