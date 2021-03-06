USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[DeleteAddress]    Script Date: 26.06.2021 16:45:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[DeleteAddress](
@CountryId uniqueidentifier,
@StateId uniqueidentifier,
@CountyId uniqueidentifier,
@DistrictId uniqueidentifier
)
as
begin 	
	begin tran
		begin try
		delete from District where CountyId = @CountyId
		delete from County where StateId = @StateId
		delete from dbo.State where CountryId = @CountryId
		delete from Country where Id = @CountryId
		commit tran
		end try
		begin catch
			rollback tran
		end catch
end
