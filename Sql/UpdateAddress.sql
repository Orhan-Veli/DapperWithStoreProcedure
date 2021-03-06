USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[UpdateAddress]    Script Date: 26.06.2021 17:00:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[UpdateAddress](
@CountryId uniqueidentifier,
@CountryName nvarchar(50),
@StateId uniqueidentifier,
@StateName nvarchar(50),
@CountyId uniqueidentifier,
@CountyName nvarchar(50),
@DistrictId uniqueidentifier,
@DistrictName nvarchar(50)
)as
begin
	begin tran
		begin try
			Update Country
			set [Name] = @CountyName
			where Id = @CountryId
			Update State
			set [Name] = @StateName
			where Id = @StateId
			Update County
			set [Name] = @CountyName
			where Id = @CountyId
			Update District
			set [Name] = @DistrictName
			where Id = @DistrictId
			commit tran
		end try
		begin catch
			rollback tran
		end catch
end