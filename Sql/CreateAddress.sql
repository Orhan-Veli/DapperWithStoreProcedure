USE [Library]
GO
/****** Object:  StoredProcedure [dbo].[CreateAddress]    Script Date: 26.06.2021 16:36:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER proc [dbo].[CreateAddress](
@CountryName nvarchar(50),
@StateName nvarchar(50),
@CountyName nvarchar(50),
@DistrictName nvarchar(50)
)as
begin
begin tran
	begin try
		declare @CountryId uniqueidentifier
		declare @StateId uniqueidentifier
		declare @CountyId uniqueidentifier
		declare @DistrictId uniqueidentifier
		set @CountryId = NEWID()
		set @StateId = NEWID()
		set @CountyId = NEWID()
		set @DistrictId = NEWID()
		insert into Country values(@CountryId,@CountryName)
		insert into dbo.State values(@StateId,@StateName,@CountryId)
		insert into County values(@CountyId,@CountyName,@StateId)
		insert into District values(@DistrictId,@DistrictName,@CountyId)
		commit tran
	end try
	begin catch
		rollback tran
	end catch
end