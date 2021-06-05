create proc CreateAddress(
@CountryName nvarchar(50),
@StateName nvarchar(50),
@CountyName nvarchar(50),
@DistrictName nvarchar(50)
)as
begin
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
end